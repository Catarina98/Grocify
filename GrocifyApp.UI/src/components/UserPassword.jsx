import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';

//Internal components
import CustomInput from './CustomInput';

//Assets & Css
import CheckmarkIcon from '../assets/checkmark.svg';
import styles from './UserPassword.module.scss';

//Consts
import { AuthConsts } from '../consts/ENConsts';
//import AppRoutes from '../consts/AppRoutes';

const UserPasswordForm = () => {
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [isValidInitial, setValidInitial] = useState(false);

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

            <div id="errorslist" className={`${isValidInitial ? '' : 'invalid-initial'} errors-list`}> {/*@(_firstInputChanged ? string.Empty : "init")*/}
                <div id="length" className={styles.errorRow}>
                    <div className={styles.iconMT4 + " icon--w16"}>
                        <ReactSVG className="react-svg color-n300" src={CheckmarkIcon} />
                    </div>
                    
                    <span className="text text-left">
                        Your password must be at least 8 characters long
                    </span>
                </div>
                <div id="lowerupper" className={styles.errorRow}>
                    <div className={styles.iconMT4 + " icon--w16"}>
                        <ReactSVG className="react-svg color-n300" src={CheckmarkIcon} />
                    </div>

                    <span className="text text-left">Must contain both uppercase and lowercase letters</span>
                </div>
                <div id="numbercharacter" className={styles.errorRow}>
                    <div className={styles.iconMT4 + " icon--w16"}>
                        <ReactSVG className="react-svg color-n300" src={CheckmarkIcon} />
                    </div>

                    <span className="text text-left">Must contain at least one number or special character</span>
                </div>
                <div id="passwordmatch" className={styles.errorRow}>
                    <div className={styles.iconMT4 + " icon--w16"}>
                        <ReactSVG className="react-svg color-n300" src={CheckmarkIcon} />
                    </div>

                    <span className="text text-left">Passwords must match</span>
                </div>
            </div >
        </>
    );
};

export default UserPasswordForm;
