import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import LoginForm from './components/Login';
import WeatherForecast from './pages/WeatherForecast';
import Settings from './pages/Settings';
import AppRoutes from './consts/AppRoutes';
import './styles/styles.scss';

function App() {
    //Check if the user is authenticated
    const isAuthenticated = localStorage.getItem('token');

    return (
        <div className="container-page dark">
            <Router>
                <Routes>
                    <Route
                        path="/weatherforecast"
                        element={<WeatherForecast />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to="/weatherforecast" /> : <LoginForm />} />
                    <Route
                        path={AppRoutes.Settings}
                        element={<Settings />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to={AppRoutes.Settings} /> : <LoginForm />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;