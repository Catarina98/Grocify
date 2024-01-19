import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import LoginForm from './components/Login';
import WeatherForecast from './pages/WeatherForecast';
import Settings from './pages/Settings';
import Layout from './components/Layout/Layout.jsx';
import AppRoutes from './consts/AppRoutes';
import './styles/styles.scss';

function App() {
    //Check if the user is authenticated
    const isAuthenticated = localStorage.getItem('token');

    return (
        <>
            <div className="container-page">
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

            <Layout />
        </>
    );
}

export default App;