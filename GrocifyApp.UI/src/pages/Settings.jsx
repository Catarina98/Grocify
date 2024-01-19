import { useState } from 'react';
//import { useNavigate } from 'react-router-dom';
import { PlaceholderConsts } from '../consts/ENConsts';
import CustomInput from '../components/CustomInput';
import SearchIcon from '../assets/search-ic.svg';

function Settings() {
    //const navigate = useNavigate();
    const [searchInput, setSearchInput] = useState('');
    
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
                <div className="card">
                    <div className="card-header">Products</div>

                    <div className="card-body">
                        <div className="card-body-row">
                            <div className="text">Products</div>

                            <div className="icon">+</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Settings;