import PropTypes from 'prop-types';
import { ReactSVG } from 'react-svg';

const MoreOptionsButton = ({ icon, text, classColor, onClick }) => {

    return (
        <div className={"more-options-row cursor-pointer " + classColor} onClick={onClick}>
            <div className="icon">
                <ReactSVG className="react-svg icon-color--n600" src={icon} />
            </div>

            <div className="text">
                {text}
            </div>
        </div>
    );
};

MoreOptionsButton.propTypes = {
    icon: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired,
    classColor: PropTypes.string,
    onClick: PropTypes.func
};

export default MoreOptionsButton;