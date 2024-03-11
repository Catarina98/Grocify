import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Assets & Css
import CrossIcon from '../assets/cross-ic.svg';
import AlertCircleIcon from '../assets/alert-circle.svg';

const Alert = ({ message, onClose }) => {
    return (
        <div className="alert-error">
            <div className="alert-info text">
                <ReactSVG className="react-svg icon-color--r300" src={AlertCircleIcon} />

                {message}
            </div>

            <div className="icon cursor-pointer" onClick={onClose}>
                <ReactSVG className="react-svg icon-color--n600" src={CrossIcon} />
            </div>
        </div>
    );
};

Alert.propTypes = {
    message: PropTypes.string.isRequired,
    onClose: PropTypes.func.isRequired
};

export default Alert;