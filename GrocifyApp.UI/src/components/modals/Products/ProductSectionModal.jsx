import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../BaseModal';
import CustomInputApp from '../../CustomInputApp';
import ProductSectionSelector from '../../Products/ProductSectionsSelector';
import useApiRequest from '../../../hooks/useApiRequests';

//Assets & Css
import styles from '../ContentModal.module.scss';

//Consts
import { PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../../consts/ENConsts';
import InputType from '../../../consts/InputType';
import ApiEndpoints from '../../../consts/ApiEndpoints';

const ProductSectionModal = ({ onClose, onConfirm, sectionToUpdate }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [productSectionName, setProductSectionName] = useState(sectionToUpdate != null ? sectionToUpdate.name : '');
    const [productSectionIcon, setProductSectionIcon] = useState(sectionToUpdate != null ? sectionToUpdate.icon : 'Home');

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        const isSectionEdited = sectionToUpdate && (productSectionName !== sectionToUpdate.name || productSectionIcon !== sectionToUpdate.icon);
        const areInputsValid = productSectionName !== "" && productSectionIcon !== "";

        setButtonDisabled(!areInputsValid || (sectionToUpdate && !isSectionEdited));
    }, [productSectionIcon, productSectionName]);
    
    const createProductSection = async () => {

        const data = { name: productSectionName, icon: productSectionIcon };

        await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'POST', data);

        onConfirm();
    };

    const editProductSection = async () => {

        const data = { name: productSectionName, icon: productSectionIcon };

        await makeRequest(ApiEndpoints.ProductSectionsId_Endpoint(sectionToUpdate.id), 'PUT', data);

        onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={sectionToUpdate ? editProductSection : createProductSection} isButtonDisabled={isButtonDisabled}
            buttonText={sectionToUpdate ? ButtonConsts.Update : ButtonConsts.Create}
            titleModal={sectionToUpdate ? ModalConsts.EditProductSection(sectionToUpdate.name) : ModalConsts.NewProductSection} modalBody={
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
    sectionToUpdate: PropTypes.object
};

export default ProductSectionModal;