import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import useApiRequest from '../../hooks/useApiRequests';
import ProductModal from '../../components/modals/ProductModal';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts } from '../../consts/ENConsts';
import { ButtonConsts } from '../../consts/ENConsts';
import IconsConsts from "../../consts/IconsConsts";
import { ColorSections, IconColorSections } from "../../consts/ColorsConsts";
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './Products.module.scss';

function Products() {
    const [searchInput, setSearchInput] = useState('');
    const [sections, setSections] = useState([]);
    const [selectedSection, setSelectedSection] = useState([]);
    const [products, setProducts] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();

    const getProducts = async (sectionId) => {
        setSelectedSection(sectionId);
        const filteredEntities = { ProductSectionId: sectionId };
        const productsResponse = await makeRequest(ApiEndpoints.Products_Endpoint, 'GET', null, filteredEntities);
        setProducts(productsResponse);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const sectionsResponse = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET');
                setSections(sectionsResponse);
                await getProducts(sectionsResponse[0].id);
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
    };

    const onConfirmProduct = async (sectionId) => {
        await getProducts(sectionId);
    };

    return (
        <Layout>
            {isModalOpen && <ProductModal onClose={closeModal} onConfirm={onConfirmProduct} />}

            <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchProducts}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => setSearchInput(e.target.value)} />
            </div>

            <div className={styles.containerSections}>
                {sections.map(section => (
                    <div key={section.id} className={styles.sectionInfo} onClick={() => getProducts(section.id)}>
                        <div className={styles.iconW24 + " cursor-pointer"}>
                            <ReactSVG className={`react-svg ${section.id === selectedSection ? IconColorSections[section.icon] : 'icon-color--n500'}`} src={IconsConsts[section.icon] ?? null} />
                        </div>

                        <div className={`text-ellipsis--line2 text text--xxs ${section.id === selectedSection ? ColorSections[section.icon] : 'color--n500'}`}>{section.name}</div>
                    </div>
                ))}
            </div>

            <div className={styles.containerProducts}>
                {products.map(product => (
                    <div className={styles.sectionRow} key={product.id}>
                        <div className={styles.sectionInfo}>
                            <div className="text text-ellipsis">{product.name}</div>
                        </div>

                        {product.houseId != null && (
                            <div className="icon cursor-pointer">
                                <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                            </div>
                        )}
                    </div>
                ))}
            </div>

            <button className="primary-button btn--l btn-float" onClick={() => openModal()}>
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewProduct}
            </button>
        </Layout>
    );
}

export default Products;