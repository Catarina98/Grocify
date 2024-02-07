import { useState, useEffect } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../components/BaseModal';

//Assets & Css
import styles from './DefaultList.module.scss';

//Consts
import { GenericConsts } from '../consts/ENConsts';
import ApiEndpoints from '../consts/ApiEndpoints';

const DefaultList = ({ isOpen, onClose }) => {
    const token = localStorage.getItem('token');
    const [shoppingListData, setShoppingListData] = useState(null);
    const [defaultShoppingList, setDefaultShoppingList] = useState(null);
    const [oldDefaultShoppingList, setOldDefaultShoppingList] = useState(null);
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const handleSetDefaultList = (shoppingList) => {
        setDefaultShoppingList(shoppingList);
        setButtonDisabled(shoppingList.id === oldDefaultShoppingList?.id);
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(ApiEndpoints.ShoppingList_Endpoint, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`,
                    },
                });

                if (response.ok) {
                    const fetchedData = await response.json();
                    setShoppingListData(fetchedData);

                    const defaultList = fetchedData.find(item => item.defaultList);

                    setDefaultShoppingList(defaultList);

                    if (oldDefaultShoppingList == null) {
                        setOldDefaultShoppingList(defaultList);
                    }

                    setButtonDisabled(defaultList.id != oldDefaultShoppingList?.id);
                } else {
                    const errorData = await response.json();
                    console.log(errorData.errors[0]);
                }
            } catch (error) {
                console.log(GenericConsts.Error);
            }
        };

        fetchData();
    }, []);

    const updateDefaultShoppingList = async () => {
        try {
            if (defaultShoppingList == null) {
                return;
            }

            const response = await fetch(ApiEndpoints.DefaultShoppingList_Endpoint(defaultShoppingList.id), {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${token}`
                }
            });

            if (response.ok) {
                console.log("updated");
            } else {
                const errorData = await response.json();
                console.log(errorData.errors[0]);
            }
        } catch (error) {
            console.log(GenericConsts.Error);
        }
    };

    return (
        <BaseModal isOpen={isOpen} onClose={onClose} buttonConfirm={updateDefaultShoppingList} buttonDisabled={isButtonDisabled}>
            <div className={styles.contentList}>
                {shoppingListData != null && shoppingListData.length > 0 ? (
                    shoppingListData.map((shoppingList) => (
                        <div key={shoppingList.id} onClick={() => handleSetDefaultList(shoppingList)}
                            className={`cursor-pointer text list-row + ${styles.listRow} ${shoppingList.id == defaultShoppingList.id ? styles.default + " default" : ''}`}>{shoppingList.name}</div>
                    ))
                ) : (
                    <div>No shopping list data available</div> //todo later (empty state)
                )}
            </div>
        </BaseModal>
    );
};

DefaultList.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    children: PropTypes.node,
};

export default DefaultList;