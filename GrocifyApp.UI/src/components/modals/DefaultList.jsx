import { useState, useEffect } from 'react';
import PropTypes from 'prop-types';

//Internal components
import useApiRequest from '../hooks/useApiRequests';
import BaseModal from './BaseModal';

//Assets & Css
import styles from './DefaultList.module.scss';

//Consts
import { GenericConsts, ButtonConsts, ModalConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';

const DefaultList = ({ isOpen, onClose }) => {
    const [shoppingListData, setShoppingListData] = useState(null);
    const [defaultShoppingList, setDefaultShoppingList] = useState(null);
    const [oldDefaultShoppingList, setOldDefaultShoppingList] = useState(null);
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const { makeRequest } = useApiRequest();

    const handleSetDefaultList = (shoppingList) => {
        setDefaultShoppingList(shoppingList);
        setButtonDisabled(shoppingList.id === oldDefaultShoppingList?.id);
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
                const responseData = await makeRequest(ApiEndpoints.ShoppingList_Endpoint, 'GET');

                setShoppingListData(responseData);

                const defaultList = responseData.find(item => item.defaultList);

                setDefaultShoppingList(defaultList);

                if (oldDefaultShoppingList == null) {
                    setOldDefaultShoppingList(defaultList);
                }

                setButtonDisabled(oldDefaultShoppingList ? true : defaultList.id != oldDefaultShoppingList?.id);
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    const updateDefaultShoppingList = async () => {
        try {
            await makeRequest(ApiEndpoints.DefaultShoppingList_Endpoint(defaultShoppingList.id), 'PUT');
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <BaseModal isOpen={isOpen} onClose={onClose} onConfirm={updateDefaultShoppingList} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Update} titleModal={ModalConsts.DefaultShoppingList} modalBody={
            <div className={styles.contentList}>
                {shoppingListData != null && shoppingListData.length > 0 ? (
                    shoppingListData.map((shoppingList) => (
                        <div key={shoppingList.id} onClick={() => handleSetDefaultList(shoppingList)}
                            className={`cursor-pointer text list-row + ${styles.listRow} ${shoppingList.id == defaultShoppingList.id ? styles.default + " default" : ''}`}>{shoppingList.name}</div>
                    ))
                ) : (
                    <div>No shopping list data available</div> //todo later (empty state)
                )}
            </div> } />
    );
};

DefaultList.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired
};

export default DefaultList;