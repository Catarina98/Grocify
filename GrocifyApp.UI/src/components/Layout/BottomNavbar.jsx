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
    { iconSrc: CartIcon, text: NavbarConsts.Lists },
    { iconSrc: InventoryIcon, text: NavbarConsts.Inventories },
    { iconSrc: RecipeIcon, text: NavbarConsts.Recipes },
    { iconSrc: CalendarIcon, text: NavbarConsts.Plan },
    { iconSrc: SettingsIcon, text: NavbarConsts.Settings },
];

const NavbarMenu = ({ iconSrc, text, activeNavItem, onClick }) => (
    <div className={`navbar-menu ${activeNavItem === text ? 'active' : ''}`}
        onClick={() => onClick(text)}>
        <div className="navbar-menu-icon">
            <ReactSVG className="react-svg" src={iconSrc} />
        </div>
        <div className="navbar-menu-text text--xs weight--xs color-n500">{text}</div>
    </div>
);

NavbarMenu.propTypes = {
    iconSrc: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired,
    activeNavItem: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired,
};

const BottomNavbar = () => {
    const [activeNavItem, setActiveNavItem] = useState(NavbarConsts.Lists);
    const navigate = useNavigate();

    const handleNavItemClick = (itemName) => {
        setActiveNavItem(itemName);

        navigate(AppRoutes.Settings);
    };

    return (
        <div className="bottom-navbar">
            {menuItems.map((menuItem, index) => (
                <NavbarMenu
                    key={index}
                    {...menuItem}
                    activeNavItem={activeNavItem}
                    onClick={handleNavItemClick}
                />
            ))}
        </div>
    );
};

export default BottomNavbar;
