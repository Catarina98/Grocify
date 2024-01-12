import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import LoginForm from './components/Login';
import WeatherForecast from './components/WeatherForecast';
import './App.css';

function App() {
    const isAuthenticated = localStorage.getItem('token'); // Check if the user is authenticated
    console.log("is authenticated " + isAuthenticated)

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/login" element={<LoginForm />} />
                    {/* Protected Route: Redirect to login if not authenticated */}
                    <Route
                        path="/weatherforecast"
                        element={isAuthenticated ? <WeatherForecast /> : <Navigate to="/login" />}
                    />
                    {/* Redirect to login if no match */}
                    <Route index element={<Navigate to="/weatherforecast" />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;