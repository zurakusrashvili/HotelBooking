using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Data;

namespace HotelBooking.Repository
{
    public class RoomRepository : GenericRepository<Room>, IRoomsRepository
    {
        private readonly HotelBookingDbContext _context;

        public RoomRepository(HotelBookingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.FindAsync(id); 
        }

        //public async Task<Category> GetDetails(int id)
        //{
        //    return await _context.Categories
        //        .Include(q => q.Products)
        //        .FirstOrDefaultAsync(q => q.Id == id);
        //}
    }
}
