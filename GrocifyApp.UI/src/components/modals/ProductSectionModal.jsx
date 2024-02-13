import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';

//Internal components
import BaseModal from './BaseModal';
import CustomInputApp from '../CustomInputApp';
import SelectorDropdown from '../Dropdown/SelectorDropdown';
import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
import styles from './ProductSectionModal.module.scss';

//Consts
import { PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';

const DefaultList = ({ isOpen, onClose }) => {
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
    };

    return (
        <BaseModal isOpen={isOpen} onClose={onClose} onConfirm={createProductSection} isButtonDisabled={isButtonDisabled}
            buttonText={ButtonConsts.Create} titleModal={ModalConsts.NewProductSection} modalBody={
            <div className={styles.inputRow}>
                <CustomInputApp className="app-form mb-0"
                    type="input"
                    placeholder={PlaceholderConsts.AddSectionName}
                    label={LabelConsts.ProductSectionName}
                    value={productSectionName}
                        onChange={(e) => setProductSectionName(e.target.value)} />

                    <SelectorDropdown
                        selectedValue={productSectionIcon}
                        placeholder={"Placeholder"}
                        selectedValueChanged={(e) => setIcon(e)}
                        title={ModalConsts.IconSection}
                        contentClass={"Class"}
                        isIcon={true}
                        label={LabelConsts.ProductSectionIcon} />
            </div>} />
    );
};

DefaultList.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired
};

export default DefaultList;