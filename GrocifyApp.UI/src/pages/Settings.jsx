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
import { PlaceholderConsts, SettingsConsts, GenericConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';
//import ApiEndpoints from '../consts/ApiEndpoints';

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
    const [darkMode, setDarkMode] = useState(props.userAuth ? props.userAuth.isDarkMode : false);
    //const [darkMode, setDarkMode] = props.userAuth ? props.userAuth.isDarkMode : false;
    const [errorMessage, setErrorMessage] = useState('');
    const navigate = useNavigate();

    const updateUserDarkMode = async () => {
        
        try {
            var p = props.userAuth.password; //change

            props.userAuth.confirmPassword = p; //change

            const response = await fetch(`api/User/${props.userAuth.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(props.userAuth),
            });

            if (response.ok) {
                //const userData = await response.json();
                //setDarkMode(userData.isDarkMode);
                console.log("updated");
            } else {
                const errorData = await response.json();
                setErrorMessage(errorData.errors[0]);
            }
        } catch (error) {
            setErrorMessage(GenericConsts.Error);
        }
    };

    useEffect(() => {
        if (props.userAuth) {
            setDarkMode(props.userAuth.isDarkMode);
        }
    }, [props.userAuth]);

    const sendDataToParent = () => {
        const newDarkMode = !darkMode;
        setDarkMode(newDarkMode);

        if (props.userAuth) {
            props.userAuth.isDarkMode = newDarkMode;
        }
        
        updateUserDarkMode();
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
    userAuth: PropTypes.object,
};

export default Settings;