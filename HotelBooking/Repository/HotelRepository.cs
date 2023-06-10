using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Data;

namespace HotelBooking.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelBookingDbContext _context;

        public HotelRepository(HotelBookingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
           return await _context.Hotels
                .Include(r => r.Rooms)
                .ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _context.Hotels
                .Include(q => q.Rooms)
                .ThenInclude(q => q.Images)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Hotel>> GetHotelByCity(string city)
        {
            return await _context.Hotels
                .Where(h => h.City.ToLower() == city.ToLower())
                .ToListAsync();
        }

        public async Task<List<string>> GetCities()
        {
            return await  _context.Hotels
                .Select(h => h.City)
                .Distinct()
                .ToListAsync();
        }

       
    }
}
