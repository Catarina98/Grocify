const ApiEndpoints = {
    Login_Endpoint: 'api/Auth/login',
    Register_Endpoint: 'api/Auth/register',
    UserDarkMode_Endpoint: 'api/User/toggleDarkMode',
    ProductSections_Endpoint: (houseId) => `api/ProductSection/${houseId}/products`
};

export default ApiEndpoints;