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
import { PlaceholderConsts, ButtonConsts } from '../../consts/ENConsts';
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
        <div>
            {Object.entries(groupedProducts).map(([sectionId, sectionProducts]) => (
                <div key={sectionId} className={styles.containerList}>
                    <div className="icon icon-options cursor-pointer">
                        <ReactSVG className="react-svg icon-color--n600" src={sections[sectionId]} />
                    </div>
                    {sectionProducts.map(product => (
                        <div key={product.id} className={styles.product}>
                            <div className="title weight--m text-ellipsis">{product.name}</div>
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