import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Consts
import InputType from '../consts/InputType';

const CustomInputApp = ({ type, placeholder, value, onChange, label, className, icon, isRequired }) => {
    return (
        <div className={`input-box ${className}`}>
            {label && (
                <label className="input-label">
                    {label}

                    {isRequired && <span className="required-indicator">*</span>}
                </label>
            )}

            <div className="input-box-holder">
                {type == InputType.TextArea &&
                    <textarea type={type}
                        className="input-text"
                        required={isRequired}
                        placeholder={placeholder}
                        value={value}
                        onChange={onChange}
                        maxLength="500">
                    </textarea>
                }

                {type == InputType.Password &&
                    <div className="icon show-hide-icon" onClick="showHidePassword(@Id)">
                        <ReactSVG className="react-svg" src={icon} />
                        <div className="line"></div>
                    </div>
                }

                {type == InputType.Custom &&
                    value
                }

                {type == InputType.Input &&
                    <input
                        className="input-text"
                        type={type}
                        required={isRequired}
                        placeholder={placeholder}
                        value={value}
                        onChange={onChange}
                    />
                }

                {icon && (
                    <div className="icon">
                        <ReactSVG className="react-svg" src={icon} />
                    </div>
                )}

                {placeholder && (
                    <label className="input-placeholder">
                        {placeholder}

                        {isRequired && <span className="required-indicator">*</span>}
                    </label>
                )}
            </div >
        </div>
    );
};

CustomInputApp.propTypes = {
    type: PropTypes.string.isRequired,
    value: PropTypes.node.isRequired,
    onChange: PropTypes.func.isRequired,
    label: PropTypes.string.isRequired,
    placeholder: PropTypes.string,
    className: PropTypes.string,
    icon: PropTypes.string,
    isRequired: PropTypes.bool
};

export default CustomInputApp;