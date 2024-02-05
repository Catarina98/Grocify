import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

//Assets & Css
import CrossIcon from '../assets/cross-ic.svg';
import styles from './BaseModal.module.scss';

const BaseModal = ({ isOpen, onClose }) => {
    const toggleModal = () => {
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
                    <div className="title title--s weight--m">Change default Shopping List</div>

                    <div className="icon icon--w32 cursor-pointer" onClick={toggleModal}>
                        <ReactSVG className="react-svg" src={CrossIcon} />
                    </div>
                </div>
                
                <div className={styles.modalContent}>Your modal content goes here</div>

                <div className={styles.modalFooter}>
                    <button className="secondary-button btn--m">
                        Cancel
                    </button>

                    <button className="primary-button btn--m">
                        Update
                    </button>
                </div>
            </div>
        </div>
    );
};

BaseModal.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
};

export default BaseModal;