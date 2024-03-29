import { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Assets & Css
import CartIcon from '../../assets/cart-ic.svg';
import InventoryIcon from '../../assets/inventory-ic.svg';
import RecipeIcon from '../../assets/recipes-ic.svg';
import CalendarIcon from '../../assets/calendar-ic.svg';
import SettingsIcon from '../../assets/settings-ic.svg';

//Consts
import { NavbarConsts } from '../../consts/ENConsts';
import AppRoutes from '../../consts/AppRoutes';

const menuItems = [
    { iconSrc: CartIcon, text: NavbarConsts.Lists, route: AppRoutes.ShoppingLists },
    { iconSrc: InventoryIcon, text: NavbarConsts.Inventories },
    { iconSrc: RecipeIcon, text: NavbarConsts.Recipes },
    { iconSrc: CalendarIcon, text: NavbarConsts.Plan },
    { iconSrc: SettingsIcon, text: NavbarConsts.Settings, route: AppRoutes.Settings },
];

const NavbarMenu = ({ iconSrc, text, route, isActive, onClick }) => (
    <div className={`navbar-menu ${isActive ? 'active' : ''}`}
        onClick={() => onClick(route)}>
        <div className="navbar-menu-icon">
            <ReactSVG className="react-svg" src={iconSrc} />
        </div>
        <div className="navbar-menu-text text text--xs weight--xs color--n500">{text}</div>
    </div>
);

NavbarMenu.propTypes = {
    iconSrc: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired,
    route: PropTypes.string,
    isActive: PropTypes.bool.isRequired,
    onClick: PropTypes.func.isRequired,
};

const BottomNavbar = () => {
    const [activeNavItem, setActiveNavItem] = useState(NavbarConsts.Lists);
    const navigate = useNavigate();
    const location = useLocation();

    useEffect(() => {
        const reversedMenuItems = menuItems.slice().reverse();

        const currentNavItem = reversedMenuItems.find(item => item.route && location.pathname && location.pathname.includes(item.route));

        if (currentNavItem) {
            setActiveNavItem(currentNavItem.text);
        }
    }, [location.pathname]);

    const handleNavItemClick = (route) => {
        setActiveNavItem(menuItems.find(item => item.route === route)?.text || NavbarConsts.Lists);
        navigate(route);
    };

    return (
        <div className="bottom-navbar">
            {menuItems.map((menuItem, index) => (
                <NavbarMenu
                    key={index}
                    iconSrc={menuItem.iconSrc}
                    text={menuItem.text}
                    route={menuItem.route}
                    isActive={activeNavItem === menuItem.text}
                    onClick={handleNavItemClick}
                />
            ))}
        </div>
    );
};

export default BottomNavbar;
