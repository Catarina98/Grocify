import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Assets & Css
import CrossIcon from '../assets/cross-ic.svg';
import styles from './BaseModal.module.scss';

//Consts
import { ButtonConsts, ModalConsts } from '../consts/ENConsts';

const BaseModal = ({ title, isOpen, onClose, modalBody, onConfirm, isButtonDisabled, isConfirmModal }) => {
    const toggleModal = () => {
        onClose(!isOpen);
    };

    const confirmModal = () => {
        onConfirm();
        onClose(!isOpen);
    };

    return (
        <div className={`${isConfirmModal ? styles.confirmModal : ""}`}>
            {isOpen && (
                <div className={styles.modalBackdrop} onClick={toggleModal}>
                </div>
            )}
            <div className={`${styles.modalMobile + " modal-mobile"} ${isOpen ? styles.open : ''}`}>
                <div className={styles.modalHeader + " modal-header"}>
                    <div className={"title title--s weight--m " + styles.title}>{title}</div>

                    <div className={"icon icon--w32 cursor-pointer " + styles.toggleModal} onClick={toggleModal}>
                        <ReactSVG className="react-svg" src={CrossIcon} />
                    </div>
                </div>

                {modalBody && (<div className={styles.modalContent}>{modalBody}</div>)}                

                <div className={styles.modalFooter + " modal-footer"}>
                    <button className="secondary-button btn--m" onClick={toggleModal}>
                        {ButtonConsts.Cancel}
                    </button>

                    <button className={styles.confirmBtn + " primary-button btn--m"} onClick={confirmModal} disabled={isButtonDisabled}>
                        {isConfirmModal ? ButtonConsts.Delete : ButtonConsts.Update}
                    </button>
                </div>
            </div>
        </div>
    );
};

BaseModal.propTypes = {
    title: PropTypes.string,
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    modalBody: PropTypes.node,
    onConfirm: PropTypes.func.isRequired,
    isButtonDisabled: PropTypes.bool,
    isConfirmModal: PropTypes.bool,
};

export default BaseModal;