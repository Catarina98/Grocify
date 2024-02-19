import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import Layout from '../components/Layout/Layout';
import Searchbar from '../components/Searchbar';
import DefaultList from '../components/modals/DefaultList';
import useApiRequest from '../hooks/useApiRequests';

//Assets & Css
import ChevronIcon from '../assets/chevron-ic.svg';
import LogoutIcon from '../assets/logout-ic.svg';
import TrashIcon from '../assets/trash-ic.svg';
import styles from './Settings.module.scss';

//Consts
import { PlaceholderConsts, SettingsConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';
import ApiEndpoints from '../consts/ApiEndpoints';

function Settings(props) {  
    const [searchInput, setSearchInput] = useState('');
    const [isModalOpen, setIsModalOpen] = useState(false);
    const navigate = useNavigate();
    const { makeRequest } = useApiRequest();

    const settingsItems = [
        {
            tableName: SettingsConsts.Products,
            items: [
                { title: SettingsConsts.Products, link: AppRoutes.Products },
                { title: SettingsConsts.ProductSections, link: AppRoutes.ProductSections },
                { title: SettingsConsts.ProductMeasures, link: AppRoutes.ProductMeaures },
            ]
        },
        {
            tableName: SettingsConsts.DefaultLists,
            items: [
                { title: SettingsConsts.Inventory },
                { title: SettingsConsts.ShoppingList, link: () => openModal() },
            ]
        },
        {
            tableName: SettingsConsts.MealPlan,
            items: [
                { title: SettingsConsts.MealPlan },
                { title: SettingsConsts.Meals },
            ]
        },
        {
            tableName: SettingsConsts.Appearance,
            items: [
                {
                    title: SettingsConsts.DarkMode
                }
            ]
        },
        {
            tableName: SettingsConsts.Account,
            items: [
                { title: SettingsConsts.Logout, icon: LogoutIcon, link: AppRoutes.Logout },
                { title: SettingsConsts.ClearData, icon: TrashIcon, color: 'icon-color--r300' },
            ]
        }
    ];

    const updateUserDarkMode = async () => {
        try {
            await makeRequest(ApiEndpoints.UserDarkMode_Endpoint, 'PUT');
        } catch (error) {
            console.log(error);
        }
    };

    const sendDataToParent = () => {                
        updateUserDarkMode();
        props.onDarkModeChange(!props.isDarkMode);
    };

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
    };

    let isDarkMode = props.isDarkMode;
        
    const renderTableRowContent = (tableTitle, settingItem, darkMode) => {
        const handleLinkClick = (link) => {
            if (typeof link === 'function') {
                link(); // Execute the function
            } else if (typeof link === 'string') {
                navigate(link);
            }
        };

        return (
            <div className={styles.cardBodyRow + " card-body-row cursor-pointer"} key={settingItem.title} onClick={settingItem.link ? () => handleLinkClick(settingItem.link) : undefined}>
                <div className="text">{settingItem.title}</div>
                {tableTitle === SettingsConsts.Appearance ? (
                    <label className="toggle cursor-pointer">
                        <input type="checkbox" checked={darkMode} onChange={() => sendDataToParent()} />
                        <span className="slider"></span>
                    </label>
                ) : (
                        <div className="icon cursor-pointer">
                            <ReactSVG className={"react-svg " + settingItem.color} src={settingItem.icon == null ? ChevronIcon : settingItem.icon} />
                    </div>
                )}
            </div>
        );
    }

    return (
        <Layout>
            <div className="container-settings">
                <div className={styles.searchbarContainer}>
                    <Searchbar placeholder={PlaceholderConsts.Search}
                        label={PlaceholderConsts.Search}
                        value={searchInput}
                        onChange={(e) => setSearchInput(e.target.value)} />
                </div>

                {isModalOpen && <DefaultList isOpen={isModalOpen} onClose={closeModal} />}
               
                <div className={styles.containerCards}>
                    {settingsItems.map(settingTable => (
                        <div className={styles.card + " card"} key={settingTable.tableName}>
                            <div className={styles.cardHeader + " card-header title title--s weight--l"}>{settingTable.tableName}</div>

                            <div className="card-body">
                                {settingTable.items.map(settingItem => (
                                    renderTableRowContent(settingTable.tableName, settingItem, isDarkMode)
                                ))}
                            </div>
                        </div>
                    ))}
                </div>

            </div>
        </Layout>
    );
}

Settings.propTypes = {
    onDarkModeChange: PropTypes.func.isRequired,
    isDarkMode: PropTypes.bool.isRequired
};

export default Settings;
