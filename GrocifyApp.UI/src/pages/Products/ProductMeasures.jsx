import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';

//Assets & Css
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';
import styles from './ProductSections.module.scss';

//Consts
import { PlaceholderConsts, ButtonConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';

function ProductMeasures() {
    const [searchInput, setSearchInput] = useState('');
    const [measures, setMeasures] = useState([]);
    const token = localStorage.getItem('token');
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(ApiEndpoints.ProductMeasures_Endpoint, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`,
                    },
                });

                if (!response.ok) {
                    throw new Error(`Failed to fetch data: ${response.statusText}`);
                }

                const data = await response.json();
                setMeasures(data);
            } catch (error) {
                console.log('');
            }
        };

        fetchData();
    }, [token]);

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

            <div className={styles.containerSections}>
                {measures.map(section => (
                    <div className={styles.sectionRow} key={section.id}>
                        <div className="text">{section.name}</div>

                        {section.houseId != null && (
                            <div className="icon cursor-pointer">
                                <ReactSVG className="react-svg icon-color--n600" src={DotsIcon} />
                            </div>
                        )}
                    </div>
                ))}
            </div>

            <button className="primary-button btn--l btn-float">
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewMeasure}
            </button>
        </Layout>
    );
}

export default ProductMeasures;