const ApiEndpoints = {
    Login_Endpoint: 'api/Auth/login',
    Register_Endpoint: 'api/Auth/register',

    UserDarkMode_Endpoint: 'api/User/toggleDarkMode',
    DefaultShoppingList_Endpoint: (shoppingListId) => `api/ShoppingList/${shoppingListId}/setdefault`,

    ProductSections_Endpoint: '/api/ProductSection',
    ProductSectionsId_Endpoint: (productSectionId) => `/api/ProductSection/${productSectionId}`,
    ProductMeasures_Endpoint: '/api/ProductMeasure',
    ProductMeasuresId_Endpoint: (productMeasureId) => `/api/ProductMeasure/${productMeasureId}`,
    Products_Endpoint: '/api/Product',
    ProductId_Endpoint: (productId) => `/api/Product/${productId}`,

    ShoppingList_Endpoint: 'api/ShoppingList', 
    ShoppingListProducts_Endpoint: (shoppingListId) => `api/ShoppingList/${shoppingListId}/products`,
    
    Filtered: '/filtered'
};

export default ApiEndpoints;