import { useState, useEffect } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../components/BaseModal';

//Assets & Css
//import CrossIcon from '../assets/cross-ic.svg';
import styles from './DefaultList.module.scss';

//Consts
import { GenericConsts } from '../consts/ENConsts';
import ApiEndpoints from '../consts/ApiEndpoints';

const DefaultList = ({ isOpen, onClose, children }) => {
    const token = localStorage.getItem('token');
    const [shoppingListData, setShoppingListData] = useState(null);
    const [defaultShoppingList, setDefaultShoppingList] = useState(null);
    
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
                    setDefaultShoppingList(fetchedData.find(item => item.defaultList));
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
            if (token == undefined) {
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
        <BaseModal isOpen={isOpen} onClose={onClose} buttonConfirm={updateDefaultShoppingList}>
            <div className={styles.contentList}>
                {shoppingListData != null && shoppingListData.length > 0 ? (
                    shoppingListData.map((shoppingList) => (
                        <div key={shoppingList.id} onClick={() => setDefaultShoppingList(shoppingList)}
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