import { useState } from 'react';
import { ReactSVG } from 'react-svg';
//import { useNavigate } from 'react-router-dom';
import { PlaceholderConsts } from '../consts/ENConsts';
import CustomInput from '../components/CustomInput';
import SearchIcon from '../assets/search-ic.svg';
import ChevronIcon from '../assets/chevron-ic.svg';
import LogoutIcon from '../assets/logout-ic.svg';
import TrashIcon from '../assets/trash-ic.svg';
import { SettingsConsts } from '../consts/ENConsts';
import './Settings.jsx.scss';

const settingsItems = [
    {
        tableName: SettingsConsts.Products,
        titles: [SettingsConsts.Products, SettingsConsts.ProductSections, SettingsConsts.ProductMeasures],
    },
    {
        tableName: SettingsConsts.DefaultLists,
        titles: [SettingsConsts.Inventory, SettingsConsts.ShoppingList],
    },
    {
        tableName: SettingsConsts.MealPlan,
        titles: [SettingsConsts.MealPlan, SettingsConsts.Meals],
    },
    {
        tableName: SettingsConsts.Appearance,
        titles: [SettingsConsts.DarkMode],
    },
    {
        tableName: SettingsConsts.Account,
        titles: [SettingsConsts.Logout, SettingsConsts.ClearData],
    }
];

function Settings() {
    //const navigate = useNavigate();
    const [searchInput, setSearchInput] = useState('');
    const [darkMode, setDarkMode] = useState(false); //change to darkMode not false

    return (
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
                        <div className="card-header title--s weight--l color-n600">{item.tableName}</div>

                        <div className="card-body">
                            {item.titles.map(title => (
                                <div className="card-body-row" key={title}>
                                    <div className="text">{title}</div>


                                    {item.tableName === SettingsConsts.Appearance ? (
                                        <div className="private-toggle">
                                            <label className="toggle">
                                                <input type="checkbox" checked={darkMode} onChange={() => setDarkMode(!darkMode)} />
                                                <span className="slider"></span>
                                            </label>
                                        </div>
                                    ) : (
                                        <div className="icon--w16">
                                            {item.tableName === SettingsConsts.Account ? (
                                                <ReactSVG className={`react-svg ${title === SettingsConsts.ClearData ? 'color-r300' : ''}`} src={title === SettingsConsts.Logout ? LogoutIcon : TrashIcon} />
                                            ) : (
                                                <ReactSVG className="react-svg" src={title === SettingsConsts.DarkMode ? LogoutIcon : ChevronIcon} />
                                            )}
                                        </div>
                                    )}
                                </div>
                            ))}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Settings;