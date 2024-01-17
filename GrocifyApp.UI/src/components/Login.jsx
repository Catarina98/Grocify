import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import ReactLogo from '../assets/logo.svg';
import LoginConsts from '../consts/enconsts/LoginConsts';
import ApiEndpoints from '../consts/ApiEndpoints';


const LoginForm = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

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
                console.error('Login failed', errorData);
            }
        } catch (error) {
            console.error('Error during login', error);
        } finally {
            loginButton.classList.remove("loading");
        }
    };

    return (
        <div className="container-page">
            <img src={ReactLogo} alt="React Logo" />
            <form className="input-form">
                <h2>{LoginConsts.SignIn}</h2>
                <p>{LoginConsts.EnterDetails}</p>
                <div className="input-box mt-3">
                    <input className="input-text"
                        type="email" placeholder="name@example.com"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                    <label className="input-placeholder">{LoginConsts.Email}</label>
                </div>
                <div className="input-box">
                    <input className="input-text"
                        type="password" placeholder="+assword"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <label className="input-placeholder">{LoginConsts.Password}</label>
                </div>

                <button type="button" className="primary-button" onClick={handleLogin}>
                    <span>{LoginConsts.SignIn}</span>
                    <div className="loading-button white"></div>
                </button>
            </form>

            <div className="text-center mt-4">
                <div>{LoginConsts.HaveAccount}</div>
                <a className="subtle-button" href="/register">{LoginConsts.SignUp}</a>
            </div>
        </div>
    );
};

export default LoginForm;
