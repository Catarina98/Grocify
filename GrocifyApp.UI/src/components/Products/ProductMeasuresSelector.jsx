import { useState, useEffect } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../modals/BaseModal';
import CustomInputApp from '../CustomInputApp';
//import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import ChevronIcon from '../../assets/chevron-filled-ic.svg';
import styles from './SelectorDropdown.module.scss';

//Consts
import { LabelConsts } from '../../consts/ENConsts';
//import ApiEndpoints from "../../consts/ApiEndpoints";
import InputType from '../../consts/InputType';

const ProductMeasuresSelector = ({ selectedValue, selectedValueChanged, productMeasures }) => {
    const [isOpen, setIsOpen] = useState(false);
    //const [measures, setMeasures] = useState([]);
    //const { makeRequest } = useApiRequest();

    //const fetchData = async () => {
    //    try {
    //        const responseData = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET');
    //        setMeasures(responseData);
    //    } catch (error) {
    //        console.log(error);
    //    }
    //};

    //useEffect(() => {
    //    fetchData();
    //}, []);

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
                    label={LabelConsts.ProductMeasure}
                    value={selectedValue.name}
                    onChange={selectedValueChanged}
                    icon={ChevronIcon}
                />
            </div>

            <BaseModal isOpen={isOpen} onClose={handleCloseModal} titleModal={LabelConsts.ProductMeasure} noFooter={true} modalBody={
                    <div className={styles.containerSections}>
                        {productMeasures.map((measure) => (
                            <div key={measure.id} value={measure.name} onClick={() => handleOptionChange(measure)}
                                className={`${styles.sectionRow} text ${measure === selectedValue ? styles.selected : ''}`}>
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
    productMeasures: PropTypes.node
};

export default ProductMeasuresSelector;
