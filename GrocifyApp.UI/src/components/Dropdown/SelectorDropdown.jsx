import { useState } from 'react';
import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Internal components
import BaseModal from '../modals/BaseModal';
import CustomInputApp from '../../components/CustomInputApp';

//Assets & Css
import ChevronIcon from '../../assets/chevron-ic.svg';
import styles from './SelectorDropdown.module.scss';

//Consts
import IconsConsts from "../../consts/IconsConsts";
import { BgColorSections, ColorSections } from "../../consts/ColorsConsts";

const SelectorDropdown = ({ selectedValue, placeholder, selectedValueChanged, title, contentClass, label }) => {
    const [isOpen, setIsOpen] = useState(false);

    const handleOpenModal = () => {
        setIsOpen(true);
    };

    const handleCloseModal = () => {
        setIsOpen(false);
    };

    const handleOptionChange = (e) => {
        selectedValueChanged(e);
    };

    return (
        <div>
            <div onClick={handleOpenModal} className={contentClass}>
                <CustomInputApp className="app-form mb-0"
                    type="icon"
                    placeholder={placeholder}
                    label={label}
                    value={selectedValue}
                    onChange={selectedValueChanged}
                    icon={ChevronIcon} />
            </div>

            {isOpen && <BaseModal isOpen={isOpen} onClose={handleCloseModal} titleModal={title} noFooter={true} modalBody={
                <div className="grid-columns-6">
                    {Object.keys(IconsConsts).map(section => (
                        <div key={section} value={section} onClick={() => handleOptionChange(section)} className={`${IconsConsts[section] === selectedValue ? BgColorSections[section] + ' ' + styles.sectionSelected : ''}`}>
                            <ReactSVG className={"react-svg icon-w32-24 " + ColorSections[section]} src={IconsConsts[section]} />
                        </div>
                    ))}
                </div>
            } />}
        </div>
    );
};

SelectorDropdown.propTypes = {
    selectedValue: PropTypes.string,
    placeholder: PropTypes.string,
    selectedValueChanged: PropTypes.func.isRequired,
    title: PropTypes.string.isRequired,
    contentClass: PropTypes.string.isRequired,
    label: PropTypes.string
};

export default SelectorDropdown;







//import { useState, useEffect, useRef } from 'react';
//import PropTypes from 'prop-types';
//import { ReactSVG } from 'react-svg';

////Internal components
//import SlideDropdown from './SlideDropdown';

//function SelectorDropdown({ SelectedValue, Placeholder, SelectedValueChanged, EnableRemoveSelection, Title, ContentClass, IconSourceClass }) {
//    const [options, setOptions] = useState([]);
//    const SlideDropdownRef = useRef(null);

//    useEffect(() => {
//        const enumValues = Object.values(SelectedValue);
//        setOptions(enumValues);
//    }, [SelectedValue]);

//    const getIcon = (value) => {
//        return IconSourceClass[value];
//    };

//    const getDisplayNameFromEnum = (enumValue) => {
//        // Implement logic to get display name from enum in React way
//    };

//    const selectValue = (value) => {
//        // Implement logic to select value in React way
//    };

//    return (
//        <div className="selector-main">
//            <SlideDropdown ref={SlideDropdownRef}
//                Trigger={
//                    <span className="text bold text-main-color mr-auto color-n500">
//                        {(SelectedValue === null ? Placeholder : getDisplayNameFromEnum(SelectedValue))}
//                    </span>
//                }

//                Options={
//                    <>
//                        <div className={ContentClass} onClick={() => SlideDropdownRef.current.CloseDropdown()}>
//                            <div className="text weight--m color--n700">
//                                {Title}
//                            </div>

//                            {/*<svg src={IconsConst.Generic.Close} className="iconColorMain cursor-pointer" />*/}
//                        </div>

//                        {options.map((value) => (
//                            <button key={value} className={`btn option-item ${value === SelectedValue ? 'active' : ''}`} onClick={() => selectValue(value)}
//                                disabled={(value === SelectedValue && !EnableRemoveSelection)}>

//                                {getIcon(value) && <svg src={getIcon(value)} className="iconColorMain" />}

//                                <span className="text">
//                                    {getDisplayNameFromEnum(value)}
//                                </span>
//                            </button>
//                        ))}
//                    </>
//                } />
//        </div>
//    );
//}

//SelectorDropdown.propTypes = {
//    SelectedValue: PropTypes.any.isRequired,
//    Placeholder: PropTypes.string.isRequired,
//    SelectedValueChanged: PropTypes.func.isRequired,
//    EnableRemoveSelection: PropTypes.bool.isRequired,
//    Title: PropTypes.string.isRequired,
//    ContentClass: PropTypes.string.isRequired,
//    IconSourceClass: PropTypes.object.isRequired,
//};

//export default SelectorDropdown;
