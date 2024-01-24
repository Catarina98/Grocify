import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
//import { useNavigate } from 'react-router-dom';
import { PlaceholderConsts } from '../../consts/ENConsts';
//import PropTypes from 'prop-types';
import CustomInput from '../../components/CustomInput';
import SearchIcon from '../../assets/search-ic.svg';
import DotsIcon from '../../assets/3-dots-ic.svg';
import ChevronIcon from '../../assets/chevron-ic.svg';
//import { ApiEndpoints } from '../../consts/ApiEndpoints';
//import './Settings.jsx.scss';
import Layout from '../../components/Layout/Layout';
import './ProductSections.jsx.scss';

function ProductSections() {
    const [searchInput, setSearchInput] = useState('');
    const [sections, setSections] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
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
                setError(error);
            } finally {
                setLoading(false);
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
                    {/*<CustomInputText @ref="SearchInputRef" Placeholder="@GenericsConst.Search"*/}
                    {/*                 @bind-Value="SearchInput" class="app-form mb-0" Icon="@IconsCore.Generic.Search"*/}
                    {/*                 OnInput="async x => await OnSearchChange(x)"/>*/}
                    <CustomInput className="app-form mb-0"
                        type="input"
                        placeholder={PlaceholderConsts.SearchSections}
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

            <div>
                <div className="container-sections">
                    {sections.map(section => (
                        <div className="section-row" key={section.id}>
                            <div className="section-info">
                                {/*<div>Icon: {section.icon}</div> save icon on db */}
                                <div className="icon--w24 cursor-pointer">
                                    <ReactSVG className="react-svg icon-color--p100" src={SearchIcon} />
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
            </div>
        </Layout>
    );
}

export default ProductSections;