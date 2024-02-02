import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import PropTypes from 'prop-types';

const Logout = (props) => {
    const navigate = useNavigate();

    useEffect(() => {
        localStorage.removeItem('token');
        localStorage.removeItem('isDarkMode');
        localStorage.removeItem('userId');

        props.onDarkModeChange(false);
        
        navigate('/');
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
