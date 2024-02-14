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

const ProductSectionModal = ({ onClose, onConfirm }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const [productSectionName, setProductSectionName] = useState("");
    const [productSectionIcon, setProductSectionIcon] = useState('Home');
    const { makeRequest } = useApiRequest();

    useEffect(() => {
        if (productSectionName !== "" && productSectionIcon !== "") {
            setButtonDisabled(false);
        } else {
            setButtonDisabled(true);
        }
    }, [productSectionIcon, productSectionName]);

    const setIcon = (icon) =>
    {
        setProductSectionIcon(icon);
    };
    
    const createProductSection = async () => {

        const data = { name: productSectionName, icon: productSectionIcon };

        await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'POST', data);

        onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={createProductSection} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Create} titleModal={ModalConsts.NewProductSection} modalBody={
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
                        selectedValueChanged={(e) => setIcon(e)} />
            </div>} />
    );
};

ProductSectionModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func
};

export default ProductSectionModal;