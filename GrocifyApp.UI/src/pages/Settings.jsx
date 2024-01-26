import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';

//Internal components
import Layout from '../components/Layout/Layout';
import CustomInput from '../components/CustomInput';

//Assets & Css
import SearchIcon from '../assets/search-ic.svg';
import ChevronIcon from '../assets/chevron-ic.svg';
import LogoutIcon from '../assets/logout-ic.svg';
import TrashIcon from '../assets/trash-ic.svg';
import './Settings.jsx.scss';

//Consts
import { PlaceholderConsts } from '../consts/ENConsts';
import { SettingsConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';

function Settings() {
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
    const [darkMode, setDarkMode] = useState(false); //change to darkMode not false
    const navigate = useNavigate();

    const renderTableRowContent = (tableTitle, settingItem, darkMode) => {
        const handleLinkClick = (link) => {
            if (typeof link === 'function') {
                link(); // Execute the function
            } else if (typeof link === 'string') {
                navigate(link);
            }
        };

        return (
            <div className="card-body-row" key={settingItem.title} onClick={settingItem.link ? () => handleLinkClick(settingItem.link) : undefined}>
                <div className="text">{settingItem.title}</div>
                {tableTitle === SettingsConsts.Appearance ? (
                    <label className="toggle cursor-pointer">
                        <input type="checkbox" checked={darkMode} onChange={() => setDarkMode(!darkMode)} />
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
                <div className="searchbar-container">
                    <div className="searchbar-holder">
                        <CustomInput className="app-form mb-0"
                            type="password"
                            placeholder={PlaceholderConsts.Search}
                            label={PlaceholderConsts.Search}
                            value={searchInput}
                            icon={SearchIcon}
                            onChange={(e) => setSearchInput(e.target.value)} />
                    </div>
                </div>

                <div className="container-cards">
                    {settingsItems.map(settingTable => (
                        <div className="card" key={settingTable.tableName}>
                            <div className="card-header title--s weight--l color-n600">{settingTable.tableName}</div>

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

export default Settings;