import { useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../modals/BaseModal';
import CustomInputApp from '../CustomInputApp';

//Assets & Css
import ChevronIcon from '../../assets/chevron-filled-ic.svg';
import styles from './SelectorDropdown.module.scss';

//Consts
import { LabelConsts } from '../../consts/ENConsts';
import InputType from '../../consts/InputType';

const ProductMeasuresSelector = ({ selectedValue, selectedValueChanged, productMeasures }) => {
    const [isOpen, setIsOpen] = useState(false);

    const handleOpenModal = () => {
        setIsOpen(true);
    };

    const handleCloseModal = () => {
        setIsOpen(false);
    };

    const handleOptionChange = (measure) => {
        selectedValueChanged(measure);
        handleCloseModal();
    };

    return (
        <div>
            <div onClick={handleOpenModal}>
                <CustomInputApp className="app-form mb-0"
                    type={InputType.Custom}
                    label={LabelConsts.Measure}
                    value={selectedValue.name}
                    onChange={selectedValueChanged}
                    icon={ChevronIcon}
                />
            </div>

            <BaseModal isOpen={isOpen} onClose={handleCloseModal} titleModal={LabelConsts.Measure} noFooter={true} modalBody={
                    <div className={styles.containerMeasures}>
                        {productMeasures.map((measure) => (
                            <div key={measure.id} value={measure.name} onClick={() => handleOptionChange(measure)}
                                className={`${styles.measureRow} text ${measure.name === selectedValue.name ? styles.selected : ''}`}>
                                {measure.name}
                            </div>
                        ))}
                    </div>
                }
            />
        </div>
    );
};

ProductMeasuresSelector.propTypes = {
    selectedValueChanged: PropTypes.func.isRequired,
    selectedValue: PropTypes.object,
    productMeasures: PropTypes.array
};

export default ProductMeasuresSelector;
