//import React from 'react';
import BottomNavbar from './BottomNavbar';

const Layout = ({ children }) => {
    return (
        <div>
            <div className="content">{children}</div>

            <BottomNavbar />
        </div>
    );
};

export default Layout;
