const ApiEndpoints = {
    Login_Endpoint: 'api/Auth/login',
    User_Endpoint: (userId) => `api/User/${userId}`
};

export default ApiEndpoints;