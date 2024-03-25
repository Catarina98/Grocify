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

const ShoppingListModal = ({ onClose, onConfirm, sectionToUpdate }) => {
    const [isButtonDisabled, setButtonDisabled] = useState(true);

    const [listName, setListName] = useState(sectionToUpdate != null ? sectionToUpdate.name : '');

    const { makeRequest } = useApiRequest();

    useEffect(() => {
        const isSectionEdited = sectionToUpdate && (listName !== sectionToUpdate.name);
        const areInputsValid = listName !== "";

        setButtonDisabled(!areInputsValid || (sectionToUpdate && !isSectionEdited));
    }, [listName]);
    
    const createList = async () => {

        const data = { name: listName };

        await makeRequest(ApiEndpoints.ShoppingList_Endpoint, 'POST', data);

        onConfirm();
    };

    const editList = async () => {

        //const data = { name: productSectionName, icon: productSectionIcon };

        //await makeRequest(ApiEndpoints.ProductSectionsId_Endpoint(sectionToUpdate.id), 'PUT', data);

        //onConfirm();
    };

    return (
        <BaseModal isOpen={true} onClose={onClose} onConfirm={sectionToUpdate ? editList : createList} isButtonDisabled={isButtonDisabled}
            buttonText={sectionToUpdate ? ButtonConsts.Update : ButtonConsts.Create}
            titleModal={sectionToUpdate ? ModalConsts.EditProductSection(sectionToUpdate.name) : ButtonConsts.NewList} modalBody={
            <div className={styles.inputRow}>
                    <CustomInputApp className="app-form mb-0"
                        type={InputType.Input}
                        placeholder={PlaceholderConsts.AddListName}
                        label={LabelConsts.ShoppingList}
                        value={listName}
                        onChange={(e) => setListName(e.target.value)}
                        isRequired={true} />
            </div>} />
    );
};

ShoppingListModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func,
    sectionToUpdate: PropTypes.object,
};

export default ShoppingListModal;