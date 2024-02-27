import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';
import ProductMeasureModal from '../../components/modals/Products/ProductMeasureModal';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';
import styles from './ProductMeasures.module.scss';

//Consts
import { PlaceholderConsts, ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';

function ProductMeasures() { //todo
    const [searchInput, setSearchInput] = useState('');
    const [measures, setMeasures] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const navigate = useNavigate();

    const { makeRequest } = useApiRequest();
    
    const fetchData = async () => {
        try {
            const responseData = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET');
            setMeasures(responseData);
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

    const onConfirmCreateMeasure = async () => {
        await fetchData();
    };

    return (
        <Layout>
            <div className={styles.searchbarContainer + " searchbar-container searchbar-border"}>
                <div className="icon cursor-pointer rotate-180" onClick={() => navigate(-1)}>
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <Searchbar placeholder={PlaceholderConsts.SearchMeasures}
                    label={PlaceholderConsts.Search}
                    value={searchInput}
                    onChange={(e) => setSearchInput(e.target.value)} />
            </div>

            {isModalOpen && <ProductMeasureModal onClose={closeModal} onConfirm={onConfirmCreateMeasure} />}

            <div className={styles.containerMeasures}>
                {measures.map(measure => (
                    <div className={styles.measureRow} key={measure.id}>
                        <div className="text">{measure.name}</div>

                        {measure.houseId != null && (
                            <div className="icon icon-options cursor-pointer">
                                <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                            </div>
                        )}
                    </div>
                ))}
            </div>

            <button className="primary-button btn--l btn-float" onClick={() => openModal()}>
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewMeasure}
            </button>
        </Layout>
    );
}

export default ProductMeasures;