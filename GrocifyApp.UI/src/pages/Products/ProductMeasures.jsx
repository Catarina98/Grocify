import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import ProductMeasureModal from '../../components/modals/Products/ProductMeasureModal';
import MoreOptionsModal from '../../components/modals/MoreOptionsModal';
import BaseModal from '../../components/modals/BaseModal';
import EmptyState from '../../components/EmptyState';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';
import styles from './ProductMeasures.module.scss';

//Consts
import { PlaceholderConsts, ButtonConsts, ModalConsts, EntityConsts, GenericConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';

function ProductMeasures() {
    const [searchInput, setSearchInput] = useState('');

    const [measures, setMeasures] = useState(null);
    const [selectedMeasure, setSelectedMeasure] = useState(null);

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isMoreOptionsOpen, setIsMoreOptionsOpen] = useState(false);
    const [isModalDeleteOpen, setIsModalDeleteOpen] = useState(false);

    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();

    const fetchData = async () => {
        try {
            const responseData = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET');
            setMeasures([responseData]);
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    //---------Delete measures---------
    const deleteMeasure = async () => {
        try {
            await makeRequest(ApiEndpoints.ProductMeasuresId_Endpoint(selectedMeasure.id), 'DELETE');
            setMeasures(prevMeasures => prevMeasures.filter(measure => measure.id !== selectedMeasure.id));
            setSelectedMeasure(null);
        } catch (error) {
            console.log(error);
        }
    };

    const closeDeleteModal = async () => {
        setIsModalDeleteOpen(false);
        setSelectedMeasure(null);
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
        setSelectedMeasure(null);
        setIsModalOpen(false);
    };

    const openMoreOptionsModal = (measure) => {
        setSelectedMeasure(measure);
        setIsMoreOptionsOpen(true);
    };

    const closeMoreOptionsModal = (removeSelected) => {
        if (removeSelected) {
            setSelectedMeasure(null);
        }

        setIsMoreOptionsOpen(false);
    };

    const onConfirmMeasure = async () => {
        await fetchData();
    };

    const editMeasure = () => {
        closeMoreOptionsModal();
        openModal();
    };

    return (
        <Layout>
            {isModalOpen && <ProductMeasureModal onClose={closeModal} onConfirm={onConfirmMeasure} measureToUpdate={selectedMeasure} />}

            {isMoreOptionsOpen && <MoreOptionsModal onClose={() => closeMoreOptionsModal(true)}
                onEdit={{ text: ModalConsts.EditEntity(EntityConsts.ProductMeasure), method: () => editMeasure() }}
                onDelete={{ text: ModalConsts.DeleteEntity(EntityConsts.ProductMeasure), method: () => openDeleteModal() }} />}

            {selectedMeasure != null && isModalDeleteOpen && (
                <BaseModal isConfirmModal={true} isOpen={isModalDeleteOpen} onClose={() => closeDeleteModal()} onConfirm={deleteMeasure}
                    titleModal={ModalConsts.DeleteTitle(`<span class="color--primary">${selectedMeasure.name}</span> ` + GenericConsts.Measure)} />)}

            <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchMeasures}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => setSearchInput(e.target.value)} />
            </div>

            {measures != null && measures.length > 0 && (<>
                <div className={styles.containerMeasures}>
                    {measures.map(measure => (
                        <div className={styles.measureRow} key={measure.id}>
                            <div className="text">{measure.name}</div>

                            {measure.houseId != null && (
                                <div className="icon icon-options cursor-pointer" onClick={() => openMoreOptionsModal(measure)}>
                                    <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                                </div>
                            )}
                        </div>
                    ))}
                </div>

                <button className="primary-button btn--l btn-float" onClick={() => openModal()}>
                    <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                    {ButtonConsts.NewMeasure}
                </button> </>
            )}

            {measures != null && measures.length === 0 &&
                <EmptyState entity={EntityConsts.ProductMeasure} onCreate={() => openModal()} buttonText={ButtonConsts.NewMeasure} />}

            {measures === null &&
                <div className="loading bigger">
                    <div className="loading-button bigger"></div>
                </div>}
        </Layout>
    );
}

export default ProductMeasures;