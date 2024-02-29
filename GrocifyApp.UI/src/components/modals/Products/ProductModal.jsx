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

const ProductModal = ({ onClose, onConfirm, productSections }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [productName, setProductName] = useState("");
    const [productSection, setProductSection] = useState(productSections[0]);
    const [productMeasure, setProductMeasure] = useState([]);

    const [measures, setMeasures] = useState([]);

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

            if (pMeasures) {
                setProductMeasure(pMeasures[0]);
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

        const data = { name: productName, productSectionId: section.id, productSection: section, productMeasureId: measure.id, productMeasure: measure };
                
        try {
            await makeRequest(ApiEndpoints.Products_Endpoint, 'POST', data);
        } catch (error) {
            console.log(error); //todo: add error message for user
        }

        onConfirm(data.productSectionId);
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={createProduct} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Create} titleModal={ModalConsts.NewProduct} modalBody={
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
    onConfirm: PropTypes.func
};

export default ProductModal;