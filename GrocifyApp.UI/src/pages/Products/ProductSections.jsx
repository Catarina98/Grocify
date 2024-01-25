import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
//import { useNavigate } from 'react-router-dom';
import { PlaceholderConsts } from '../../consts/ENConsts';
import { ButtonConsts } from '../../consts/ENConsts';
//import PropTypes from 'prop-types';
import CustomInput from '../../components/CustomInput';
import SearchIcon from '../../assets/search-ic.svg';
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
import PlusCircleIcon from '../../assets/plus-circle-ic.svg';
import IconsConsts from "../../consts/IconsConsts";
//import { ApiEndpoints } from '../../consts/ApiEndpoints';
import Layout from '../../components/Layout/Layout';
import './ProductSections.jsx.scss';

function ProductSections() {
    const [searchInput, setSearchInput] = useState('');
    const [sections, setSections] = useState([]);
    //const [loading, setLoading] = useState(true);
    //const [error, setError] = useState(null);
    //const [houseId, setHouseId] = useState('');
    //const navigate = useNavigate();
    const houseId = "70835d8c-dcc0-4d36-8172-08dc12c93d56";

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(`api/ProductSection/${houseId}/products`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    throw new Error(`Failed to fetch data: ${response.statusText}`);
                }

                // Parse the response body as JSON
                const data = await response.json();
                setSections(data);
            } catch (error) {
                /*setError(error);*/
            } finally {
                //setLoading(false);
            }
        };

        fetchData();
    }, []); // The empty dependency array means this effect runs once, similar to componentDidMount

    return (
        <Layout>
            <div className="searchbar-container"> {/*missing border*/}
                <div className="icon--w16 cursor-pointer rotate-180">
                    <ReactSVG className="react-svg icon-color--n600" src={ChevronIcon} />
                </div>

                <div className="searchbar-holder">
                    <CustomInput className="app-form mb-0"
                        type="input"
                        placeholder={PlaceholderConsts.SearchSections}
                        label={PlaceholderConsts.Search}
                        value={searchInput}
                        icon={SearchIcon}
                        onChange={(e) => setSearchInput(e.target.value)} />
                </div>
            </div>

            <div className="container-sections">
                {sections.map(section => (
                    <div className="section-row" key={section.id}>
                        <div className="section-info">
                            <div className="icon--w24 cursor-pointer">
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

            <button className="primary-button btn--l">
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {ButtonConsts.NewSection}
            </button>
        </Layout>
    );
}

export default ProductSections;