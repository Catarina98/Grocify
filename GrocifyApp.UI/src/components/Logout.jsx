import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import AppRoutes from '../consts/AppRoutes';

const Logout = (props) => {
    const navigate = useNavigate();

    useEffect(() => {
        localStorage.removeItem('token');
        localStorage.removeItem('isDarkMode');
        localStorage.removeItem('userId');

        props.onDarkModeChange(false);
        
        navigate(AppRoutes.ShoppingLists);
    }, [navigate]);

  return (
    <div>
      Logging out...
          {
              //todo implement
          }
    </div>
  );
};

Logout.propTypes = {
    onDarkModeChange: PropTypes.func.isRequired
};

export default Logout;
