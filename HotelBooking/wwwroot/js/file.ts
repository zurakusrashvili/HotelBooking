class LobbyClass {
    constructor() {
        let lobbyApp = angular.module("lobbyApp", ['ui.bootstrap'])

        lobbyApp.controller("lobbyController", [
            "$scope", "$http", ($scope: ILobbyScope, $http: ng.IHttpService) => {
                

                $.extend($scope, {

                    //getAllBasket
                    // addToBasket()

                    //addToApiBasket(data: BasketPostDto) {
                    //    $.ajax({
                    //        type: "POST",
                    //        url: `https://${window.location.host}/api/Baskets/AddToBasket`,
                    //        data: JSON.stringify(data),
                    //        headers: {
                    //            'Accept': 'application/json',
                    //            'Content-Type': 'application/json'
                    //        },
                    //        dataType: 'json',
                    //        success: function (response) {
                    //        }
                    //    });
                    //},




                    //createFilterParams(roomTypeId?: boolean, priceFrom?: number, priceTo?: number, guestsCount?: number, checkIn?: string, checkOut?: string) {
                    //    let obj: any = {

                    //    }

                    //    if (vegeterian == true) {
                    //        obj.vegeterian = vegeterian;
                    //    }

                    //    if (nuts == false) {
                    //        obj.nuts = nuts;
                    //    }

                    //    if (spiciness !== null && spiciness !== -1) {
                    //        obj.spiciness = spiciness
                    //    }

                    //    if (categoryId !== null) {
                    //        obj.categoryId = categoryId;
                    //    }

                    //    return obj;
                    //},
                    // getFilteredProducts()
                    //getFilteredProducts(vegeterian?: boolean, nuts?: boolean, spiciness?: number, categoryId?: number) {
                    //    let object = $scope.createFilterParams(vegeterian, nuts, spiciness, categoryId)
                        
                    //    const params = '?' + new URLSearchParams(object).toString();

                    //    $.ajax({
                    //        type: "GET",
                    //        url: `https://${window.location.host}/api/Products/GetFiltered${params}`,
                    //        success: function (response) {
                    //            $scope.products = response;
                    //            $scope.$apply();
                    //        }
                    //    });
                    //},

                    //filterProducts(Id: number) {
                    //    if (Id) {
                    //        $scope.activeCategoryId = Id;
                    //        $.ajax({
                    //            type: "GET",
                    //            url: `https://${window.location.host}/api/Products/GetFiltered?categoryId=${Id}`,
                    //            success: function (response) {
                    //                $scope.products = response;
                    //                $scope.$apply()
                    //            }
                    //        });
                    //    } else {
                    //        $scope.getAllProducts()
                    //    }
                    //},



                    hotelsGetAll() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Hotels/GetAll`,
                            success: function (response) {
                                $scope.hotels = response;
                                $scope.getCities();
                                console.log($scope.hotels)
                            }
                        });
                    },

                    getHotelById(id: number) {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Hotels/GetHotel/${id}`,
                            success: function (response) {
                                $scope.filteredRooms = response.rooms;
                                $scope.$apply();

                            }
                        });
                    },
                    getHotelByCity(city?: string) {
                        var link;
                        if (city) {
                            link = `https://${window.location.host}/api/Hotels/GetHotels?city=${city}`
                        } else {
                            link = `https://${window.location.host}/api/Hotels/GetAll`
                        }

                        $.ajax({
                            type: "GET",
                            url: link,
                            success: function (response) {
                                $scope.hotels = response;
                                $scope.$apply();
                            }
                        });
                    },

                    getCities() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Hotels/GetCities`,
                            success: function (response) {
                                $scope.cities = response;
                                $scope.$apply();
                            }
                        });
                    },

                    getAllRooms() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Rooms/GetAll`,
                            success: function (response) {
                                $scope.Rooms = response;
                                $scope.$apply();
                            }
                        });
                    },
                    getRoomById(id: number) {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Rooms/GetRoom/${id}`,
                            success: function (response) {
                                console.log(response)
                            }
                        });
                    },
                    getAvailableRooms(dateFrom: string, dateTo: string) {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Rooms/GetAvailableRooms?from=${dateFrom}&to=${dateTo}`,
                            success: function (response) {
                                console.log(response)
                            }
                        });
                    },
                    getRoomTypes() {
                        $.ajax({
                            type: "GET",
                            url: `https://${window.location.host}/api/Rooms/GetRoomTypes`,
                            success: function (response) {
                                console.log(response)
                                $scope.roomTypes = response;
                                $scope.$apply();
                            }
                        });
                    },
                    getFilteredRooms(filter: FilterConfig) {
                        $.ajax({
                            type: "POST",
                            url: `https://${window.location.host}/api/Rooms/GetFiltered`,
                            data: JSON.stringify(filter),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                                $scope.filteredRooms = response;
                                console.log($scope.filteredRooms)
                                $scope.$apply();
                            }
                        });
                    },

                    filterByRoomType(id?: any) {
                        var link;
                        var filter: FilterConfig = {

                        };

                        if (id) {
                            filter.roomTypeId = id
                        } 

                        $.ajax({
                            type: "POST",
                            url: `https://${window.location.host}/api/Rooms/GetFiltered`,
                            data: JSON.stringify(filter),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                                console.log(response)
                                $scope.filteredRooms = response;
                                if (!id) {
                                    $scope.Rooms = response;
                                }
                                $scope.$apply();
                            }
                        });
                    },
                    apiBookRoom(bookConfig: BookingConfig) {
                        console.log("ჯავშანი")
                        $.ajax({
                            type: "POST",
                            url: `https://${window.location.host}/api/Booking`,
                            data: JSON.stringify(bookConfig),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                                alert("ოთახი წარმატებით დაიჯავშნა")
                            },
                            error: function (error) {
                                alert(error.statusText)
                            }
                        });
                    },

                    changeActiveTab(data: any) {
                        $scope.activeTab = data;
                    },

                    applyRoomsFilter() {
                        var formData = $('#filterForm').serializeArray();
                        console.log(formData);

                        var priceFrom, priceTo, roomType, checkIn, checkOut, guests;

                        var filter: FilterConfig = {
                        }

                        for (var val of formData) {
                            if (val.name == 'price-from' && Boolean(val.value)) {
                                filter.priceFrom = parseInt(val.value)
                            }

                            if (val.name == 'price-to' && Boolean(val.value)) {
                                filter.priceTo = parseInt(val.value)
                            }

                            if (val.name == 'room' && Boolean(val.value)) {
                                filter.roomTypeId = parseInt(val.value)
                            }

                            if (val.name == 'checkinfilter' && Boolean(val.value)) {
                                filter.checkIn = val.value
                            }

                            if (val.name == 'checkoutfilter' && Boolean(val.value)) {
                                filter.checkOut = val.value
                            }

                            if (val.name == 'adults' && Boolean(val.value)) {
                                filter.guestsCount = parseInt(val.value)
                            }
                        }


                        $scope.getFilteredRooms(filter)


                       
                    },

                    bookRoom(room: Room) {
                        var formData = $('#reservationform').serializeArray();
                        console.log(formData);
                        

                        let bookObj: BookingConfig = {
                            checkInDate: formData[0].value,
                            checkOutDate: formData[1].value,
                            customerId: "1",
                            customerName: formData[2].value,
                            customerPhone: formData[3].value,
                            isConfirmed: true,
                            roomId: room.id,
                        }

                        $scope.apiBookRoom(bookObj);
                    },

                    selectRoom(room: Room) {
                        $(window).scrollTop(0)
                        $scope.selectedForBooking = room;

                        $scope.relatedRooms = $scope.filteredRooms.filter((r) => {
                            return r.hotelId = room.hotelId
                        }).slice(0, 3);

                        console.log("related", $scope.relatedRooms, "rooms", $scope.Rooms)
                    },

                    selectHotel(hotel: Hotel) {
                        $(window).scrollTop(0);
                        var filter: FilterConfig = {
                            
                        }

                        $scope.getHotelById(hotel.id);
                    },

                    init: () => {
                        var Pages = {
                            Home: 0,
                            Rooms: 1,
                            Hotels: 2,
                            Details: 3
                        }
                        $scope.selectedForBooking = undefined;

                        $scope.webPages = Pages;
                        $scope.activeTab = Pages.Home;

                        $scope.getRoomTypes();
                        $scope.hotelsGetAll();
                        $scope.getAllRooms();
                    }
                })
                

            }
        ])
    }
}


(() => {
    var lobby = new LobbyClass();
})();
