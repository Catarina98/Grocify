import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import { useState } from 'react';

//Internal components
import LoginForm from './components/Authentication/Login';
import RegisterForm from './components/Authentication/Register';
import Logout from './components/Authentication/Logout';
import Settings from './pages/Settings';
import ProductSections from './pages/Products/ProductSections';
import ProductMeasures from './pages/Products/ProductMeasures';
import ShoppingLists from './pages/ShoppingLists/ShoppingLists';
import Inventories from './pages/Inventories/Inventories';

//Assets & Css
import './styles/styles.scss';

//Consts
import AppRoutes from './consts/AppRoutes';
import Products from './pages/Products/Products';

function PrivateRoute({ children }) {
    const isAuthenticated = !!localStorage.getItem('token');
    return isAuthenticated ? children : <Navigate to={AppRoutes.Login} />;
}

PrivateRoute.propTypes = {
    children: PropTypes.node.isRequired
};

function App() {
    const darkMode = localStorage.getItem('isDarkMode') === 'true';
    const [isDarkMode, setDarkMode] = useState(darkMode == undefined ? false : darkMode);

    const handleDarkModeChange = (newDarkMode) => {
        setDarkMode(newDarkMode);
        localStorage.setItem('isDarkMode', newDarkMode.toString());
    };

    return (
        <div className={`container-page ${isDarkMode ? 'dark' : ''}`}>
            <Router>
                <Routes>
                    {/* Define the public routes */}
                    <Route path={AppRoutes.Login} element={<LoginForm onDarkModeChange={handleDarkModeChange} />} />
                    <Route path={AppRoutes.Logout} element={<Logout onDarkModeChange={handleDarkModeChange} />} />
                    <Route path={AppRoutes.Register} element={<RegisterForm />} />

                    {/* Define the private routes */}
                    <Route index element={<PrivateRoute><ShoppingLists /></PrivateRoute>} />

                    <Route path={AppRoutes.Settings} element={
                        <PrivateRoute>
                            <Settings onDarkModeChange={handleDarkModeChange} isDarkMode={isDarkMode} />
                        </PrivateRoute>} />

                    <Route path={AppRoutes.ProductSections} element={<PrivateRoute><ProductSections /></PrivateRoute>} />
                    <Route path={AppRoutes.ProductMeaures} element={<PrivateRoute><ProductMeasures /></PrivateRoute>} />

                    <Route path={AppRoutes.ShoppingLists} element={<PrivateRoute><ShoppingLists /></PrivateRoute>} />
                    <Route path={AppRoutes.Inventories} element={<PrivateRoute><Inventories /></PrivateRoute>} />
                    <Route path={AppRoutes.Products} element={<PrivateRoute><Products /></PrivateRoute>} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;