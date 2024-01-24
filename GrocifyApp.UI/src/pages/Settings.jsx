import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import { useNavigate } from 'react-router-dom';
import { PlaceholderConsts } from '../consts/ENConsts';
import PropTypes from 'prop-types';
import CustomInput from '../components/CustomInput';
import SearchIcon from '../assets/search-ic.svg';
import ChevronIcon from '../assets/chevron-ic.svg';
import LogoutIcon from '../assets/logout-ic.svg';
import TrashIcon from '../assets/trash-ic.svg';
import { SettingsConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';
import './Settings.jsx.scss';
import Layout from '../components/Layout/Layout';

const settingsItems = [
    {
        tableName: SettingsConsts.Products,
        titles: [
            { name: SettingsConsts.Products, route: null },
            { name: SettingsConsts.ProductSections, route: AppRoutes.ProductSections },
            { name: SettingsConsts.ProductMeasures, route: null },
        ],
    },
    {
        tableName: SettingsConsts.DefaultLists,
        titles: [
            { name: SettingsConsts.Inventory, route: null },
            { name: SettingsConsts.ShoppingList, route: null },
        ],
    },
    {
        tableName: SettingsConsts.MealPlan,
        titles: [
            { name: SettingsConsts.MealPlan, route: null },
            { name: SettingsConsts.Meals, route: null },
        ],
    },
    {
        tableName: SettingsConsts.Appearance,
        titles: [SettingsConsts.DarkMode],
    },
    {
        tableName: SettingsConsts.Account,
        titles: [
            { name: SettingsConsts.Logout },
            { name: SettingsConsts.ClearData },
        ],
    },
];

function Settings(props) {
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

    const handleLogout = () => {
        localStorage.removeItem('token');

        navigate('/');
    };

    const goToRoute = (route) => {
        navigate(route);
    };

    return (
        <Layout>
            <div className="container-settings">
                <div className="searchbar-container">
                    <div className="searchbar-holder">
                        {/*<CustomInputText @ref="SearchInputRef" Placeholder="@GenericsConst.Search"*/}
                        {/*                 @bind-Value="SearchInput" class="app-form mb-0" Icon="@IconsCore.Generic.Search"*/}
                        {/*                 OnInput="async x => await OnSearchChange(x)"/>*/}
                        <CustomInput className="app-form mb-0"
                            type="password"
                            placeholder={PlaceholderConsts.Search}
                            label={PlaceholderConsts.Search}
                            value={searchInput}
                            icon={SearchIcon}
                            onChange={(e) => setSearchInput(e.target.value)} />

                        {/*<div className="dropdown-search">*/}
                        {/*    <div className="tab-buttons just-center">*/}
                        {/*        */}{/*<TabSet TabsList="Tabs" SelectedTab="@SelectedTab"*/}
                        {/*        */}{/*        SelectedTabChanged="OnSelectedTabChanged"/>*/}
                        {/*    </div>*/}
                        {/*    <div className="items-list">*/}
                        {/*        */}{/*@if (FilteredDataList is null || !FilteredDataList.Any())*/}
                        {/*        */}{/*{*/}
                        {/*        */}{/*    <div class="no-results text--xs">*/}
                        {/*        */}{/*        <svg data-src="@IconsConst.MainPage.SadSmile" class="icon-color--n600"/>*/}

                        {/*        */}{/*        @GenericsConst.NoResults*/}
                        {/*        */}{/*    </div>*/}
                        {/*        */}{/*}*/}
                        {/*        */}{/*else*/}
                        {/*        */}{/*{*/}
                        {/*        */}{/*    @foreach (var item in FilteredDataList)*/}
                        {/*        */}{/*    {*/}
                        {/*        */}{/*        <button class="btn item-searched" @onclick="async () => await OnItemSelect(item)">*/}
                        {/*        */}{/*            <div class="item-tab">*/}
                        {/*        */}{/*                @if (item.Type == GlobalSearchType.Files)*/}
                        {/*        */}{/*                {*/}
                        {/*        */}{/*                    <div class="file-type @FilesHelper.GetFileExtensionColor(item.Icon)">*/}
                        {/*        */}{/*                        @item.Icon*/}
                        {/*        */}{/*                    </div>*/}
                        {/*        */}{/*                }*/}
                        {/*        */}{/*                else*/}
                        {/*        */}{/*                {*/}
                        {/*        */}{/*                    <svg data-src="@item.Icon" class="icon-color--n500"/>*/}
                        {/*        */}{/*                }*/}

                        {/*        */}{/*                <div class="text--xs">*/}
                        {/*        */}{/*                    @item.Name*/}
                        {/*        */}{/*                </div>*/}
                        {/*        */}{/*            </div>*/}

                        {/*        */}{/*            @if (item.Type == GlobalSearchType.Topics)*/}
                        {/*        */}{/*            {*/}
                        {/*        */}{/*                <FollowBtn TopicId="(int) item.Id" TopicTitle="@item.Name" IsTopicPrivate="(bool) item.Value!"/>*/}
                        {/*        */}{/*            }*/}
                        {/*        */}{/*        </button>*/}
                        {/*        */}{/*    }*/}
                        {/*        */}{/*}*/}
                        {/*    </div>*/}
                        {/*</div>*/}
                    </div>
                </div>

                <div className="container-cards">
                    {settingsItems.map(item => (
                        <div className="card" key={item.tableName}>
                            <div className="card-header title title--s weight--l">{item.tableName}</div>

                            <div className="card-body">
                                {item.titles.map(title => (
                                    <div className="card-body-row" key={title.name}>
                                        <div className="text">{title.name}</div>

                                        {item.tableName === SettingsConsts.Appearance ? (
                                            <label className="toggle cursor-pointer">
                                                <input type="checkbox" checked={darkMode} onChange={() => sendDataToParent()} />
                                                <span className="slider"></span>
                                            </label>
                                        ) : (
                                            (item.tableName === SettingsConsts.Account && title.name === SettingsConsts.Logout) ? (
                                                <div className="icon--w16 cursor-pointer" onClick={handleLogout}>
                                                    <ReactSVG className="react-svg" src={LogoutIcon} />
                                                </div>
                                            ) : (item.tableName === SettingsConsts.Account && title.name === SettingsConsts.ClearData ?
                                                <div className="icon--w16 cursor-pointer">
                                                    <ReactSVG className="react-svg color-r300" src={TrashIcon} />
                                                </div>
                                                :
                                                <div className="icon--w16 cursor-pointer" onClick={() => goToRoute(title.route)}>
                                                    <ReactSVG className="react-svg" src={ChevronIcon} />
                                                </div>
                                            )
                                        )}
                                    </div>
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