import PropTypes from 'prop-types';

const CustomInput = ({ type, placeholder, value, onChange, label, className }) => {
    return (
        <div className={`input-box ${className}`}>
            <input
                className="input-text"
                type={type}
                placeholder={placeholder}
                value={value}
                onChange={onChange}
            />
            <label className="input-placeholder">{label}</label>
        </div>
    );
};

CustomInput.propTypes = {
    type: PropTypes.string.isRequired,
    placeholder: PropTypes.string.isRequired,
    value: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    label: PropTypes.string.isRequired,
    className: PropTypes.string
};

export default CustomInput;
