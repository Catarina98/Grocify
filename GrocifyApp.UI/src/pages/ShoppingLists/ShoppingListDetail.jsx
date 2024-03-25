import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import useApiRequest from '../../hooks/useApiRequests';
import ShoppingListProductModal from '../../components/modals/ShoppingLists/ShoppingListProductModal';

//Assets & Css
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';
import PlusIcon from '../../assets/plus-ic.svg';
import MinusIcon from '../../assets/minus-ic.svg';

//Consts
import IconsConsts from '../../consts/IconsConsts';
import { IconColorSections } from '../../consts/ColorsConsts';
import { ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './ShoppingListDetail.module.scss';

function ShoppingListDetail({ shoppingList }) {
    const [products, setProducts] = useState([]);
    const [sections, setSections] = useState([]);
    const [measures, setMeasures] = useState([]);
    const [list, setList] = useState([]);

    const [selectedProduct, setSelectedProduct] = useState('');
    const [checkedProducts, setCheckedProducts] = useState([]);

    const [isAddProductsModalOpen, setAddProductsIsModalOpen] = useState(false);

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        const fetchData = async () => {
            try {
                await getShoppingListProducts();
                await getProductMeasures();
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    const openAddProductsModal = () => {
        setAddProductsIsModalOpen(true);
    };

    const closeAddProductsModal = () => {
        setAddProductsIsModalOpen(false);
    };

    const getProductMeasures = async () => {
        const getMeasures = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET', null);
        setMeasures(getMeasures);
    };

    const getShoppingListProducts = async () => {
        const listProductsResponse = await makeRequest(ApiEndpoints.ShoppingListProducts_Endpoint(shoppingList.id), 'GET', null);

        const sortedProductsList = listProductsResponse.sort((a, b) => a.product.productSectionId - b.product.productSectionId);

        const sectionMap = new Map();
        
        listProductsResponse.forEach(listProduct => {
            const sectionId = listProduct.product.productSectionId;
            const section = listProduct.product.productSection;
            
            if (!sectionMap.has(sectionId)) {
                sectionMap.set(sectionId, section);
            }
        });
        
        const uniqueSections = Array.from(sectionMap.values());

        setSections(uniqueSections);
        setList(sortedProductsList);

        const products = sortedProductsList.map(item => item.product);
        setProducts(products);
    };

    const updateProductsToShoppingList = async (product, quantity) => {
        //const q = isToIncrement ? 1 : -1;
        
        const data = { quantity: quantity, productId: product.id };

        try {
            await makeRequest(ApiEndpoints.ShoppingListProducts_Endpoint(shoppingList.id), 'PUT', data);

            await getShoppingListProducts();
        }
        catch (error) {
            console.error(error);
        }
    };

    const handleCheckboxChange = (productId) => {
        if (checkedProducts.includes(productId)) {
            setCheckedProducts(checkedProducts.filter(id => id !== productId));
        } else {
            setCheckedProducts([...checkedProducts, productId]);
            setSelectedProduct(null);
        }
    };
    
    const groupedProducts = {};
    list.forEach(pair => {
        const product = pair.product;
        const quantity = pair.quantity;
        const sectionId = product.productSectionId;

        if (!groupedProducts[sectionId]) {
            groupedProducts[sectionId] = [];
        }
        groupedProducts[sectionId].push({ product, quantity });
    });

    return (
        <div className={styles.containerList}>
            <button className={"subtle-button btn--m " + styles.subtleButton} onClick={() => openAddProductsModal()}>
                <ReactSVG className={"react-svg icon-color--primary " + styles.subtleButton} src={PlusCircleIcon} />
                {ButtonConsts.AddProduct}
            </button>

            {isAddProductsModalOpen && <ShoppingListProductModal onClose={closeAddProductsModal} shoppingListProducts={list} productsArray={products}
                onConfirm={updateProductsToShoppingList} />}

            {Object.entries(groupedProducts).map(([sectionId, sectionProducts]) => (
                <div key={sectionId} className={styles.productsList}>
                    <div className={styles.sectionInfo}>
                        <div className="icon icon--w32 cursor-pointer">
                            <ReactSVG className={`react-svg ${IconColorSections[sections.find(s => s.id === sectionId).icon]}`} src={IconsConsts[sections.find(s => s.id === sectionId).icon]} />
                        </div>

                        <div className="text-ellipsis--line2 text">{sections.find(s => s.id === sectionId).name}</div>
                    </div>

                    {sectionProducts.map(pair => (
                        <div key={pair.product.id} className={styles.product}>
                            <div className={styles.checkBox}>
                                <label className="checkbox-container">
                                    <input type="checkbox" onChange={() => handleCheckboxChange(pair.product.id)}
                                        checked={checkedProducts.includes(pair.product.id)} />
                                </label>

                                <div className={"text text-ellipsis " + (pair.product.id === selectedProduct ? "weight--m"
                                    : checkedProducts.includes(pair.product.id) ? "color--n400" : '')}>{pair.product.name}</div>
                            </div>

                            {measures !== null && measures.length > 0 && (
                                <div className={styles.quantitySection} onClick={() => setSelectedProduct(pair.product.id)}>
                                    <div className={"icon cursor-pointer " + (pair.product.id === selectedProduct ? '' : styles.displayNone)}
                                        onClick={() => updateProductsToShoppingList(pair.product, -1)}>
                                        <ReactSVG className="react-svg" src={MinusIcon} />
                                    </div>

                                    <div className={"text text-ellipsis " + (pair.product.id === selectedProduct ? "weight--m"
                                        : checkedProducts.includes(pair.product.id) ? "color--n400" : '')}>
                                        {pair.quantity + " " + measures.find(m => m.id === pair.product.productMeasureId).name}
                                    </div>

                                    <div className={"icon cursor-pointer " + (pair.product.id === selectedProduct ? '' : styles.displayNone)}
                                        onClick={() => updateProductsToShoppingList(pair.product, 1)}>
                                        <ReactSVG className="react-svg" src={PlusIcon} />
                                    </div>
                                </div>
                            )}
                        </div>
                    ))}
                </div>
            ))}
        </div>
    );
}

ShoppingListDetail.propTypes = {
    shoppingList: PropTypes.object.isRequired
};

export default ShoppingListDetail;
