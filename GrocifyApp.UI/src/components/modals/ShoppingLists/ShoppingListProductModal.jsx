import { useEffect, useState } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../BaseModal';
import Searchbar from '../../Searchbar';
import useApiRequest from '../../../hooks/useApiRequests';

//Assets & Css
import PlusCircleIcon from '../../../assets/plus-circle-ic.svg';
import styles from '../ContentModal.module.scss';

//Consts
import { PlaceholderConsts, ButtonConsts, ModalConsts } from '../../../consts/ENConsts';
import InputType from '../../../consts/InputType';
import ApiEndpoints from '../../../consts/ApiEndpoints';

const ShoppingListProductModal = ({ onClose, onConfirm, onError }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [searchInput, setSearchInput] = useState('');

    const [products, setProducts] = useState([]);
    const [productsSelected, setProductsSelected] = useState(null);

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        setButtonDisabled(productsSelected === null || !productsSelected.Any());
    }, [productsSelected]);

    const addProductToList = async (addProductId) => {

        const data = { quantity: 1, productId: addProductId };

        try {
            await makeRequest(ApiEndpoints.ShoppingList_Endpoint, 'POST', data);
        }
        catch (error) {
            onError(error.message);
        }

        onConfirm();
    };

    const filterProductsByName = async (productName) => {
        setSearchInput(productName);

        await getProducts(productName);
    };

    const getProducts = async (productName) => {
        const filteredEntities = { Name: productName };

        const productsResponse = await makeRequest(ApiEndpoints.ProductsWSections_Endpoint, 'GET', null, filteredEntities);
        setProducts(productsResponse);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                await getProducts();
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={addProductToList} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Save} hasSearchbar={true}
            titleModal={ButtonConsts.AddProduct} modalBody={
                <div className={styles.containerModal}>
                    <Searchbar placeholder={PlaceholderConsts.Search}
                        label={PlaceholderConsts.Search}
                        value={searchInput}
                        onChange={(e) => setSearchInput(e.target.value)} />

                    <div className={styles.list}>
                        {products.map(product => (
                            <div className={styles.row} key={product.id}>
                                <div className="icon cursor-pointer">
                                    <ReactSVG className="react-svg icon-color--primary" src={PlusCircleIcon} />
                                </div>

                                <div className="text">
                                    {product.name}
                                </div>

                                <div className="text color--n400">
                                    {ModalConsts.InSection(product.productSection.name)}
                                </div>
                            </div>
                        ))}
                    </div>
                </div>} />
    );
};

ShoppingListProductModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func,
    onError: PropTypes.func
};

export default ShoppingListProductModal;