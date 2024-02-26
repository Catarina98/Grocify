import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts, ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';
//import styles from './ShoppingLists.module.scss';

function ShoppingListDetail() {
    //const [searchInput, setSearchInput] = useState('');
    //const [lists, setLists] = useState([]);

    //const { makeRequest } = useApiRequest();

    //const getShoppingLists = async () => {
    //    const listsResponse = await makeRequest(ApiEndpoints.ShoppingList_Endpoint, 'GET', null);
    //    setLists(listsResponse);
    //};

    //useEffect(() => {
    //    const fetchData = async () => {
    //        try {
    //            await getShoppingLists();
    //        } catch (error) {
    //            console.log(error);
    //        }
    //    };

    //    fetchData();
    //}, []);

    return (
        //<div className={styles.containerList}>
        //    <div className="" key={shoppingList.id}>
        //        <div className={styles.listInfo}>
        //            <div className="title weight--m text-ellipsis">{list.name}</div>
        //        </div>

        //        <div className="icon icon-options cursor-pointer">
        //            <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
        //        </div>
        //    </div>
        //</div>
        <div>Detail</div>
    );
}

export default ShoppingListDetail;