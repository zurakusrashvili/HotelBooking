interface ILobbyScope extends ng.IScope {
    products: Product[],
    categories: Category[],
    basketTotal: number,

    isVegeterianOn: boolean,
    isNutsOn: boolean,
    spicinessCount: number;
    activeCategoryId: number;


    basketGetAll: () => void,
    calculateTotal: () => void,
    updateBasket: (data: BasketUpdateDto) => void,
    addToBasket: (data: BasketPostDto) => void,
    deleteFromBasket: (id: number) => void,
    getAllCategories: () => void,
    getAllProducts: () => void,
    getFilteredProducts: (vegeterian?: boolean, nuts?: boolean, spiciness?: number, categoryId?: number) => void,
}


interface Product {
    id: number,
    name: string,
    price: number,
    nuts: boolean,
    image: string,
    vegeterian: boolean,
    spiciness: number,
    categoryId: number
}

interface BasketUpdateDto {
    quantity: number,
    price: number,
    productId: number
}

interface BasketPostDto {
    quantity: number,
    price: number,
    productId: number
}

interface Category {
    id: number,
    name: string
}


interface filterProduct {
    vegeterian?: boolean,
    nuts?: boolean,
    spiciness?: number,
    categoryId?: number
}
