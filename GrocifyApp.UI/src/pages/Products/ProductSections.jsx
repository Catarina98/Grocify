import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';

//Internal components
import Searchbar from '../../components/Searchbar';
import Layout from '../../components/Layout/Layout';

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

function ProductSections() {
    const [searchInput, setSearchInput] = useState('');
    const [sections, setSections] = useState([]);
    const token = localStorage.getItem('token');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(ApiEndpoints.ProductSections_Endpoint, {
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
                setSections(data);
            } catch (error) {
                console.log('');
            }
        };

        fetchData();
    }, []);

    return (
        <Layout>
            <div className={styles.searchbarContainer + " searchbar-container"}> {/*missing border*/}
                <div className="icon--w16 cursor-pointer rotate-180">
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
                                <ReactSVG className="react-svg icon-color--p100" src={IconsConsts[section.icon]} />
                            </div>

                            <div className="text">{section.name}</div>
                        </div>

                        {section.houseId != null && (
                            <div className="icon--w16 cursor-pointer">
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