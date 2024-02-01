import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';

//Internal components
import CustomInput from './CustomInput';
import UserPassword from './UserPassword';

//Assets & Css
import ReactLogo from '../assets/logo_with_text.svg';
import ArrowIcon from '../assets/arrow-ic.svg';
import ApiEndpoints from '../consts/ApiEndpoints';
import styles from './Register.module.scss';

//Consts
import { GenericConsts, AuthConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';

const RegisterForm = () => {
    const navigate = useNavigate();
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [showPart1, setShowPart1] = useState(true);
    const [errorMessage, setErrorMessage] = useState('');

    const isValidName = name.trim() !== '';
    const isValidEmail = /^\S+@\S+\.\S+$/.test(email);
    const [isButtonDisabled, setButtonDisabled] = useState(false);
    
    const handleProceed = () => { //instead of set the error, we could disable the button to proceed. what do you think?
        if (!isValidName) {
            setErrorMessage("Please enter your name.");
        } else if (!isValidEmail) {
            setErrorMessage("Please enter a valid email address.");
        } else {
            setShowPart1(false);
            setErrorMessage('');
        }
    };

    const handleButtonDisableChange = (data) => {
        const { isValidInitial, password, confirmPassword } = data;
        setButtonDisabled(!isValidInitial);
        setPassword(password);
        setConfirmPassword(confirmPassword);
    };
    
    const handleRegister = async (event) => {
        const data = { name, email, password, confirmPassword };

        const registerButton = event.target;

        registerButton.classList.add("loading");

        try {
            const response = await fetch(ApiEndpoints.Register_Endpoint, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            });

            if (response.ok) {
                console.log('Register successful');

                navigate('/');
            } else {
                const errorData = await response.json();
                console.error('Register failed', errorData.errors[0]);

                setErrorMessage(errorData.errors[0]);
            }
        } catch (error) {
            console.error('Error during register', error);

            setErrorMessage(GenericConsts.Error);
        } finally {
            registerButton.classList.remove("loading");
        }
    };

    return (
        <div className={styles.login}>
            <ReactSVG className="react-svg" src={ReactLogo} />
            <form className={styles.inputForm + " input-form"}>
                <div className="title title--xl">{AuthConsts.SignUp}</div>
                <p className={styles.loginDesc + " text color-n500"}>{AuthConsts.EnterDetails}</p>
                <p id="error" className="text error">{errorMessage}</p>

                {showPart1 ? (
                    <>
                        <CustomInput className ="mt-3"
                            type="text"
                            value={name}
                            label={AuthConsts.Name}
                            onChange={(e) => setName(e.target.value)} />

                        <CustomInput className="mt-3"
                            type="email"
                            value={email}
                            label={AuthConsts.Email}
                            onChange={(e) => setEmail(e.target.value)} />
                    </>
                ) : (
                        <UserPassword onButtonDisableChanged={(data) => handleButtonDisableChange(data)} />
                )}

                {showPart1 && (
                    <button type="button" className={styles.btn + ' primary-button btn--xl'} onClick={handleProceed}>
                        <span>Proceed</span>
                    </button>
                )}

                {!showPart1 && (
                    <div className={styles.buttons}>
                        <button type="button" className={styles.btn + ' secondary-button btn--xl'} onClick={() => setShowPart1(true)}>
                            <span>Back</span>
                        </button>

                        <button type="button" disabled={isButtonDisabled} className={styles.btn + " primary-button btn--xl"} onClick={handleRegister}>
                            <span>{AuthConsts.SignUp}</span>
                            <div className="loading-button white"></div>
                        </button>
                    </div>
                )}
            </form>

            {showPart1 && (
                <div className={styles.formFooter}>
                    <div className="text color-n500">{AuthConsts.AlreadyHaveAccount}</div>
                    <a className="subtle-button" href={AppRoutes.Login}>
                        <span className="btn-text btn--m">{AuthConsts.SignIn}</span>
                        <div className="btn-icon">
                            <ReactSVG src={ArrowIcon} className="arrow-right" />
                        </div>
                    </a>
                </div>
            )}
            
        </div>
    );
};

export default RegisterForm;
