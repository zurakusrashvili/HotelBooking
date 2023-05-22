using HotelBooking.Data;

namespace HotelBooking.Contracts
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);

    }
}
