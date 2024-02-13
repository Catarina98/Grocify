import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Assets & Css
import CrossIcon from '../../assets/cross-ic.svg';
import styles from './BaseModal.module.scss';

//Consts
import { ButtonConsts } from '../../consts/ENConsts';

const BaseModal = ({ isOpen, onClose, modalBody, onConfirm, isButtonDisabled, buttonText, titleModal, noFooter }) => {
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
            <div className={`${styles.modalMobile + " modal-mobile"} ${isOpen ? styles.open : ''} ${noFooter ? styles.noFooter : ''}`}>
                <div className={styles.modalHeader + " modal-header"}>
                    <div className="title title--s weight--m">{titleModal}</div>

                    <div className="icon icon--w32 cursor-pointer" onClick={toggleModal}>
                        <ReactSVG className="react-svg" src={CrossIcon} />
                    </div>
                </div>
                
                <div className={styles.modalContent}>{modalBody}</div>

                {!noFooter && <div className={styles.modalFooter + " modal-footer"}>
                    <button className="secondary-button btn--m" onClick={toggleModal}>
                        {ButtonConsts.Cancel}
                    </button>

                    <button className="primary-button btn--m" onClick={confirmModal} disabled={isButtonDisabled}>
                        {buttonText != null && buttonText != "" ? buttonText : ButtonConsts.Confirm}
                    </button>
                </div> }                
            </div>
        </div>
    );
};

BaseModal.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    modalBody: PropTypes.node,
    onConfirm: PropTypes.func,
    isButtonDisabled: PropTypes.bool,
    buttonText: PropTypes.string,
    titleModal: PropTypes.string.isRequired,
    noFooter: PropTypes.bool,
};

export default BaseModal;