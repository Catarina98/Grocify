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
    //const [password, setPassword] = useState('');
    //const [confirmPassword, setConfirmPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleRegister = async (event) => {
        const data = { name, email };

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

                {/*<CustomInput*/}
                {/*    type="password"*/}
                {/*    value={password}*/}
                {/*    label={AuthConsts.Password}*/}
                {/*    onChange={(e) => setPassword(e.target.value)} />*/}

                {/*<CustomInput*/}
                {/*    type="password"*/}
                {/*    value={confirmPassword}*/}
                {/*    label={AuthConsts.ConfirmPassword}*/}
                {/*    onChange={(e) => setConfirmPassword(e.target.value)} />*/}

                <UserPassword />

                <button type="button" className={styles.btn + " primary-button btn--xl"} onClick={handleRegister}>
                    <span>{AuthConsts.SignUp}</span>
                    <div className="loading-button white"></div>
                </button>
            </form>

            <div className={styles.formFooter}>
                <div className="text color-n500">{AuthConsts.AlreadyHaveAccount}</div>
                <a className="subtle-button" href={AppRoutes.Login}>
                    <span className="btn-text btn--m">{AuthConsts.SignIn}</span>
                    <div className="btn-icon">
                        <ReactSVG src={ArrowIcon} className="arrow-right" />
                    </div>
                </a>
            </div>
        </div>
    );
};

export default RegisterForm;
