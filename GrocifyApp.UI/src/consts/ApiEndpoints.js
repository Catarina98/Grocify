const ApiEndpoints = {
    Login_Endpoint: 'api/Auth/login',
    User_Endpoint: (userId) => `api/User/${userId}`,
    UserDarkMode_Endpoint: 'api/User/toggleDarkMode',
};

export default ApiEndpoints;