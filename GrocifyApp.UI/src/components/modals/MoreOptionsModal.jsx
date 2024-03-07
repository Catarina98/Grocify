import PropTypes from 'prop-types';

//Internal components
import BaseModal from './BaseModal';
import MoreOptionsButton from './MoreOptionsButton';

//Assets & Css
import EditIcon from '../../assets/edit-ic.svg';
import TrashIcon from '../../assets/trash-ic.svg';

//Consts
import { ModalConsts } from '../../consts/ENConsts';

const MoreOptionsModal = ({ onClose, onEdit, onDelete, content }) => {

    return (
        <BaseModal isOpen={true} onClose={onClose} titleModal={ModalConsts.MoreOptions} noFooter={true} modalBody={
            <div className="more-options-content">
                {onEdit && (
                    <MoreOptionsButton icon={EditIcon} text={onEdit.text}
                        onClick={onEdit.method} /> )}
                
                {onDelete && (
                    <MoreOptionsButton icon={TrashIcon} text={onDelete.text}
                        classColor="color-r300" onClick={onDelete.method} />)}
                
                {content}
            </div>
        } />
    );
};

MoreOptionsModal.propTypes = {
    onClose: PropTypes.func.isRequired,
    onEdit: PropTypes.object,
    onDelete: PropTypes.object,
    content: PropTypes.node
};

export default MoreOptionsModal;