import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components

//Assets & Css
import BoxIcon from '../assets/box-ic.svg';
import PlusCircleIcon from '../assets/plus-circle-ic.svg';
import styles from './EmptyState.module.scss';

//Consts
import { EmptyStateConsts } from '../consts/ENConsts';

const EmptyState = ({ entity, onCreate, buttonText }) => {
    return (
        <div className={styles.emptyStateContainer}>
            <div className="icon">
                <ReactSVG className="react-svg icon-color--n600" src={BoxIcon} />
            </div>

            <div className={styles.emptyStateText}>
                <div className="text--l">
                    {EmptyStateConsts.Title(entity)}
                </div>

                <div className="text--xs">
                    {EmptyStateConsts.Description(entity)}
                </div>
            </div>

            <button className="primary-button btn--l" onClick={onCreate}>
                <ReactSVG className="react-svg icon-color--n100" src={PlusCircleIcon} />

                {buttonText}
            </button>
        </div>
    );
};

EmptyState.propTypes = {
    entity: PropTypes.string.isRequired,
    onCreate: PropTypes.func,
    buttonText: PropTypes.string
};

export default EmptyState;