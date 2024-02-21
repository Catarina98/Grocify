import PropTypes from 'prop-types';

//Internal components
import BaseModal from './BaseModal';

//Consts
import { ModalConsts } from '../../consts/ENConsts';

const MoreOptionsModal = ({ content, onClose }) => {

    return (
        <BaseModal isOpen={true} onClose={onClose} titleModal={ModalConsts.MoreOptions} noFooter={true} modalBody={
            <div className="more-options-content">
                {content}
            </div>
        } />
    );
};

MoreOptionsModal.propTypes = {
    content: PropTypes.node.isRequired,
    onClose: PropTypes.func.isRequired
};

export default MoreOptionsModal;