import { useEffect, useState } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../BaseModal';
import Searchbar from '../../Searchbar';
import useApiRequest from '../../../hooks/useApiRequests';

//Assets & Css
import PlusCircleIcon from '../../../assets/plus-circle-ic.svg';
import MinusCircleIcon from '../../../assets/minus-circle-ic.svg';
import styles from '../ContentModal.module.scss';

//Consts
import { PlaceholderConsts, ButtonConsts, ModalConsts } from '../../../consts/ENConsts';
import InputType from '../../../consts/InputType';
import ApiEndpoints from '../../../consts/ApiEndpoints';

const ShoppingListProductModal = ({ onClose, onError, shoppingListProducts, productsArray, onConfirm }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [searchInput, setSearchInput] = useState('');

    const [products, setProducts] = useState([]);
    const [productsSelected, setProductsSelected] = useState(productsArray);

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        setButtonDisabled(productsSelected === productsArray);
    }, [productsSelected]);
    
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

    const toggleProductSelection = async (newProduct) => {
        if (productsSelected.some(product => product.id === newProduct.id)) {
            const quantity = shoppingListProducts.find(p => p.productId === newProduct.id).quantity;
            await onConfirm(newProduct, -quantity);
            setProductsSelected(prevProducts => prevProducts.filter(p => p.id !== newProduct.id));
        } else {
            await onConfirm(newProduct, 1);
            setProductsSelected(prevProducts => [...prevProducts, newProduct]);
        }
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} isButtonDisabled={isButtonDisabled} buttonText={ButtonConsts.Save} noFooter={true}
            titleModal={ButtonConsts.AddProduct} modalBody={
                <div className={styles.containerModal}>
                    <Searchbar placeholder={PlaceholderConsts.Search}
                        label={PlaceholderConsts.Search}
                        value={searchInput}
                        onChange={(e) => setSearchInput(e.target.value)} />

                    <div className={styles.list}>
                        {products.map(product => (
                            <div className={styles.row} key={product.id}>
                                <div className="icon cursor-pointer" onClick={() => toggleProductSelection(product)}>
                                    <ReactSVG className={"react-svg " + (productsSelected.some(p => p.id === product.id) ? "icon-color--r300" : "icon-color--primary")}
                                        src={productsSelected.some(p => p.id === product.id) ? MinusCircleIcon : PlusCircleIcon} />
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
    shoppingListProducts: PropTypes.node.isRequired,
    productsArray: PropTypes.array.isRequired,
    onError: PropTypes.func,
    onConfirm: PropTypes.func
};

export default ShoppingListProductModal;