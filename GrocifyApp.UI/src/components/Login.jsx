import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const LoginForm = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        const data = { email, password };

        try {
            const response = await fetch('https://localhost:7181/api/Auth/login', {
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

                navigate('/');
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
