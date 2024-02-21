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

const ProductMeasureModal = ({ onClose, onConfirm }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const [productMeasureName, setProductMeasureName] = useState("");
    const { makeRequest } = useApiRequest();

    useEffect(() => {
        if (productMeasureName !== "") {
            setButtonDisabled(false);
        } else {
            setButtonDisabled(true);
        }
    }, [productMeasureName]);

    const createProductMeasure = async () => {

        const data = { name: productMeasureName };

        await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'POST', data);

        onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={createProductMeasure} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Create} titleModal={ModalConsts.NewProductMeasure} modalBody={
                <div className={styles.inputRow}>
                    <CustomInputApp className="app-form mb-0"
                        type={InputType.Input}
                        placeholder={PlaceholderConsts.AddSectionName}
                        label={LabelConsts.ProductMeasureName}
                        value={productMeasureName}
                        onChange={(e) => setProductMeasureName(e.target.value)}
                        isRequired={true} />
                </div>} />
    );
};

ProductMeasureModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func
};

export default ProductMeasureModal;