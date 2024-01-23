import PropTypes from 'prop-types';
import BottomNavbar from './BottomNavbar';

const Layout = ({ children }) => {
    return (
        <div>
            <div className="content">{children}</div>

            <BottomNavbar />
        </div>
    );
};

Layout.propTypes = {
    children: PropTypes.node.isRequired,
};

export default Layout;