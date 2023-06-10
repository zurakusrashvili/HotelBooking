using HotelBooking.Data;
using HotelBooking.Models.Filters;
using HotelBooking.Models.Rooms;

namespace HotelBooking.Contracts
{
    public interface IRoomsRepository : IGenericRepository<Room>
    {
        //Task<List<Room>> GetFiltered(bool? vegeterian, bool? nuts, int? spiciness, int? categoryId);
        Task<List<Room>> GetAllRooms();
        Task<List<RoomType>> GetRoomTypes();
        Task<Room> GetRoomById(int id);

        Task<List<Room>> GetFiltered(RoomFilter filter);   
        //Task<IList<Room>> GetAvailableRooms();
    }
}
