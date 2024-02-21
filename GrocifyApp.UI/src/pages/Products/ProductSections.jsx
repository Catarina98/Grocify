import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import useApiRequest from '../../hooks/useApiRequests';
import BaseModal from '../../components/BaseModal';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts } from '../../consts/ENConsts';
import { ButtonConsts, ModalConsts } from '../../consts/ENConsts';
import IconsConsts from "../../consts/IconsConsts";
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './ProductSections.module.scss';

function ProductSections() {
    const [searchInput, setSearchInput] = useState('');
    const [sections, setSections] = useState([]);
    const [selectedSection, setSelectedSection] = useState([]);
    const [isModalDeleteOpen, setIsModalDeleteOpen] = useState(false);
    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const responseData = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET');
                setSections(responseData);
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);


    const deleteSection = async () => {
        try {
            await makeRequest(ApiEndpoints.ProductSectionsId_Endpoint(selectedSection.id), 'DELETE');

            setSections(prevSections => prevSections.filter(section => section.id !== selectedSection.id));

            setSelectedSection(null);
        } catch (error) {
            console.log(error);
        }
    };

    const closeModal = async () => {
        setIsModalDeleteOpen(false);

        setSelectedSection(null);
    };

    const openDeleteModal = (section) => {
        setSelectedSection(section);

        setIsModalDeleteOpen(true);
    };

    return (
        <Layout>

            {selectedSection != null && isModalDeleteOpen && (
                <BaseModal isConfirmModal={true} isOpen={isModalDeleteOpen} onClose={() => closeModal()} onConfirm={deleteSection}
                    title={ModalConsts.DeleteSection(selectedSection.name)} />)}

            <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchSections}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => setSearchInput(e.target.value)} />
            </div>
            
            <div className={styles.containerSections}>
                {sections.map(section => (
                    <div className={styles.sectionRow} key={section.id}>
                        <div className={styles.sectionInfo}>
                            <div className={styles.iconW24 + " cursor-pointer"}>
                                <ReactSVG className="react-svg icon-color--p100" src={IconsConsts[section.icon] ?? null} />
                            </div>

                            <div className="text">{section.name}</div>
                        </div>

                        {section.houseId != null && (
                            <div className="icon cursor-pointer" onClick={() => openDeleteModal(section)}>
                                <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                            </div>
                        )}
                    </div>
                ))}
            </div>

            <button className="primary-button btn--l btn-float">
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewSection}
            </button>
        </Layout>
    );
}

export default ProductSections;