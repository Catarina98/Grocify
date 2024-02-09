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
