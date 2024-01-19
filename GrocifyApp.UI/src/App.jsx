import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import LoginForm from './components/Login';
import WeatherForecast from './pages/WeatherForecast';
import Settings from './pages/Settings';
import Layout from './components/Layout/Layout.jsx';
import './styles/styles.scss';

function App() {
    //Check if the user is authenticated
    const isAuthenticated = localStorage.getItem('token');

    return (
        <div className="container-page">
            <Layout />

            <Router>
                <Routes>
                    <Route
                        path="/weatherforecast"
                        element={<WeatherForecast />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to="/weatherforecast" /> : <LoginForm />} />
                    <Route
                        path="/settings"
                        element={<Settings />}
                    />
                    <Route index element={isAuthenticated ? <Navigate to="/settings" /> : <LoginForm />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;