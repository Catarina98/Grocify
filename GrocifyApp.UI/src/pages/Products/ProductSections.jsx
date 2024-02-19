import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import ProductSectionModal from '../../components/modals/ProductSectionModal';
import useApiRequest from '../../hooks/useApiRequests';
import EmptyState from '../../components/EmptyState';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';

//Consts
import { PlaceholderConsts } from '../../consts/ENConsts';
import { ButtonConsts } from '../../consts/ENConsts';
import IconsConsts from "../../consts/IconsConsts";
import ApiEndpoints from '../../consts/ApiEndpoints';
import styles from './ProductSections.module.scss';
import { ColorSections } from '../../consts/ColorsConsts';

function ProductSections() {
    const [searchInput, setSearchInput] = useState('');
    const [sections, setSections] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();

    const fetchData = async () => {
        try {
            const responseData = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET');
            setSections(responseData);
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
    };

    const onConfirmCreateSection = async() => {
        await fetchData();
    };

    return (
        <Layout>
            {sections.length > 0 && <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchSections}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => setSearchInput(e.target.value)} />
            </div>}

            {isModalOpen && <ProductSectionModal onClose={closeModal} onConfirm={onConfirmCreateSection} />}

            <div className={styles.containerSections}>
                {sections.map(section => (
                    <div className={styles.sectionRow} key={section.id}>
                        <div className={styles.sectionInfo}>
                            <div className={styles.iconW24 + " cursor-pointer"}>
                                <ReactSVG className={"react-svg " + ColorSections[section.icon]} src={IconsConsts[section.icon] ?? null} />
                            </div>

                            <div className="text">{section.name}</div>
                        </div>

                        {section.houseId != null && (
                            <div className="icon cursor-pointer">
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

            {sections.length === 0 && <EmptyState />}
        </Layout>
    );
}

export default ProductSections;