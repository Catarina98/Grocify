const GenericConsts = {
    Error: "Something went wrong",
    Section: "section"
};

const EntityConsts = {
    ProductSection: "product section",
    ProductMeasure: "product measure",
};

const ButtonConsts = {
    NewSection: "New section",
    Proceed: "Proceed",
    Back: "Back",
    Cancel: "Cancel",
    Update: "Update",
    Create: "Create",
    Confirm: "Confirm",
    Delete: "Delete",
    NewMeasure: "New measure",
    NewProduct: "New product",
    NewList: "New shopping list",
};

const SettingsConsts = {
    Products: "Products",
    ProductSections: "Product sections",
    ProductMeasures: "Product measures",
    DefaultLists: "Default lists",
    ShoppingList: "Shopping list",
    Inventory: "Inventory",
    MealPlan: "Meal plan",
    Meals: "Meals",
    Appearance: "Appearance",
    DarkMode: "Dark mode",
    Account: "Account",
    Logout: "Logout",
    ClearData: "Clear all data",
};

const PlaceholderConsts = {
    Search: "Search...",
    SearchSections: "Search for product sections...",
    SearchMeasures: "Search for product measures...",
    SearchProducts: "Search for products...",
    SearchLists: "Search for shopping lists...",
    AddSectionName: "Add section name",
    AddMeasureName: "Add measure name",
};

const LabelConsts = {
    ProductSectionName: "Product section name",
    ProductSectionIcon: "Section icon",
    ProductMeasureName: "Product measure name",
};

const NavbarConsts = {
    Lists: "Lists",
    Inventories: "Inventories",
    Recipes: "Recipes",
    Plan: "Plan",
    Settings: "Settings"
};

const AuthConsts = {
    SignIn: "Sign in",
    EnterDetails: "Please enter your details bellow",
    HaveAccount: "Don't have an account?",
    AlreadyHaveAccount: "Already have an account?",
    SignUp: "Sign up",
    Email: "Email",
    Password: "Password",
    Name: "Name",
    ConfirmPassword: "ConfirmPassword",
    ErrorMessage: "The email or password you entered is incorrect.",
    EmailPlaceholer: "name@example.com",
    PasswordPlaceholer: "password",
    NameError: "Please enter your name",
    EmailError: "Please enter a valid email address"
};

const PassRulesConsts = {
    PasswordLong: "Your password must be at least 8 characters long",
    PassUpperLower: "Must contain both uppercase and lowercase letters",
    PassSpecialCharacters: "Must contain at least one number or special character",
    PasswordMatch: "Passwords must match",
};

const ModalConsts = {
    DefaultShoppingList: "Change default shopping list",
    NewProductSection: "New product section",
    IconSection: "Icon of section",
    NewProductMeasure: "New product measure",
    MoreOptions: "More options",
    EditEntity: (entity) => `Edit ${entity}`,
    DeleteEntity: (entity) => `Delete ${entity}`,
    DeleteTitle: (itemToDelete) => `Are you sure you want to delete ${itemToDelete}?`,
    EditProductSection: (sectionName) => `Edit <span class="color--primary">${sectionName}</span> section`,
};

const EmptyStateConsts = {
    Title: (entity) => `There's no ${entity}`,
    Description: (entity) => `Click the button below to create a ${entity}`,
};

export {
    GenericConsts,
    EntityConsts,
    SettingsConsts,
    PlaceholderConsts,
    LabelConsts,
    NavbarConsts,   
    ButtonConsts,
    AuthConsts,
    PassRulesConsts,
    ModalConsts,
    EmptyStateConsts
};