import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import useApiRequest from '../../hooks/useApiRequests';
//import ShoppingListDetail from './ShoppingListDetail';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts, ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from '../Lists.module.scss';

function ShoppingLists() {
    const [searchInput, setSearchInput] = useState('');

    const [inventories, setInventories] = useState([]);
    const [inventoryDetailId, setInventoryDetailId] = useState('');

    const [isModalOpen, setIsModalOpen] = useState(false);

    const { makeRequest } = useApiRequest();

    const getInventories = async () => {
        const inventoriesResponse = await makeRequest(ApiEndpoints.Inventory_Endpoint, 'GET', null);
        setInventories(inventoriesResponse);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                await getInventories();
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        //setSelectedSection(null);
        setIsModalOpen(false);
    };

    return (
        <Layout>
            {/*{isModalOpen && <ProductSectionModal onClose={closeModal} onConfirm={onConfirmSection} sectionToUpdate={selectedSection} />}*/}

            <Searchbar placeholder={PlaceholderConsts.SearchInventories}
                label={PlaceholderConsts.SearchInventories}
                value={searchInput}
                onChange={(e) => setSearchInput(e.target.value)} />

            <div className={styles.containerLists}>
                {inventories.map(inventory => (
                    <div key={inventory.id}>
                        <div className={styles.listRow}>
                            <div className={styles.listInfo} onClick={() => setInventoryDetailId(inventoryDetailId === inventory.id ? '' : inventory.id)}>
                                <div className="title weight--m text-ellipsis">{inventory.name}</div>

                                <div className="icon icon-options cursor-pointer">
                                    <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                                </div>
                            </div>

                            {/*{inventoryDetailId !== '' && inventoryDetailId === inventory.id &&*/}
                            {/*    <ShoppingListDetail shoppingList={inventory} />}*/}
                        </div>
                    </div>
                ))}
            </div>

            <button className="primary-button btn--l btn-float" onClick={() => openModal()}>
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewInventory}
            </button>
        </Layout>
    );
}

export default ShoppingLists;