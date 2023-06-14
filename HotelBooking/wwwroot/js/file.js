var LobbyClass = /** @class */ (function () {
    function LobbyClass() {
        var lobbyApp = angular.module("lobbyApp", ['ui.bootstrap']);
        lobbyApp.controller("lobbyController", [
            "$scope", "$http", function ($scope, $http) {
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
                    hotelsGetAll: function () {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Hotels/GetAll"),
                            success: function (response) {
                                $scope.hotels = response;
                                $scope.getCities();
                                console.log($scope.hotels);
                            }
                        });
                    },
                    getHotelById: function (id) {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Hotels/GetHotel/").concat(id),
                            success: function (response) {
                                $scope.filteredRooms = response.rooms;
                                $scope.$apply();
                            }
                        });
                    },
                    getHotelByCity: function (city) {
                        var link;
                        if (city) {
                            link = "https://".concat(window.location.host, "/api/Hotels/GetHotels?city=").concat(city);
                        }
                        else {
                            link = "https://".concat(window.location.host, "/api/Hotels/GetAll");
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
                    getCities: function () {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Hotels/GetCities"),
                            success: function (response) {
                                $scope.cities = response;
                                $scope.$apply();
                            }
                        });
                    },
                    getAllRooms: function () {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Rooms/GetAll"),
                            success: function (response) {
                                $scope.Rooms = response;
                                $scope.$apply();
                            }
                        });
                    },
                    getRoomById: function (id) {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Rooms/GetRoom/").concat(id),
                            success: function (response) {
                                console.log(response);
                            }
                        });
                    },
                    getAvailableRooms: function (dateFrom, dateTo) {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Rooms/GetAvailableRooms?from=").concat(dateFrom, "&to=").concat(dateTo),
                            success: function (response) {
                                console.log(response);
                            }
                        });
                    },
                    getRoomTypes: function () {
                        $.ajax({
                            type: "GET",
                            url: "https://".concat(window.location.host, "/api/Rooms/GetRoomTypes"),
                            success: function (response) {
                                console.log(response);
                                $scope.roomTypes = response;
                                $scope.$apply();
                            }
                        });
                    },
                    getFilteredRooms: function (filter) {
                        $.ajax({
                            type: "POST",
                            url: "https://".concat(window.location.host, "/api/Rooms/GetFiltered"),
                            data: JSON.stringify(filter),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                                $scope.filteredRooms = response;
                                console.log($scope.filteredRooms);
                                $scope.$apply();
                            }
                        });
                    },
                    filterByRoomType: function (id) {
                        var link;
                        var filter = {};
                        if (id) {
                            filter.roomTypeId = id;
                        }
                        $.ajax({
                            type: "POST",
                            url: "https://".concat(window.location.host, "/api/Rooms/GetFiltered"),
                            data: JSON.stringify(filter),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                                console.log(response);
                                $scope.filteredRooms = response;
                                if (!id) {
                                    $scope.Rooms = response;
                                }
                                $scope.$apply();
                            }
                        });
                    },
                    apiBookRoom: function (bookConfig) {
                        console.log("ჯავშანი");
                        $.ajax({
                            type: "POST",
                            url: "https://".concat(window.location.host, "/api/Booking"),
                            data: JSON.stringify(bookConfig),
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            dataType: 'json',
                            success: function (response) {
                                alert("ოთახი წარმატებით დაიჯავშნა");
                            },
                            error: function (error) {
                                alert(error.statusText);
                            }
                        });
                    },
                    changeActiveTab: function (data) {
                        $scope.activeTab = data;
                    },
                    applyRoomsFilter: function () {
                        var formData = $('#filterForm').serializeArray();
                        console.log(formData);
                        var priceFrom, priceTo, roomType, checkIn, checkOut, guests;
                        var filter = {};
                        for (var _i = 0, formData_1 = formData; _i < formData_1.length; _i++) {
                            var val = formData_1[_i];
                            if (val.name == 'price-from' && Boolean(val.value)) {
                                filter.priceFrom = parseInt(val.value);
                            }
                            if (val.name == 'price-to' && Boolean(val.value)) {
                                filter.priceTo = parseInt(val.value);
                            }
                            if (val.name == 'room' && Boolean(val.value)) {
                                filter.roomTypeId = parseInt(val.value);
                            }
                            if (val.name == 'checkinfilter' && Boolean(val.value)) {
                                filter.checkIn = val.value;
                            }
                            if (val.name == 'checkoutfilter' && Boolean(val.value)) {
                                filter.checkOut = val.value;
                            }
                            if (val.name == 'adults' && Boolean(val.value)) {
                                filter.guestsCount = parseInt(val.value);
                            }
                        }
                        $scope.getFilteredRooms(filter);
                    },
                    bookRoom: function (room) {
                        var formData = $('#reservationform').serializeArray();
                        console.log(formData);
                        var bookObj = {
                            checkInDate: formData[0].value,
                            checkOutDate: formData[1].value,
                            customerId: "1",
                            customerName: formData[2].value,
                            customerPhone: formData[3].value,
                            isConfirmed: true,
                            roomId: room.id,
                        };
                        $scope.apiBookRoom(bookObj);
                    },
                    selectRoom: function (room) {
                        $(window).scrollTop(0);
                        $scope.selectedForBooking = room;
                        $scope.bookedDatesForSelectedRoom = [];
                        $scope.selectedForBooking.bookedDates.forEach(function (date) {
                            $scope.bookedDatesForSelectedRoom.push(date.date.split('T')[0]);
                        });
                        $scope.relatedRooms = $scope.filteredRooms.filter(function (r) {
                            return r.hotelId = room.hotelId;
                        }).slice(0, 3);
                        console.log("related", $scope.relatedRooms, "rooms", $scope.Rooms);
                    },
                    selectHotel: function (hotel) {
                        $(window).scrollTop(0);
                        var filter = {};
                        $scope.getHotelById(hotel.id);
                    },
                    init: function () {
                        var Pages = {
                            Home: 0,
                            Rooms: 1,
                            Hotels: 2,
                            Details: 3
                        };
                        $scope.selectedForBooking = undefined;
                        $scope.webPages = Pages;
                        $scope.activeTab = Pages.Home;
                        $scope.getRoomTypes();
                        $scope.hotelsGetAll();
                        $scope.getAllRooms();
                    }
                });
            }
        ]);
    }
    return LobbyClass;
}());
(function () {
    var lobby = new LobbyClass();
})();
//# sourceMappingURL=file.js.map