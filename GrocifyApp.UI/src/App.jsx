import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import LoginForm from './components/Login';
import WeatherForecast from './components/WeatherForecast';
import './App.css';

function App() {
    const isAuthenticated = localStorage.getItem('token'); // Check if the user is authenticated

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route
                        path="/weatherforecast"
                        element={<WeatherForecast />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to="/weatherforecast" /> : <LoginForm />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;