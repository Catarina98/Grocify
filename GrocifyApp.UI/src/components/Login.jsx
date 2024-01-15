import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../App.css';
import ReactLogo from '../assets/logo.svg';

const LoginForm = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        const data = { email, password };

        try {
            const response = await fetch('api/Auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            });

            if (response.ok) {
                // Assuming your API returns a token
                const t = await response.text();

                // You can store the token in local storage or a state management library
                // For simplicity, storing in local storage here
                localStorage.setItem('token', t);

                // Redirect or perform any other actions after successful login
                console.log('Login successful');

                navigate('/weatherforecast');
            } else {
                const errorData = await response.json();
                console.error('Login failed', errorData);
                // Handle error, display error message, etc.
            }
        } catch (error) {
            console.error('Error during login', error);
            // Handle error, display error message, etc.
        }
    };

    return (
        <div>
            <img src={ReactLogo} alt="React Logo" />
            <form className="input-form">
                <h2>Sign in</h2>
                <p>Please enter your details bellow</p>
                <div className="input-box mt-3">
                    <input className="input-text"
                        type="email" placeholder="name@example.com"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                    <label className="input-placeholder">Email</label>
                </div>
                <div className="input-box">
                    <input className="input-text"
                        type="password" placeholder="+assword"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <label className="input-placeholder">Password</label>
                </div>

                <button type="button" className="primary-button" onClick={handleLogin}>
                    Sign in
                </button>
            </form>

            <div className="text-center mt-4">
                <div>Don't have an account?</div>
                <a className="subtle-button" href="/register">Sign up</a>
            </div>
        </div>
    );
};

export default LoginForm;
