import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

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
        }
    };

    return (
        <div>
            <h2>Login</h2>
            <form>
                <label>Email:</label>
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <br />
                <label>Password:</label>
                <input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <br />
                <button type="button" onClick={handleLogin}>
                    Login
                </button>
            </form>
        </div>
    );
};

export default LoginForm;
