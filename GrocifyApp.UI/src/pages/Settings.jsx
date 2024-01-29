import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import Layout from '../components/Layout/Layout';
import CustomInput from '../components/CustomInput';

//Assets & Css
import SearchIcon from '../assets/search-ic.svg';
import ChevronIcon from '../assets/chevron-ic.svg';
import LogoutIcon from '../assets/logout-ic.svg';
import TrashIcon from '../assets/trash-ic.svg';
import styles from './Settings.module.scss';

//Consts
import { PlaceholderConsts } from '../consts/ENConsts';
import { SettingsConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';

function Settings(props) {
    const settingsItems = [
        {
            tableName: SettingsConsts.Products,
            items: [
                { title: SettingsConsts.Products },
                { title: SettingsConsts.ProductSections },
                { title: SettingsConsts.ProductMeasures },
            ]
        },
        {
            tableName: SettingsConsts.DefaultLists,
            items: [
                { title: SettingsConsts.Inventory },
                { title: SettingsConsts.ShoppingList },
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
                { title: SettingsConsts.ClearData, icon: TrashIcon, color: 'color-r300' },
            ]
        }
    ];

    const [searchInput, setSearchInput] = useState('');
    const [darkMode, setDarkMode] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        // Ensure dark mode state is updated when it changes externally
        setDarkMode(props.isDarkMode);
    }, [props.isDarkMode]);

    const sendDataToParent = () => {
        // Toggle dark mode state and send it to the parent component
        const newDarkMode = !darkMode;
        setDarkMode(newDarkMode);
        props.onDarkModeChange(newDarkMode);
    };
        
    const renderTableRowContent = (tableTitle, settingItem, darkMode) => {
        const handleLinkClick = (link) => {
            if (typeof link === 'function') {
                link(); // Execute the function
            } else if (typeof link === 'string') {
                navigate(link);
            }
        };

        return (
            <div className={styles.cardBodyRow + " card-body-row"} key={settingItem.title} onClick={settingItem.link ? () => handleLinkClick(settingItem.link) : undefined}>
                <div className="text">{settingItem.title}</div>
                {tableTitle === SettingsConsts.Appearance ? (
                    <label className="toggle cursor-pointer">
                        <input type="checkbox" checked={darkMode} onChange={() => sendDataToParent()} />
                        <span className="slider"></span>
                    </label>
                ) : (
                    <div className="icon--w16 cursor-pointer">
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
                    <div className="searchbar-holder">
                        <CustomInput className="app-form mb-0"
                            type="text"
                            placeholder={PlaceholderConsts.Search}
                            label={PlaceholderConsts.Search}
                            value={searchInput}
                            icon={SearchIcon}
                            onChange={(e) => setSearchInput(e.target.value)} />
                    </div>
                </div>

                <div className={styles.containerCards}>
                    {settingsItems.map(settingTable => (
                        <div className={styles.card + " card"} key={settingTable.tableName}>
                            <div className={styles.cardHeader + " card-header title title--s weight--l"}>{settingTable.tableName}</div>

                            <div className="card-body">
                                {settingTable.items.map(settingItem => (
                                    renderTableRowContent(settingTable.tableName, settingItem, darkMode)
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
    isDarkMode: PropTypes.bool.isRequired,
};

export default Settings;