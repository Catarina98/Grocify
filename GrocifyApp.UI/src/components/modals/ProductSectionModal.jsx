import { useState } from 'react';
import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Internal components
import BaseModal from './BaseModal';
import CustomInputApp from '../CustomInputApp';
import SelectorDropdown from '../Dropdown/SelectorDropdown';

//Assets & Css
import styles from './ProductSectionModal.module.scss';

//Consts
import { GenericConsts, PlaceholderConsts, LabelConsts, ButtonConsts, ModalConsts } from '../../consts/ENConsts';
import ApiEndpoints from '../../consts/ApiEndpoints';
import IconsConsts from '../../consts/IconsConsts';

const DefaultList = ({ isOpen, onClose }) => {
    const token = localStorage.getItem('token');
    const [productSectionData, setProductSectionData] = useState([]);
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const [productSectionName, setProductSectionName] = useState("");
    const [productSectionIcon, setProductSectionIcon] = useState(IconsConsts['Home']);
    
    //const handleSetDefaultList = (shoppingList) => {
    //    setDefaultShoppingList(shoppingList);
    //    setButtonDisabled(shoppingList.id === oldDefaultShoppingList?.id);
    //}
    
    const createProductSection = async () => {
        try {
            const response = await fetch(ApiEndpoints.DefaultShoppingList_Endpoint(defaultShoppingList.id), {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${token}`
                }
            });

            if (response.ok) {
                console.log("updated");
            } else {
                const errorData = await response.json();
                console.log(errorData.errors[0]);
            }
        } catch (error) {
            console.log(GenericConsts.Error);
        }
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
                        selectedValueChanged={(e) => setProductSectionName(e.target.value)}
                        title={"Title"}
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

                    //<DropdownButton text={GenericConsts.Button.Archive} icon={IconsShared.TopicPage.Archive} onClick={() => ConfirmModal!.ArchiveRestore(true)} />

                    //        <DropdownButton customClass={CssConst.DeleteBtn} text={GenericConsts.Delete} icon={IconsConst.Generic.Trash} onClick={ConfirmModal!.Delete} />