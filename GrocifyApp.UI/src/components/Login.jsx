import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ReactSVG } from 'react-svg';
import { GenericConsts, LoginConsts } from '../consts/ENConsts';
import ReactLogo from '../assets/logo_with_text.svg';
import ArrowIcon from '../assets/arrow-ic.svg';
import ApiEndpoints from '../consts/ApiEndpoints';
import AppRoutes from '../consts/AppRoutes';
import CustomInput from './CustomInput';
import './Login.jsx.scss';


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
                const t = await response.text();

                localStorage.setItem('token', t);

                console.log('Login successful');

                navigate('/weatherforecast');
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
        <div className="container-page">
            <ReactSVG className="react-svg" src={ReactLogo} />
            <form className="input-form">
                <div className="title title--xl color-n700">{LoginConsts.SignIn}</div>
                <p className="text color-n500 login-desc">{LoginConsts.EnterDetails}</p>
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

                <button type="button" className="primary-button btn--xl" onClick={handleLogin}>
                    <span>{LoginConsts.SignIn}</span>
                    <div className="loading-button white"></div>
                </button>
            </form>

            <div className="form-footer">
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
