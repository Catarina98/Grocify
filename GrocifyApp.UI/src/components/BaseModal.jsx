import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Assets & Css
import CrossIcon from '../assets/cross-ic.svg';
import styles from './BaseModal.module.scss';

//Consts
import { ButtonConsts, ModalConsts } from '../consts/ENConsts';

const BaseModal = ({ isOpen, onClose, modalBody, onConfirm, isButtonDisabled }) => {
    const toggleModal = () => {
        onClose(!isOpen);
    };

    const confirmModal = () => {
        onConfirm();
        onClose(!isOpen);
    };

    return (
        <div>
            {isOpen && (
                <div className={styles.modalBackdrop} onClick={toggleModal}>
                </div>
            )}
            <div className={`${styles.modalMobile + " modal-mobile"} ${isOpen ? styles.open : ''}`}>
                <div className={styles.modalHeader + " modal-header"}>
                    <div className="title title--s weight--m">{ModalConsts.DefaultShoppingList}</div>

                    <div className="icon icon--w32 cursor-pointer" onClick={toggleModal}>
                        <ReactSVG className="react-svg" src={CrossIcon} />
                    </div>
                </div>
                
                <div className={styles.modalContent}>{modalBody}</div>

                <div className={styles.modalFooter + " modal-footer"}>
                    <button className="secondary-button btn--m" onClick={toggleModal}>
                        {ButtonConsts.Cancel}
                    </button>

                    <button className="primary-button btn--m" onClick={confirmModal} disabled={isButtonDisabled}>
                        {ButtonConsts.Update}
                    </button>
                </div>
            </div>
        </div>
    );
};

BaseModal.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    modalBody: PropTypes.node,
    onConfirm: PropTypes.func.isRequired,
    isButtonDisabled: PropTypes.bool,
};

export default BaseModal;