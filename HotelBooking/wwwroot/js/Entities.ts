interface ILobbyScope extends ng.IScope {
    hotels: Hotel[],
    selectedHotel: Hotel,
    Rooms: Room[],

    cities: any[],

    apiBookRoom: (bookObj: BookingConfig) => void,
    hotelsGetAll: () => void,
    getHotelById: (id: number) => void,
    getHotelByCity: (city: string) => void,
    getCities: () => void,

    getAllRooms: () => void,
    getRoomById: (id: number) => void,
    getAvailableRooms: (dateFrom: string, dateTo: string) => void,
    getRoomTypes: () => void,
    getFilteredRooms: (filter: FilterConfig) => void,
    filterByRoomType: (id?: any) => void;
    activeTab: number
    webPages: any
    selectedForBooking: Room;
    relatedRooms: Room[];
    applyRoomsFilter: () => void;
    //types
    roomTypes: { id: number, name: string }[]
    filteredRooms: Room[]

    selectHotel: () => {}
}

interface BookingConfig {
    roomId: number,
    checkInDate: string,
    checkOutDate: string,
    isConfirmed: boolean,
    customerName: string,
    customerId: string,
    customerPhone: string
}


interface FilterConfig {
    roomTypeId?: number,
    priceFrom?: number,
    priceTo?: number,
    guestsCount?: number,
    checkIn?: string,
    checkOut?: string
}

interface Hotel {
    id: number,
    name: string,
    address: string,
    city: string,
    featuredImage: string,
    rooms: Room[],
}

interface Room {
    id: number,
    name: string,
    hotelId: number,
    pricePerNight: number,
    available: boolean,
    maximumGuests: number,
    roomTypeid: number,
    bookedDates: any[],
    images: any[]
}