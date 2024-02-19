import { useEffect, useState } from 'react';
import { ReactSVG } from 'react-svg';
import PropTypes from 'prop-types';

//Internal components

//Assets & Css
import BoxIcon from '../assets/box-ic.svg';
import styles from './EmptyState.module.scss';

//Consts
import { EmptyStateConsts } from '../consts/ENConsts';

const EmptyState = ({ onClose, onConfirm }) => {
    //const [isButtonDisabled, setButtonDisabled] = useState(true);
    //const [productSectionName, setProductSectionName] = useState("");
    //const [productSectionIcon, setProductSectionIcon] = useState('Home');

    //useEffect(() => {
    //    if (productSectionName !== "" && productSectionIcon !== "") {
    //        setButtonDisabled(false);
    //    } else {
    //        setButtonDisabled(true);
    //    }
    //}, [productSectionIcon, productSectionName]);

    //const createProductSection = async () => {

    //    const data = { name: productSectionName, icon: productSectionIcon };

    //    await makeRequest(ApiEndpoints.ProductSections_Endpoint, 'POST', data);

    //    onConfirm();
    //};

    return (
        <div className={styles.emptyStateContainer}>
            <div className="icon">
                <ReactSVG className="react-svg icon-color--n600" src={BoxIcon} />
            </div>

            <div className={styles.emptyStateText}>
                <div className="text--l">
                    {EmptyStateConsts.Title("product section")} {/*use entity const*/}
                </div>

                <div className="text--xs">
                    {EmptyStateConsts.Description("product section")}
                </div>
            </div>

        </div>
    );
};

EmptyState.propTypes = {
    onClose: PropTypes.func.isRequired,
    onConfirm: PropTypes.func
};

export default EmptyState;