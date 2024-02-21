const ColorSections = {
    Home: 'color--p100',
    Fishmonger: 'color--b400',
    Meat: 'color--r300',
    Sweetgrocery: 'color--r200',
    Saltygrocery: 'color--y400',
    FrozenFood: 'color--b200',
    PersonalCare: 'color--p300',
    Bakery: 'color--o300',
    Dairy: 'color--b300',
    FruitsVegetables: 'color--g300',
    Drinks: 'color--r500',
    Takeaway: 'color--y300'
};

const BgColorSections = {};
const IconColorSections = {};

// Populate BgColorSections and ColorSections dynamically
for (const key in ColorSections) {
    BgColorSections[key] = `bg-${ColorSections[key]}`;
    IconColorSections[key] = `icon-${ColorSections[key]}`;
}

export { ColorSections, BgColorSections, IconColorSections };