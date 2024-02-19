import { useState } from 'react';
import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Internal components
import BaseModal from '../modals/BaseModal';
import CustomInputApp from '../CustomInputApp';

//Assets & Css
import ChevronIcon from '../../assets/chevron-filled-ic.svg';
import styles from './SelectorDropdown.module.scss';

//Consts
import { LabelConsts, ModalConsts } from '../../consts/ENConsts';
import IconsConsts from "../../consts/IconsConsts";
import { BgColorSections, ColorSections } from "../../consts/ColorsConsts";
import InputType from '../../consts/InputType';

const ProductSectionsSelector = ({ selectedValue, selectedValueChanged }) => {
    const [isOpen, setIsOpen] = useState(false);

    const handleOpenModal = () => {
        setIsOpen(true);
    };

    const handleCloseModal = () => {
        setIsOpen(false);
    };

    const handleOptionChange = (e) => {
        selectedValueChanged(e);

        handleCloseModal();
    };

    return (
        <div>
            <div onClick={handleOpenModal}>
                <CustomInputApp className="app-form mb-0"
                    type={InputType.Custom}
                    label={LabelConsts.ProductSectionIcon}
                    value={
                        <div className="icon">
                            <ReactSVG className={`react-svg ${ColorSections[selectedValue]} ${styles.reactSvg}`} src={IconsConsts[selectedValue]} />
                        </div>
                    }
                    onChange={selectedValueChanged}
                    icon={ChevronIcon} />
            </div>

            <BaseModal isOpen={isOpen} onClose={handleCloseModal} titleModal={ModalConsts.IconSection} noFooter={true}
                modalBody=
                {
                    <div className="grid-columns-6">
                        {Object.keys(IconsConsts).map(section => (
                            <div key={section} value={section} onClick={() => handleOptionChange(section)} className={`${section === selectedValue ? BgColorSections[section] + ' ' + styles.sectionSelected : ''}`}>
                                <ReactSVG className={"react-svg icon-w32-24 " + ColorSections[section]} src={IconsConsts[section]} />
                            </div>
                        ))}
                    </div>
                }
            />
        </div>
    );
};

ProductSectionsSelector.propTypes = {
    selectedValue: PropTypes.string,
    selectedValueChanged: PropTypes.func.isRequired
};

export default ProductSectionsSelector;
