import { useState, useEffect } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import CustomInput from '../CustomInput';

//Assets & Css
import CheckmarkIcon from '../../assets/checkmark.svg';
import styles from './UserPassword.module.scss';

//Consts
import { AuthConsts, PassRulesConsts } from '../../consts/ENConsts';

const UserPasswordForm = (props) => {
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [isValidInitial, setValidInitial] = useState(false);
    const [validationResults, setValidationResults] = useState({
        length: false,
        lowerUpper: false,
        numberCharacter: false,
        passwordMatch: false,
    });

    useEffect(() => {
        const lengthValid = password.length >= 8;
        const lowerUpperValid = /[a-z]/.test(password) && /[A-Z]/.test(password);
        const numberCharacterValid = /\d/.test(password) || /[!@#$%^&*(),.?":{}|<>]/.test(password);
        const passwordMatchValid = password != "" && confirmPassword === password;

        setValidationResults({
            length: lengthValid,
            lowerUpper: lowerUpperValid,
            numberCharacter: numberCharacterValid,
            passwordMatch: passwordMatchValid,
        });

        setValidInitial(lengthValid && lowerUpperValid && numberCharacterValid && passwordMatchValid);
    }, [password, confirmPassword]);
    
    useEffect(() => {
        props.onButtonDisableChanged({
            isValidInitial,
            password,
            confirmPassword,
        });
    }, [isValidInitial, password, confirmPassword, props]);

    return (
        <>
            <CustomInput 
                type="password"
                value={password}
                label={AuthConsts.Password}
                onChange={(e) => setPassword(e.target.value)} />

            <CustomInput
                type="password"
                value={confirmPassword}
                label={AuthConsts.ConfirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)} />

            <div id="errorslist" className={`${isValidInitial ? '' : 'invalid-initial'} errors-list`}>
                <div id="length" className={`${styles.errorRow} ${validationResults.length ? styles.valid : ""}`}>
                    <div className={styles.iconMT4 + " icon"}>
                        <ReactSVG className="react-svg" src={CheckmarkIcon} />
                    </div>
                    <span className="text text-left">{PassRulesConsts.PasswordLong}</span>
                </div>

                <div id="lowerupper" className={`${styles.errorRow} ${validationResults.lowerUpper ? styles.valid : ""}`}>
                    <div className={styles.iconMT4 + " icon"}>
                        <ReactSVG className="react-svg" src={CheckmarkIcon} />
                    </div>
                    <span className="text text-left">{PassRulesConsts.PassUpperLower}</span>
                </div>

                <div id="numbercharacter" className={`${styles.errorRow} ${validationResults.numberCharacter ? styles.valid : ""}`}>
                    <div className={styles.iconMT4 + " icon"}>
                        <ReactSVG className="react-svg" src={CheckmarkIcon} />
                    </div>
                    <span className="text text-left">{PassRulesConsts.PassSpecialCharacters}</span>
                </div>

                <div id="passwordmatch" className={`${styles.errorRow} ${validationResults.passwordMatch ? styles.valid : ""}`}>
                    <div className={styles.iconMT4 + " icon"}>
                        <ReactSVG className="react-svg" src={CheckmarkIcon} />
                    </div>
                    <span className="text text-left">{PassRulesConsts.PasswordMatch}</span>
                </div>
            </div>
        </>
    );
};

UserPasswordForm.propTypes = {
    onButtonDisableChanged: PropTypes.func.isRequired,
};

export default UserPasswordForm;
