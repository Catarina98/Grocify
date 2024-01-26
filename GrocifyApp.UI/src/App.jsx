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
    const [isDarkMode, setDarkMode] = useState(false);
    const [userAuth, setUserAuth] = getUserDarkMode();
    const userId = "581ccc32-dd5d-455b-d2c2-08dc11ed02ad";
    const emailUser = localStorage.getItem.email;
    const [errorMessage, setErrorMessage] = useState('');

    const getUserDarkMode = async () => {
        try {
            const response = await fetch('api/User/${userId}', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.ok) {
                //const userData = await response.json();
                setUserAuth(await response.json());
                setDarkMode(userAuth.isDarkMode);
            } else {
                const errorData = await response.json();
                setErrorMessage(errorData.errors[0]);
            }
        } catch (error) {
            //setErrorMessage(GenericConsts.Error);
        }
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
                    <Route path={AppRoutes.Settings} element={<PrivateRoute><Settings onDarkModeChange={(data) => setDarkMode(data)} isDarkMode={isDarkMode} /></PrivateRoute>} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;