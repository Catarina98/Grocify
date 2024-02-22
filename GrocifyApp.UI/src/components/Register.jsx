import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';

//Internal components
import CustomInput from './CustomInput';
import UserPassword from './UserPassword';
import useApiRequest from '../hooks/useApiRequests';

//Assets & Css
import ReactLogo from '../assets/logo_with_text.svg';
import ArrowIcon from '../assets/arrow-ic.svg';
import ApiEndpoints from '../consts/ApiEndpoints';
import stylesAuth from './Auth.module.scss';
import styles from './Register.module.scss';

//Consts
import { AuthConsts, ButtonConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';
import { useEffect } from 'react';

const RegisterForm = () => {
    const navigate = useNavigate();
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [showPart1, setShowPart1] = useState(true);
    const [errorMessage, setErrorMessage] = useState('');
    const [isButtonDisabled, setButtonDisabled] = useState(true);
    const [firstTime, setFirstTime] = useState(true);
    const { makeRequest, isLoading } = useApiRequest();

    useEffect(() => {
        if (firstTime) {
            setFirstTime(false);
            return;
        }

        const isValidName = name.trim() !== '';
        const isValidEmail = /^\S+@\S+\.\S+$/.test(email);

        if (!isValidName) {
            setErrorMessage(AuthConsts.NameError);
            setButtonDisabled(true);
        } else if (!isValidEmail) {
            setErrorMessage(AuthConsts.EmailError);
            setButtonDisabled(true);
        } else {
            setErrorMessage('');
            setButtonDisabled(false);
        }

    }, [name, email]);

    const handleButtonDisableChange = (data) => {
        const { isValidInitial, password, confirmPassword } = data;
        setButtonDisabled(!isValidInitial);
        setPassword(password);
        setConfirmPassword(confirmPassword);
    };

    const handleRegister = async () => {
        const data = { name, email, password, confirmPassword };

        try {
            const parsedT = await makeRequest(ApiEndpoints.Register_Endpoint, 'POST', data);

            localStorage.setItem('token', parsedT.token);

            console.log('Register successful');

            navigate(AppRoutes.ShoppingLists);
        } catch (error) {
            setErrorMessage(error.message);
        }
    };

    return (
        <div className={stylesAuth.auth}>
            <ReactSVG className="react-svg" src={ReactLogo} />
            <form className={stylesAuth.inputForm + " input-form"}>
                <div className="title title--xl">{AuthConsts.SignUp}</div>
                <p className={stylesAuth.authDesc + " text color--n500"}>{AuthConsts.EnterDetails}</p>
                <p id="error" className="text error">{errorMessage}</p>

                {showPart1 ? (
                    <>
                        <CustomInput className="mt-3"
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
                    <button type="button" disabled={isButtonDisabled} className={stylesAuth.btn + ' primary-button btn--xl'} onClick={() => setShowPart1(false)}>
                        <span>{ButtonConsts.Proceed}</span>
                    </button>
                )}

                {!showPart1 && (
                    <div className={styles.buttons}>
                        <button type="button" className={stylesAuth.btn + ' secondary-button btn--xl'} onClick={() => setShowPart1(true)}>
                            <span>{ButtonConsts.Back}</span>
                        </button>

                        <button type="button" disabled={isButtonDisabled} className={`${stylesAuth.btn} primary-button btn--xl ${isLoading ? 'loading' : ''}`} onClick={handleRegister}>
                            <span>{AuthConsts.SignUp}</span>
                            <div className="loading-button white"></div>
                        </button>
                    </div>
                )}
            </form>

            {showPart1 && (
                <div className={stylesAuth.formFooter}>
                    <div className="text color--n500">{AuthConsts.AlreadyHaveAccount}</div>
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
