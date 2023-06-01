using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Contracts
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);

    }
}
