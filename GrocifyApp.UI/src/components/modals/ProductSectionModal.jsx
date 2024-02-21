import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from './BaseModal';
import CustomInputApp from '../CustomInputApp';
import ProductSectionSelector from '../Products/ProductSectionsSelector';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import styles from './ProductSectionModal.module.scss';

//Consts
import { PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../consts/ENConsts';
import InputType from '../../consts/InputType';
import ApiEndpoints from '../../consts/ApiEndpoints';

const ProductSectionModal = ({ onClose, onConfirm, section }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const [productSectionName, setProductSectionName] = useState(section != null ? section.name : '');
    const [productSectionIcon, setProductSectionIcon] = useState(section != null ? section.icon : 'Home');
    const { makeRequest } = useApiRequest();

    useEffect(() => {
        if (productSectionName !== "" && productSectionIcon !== "") {
            setButtonDisabled(false);
        } else {
            setButtonDisabled(true);
        }
    }, [productSectionIcon, productSectionName]);
    
    const createProductSection = async () => {

        const data = { name: productSectionName, icon: productSectionIcon };

        await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'POST', data);

        onConfirm();
    };

    const editProductSection = async () => {

        const data = { name: productSectionName, icon: productSectionIcon };

        await makeRequest(ApiEndpoints.ProductSection_Endpoint(section.id), 'PUT', data);

        onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={section ? editProductSection : createProductSection} isButtonDisabled={isButtonDisabled}
            buttonText={section ? ButtonConsts.Update : ButtonConsts.Create}
            titleModal={section ? ModalConsts.EditProductSection : ModalConsts.NewProductSection} modalBody={
            <div className={styles.inputRow}>
                    <CustomInputApp className="app-form mb-0"
                        type={InputType.Input}
                        placeholder={PlaceholderConsts.AddSectionName}
                        label={LabelConsts.ProductSectionName}
                        value={productSectionName}
                        onChange={(e) => setProductSectionName(e.target.value)}
                        isRequired={true} />

                    <ProductSectionSelector
                        selectedValue={productSectionIcon}
                        selectedValueChanged={(e) => setProductSectionIcon(e)} />
            </div>} />
    );
};

ProductSectionModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func,
    section: PropTypes.object
};

export default ProductSectionModal;