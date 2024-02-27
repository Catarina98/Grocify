const ApiEndpoints = {
    Login_Endpoint: 'api/Auth/login',
    Register_Endpoint: 'api/Auth/register',

    UserDarkMode_Endpoint: 'api/User/toggleDarkMode',
    DefaultShoppingList_Endpoint: (shoppingListId) => `api/ShoppingList/${shoppingListId}/setdefault`,

    ProductSections_Endpoint: '/api/ProductSection',
    ProductSectionsId_Endpoint: (productSectionId) => `/api/ProductSection/${productSectionId}`,
    ProductMeasures_Endpoint: '/api/ProductMeasure',
    Products_Endpoint: '/api/Product',

    ShoppingList_Endpoint: 'api/ShoppingList',    
    
    Filtered: '/filtered'
};

export default ApiEndpoints;