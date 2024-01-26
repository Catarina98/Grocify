import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const Logout = () => {
    const navigate = useNavigate();

    useEffect(() => {
        localStorage.removeItem('token');
        
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
