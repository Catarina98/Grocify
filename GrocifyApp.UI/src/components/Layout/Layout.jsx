import PropTypes from 'prop-types';

//Internal components
import BottomNavbar from './BottomNavbar';

const Layout = ({ children }) => {
    return (
        <>
            <div className="content">{children}</div>

            <BottomNavbar />
        </>
    );
};

Layout.propTypes = {
    children: PropTypes.node.isRequired,
};

export default Layout;
