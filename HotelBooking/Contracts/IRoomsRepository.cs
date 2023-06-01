using HotelBooking.Data;
using HotelBooking.Models.Rooms;

namespace HotelBooking.Contracts
{
    public interface IRoomsRepository : IGenericRepository<Room>
    {
        //Task<List<Room>> GetFiltered(bool? vegeterian, bool? nuts, int? spiciness, int? categoryId);
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task<IList<Room>> GetAvailableRooms(DateTime fromDate, DateTime toDate);
    }
}
