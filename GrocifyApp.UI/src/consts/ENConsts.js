const GenericConsts = {
    Error: "Something went wrong"
};

const ButtonConsts = {
    NewSection: "New section",
    Proceed: "Proceed",
    Back: "Back",
    Cancel: "Cancel",
    Update: "Update",
    Delete: "Delete",
    NewMeasure: "New measure"
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
    SearchMeasures: "Search for product measures..."
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
    DeleteSection: (section) => `Are you sure you want to delete "${section}" section?`,
};

export {
    GenericConsts,
    SettingsConsts,
    PlaceholderConsts,
    NavbarConsts,   
    ButtonConsts,
    AuthConsts,
    PassRulesConsts,
    ModalConsts
};