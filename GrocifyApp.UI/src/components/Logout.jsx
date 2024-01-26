// Logout.js
import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const Logout = () => {
    const navigate = useNavigate();

    useEffect(() => {
        // Perform logout actions
        localStorage.removeItem('token');

        // Redirect to the base page after logout
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

export default Logout;
