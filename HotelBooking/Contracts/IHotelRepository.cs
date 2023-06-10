using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Contracts
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task<List<Hotel>> GetHotelByCity(string city);
        Task<List<string>> GetCities();

    }
}
