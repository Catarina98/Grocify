import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import useApiRequest from '../../hooks/useApiRequests';
import ProductModal from '../../components/modals/Products/ProductModal';
import MoreOptionsModal from '../../components/modals/MoreOptionsModal';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts, ButtonConsts, ModalConsts, EntityConsts } from '../../consts/ENConsts';
import IconsConsts from "../../consts/IconsConsts";
import { ColorSections, IconColorSections } from "../../consts/ColorsConsts";
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './Products.module.scss';

function Products() {
    const [searchInput, setSearchInput] = useState('');

    const [sections, setSections] = useState([]);
    const [products, setProducts] = useState([]);

    const [selectedSection, setSelectedSection] = useState([]);
    const [selectedProduct, setSelectedProduct] = useState(null);

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isMoreOptionsOpen, setIsMoreOptionsOpen] = useState(false);
    const [isModalDeleteOpen, setIsModalDeleteOpen] = useState(false);

    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();

    const filterProductsBySection = async (sectionId) => {
        if (selectedSection === sectionId) { sectionId = null; }

        setSelectedSection(sectionId);

        await getProducts(sectionId, searchInput);
    };

    const filterProductsByName = async (productName) => {
        setSearchInput(productName);

        setSelectedSection(null);

        await getProducts(null, productName);
    };

    const getProducts = async (sectionId, productName) => {
        const filteredEntities = { ProductSectionId: sectionId, Name: productName };

        const productsResponse = await makeRequest(ApiEndpoints.Products_Endpoint, 'GET', null, filteredEntities);
        setProducts(productsResponse);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const sectionsResponse = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET');
                setSections(sectionsResponse);

                await filterProductsBySection(sectionsResponse[0].id);
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    //---------Delete products---------
    const deleteProduct = async () => {
        //try {
        //    await makeRequest(ApiEndpoints.ProductSectionsId_Endpoint(selectedSection.id), 'DELETE');
        //    setSections(prevSections => prevSections.filter(section => section.id !== selectedSection.id));
        //    setSelectedSection(null);
        //} catch (error) {
        //    console.log(error);
        //}
    };

    const closeDeleteModal = async () => {
        setIsModalDeleteOpen(false);
        setSelectedProduct(null);
    };

    const openDeleteModal = () => {
        closeMoreOptionsModal();
        setIsModalDeleteOpen(true);
    };
    //---------End of delete products---------

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedProduct(null);
        setIsModalOpen(false);
    };

    const openMoreOptionsModal = (product) => {
        setSelectedProduct(product);
        setIsMoreOptionsOpen(true);
    };

    const closeMoreOptionsModal = (removeSelected) => {
        if (removeSelected) {
            setSelectedProduct(null);
        }

        setIsMoreOptionsOpen(false);
    };
        
    const onConfirmProduct = async (sectionId) => {
        setSelectedSection(sectionId);
        await filterProductsBySection(sectionId);        
    };

    const editProduct = () => {
        closeMoreOptionsModal();
        openModal();
    };

    return (
        <Layout>
            {isModalOpen && <ProductModal onClose={closeModal} onConfirm={onConfirmProduct} productSections={sections} productToUpdate={selectedProduct} />}

            {isMoreOptionsOpen && <MoreOptionsModal onClose={closeMoreOptionsModal}
                onEdit={{text: ModalConsts.EditEntity(EntityConsts.Product), method: () => editProduct()}}
                onDelete={{text: ModalConsts.DeleteEntity(EntityConsts.Product), method: () => openDeleteModal()}} />}

            <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchProducts}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => filterProductsByName(e.target.value)} />
            </div>

            <div className={styles.containerSections}>
                {sections.map(section => (
                    <div key={section.id} className={styles.sectionInfo} onClick={() => filterProductsBySection(section.id)}>
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
                            <div className="icon icon-options cursor-pointer" onClick={() => openMoreOptionsModal(product)}>
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