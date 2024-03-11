import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from '../BaseModal';
import CustomInputApp from '../../CustomInputApp';
import ProductSectionSelector from '../../Products/ProductSectionsSelector';
import ProductMeasureSelector from '../../Products/ProductMeasuresSelector';
import useApiRequest from '../../../hooks/useApiRequests';

//Consts
import { PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../../consts/ENConsts';
import InputType from '../../../consts/InputType';
import ApiEndpoints from '../../../consts/ApiEndpoints';

const ProductModal = ({ onClose, onConfirm, productSections, productToUpdate }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [productName, setProductName] = useState(productToUpdate != null ? productToUpdate.name : '');
    const [productSection, setProductSection] = useState(productToUpdate != null ? productSections.find(s => s.id === productToUpdate.productSectionId) : productSections[0]);
    const [productMeasure, setProductMeasure] = useState({});

    const [measures, setMeasures] = useState([]);

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        const isProductEdited = productToUpdate &&
            (productName !== productToUpdate.name || productSection.id !== productToUpdate.productSectionId || productMeasure.id !== productToUpdate.productMeasureId);
        const areInputsValid = productName !== "";

        setButtonDisabled(!areInputsValid || (productToUpdate && !isProductEdited));
    }, [productName, productSection, productMeasure]);

    useEffect(() => {
        const fetchData = async () => {
            const pMeasures = await getProductMeasures();

            if (pMeasures) {
                if (productToUpdate) {
                    setProductMeasure(pMeasures.find(m => m.id === productToUpdate.productMeasureId));
                }
                else {
                    setProductMeasure(pMeasures[0]);
                }
            }
        };

        fetchData();
    }, []);

    const getProductMeasures = async () => {
        const responseData = await makeRequest(ApiEndpoints.ProductMeasures_Endpoint, 'GET');
        setMeasures(responseData);

        return responseData;
    };

    const createProduct = async () => {
        const section = productSections.find(s => s.id === productSection.id);
        const measure = measures.find(s => s.id === productMeasure.id);

        const data = { name: productName, productSectionId: section.id, productMeasureId: measure.id };

        try {
            await makeRequest(ApiEndpoints.Products_Endpoint, 'POST', data);
        } catch (error) {
            console.log(error); //todo: add error message for user
        }

        onConfirm(data.productSectionId);
    };

    const editProduct = async () => {
        const data = { name: productName, productSectionId: productSection.id, productMeasureId: productMeasure.id };

        try {
            await makeRequest(ApiEndpoints.ProductId_Endpoint(productToUpdate.id), 'PUT', data);
        } catch (error) {
            console.log(error); //todo: add error message for user
        }

        onConfirm(data.productSectionId);
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={productToUpdate ? editProduct : createProduct} isButtonDisabled={isButtonDisabled}
            buttonText={productToUpdate ? ButtonConsts.Update : ButtonConsts.Create}
            titleModal={productToUpdate ? ModalConsts.EditProduct(productToUpdate.name) : ModalConsts.NewProduct} modalBody={
                <>
                    <CustomInputApp className="app-form mb-0"
                        type={InputType.Input}
                        placeholder={PlaceholderConsts.AddProductName}
                        label={LabelConsts.ProductName}
                        value={productName}
                        onChange={(e) => setProductName(e.target.value)}
                        isRequired={true} />

                    <ProductSectionSelector
                        selectedValue={{ id: productSection.id, name: productSection.name, icon: productSection.icon }}
                        selectedValueChanged={(e) => setProductSection(e)}
                        productSections={productSections}
                        isViewList={true} />

                    {productMeasure.name && (<ProductMeasureSelector
                        selectedValue={{ id: productMeasure.id, name: productMeasure.name }}
                        selectedValueChanged={(e) => setProductMeasure(e)}
                        productMeasures={measures} />)}
                </>} />
    );
};

ProductModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    productSections: PropTypes.array.isRequired,
    onConfirm: PropTypes.func,
    productToUpdate: PropTypes.object
};

export default ProductModal;