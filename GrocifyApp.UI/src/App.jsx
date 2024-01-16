import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import LoginForm from './components/Login';
import WeatherForecast from './components/WeatherForecast';
import './App.css';

function App() {
    //Check if the user is authenticated
    const isAuthenticated = localStorage.getItem('token');

    return (
        <Router>
            <Routes>
                <Route
                    path="/weatherforecast"
                    element={<WeatherForecast />}
                />
                <Route index element={isAuthenticated ? <Navigate to="/weatherforecast" /> : <LoginForm />} />
            </Routes>
        </Router>
    );
}

export default App;