import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../BaseModal';
import CustomInputApp from '../../CustomInputApp';
import useApiRequest from '../../../hooks/useApiRequests';

//Assets & Css
import styles from '../ContentModal.module.scss';

//Consts
import { PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../../consts/ENConsts';
import InputType from '../../../consts/InputType';
import ApiEndpoints from '../../../consts/ApiEndpoints';

const ProductMeasureModal = ({ onClose, onConfirm, measureToUpdate }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [productMeasureName, setProductMeasureName] = useState(measureToUpdate != null ? measureToUpdate.name : '');

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        const isMeasureEdited = measureToUpdate && productMeasureName !== measureToUpdate.name;
        const areInputsValid = productMeasureName !== "";

        setButtonDisabled(!areInputsValid || (measureToUpdate && !isMeasureEdited));
    }, [productMeasureName]);

    const createProductMeasure = async () => {

        const data = { name: productMeasureName };

        await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'POST', data);

        onConfirm();
    };

    const editMeasureSection = async () => {

        const data = { name: productMeasureName };

        await makeRequest(ApiEndpoints.ProductMeasuresId_Endpoint(measureToUpdate.id), 'PUT', data);

        onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={measureToUpdate ? editMeasureSection : createProductMeasure} isButtonDisabled={isButtonDisabled}
            buttonText={measureToUpdate ? ButtonConsts.Update : ButtonConsts.Create}
            titleModal={measureToUpdate ? ModalConsts.EditProductMeasure(measureToUpdate.name) : ModalConsts.NewProductMeasure} modalBody={
                <div className={styles.inputRow}>
                    <CustomInputApp className="app-form mb-0"
                        type={InputType.Input}
                        placeholder={PlaceholderConsts.AddMeasureName}
                        label={LabelConsts.ProductMeasureName}
                        value={productMeasureName}
                        onChange={(e) => setProductMeasureName(e.target.value)}
                        isRequired={true} />
                </div>} />
    );
};

ProductMeasureModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func,
    measureToUpdate: PropTypes.object
};

export default ProductMeasureModal;