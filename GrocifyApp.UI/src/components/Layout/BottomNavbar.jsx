import { useState } from 'react';
import { ReactSVG } from 'react-svg';
import { NavbarConsts } from '../../consts/ENConsts';
import { useNavigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import CartIcon from '../../assets/cart-ic.svg';
import InventoryIcon from '../../assets/inventory-ic.svg';
import RecipeIcon from '../../assets/recipes-ic.svg';
import CalendarIcon from '../../assets/calendar-ic.svg';
import SettingsIcon from '../../assets/settings-ic.svg';
import AppRoutes from '../../consts/AppRoutes';

const menuItems = [
    { iconSrc: CartIcon, text: NavbarConsts.Lists, route: '/weatherforecast' },
    { iconSrc: InventoryIcon, text: NavbarConsts.Inventories, route: '/weatherforecast' },
    { iconSrc: RecipeIcon, text: NavbarConsts.Recipes },
    { iconSrc: CalendarIcon, text: NavbarConsts.Plan, route: '/weatherforecast' },
    { iconSrc: SettingsIcon, text: NavbarConsts.Settings, route: AppRoutes.Settings },
];

const NavbarMenu = ({ iconSrc, text, route, activeNavItem, onClick }) => (
    <div className={`navbar-menu ${activeNavItem === text ? 'active' : ''}`}
        onClick={() => onClick(text, route)}>
        <div className="navbar-menu-icon">
            <ReactSVG className="react-svg" src={iconSrc} />
        </div>
        <div className="navbar-menu-text text--xs weight--xs color-n500">{text}</div>
    </div>
);

NavbarMenu.propTypes = {
    iconSrc: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired,
    route: PropTypes.string,
    activeNavItem: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired,
};

const BottomNavbar = () => {
    const [activeNavItem, setActiveNavItem] = useState(NavbarConsts.Lists);
    const navigate = useNavigate();

    const handleNavItemClick = (text, route) => {        
        navigate(route);
        setActiveNavItem(text);
    };

    return (
        <div className="bottom-navbar">
            {menuItems.map((menuItem, index) => (
                <NavbarMenu
                    key={index}
                    iconSrc={menuItem.iconSrc}
                    text={menuItem.text}
                    route={menuItem.route}
                    activeNavItem={activeNavItem}
                    onClick={handleNavItemClick}
                />
            ))}
        </div>
    );
};

export default BottomNavbar;
