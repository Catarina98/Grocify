//import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Internal components
import BaseModal from './BaseModal';
//import useApiRequest from '../../hooks/useApiRequests';

//Assets & Css
//import styles from './MoreOptionsModal.module.scss';
import EditIcon from '../../assets/edit-ic.svg';
import TrashIcon from '../../assets/trash-ic.svg';

//Consts
import { ModalConsts, EntityConsts } from '../../consts/ENConsts';
//import ApiEndpoints from '../../consts/ApiEndpoints';

const MoreOptionsModal = ({ onClose }) => {
    //const [isButtonDisabled, setButtonDisabled] = useState(true);
    //const [productSectionName, setProductSectionName] = useState("");
    //const [productSectionIcon, setProductSectionIcon] = useState('Home');
    //const { makeRequest } = useApiRequest();

    //useEffect(() => {
    //    if (productSectionName !== "" && productSectionIcon !== "") {
    //        setButtonDisabled(false);
    //    } else {
    //        setButtonDisabled(true);
    //    }
    //}, [productSectionIcon, productSectionName]);

    //const createProductSection = async () => {

    //    const data = { name: productSectionName, icon: productSectionIcon };

    //    await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'POST', data);

    //    onConfirm();
    //};

    return (
        <BaseModal isOpen={true} onClose={onClose} titleModal={ModalConsts.MoreOptions} modalBody={
            <div className="more-options-content">
                <div className="more-options-row cursor-pointer">
                    <div className="icon">
                        <ReactSVG className="react-svg icon-color--n600" src={EditIcon} />
                    </div>

                    <div className="text">
                        {ModalConsts.EditEntity(EntityConsts.ProductSection)}
                    </div>
                </div>

                <div className="more-options-row cursor-pointer color-r300">
                    <div className="icon">
                        <ReactSVG className="react-svg icon-color--n600" src={TrashIcon} />
                    </div>

                    <div className="text">
                        {ModalConsts.DeleteEntity(EntityConsts.ProductSection)}
                    </div>
                </div>
            </div>} />
    );
};

MoreOptionsModal.propTypes = {
    onClose: PropTypes.func.isRequired
};

export default MoreOptionsModal;