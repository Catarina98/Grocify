import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Assets & Css
import CrossIcon from '../../assets/cross-ic.svg';
import styles from './BaseModal.module.scss';

//Consts
import { ButtonConsts } from '../../consts/ENConsts';

const BaseModal = ({ isOpen, onClose, titleModal, modalBody, onConfirm, isButtonDisabled, buttonText, noFooter, isConfirmModal }) => {
    const toggleModal = () => {
        onClose(!isOpen);
    };

    const confirmModal = () => {
        onConfirm();
        onClose(!isOpen);
    };

    return (
        <div className = {`${isConfirmModal ? styles.confirmModal : ""}`}>
            {isOpen && (
                <>
                    <div className={styles.modalBackdrop} onClick={toggleModal}></div>
            
                    <div className={`${styles.modalMobile + " modal-mobile"} ${isOpen ? styles.open : ''} ${noFooter ? styles.noFooter : ''}`}>
                        <div className={styles.modalHeader + " modal-header"}>
                            <div className={"title title--s weight--m " + styles.title} dangerouslySetInnerHTML={{ __html: titleModal }}/>

                            <div className={"icon icon--w32 cursor-pointer " + styles.toggleModal} onClick={toggleModal}>
                                <ReactSVG className="react-svg icon-color--n600" src={CrossIcon} />
                            </div>
                        </div>
                
                        {modalBody && (<div className={`${styles.modalContent} ${noFooter ? styles.noFooter : ''}`}>{modalBody}</div>)}

                        {!noFooter && <div className={styles.modalFooter + " modal-footer"}>
                            <button className="secondary-button btn--m" onClick={toggleModal}>
                                {ButtonConsts.Cancel}
                            </button>

                            <button className={styles.confirmBtn + " primary-button btn--m"} onClick={confirmModal} disabled={isButtonDisabled}>
                                {buttonText != null && buttonText != "" ? buttonText : isConfirmModal ? ButtonConsts.Delete : ButtonConsts.Confirm}
                            </button>
                        </div> }                
                    </div>
                </>
            )
            }
        </div>
    );
};

BaseModal.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    titleModal: PropTypes.string.isRequired,
    modalBody: PropTypes.node,
    onConfirm: PropTypes.func,
    isButtonDisabled: PropTypes.bool,
    buttonText: PropTypes.string,
    noFooter: PropTypes.bool,
    isConfirmModal: PropTypes.bool
};

export default BaseModal;