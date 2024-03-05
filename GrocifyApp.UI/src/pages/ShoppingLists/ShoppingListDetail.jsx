import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import useApiRequest from '../../hooks/useApiRequests';

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
    const [sections, setSections] = useState({});
    const [measures, setMeasures] = useState({});
    const [quantityClick, setquantityClick] = useState(false);

    const { makeRequest } = useApiRequest();

    const getProductSections = async () => {
        return await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET', null);
    };

    const getProductMeasures = async () => {
        const getMeasures = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET', null);
        setMeasures(getMeasures);
    };

    const getShoppingListProducts = async () => {
        const productsQuantityResponse = await makeRequest(ApiEndpoints.ShoppingListProducts_Endpoint(shoppingList.id), 'GET', null);

        const getProducts = productsQuantityResponse.map(kv => kv.key);
        const sortedProducts = getProducts.sort((a, b) => a.productSectionId - b.productSectionId);
        const uniqueSectionsId = new Set();
        
        sortedProducts.forEach(product => uniqueSectionsId.add(product.productSectionId));
        const sections = await getProductSections();
        
        const uniqueSections = sections.filter(section => uniqueSectionsId.has(section.id));
        
        setSections(uniqueSections);
        setProducts(sortedProducts);
    };

    const addProductsToShoppingList = async () => {
        //await makeRequest(ApiEndpoints.ShoppingListProducts_Endpoint(shoppingList.id), 'PUT', null);
        //await getShoppingListProducts();
        //TODO
    };

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

    const groupedProducts = {};
    products.forEach(product => {
        if (!groupedProducts[product.productSectionId]) {
            groupedProducts[product.productSectionId] = [];
        }
        groupedProducts[product.productSectionId].push(product);
    });

    return (
        <div className={styles.containerList}>
            <button className={"subtle-button btn--m " + styles.subtleButton} onClick={() => addProductsToShoppingList()}>
                <ReactSVG className={"react-svg icon-color--primary " + styles.subtleButton} src={PlusCircleIcon} />

                {ButtonConsts.AddProduct}
            </button>

            {Object.entries(groupedProducts).map(([sectionId, sectionProducts]) => (
                <div key={sectionId} className={styles.productsList}>
                    <div className={styles.sectionInfo}>
                        <div className="icon icon--w32 cursor-pointer">
                            <ReactSVG className={`react-svg ${IconColorSections[sections.find(s => s.id === sectionId).icon]}`} src={IconsConsts[sections.find(s => s.id === sectionId).icon]} />
                        </div>

                        <div className="text-ellipsis--line2 text">{sections.find(s => s.id === sectionId).name}</div>
                    </div>
                    
                    {sectionProducts.map(product => (
                        <div key={product.id} className={styles.product}>
                            <div className={styles.checkBox}>
                                <label className="checkbox-container">
                                    <input type="checkbox" />
                                </label>

                                <div className="text text-ellipsis">{product.name}</div>
                            </div>

                            <div onClick={() => setquantityClick(!quantityClick) }>
                                <div className={"icon cursor-pointer " + quantityClick ? '' : styles.displayNone}>
                                    <ReactSVG className="react-svg" src={PlusIcon} />
                                </div>

                                <div className="text text-ellipsis">{product.quantity}</div>

                                <div className={"icon cursor-pointer " + quantityClick ? '' : styles.displayNone}>
                                    <ReactSVG className="react-svg" src={MinusIcon} />
                                </div>
                            </div>                            
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