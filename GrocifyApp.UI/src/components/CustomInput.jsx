import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

const CustomInput = ({ type, placeholder, value, onChange, label, className, icon }) => {
    return (
        <div className={`input-box ${className}`}>
            <input
                className="input-text"
                type={type}
                placeholder={placeholder}
                value={value}
                onChange={onChange}
            />

            {icon && (
                <div className="icon">
                    <ReactSVG className="react-svg" src={icon} />
                </div>
            )}

            <label className="input-placeholder">{label}</label>
        </div>
    );
};

CustomInput.propTypes = {
    type: PropTypes.string.isRequired,
    placeholder: PropTypes.string,
    value: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    label: PropTypes.string.isRequired,
    className: PropTypes.string,
    icon: PropTypes.string
};

export default CustomInput;
