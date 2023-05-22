class LobbyClass {
    constructor() {
        let lobbyApp = angular.module("lobbyApp", [])

        lobbyApp.controller("lobbyController", [
            "$scope", "$http", ($scope: ILobbyScope, $http: ng.IHttpService) => {
                

                $.extend($scope, {

                    //getAllBasket

                    basketGetAll() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Baskets/GetAll`,
                            success: function (response) {
                                $scope.basketProducts = response
                                $scope.calculateTotal()
                                $scope.$apply();
                            }
                        });
                    },
                    //updateBasket()

                    updateBasket(data: BasketUpdateDto) {
                        $.ajax({
                            type: "PUT",
                            url: `https://${window.location.host}/api/Baskets/UpdateBasket`,
                            data: JSON.stringify(data),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: () => {
                            }
                        });
                    },

                    // addToBasket()

                    addToApiBasket(data: BasketPostDto) {
                        $.ajax({
                            type: "POST",
                            url: `https://${window.location.host}/api/Baskets/AddToBasket`,
                            data: JSON.stringify(data),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                            }
                        });
                    },

                    addToBasket(data: Product, quantity: number) {
                        let productExistsInBasket = $scope.basketProducts.find((bskt) => bskt.product.id === data.id)

                        if (productExistsInBasket) {
                            var dto: BasketUpdateDto = {
                                price: data.price,
                                productId: data.id,
                                quantity: productExistsInBasket.quantity += quantity
                            }
                            $scope.updateBasket(dto)
                        } else {
                            var dto: BasketPostDto = {
                                price: data.price,
                                productId: data.id,
                                quantity: quantity
                            }
                            $scope.addToApiBasket(dto);
                        }
                    },
                    increaseBasketQuantity(data: any) {
                        let productExistsInBasket = $scope.basketProducts.find((bskt) => bskt.product.id === data.product.id)
                        var dto: BasketUpdateDto = {
                            price: data.product.price,
                            productId: data.product.id,
                            quantity: productExistsInBasket.quantity += 1
                        }
                        $scope.updateBasket(dto)
                        $scope.calculateTotal()
                    },
                    decreaseBasketQuantity(data: any) {
                        if (data.quantity <= 1) return
                        let productExistsInBasket = $scope.basketProducts.find((bskt) => bskt.product.id === data.product.id)
                        var dto: BasketUpdateDto = {
                            price: data.product.price,
                            productId: data.product.id,
                            quantity: productExistsInBasket.quantity -= 1
                        }
                        $scope.calculateTotal()
                        $scope.updateBasket(dto)
                    },
                    // deleteProductFromBasket()
                    deleteFromBasket(id: number) {
                        $.ajax({
                            type: "DELETE",
                            url: `https://${window.location.host}/api/Baskets/DeleteProduct/${id}`,
                            success: function (response) {
                                $scope.basketGetAll()
                            }
                        });
                    },



                    // getAllCategories()
                    getAllCategories() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Categories/GetAll`,
                            success: function (response) {
                                $scope.categories = response
                                console.log(response)
                                $scope.$apply();
                            }
                        });
                    },
                    // getAllProducts
                    getAllProducts() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Products/GetAll`,
                            success: function (response) {
                                $scope.products = response
                                $scope.activeCategoryId = null;
                                $scope.$apply()
                            }
                        });
                    },
                    createFilterParams(vegeterian?: boolean, nuts?: boolean, spiciness?: number, categoryId?: number) {
                        let obj: any = {

                        }
                        if (vegeterian == true) {
                            obj.vegeterian = vegeterian;
                        }

                        if (nuts == false) {
                            obj.nuts = nuts;
                        }

                        if (spiciness !== null && spiciness !== -1) {
                            obj.spiciness = spiciness
                        }

                        if (categoryId !== null) {
                            obj.categoryId = categoryId;
                        }

                        return obj;
                    },
                    // getFilteredProducts()
                    getFilteredProducts(vegeterian?: boolean, nuts?: boolean, spiciness?: number, categoryId?: number) {
                        let object = $scope.createFilterParams(vegeterian, nuts, spiciness, categoryId)
                        
                        const params = '?' + new URLSearchParams(object).toString();

                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Products/GetFiltered${params}`,
                            success: function (response) {
                                $scope.products = response;
                                $scope.$apply();
                            }
                        });
                    },

                    calculateTotal() {
                        $scope.basketTotal = 0;
                        $scope.basketProducts.forEach((pr) => {
                            $scope.basketTotal += (pr.price * pr.quantity)
                        })
                    },
                    filterProducts(Id: number) {
                        if (Id) {
                            $scope.activeCategoryId = Id;
                            $.ajax({
                                type: "GET",
                                url: `https://${window.location.host}/api/Products/GetFiltered?categoryId=${Id}`,
                                success: function (response) {
                                    $scope.products = response;
                                    $scope.$apply()
                                }
                            });
                        } else {
                            $scope.getAllProducts()
                        }
                    },

                    applyFilter() {
                        $scope.getFilteredProducts($scope.isVegeterianOn, !$scope.isNutsOn, $scope.spicinessCount, $scope.activeCategoryId)
                    },
                    resetFilter() {
                        $scope.getAllProducts()
                        $scope.isNutsOn = null;
                        $scope.isVegeterianOn = null;
                        $scope.spicinessCount = -1;
                        $scope.activeCategoryId = null;
                    },
                    init: () => {
                        $scope.getAllProducts();
                        $scope.getAllCategories()
                        $scope.basketGetAll()


                        $scope.isNutsOn = null;
                        $scope.isVegeterianOn = null;
                        $scope.spicinessCount = -1;
                        $scope.activeCategoryId = null;

                    }
                })
                

            }
        ])
    }
}



(() => {
    var lobby = new LobbyClass();
})();
