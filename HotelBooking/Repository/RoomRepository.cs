using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Data;
using Microsoft.AspNetCore.Mvc;

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
            return await _context.Rooms
                .ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms
                .Include(r => r.Images)
                .Where(r => r.Id == id)
                .Include(r => r.AvailableDates.Take(60))
                .Where(r => r.Id == id)
                .FirstAsync();
        }

        public async Task<IList<Room>> GetAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            //var rooms = await _context.Rooms.ToListAsync();

            //foreach (var room in rooms)
            //{
            //    await _context.Entry(room)
            //        .Collection(r => r.Images)
            //        .LoadAsync();
            //}
            //return rooms;

            return await _context.Rooms
                    .Include(r => r.AvailableDates)
                    .Where(r => r.Available && r.AvailableDates.Any(ad => ad.Date >= fromDate && ad.Date <= toDate))
                    .ToListAsync();

        }

        //public async Task<Category> GetDetails(int id)
        //{
        //    return await _context.Categories
        //        .Include(q => q.Products)
        //        .FirstOrDefaultAsync(q => q.Id == id);
        //}
    }
}
