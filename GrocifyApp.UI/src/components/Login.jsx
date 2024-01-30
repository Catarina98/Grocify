import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';

//Internal components
import CustomInput from './CustomInput';

//Assets & Css
import ReactLogo from '../assets/logo_with_text.svg';
import ArrowIcon from '../assets/arrow-ic.svg';
import ApiEndpoints from '../consts/ApiEndpoints';
import styles from './Login.module.scss';

//Consts
import { GenericConsts, LoginConsts } from '../consts/ENConsts';
import AppRoutes from '../consts/AppRoutes';

const LoginForm = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleLogin = async (event) => {
        const data = { email, password };

        const loginButton = event.target;

        loginButton.classList.add("loading");

        try {
            const response = await fetch(ApiEndpoints.Login_Endpoint, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            });

            if (response.ok) {
                const userLogged = await response.json();

                localStorage.setItem('token', userLogged.token);
                localStorage.setItem('userId', userLogged.userId);
                localStorage.setItem('isDarkMode', userLogged.isDarkMode);

                console.log('Login successful');

                navigate('/');
            } else {
                const errorData = await response.json();
                console.error('Login failed', errorData.errors[0]);

                setErrorMessage(errorData.errors[0]);
            }
        } catch (error) {
            console.error('Error during login', error);

            setErrorMessage(GenericConsts.Error);
        } finally {
            loginButton.classList.remove("loading");
        }
    };

    return (
        <div className={styles.login}>
            <ReactSVG className="react-svg" src={ReactLogo} />
            <form className={styles.inputForm + " input-form"}>
                <div className="title title--xl">{LoginConsts.SignIn}</div>
                <p className={styles.loginDesc + " text color-n500"}>{LoginConsts.EnterDetails}</p>
                <p id="error" className="text error">{errorMessage}</p>


                <CustomInput className ="mt-3"
                    type="email"
                    placeholder="name@example.com"
                    value={email}
                    label={LoginConsts.Email}
                    onChange={(e) => setEmail(e.target.value)} />

                <CustomInput
                    type="password"
                    placeholder="password"
                    value={password}
                    label={LoginConsts.Password}
                    onChange={(e) => setPassword(e.target.value)} />

                <button type="button" className={styles.btn + " primary-button btn--xl"} onClick={handleLogin}>
                    <span>{LoginConsts.SignIn}</span>
                    <div className="loading-button white"></div>
                </button>
            </form>

            <div className={styles.formFooter}>
                <div className="text color-n500">{LoginConsts.HaveAccount}</div>
                <a className="subtle-button" href={AppRoutes.Register}>
                    <span className="btn-text btn--m">{LoginConsts.SignUp}</span>
                    <div className="btn-icon">
                        <ReactSVG src={ArrowIcon} className="arrow-right" />
                    </div>
                </a>
            </div>
        </div>
    );
};

export default LoginForm;
