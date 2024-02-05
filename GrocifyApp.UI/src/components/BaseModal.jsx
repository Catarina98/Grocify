import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Assets & Css
import CrossIcon from '../assets/cross-ic.svg';
import styles from './BaseModal.module.scss';

//Consts
import { ButtonConsts, ModalConsts } from '../consts/ENConsts';

const BaseModal = ({ isOpen, onClose, children, buttonConfirm }) => {
    const toggleModal = () => {
        onClose(!isOpen);
    };

    const confirmModal = () => {
        buttonConfirm();
        onClose(!isOpen);
    };

    return (
        <div>
            {isOpen && (
                <div className={styles.modalBackdrop} onClick={toggleModal}>
                </div>
            )}
            <div className={`${styles.modalMobile} ${isOpen ? styles.open : ''}`}>
                <div className={styles.modalHeader}>
                    <div className="title title--s weight--m">{ModalConsts.DefaultShoppingList}</div>

                    <div className="icon icon--w32 cursor-pointer" onClick={toggleModal}>
                        <ReactSVG className="react-svg" src={CrossIcon} />
                    </div>
                </div>
                
                <div className={styles.modalContent}>{children}</div>

                <div className={styles.modalFooter}>
                    <button className="secondary-button btn--m" onClick={toggleModal}>
                        {ButtonConsts.Cancel}
                    </button>

                    <button className="primary-button btn--m" onClick={confirmModal}>
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
    children: PropTypes.node,
    buttonConfirm: PropTypes.func.isRequired,
};

export default BaseModal;