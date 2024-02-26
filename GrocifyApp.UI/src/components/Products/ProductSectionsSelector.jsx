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
import { BgColorSections, IconColorSections } from "../../consts/ColorsConsts";
import InputType from '../../consts/InputType';

const ProductSectionsSelector = ({ selectedValue, selectedValueChanged, productSections, isViewList }) => {
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
                    label={LabelConsts.Section}
                    value={ isViewList ? (
                        <div className="text">
                            {selectedValue.name}
                        </div>
                    ) : (
                        <div className="icon">
                            <ReactSVG className={`react-svg ${IconColorSections[selectedValue.icon]} ${styles.reactSvg}`} src={IconsConsts[selectedValue.icon]} />
                        </div>)
                    }
                    onChange={selectedValueChanged}
                    icon={ChevronIcon} />
            </div>

            <BaseModal isOpen={isOpen} onClose={handleCloseModal} titleModal={LabelConsts.Section} noFooter={true}
                modalBody=
                {
                    isViewList ? (
                        <div className={styles.containerSections}>
                                {productSections.map((section) => (
                                    <div key={section.id} value={section.name} onClick={() => handleOptionChange(section)} className={styles.sectionRow + ` ${section.id === selectedValue.id ? styles.selected : ''}`}>
                                        <ReactSVG className={"react-svg icon-w32-24 " + IconColorSections[section.icon]} src={IconsConsts[section.icon]} />

                                        <div className="text">
                                            {section.name}
                                        </div>
                                    </div>
                                ))}
                            </div>
                    ) : (
                            <div className="grid-columns-6">
                                {Object.keys(IconsConsts).map(section => (
                                    <div key={section} value={section} onClick={() => handleOptionChange(section)} className={`${section === selectedValue.icon ? BgColorSections[section] + ' ' + styles.sectionSelected : ''}`}>
                                        <ReactSVG className={"react-svg icon-w32-24 " + IconColorSections[section]} src={IconsConsts[section]} />
                                    </div>
                                ))}
                            </div>
                    )
                    
                }
            />
        </div>
    );
};

ProductSectionsSelector.propTypes = {
    selectedValueChanged: PropTypes.func.isRequired,
    selectedValue: PropTypes.object,
    productSections: PropTypes.node,
    isViewList: PropTypes.bool
};

export default ProductSectionsSelector;
