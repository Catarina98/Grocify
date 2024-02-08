import PropTypes from 'prop-types';

//Internal components
import CustomInput from '../components/CustomInput';

//Assets & Css
import SearchIcon from '../assets/search-ic.svg';

const Searchbar = ({ placeholder, value, onChange, label }) => {
    return (
        <div className="searchbar-holder">
            <CustomInput className="app-form mb-0"
                type="input"
                placeholder={placeholder}
                label={label}
                value={value}
                icon={SearchIcon}
                onChange={onChange} />
        </div>
    );
};

Searchbar.propTypes = {
    placeholder: PropTypes.string.isRequired,
    value: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    label: PropTypes.string.isRequired
};

export default Searchbar;