import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import { useState} from 'react';

//Internal components
import LoginForm from './components/Login';
import WeatherForecast from './pages/WeatherForecast';
import Settings from './pages/Settings';
import Logout from './components/Logout';

//Assets & Css
import './styles/styles.scss';

//Consts
import AppRoutes from './consts/AppRoutes';
//import ApiEndpoints from './src/consts/ApiEndpoints';
//import { GenericConsts } from '.././src/consts/ENConsts';

function PrivateRoute({ children }) {
    const isAuthenticated = !!localStorage.getItem('token');
    return isAuthenticated ? children : <Navigate to={AppRoutes.Login} />;
}

PrivateRoute.propTypes = {
    children: PropTypes.node.isRequired
};

function App() {
    const storedDarkMode = localStorage.getItem('isDarkMode');
    const [isDarkMode, setDarkMode] = useState(storedDarkMode === 'true');

    const handleDarkModeChange = (newDarkMode) => {
        setDarkMode(newDarkMode);
        localStorage.setItem('isDarkMode', newDarkMode.toString());
    };

    return (
        <div className={`container-page ${isDarkMode ? 'dark' : ''}`}>
            <Router>
                <Routes>
                    {/* Define the public routes */}
                    <Route path={AppRoutes.Login} element={<LoginForm />} />
                    <Route path={AppRoutes.Logout} element={<Logout />} />

                    {/* Define the private routes */}
                    <Route index element={<PrivateRoute><WeatherForecast /></PrivateRoute>} />
                    <Route path={AppRoutes.Settings} element={
                        <PrivateRoute>
                            <Settings onDarkModeChange={handleDarkModeChange} />
                        </PrivateRoute>} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;