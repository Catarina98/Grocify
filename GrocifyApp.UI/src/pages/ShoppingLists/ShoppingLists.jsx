import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import ShoppingListModal from '../../components/modals/ShoppingLists/ShoppingListModal';
import useApiRequest from '../../hooks/useApiRequests';
import ShoppingListDetail from './ShoppingListDetail';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts, ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './ShoppingLists.module.scss';

function ShoppingLists() {
    const [searchInput, setSearchInput] = useState('');

    const [selectedList, setSelectedList] = useState(null);

    const [lists, setLists] = useState([]);
    const [listDetailId, setListDetailId] = useState('');

    const [isModalOpen, setIsModalOpen] = useState(false);

    const { makeRequest } = useApiRequest();

    const getShoppingLists = async () => {
        const listsResponse = await makeRequest(ApiEndpoints.ShoppingList_Endpoint, 'GET', null);
        setLists(listsResponse);
    };
    
    const fetchData = async () => {
        try {
            await getShoppingLists();
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedList(null);
        setIsModalOpen(false);
    };

    const onConfirmList = async () => {
        await fetchData();
    };

    return (
        <Layout>
            {isModalOpen && <ShoppingListModal onClose={closeModal} onConfirm={onConfirmList} sectionToUpdate={selectedList} />}

            <Searchbar placeholder={PlaceholderConsts.SearchLists}
                label={PlaceholderConsts.SearchLists}
                value={searchInput}
                onChange={(e) => setSearchInput(e.target.value)} />

            <div className={styles.containerLists}>
                {lists.map(list => (
                    <div key={list.id}>
                        <div className={styles.listRow}>
                            <div className={styles.listInfo} onClick={() => setListDetailId(listDetailId === list.id ? '' : list.id)}>
                                <div className="title weight--m text-ellipsis">{list.name}</div>

                                <div className="icon icon-options cursor-pointer">
                                    <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                                </div>
                            </div>  

                            {listDetailId !== '' && listDetailId === list.id &&
                                <ShoppingListDetail shoppingList={list} />}
                        </div>
                    </div>
                ))}
            </div>

            <button className="primary-button btn--l btn-float" onClick={() => openModal()}>
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewList}
            </button>
        </Layout>
    );
}

export default ShoppingLists;