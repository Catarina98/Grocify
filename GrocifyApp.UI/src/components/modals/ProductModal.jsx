import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from './BaseModal';
import CustomInputApp from '../CustomInputApp';
import ProductSectionSelector from '../Products/ProductSectionsSelector';
import ProductMeasureSelector from '../Products/ProductMeasuresSelector';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import styles from './ProductModal.module.scss';

//Consts
import { PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../consts/ENConsts';
import InputType from '../../consts/InputType';
import ApiEndpoints from '../../consts/ApiEndpoints';

const ProductModal = ({ onClose, onConfirm }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const [productName, setProductName] = useState("");
    const [productSection, setProductSection] = useState(null);
    const [productMeasure, setProductMeasure] = useState(null);
    const [measures, setMeasures] = useState([]);
    const [sections, setSections] = useState([]);
    const { makeRequest } = useApiRequest();

    useEffect(() => {
        if (productName !== "") {
            setButtonDisabled(false);
        } else {
            setButtonDisabled(true);
        }
    }, [productName]);

    useEffect(() => {
        const fetchData = async () => {
            const pMeasures = await getProductMeasures();
            await getProductSections();

            if (pMeasures) {
                setProductMeasure(pMeasures[0]);
            }

            if (sections) {
                setProductSection(sections[0]);
            }
        };

        fetchData();
    }, []);

    const getProductMeasures = async () => {
        try {
            const responseData = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET');
            setMeasures(responseData);
            return responseData;
        } catch (error) {
            console.log(error);
        }
    };

    const getProductSections = async () => {
        try {
            const responseData = await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'GET');
            setSections(responseData);
        } catch (error) {
            console.log(error);
        }
    };

    const createProduct = async () => {

        const data = { name: productName, productSectionId: productSection.id, productMeasureId: productMeasure.id };

        await makeRequest(ApiEndpoints.Product_Endpoint, 'POST', data);

        onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={createProduct} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Create} titleModal={ModalConsts.NewProduct} modalBody={
                <div className={styles.inputRow}>
                    <CustomInputApp className="app-form mb-0"
                        type={InputType.Input}
                        placeholder={PlaceholderConsts.AddProductName}
                        label={LabelConsts.ProductName}
                        value={productName}
                        onChange={(e) => setProductName(e.target.value)}
                        isRequired={true} />

                    <ProductSectionSelector
                        selectedValue={productSection}
                        selectedValueChanged={(e) => setProductSection(e)}
                        isViewList={true} />

                    <ProductMeasureSelector
                        selectedValue={productMeasure}
                        selectedValueChanged={(e) => setProductMeasure(e)} />
                </div>} />
    );
};

ProductModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func
};

export default ProductModal;