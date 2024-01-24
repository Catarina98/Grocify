import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import { useState } from 'react';
import LoginForm from './components/Login';
import WeatherForecast from './pages/WeatherForecast';
import Settings from './pages/Settings';
import ProductSections from './pages/Products/ProductSections';
import AppRoutes from './consts/AppRoutes';
import './styles/styles.scss';


function App() {
    //Check if the user is authenticated
    const isAuthenticated = localStorage.getItem('token');

    const [isDarkMode, setDarkMode] = useState(false);

    return (
        <div className={`container-page ${isDarkMode ? 'dark' : ''}`}>
            <Router>
                <Routes>
                    <Route
                        path="/weatherforecast"
                        element={<WeatherForecast />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to="/weatherforecast" /> : <LoginForm />} />
                    <Route
                        path={AppRoutes.Settings}
                        element={<Settings onDarkModeChange={(data) => setDarkMode(data)} />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to={AppRoutes.Settings} /> : <LoginForm />} />
                    <Route
                        path={AppRoutes.ProductSections}
                        element={<ProductSections />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to={AppRoutes.ProductSections} /> : <LoginForm />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;