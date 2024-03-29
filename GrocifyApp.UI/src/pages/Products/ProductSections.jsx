import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import ProductSectionModal from '../../components/modals/Products/ProductSectionModal';
import MoreOptionsModal from '../../components/modals/MoreOptionsModal';
import BaseModal from '../../components/modals/BaseModal';
import useApiRequest from '../../hooks/useApiRequests';
import EmptyState from '../../components/EmptyState';
import Alert from '../../components/Alert';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';
import styles from './ProductSections.module.scss';

//Consts
import { PlaceholderConsts, ModalConsts, ButtonConsts, EntityConsts, GenericConsts } from '../../consts/ENConsts';
import IconsConsts from "../../consts/IconsConsts";
import ApiEndpoints from '../../consts/ApiEndpoints';
import { IconColorSections } from '../../consts/ColorsConsts';

function ProductSections() {
    const [errorMessage, setErrorMessage] = useState(null);

    const [searchInput, setSearchInput] = useState('');

    const [sections, setSections] = useState(null);
    const [selectedSection, setSelectedSection] = useState(null);

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isMoreOptionsOpen, setIsMoreOptionsOpen] = useState(false);
    const [isModalDeleteOpen, setIsModalDeleteOpen] = useState(false);

    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();

    const filterProductSectionsByName = async (sectionName) => {
        setSearchInput(sectionName);

        await getProductSections(sectionName);
    };

    const getProductSections = async (sectionName) => {
        const filteredEntities = { Name: sectionName };

        const sectionsResponse = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET', null, filteredEntities);
        setSections(sectionsResponse);
    };

    const fetchData = async () => {
        try {
            await getProductSections(searchInput);
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    //---------Delete sections---------
    const deleteSection = async () => {
        try {
            await makeRequest(ApiEndpoints.ProductSectionsId_Endpoint(selectedSection.id), 'DELETE');
            setSections(prevSections => prevSections.filter(section => section.id !== selectedSection.id));
            setSelectedSection(null);
        } catch (error) {
            console.log(error);
        }
    };

    const closeDeleteModal = async () => {
        setIsModalDeleteOpen(false);
        setSelectedSection(null);
    };

    const openDeleteModal = () => {
        closeMoreOptionsModal();
        setIsModalDeleteOpen(true);
    };
    //---------End of delete sections---------

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedSection(null);
        setIsModalOpen(false);
    };

    const openMoreOptionsModal = (section) => {
        setSelectedSection(section);
        setIsMoreOptionsOpen(true);
    };

    const closeMoreOptionsModal = (removeSelected) => {
        if (removeSelected) {
            setSelectedSection(null);
        }

        setIsMoreOptionsOpen(false);
    };

    const onConfirmSection = async () => {
        await fetchData();
    };

    const editSection = () => {
        closeMoreOptionsModal();
        openModal();
    };

    const cleanErrorMessage = () => {
        setErrorMessage(null);
    }

    return (
        <Layout>
            {errorMessage && <Alert message={errorMessage} onClose={cleanErrorMessage} />}

            {isModalOpen && <ProductSectionModal onClose={closeModal} onConfirm={onConfirmSection}
                sectionToUpdate={selectedSection} onError={(error) => setErrorMessage(error)} />}

            {isMoreOptionsOpen && <MoreOptionsModal onClose={() => closeMoreOptionsModal(true)}
                onEdit={{ text: ModalConsts.EditEntity(EntityConsts.ProductSection), method: () => editSection() }}
                onDelete={{ text: ModalConsts.DeleteEntity(EntityConsts.ProductSection), method: () => openDeleteModal() }} />}

            {selectedSection != null && isModalDeleteOpen && (
                <BaseModal isConfirmModal={true} isOpen={isModalDeleteOpen} onClose={() => closeDeleteModal()} onConfirm={deleteSection}
                    titleModal={ModalConsts.DeleteTitle(`<span class="color--primary">${selectedSection.name}</span> ` + GenericConsts.Section)} />)}

            <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchSections}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => filterProductSectionsByName(e.target.value)} />
            </div>

            {sections != null && sections.length > 0 && (
                <>
                    <div className={styles.containerSections}>
                        {sections.map(section => (
                            <div className={styles.sectionRow} key={section.id}>
                                <div className={styles.sectionInfo}>
                                    <div className={styles.iconW24 + " cursor-pointer"}>
                                        <ReactSVG className={"react-svg " + IconColorSections[section.icon]} src={IconsConsts[section.icon] ?? null} />
                                    </div>

                                    <div className="text">{section.name}</div>
                                </div>

                                {section.houseId != null && (
                                    <div className="icon icon-options cursor-pointer" onClick={() => openMoreOptionsModal(section)}>
                                        <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                                    </div>
                                )}
                            </div>
                        ))}
                    </div>

                    <button className="primary-button btn--l btn-float" onClick={() => openModal()}>
                        <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                        {ButtonConsts.NewSection}
                    </button>
                </>
            )}

            {sections != null && sections.length === 0 &&
                <EmptyState entity={EntityConsts.ProductSection} onCreate={() => openModal()} buttonText={ButtonConsts.NewSection} />}

            {sections === null &&
                <div className="loading bigger">
                    <div className="loading-button bigger"></div>
                </div>}
        </Layout>
    );
}

export default ProductSections;