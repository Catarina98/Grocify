import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import IconsConsts from '../../consts/IconsConsts';
import { IconColorSections } from '../../consts/ColorsConsts';
import { ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './ShoppingListDetail.module.scss';

function ShoppingListDetail({ shoppingList }) {
    //const [searchInput, setSearchInput] = useState('');
    const [products, setProducts] = useState([]);
    const [sections, setSections] = useState({});

    const { makeRequest } = useApiRequest();

    const getProductSections = async () => {
        const sectionsResponse = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET', null);
        setSections(sectionsResponse);
    };

    const getShoppingListProducts = async () => {
        const productsResponse = await makeRequest(ApiEndpoints.ShoppingListProducts_Endpoint(shoppingList.id), 'GET', null);
        const sortedProducts = productsResponse.sort((a, b) => a.productSectionId - b.productSectionId);
        setProducts(sortedProducts);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                await getProductSections();
                await getShoppingListProducts();
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
            <button className="subtle-button btn--m">
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
                                    <input type="radio" />
                                </label>

                                <div className="text text-ellipsis">{product.name}</div>
                            </div>
                            
                            <div className="text text-ellipsis">{product.quantity}</div>
                        </div>
                    ))}
                </div>
            ))}
        </div>
    );
}

ShoppingListDetail.propTypes = {
    shoppingList: PropTypes.shape({
        shoppingListId: PropTypes.string.isRequired,
    }).isRequired,
};

export default ShoppingListDetail;