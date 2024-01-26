import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import { useState } from 'react';

//Internal components
import LoginForm from './components/Login';
import WeatherForecast from './pages/WeatherForecast';
import Settings from './pages/Settings';
import Logout from './components/Logout';

//Assets & Css
import './styles/styles.scss';

//Consts
import AppRoutes from './consts/AppRoutes';

function PrivateRoute({ children }) {
    const isAuthenticated = !!localStorage.getItem('token');
    return isAuthenticated ? children : <Navigate to={AppRoutes.Login} />;
}

PrivateRoute.propTypes = {
    children: PropTypes.node.isRequired
};

function App() {
    const [isDarkMode, setDarkMode] = useState(false);

    return (
        <div className={`container-page ${isDarkMode ? 'dark' : ''}`}>
            <Router>
                <Routes>
                    {/* Define the public routes */}
                    <Route path={AppRoutes.Login} element={<LoginForm />} />
                    <Route path={AppRoutes.Logout} element={<Logout />} />

                    {/* Define the private routes */}
                    <Route index element={<PrivateRoute><WeatherForecast /></PrivateRoute>} />
                    <Route path={AppRoutes.Settings} element={<PrivateRoute><Settings /></PrivateRoute>} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;