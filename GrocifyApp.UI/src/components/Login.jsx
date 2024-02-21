import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components
import CustomInput from './CustomInput';
import useApiRequest from '../hooks/useApiRequests';

//Assets & Css
import ReactLogo from '../assets/logo_with_text.svg';
import ArrowIcon from '../assets/arrow-ic.svg';
import ApiEndpoints from '../consts/ApiEndpoints';
import styles from './Auth.module.scss';

//Consts
import { GenericConsts, AuthConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';

const LoginForm = (props) => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const { makeRequest, isLoading } = useApiRequest();

    const handleLogin = async () => {
        const data = { email, password };

        try {
            const userLogged = await makeRequest(ApiEndpoints.Login_Endpoint, 'POST', data);

            localStorage.setItem('token', userLogged.token);
            localStorage.setItem('userId', userLogged.userId);
            localStorage.setItem('isDarkMode', userLogged.isDarkMode);

            console.log('Login successful');

            props.onDarkModeChange(userLogged.isDarkMode);

            navigate('/');
        } catch (error) {
            setErrorMessage(GenericConsts.Error);
        }
    };

    return (
        <div className={styles.auth}>
            <ReactSVG className="react-svg" src={ReactLogo} />
            <form className={styles.inputForm + " input-form"}>
                <div className="title title--xl">{AuthConsts.SignIn}</div>
                <p className={styles.authDesc + " text color--n500"}>{AuthConsts.EnterDetails}</p>
                <p id="error" className="text error">{errorMessage}</p>


                <CustomInput className ="mt-3"
                    type="email"
                    placeholder={AuthConsts.EmailPlaceholer}
                    value={email}
                    label={AuthConsts.Email}
                    onChange={(e) => setEmail(e.target.value)} />

                <CustomInput
                    type="password"
                    placeholder={AuthConsts.PasswordPlaceholer}
                    value={password}
                    label={AuthConsts.Password}
                    onChange={(e) => setPassword(e.target.value)} />

                <button type="button" className={`${styles.btn} primary-button btn--xl ${isLoading ? 'loading' : ''}`} onClick={handleLogin}>
                    <span>{AuthConsts.SignIn}</span>
                    <div className="loading-button white"></div>
                </button>
            </form>

            <div className={styles.formFooter}>
                <div className="text color--n500">{AuthConsts.HaveAccount}</div>
                <a className="subtle-button" href={AppRoutes.Register}>
                    <span className="btn-text btn--m">{AuthConsts.SignUp}</span>
                    <div className="btn-icon">
                        <ReactSVG src={ArrowIcon} className="arrow-right" />
                    </div>
                </a>
            </div>
        </div>
    );
};

LoginForm.propTypes = {
    onDarkModeChange: PropTypes.func.isRequired
};

export default LoginForm;
