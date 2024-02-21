const ApiEndpoints = {
    Login_Endpoint: 'api/Auth/login',
    Register_Endpoint: 'api/Auth/register',
    UserDarkMode_Endpoint: 'api/User/toggleDarkMode',
    ProductSections_Endpoint: '/api/ProductSection',
    ProductSection_Endpoint: (sectionId) => `/api/ProductSection/${sectionId}`,
    ShoppingList_Endpoint: 'api/ShoppingList',
    DefaultShoppingList_Endpoint: (shoppingListId) => `api/ShoppingList/${shoppingListId}/setdefault`,
    ProductMeasures_Endpoint: '/api/ProductMeasure',
    Products_Endpoint: '/api/Product',
    Filtered: '/filtered'
};

export default ApiEndpoints;