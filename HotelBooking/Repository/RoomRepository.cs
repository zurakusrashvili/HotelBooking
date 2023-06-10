using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Data;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models.Filters;

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
                    .Include(r => r.BookedDates)
                    .Include(r => r.Images)
                    .ToListAsync();
        }

        public async Task<List<RoomType>> GetRoomTypes()
        {
            return await _context.RoomTypes
                .ToListAsync();
        }

        //public async Task<Room> GetRoomById(int id)
        //{
        //    return await _context.Rooms
        //        .Include(r => r.Images)
        //        .Where(r => r.Id == id)
        //        .Include(r => r.AvailableDates.Take(60))
        //        .Where(r => r.Id == id)
        //        .FirstAsync();
        //}

        public async Task<Room> GetRoomById(int id)
        {
            var currentDate = DateTime.Now;
            var futureDate = currentDate.AddDays(60);

            return await _context.Rooms
                .Include(r => r.Images)
                .Where(r => r.Id == id)
                .Include(r => r.BookedDates)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Room>> GetFiltered(RoomFilter filter = null)
        {
            var query = _context.Rooms
                .Include(r => r.Images)
                .Include(r => r.BookedDates)
                .AsQueryable();

            if (filter?.RoomTypeId != null)
                query = query.Where(r => r.RoomTypeId == filter.RoomTypeId);

            if (filter?.PriceFrom != null)
                query = query.Where(r => r.PricePerNight >= filter.PriceFrom);

            if (filter?.PriceTo != null)
                query = query.Where(r => r.PricePerNight <= filter.PriceTo);

            if (filter?.MaximumGuests != null)
                query = query.Where(r => r.MaximumGuests >= filter.MaximumGuests);

            if(filter?.CheckIn != null && filter?.CheckOut != null)
            {
                query = query.Where(room =>
                    !room.BookedDates.Any(ad => ad.Date >= filter.CheckIn && ad.Date <= filter.CheckOut)
                );
            }

            return query.ToList();
        }

        //public async Task<IList<Room>> GetAvailableRooms()
        //{
        //    //var rooms = await _context.Rooms.ToListAsync();

        //    //foreach (var room in rooms)
        //    //{
        //    //    await _context.Entry(room)
        //    //        .Collection(r => r.Images)
        //    //        .LoadAsync();
        //    //}
        //    //return rooms;

        //    return await _context.Rooms
        //            .Include(r => r.BookedDates)
        //            .ToListAsync();

        //}

        //public async Task<Category> GetDetails(int id)
        //{
        //    return await _context.Categories
        //        .Include(q => q.Products)
        //        .FirstOrDefaultAsync(q => q.Id == id);
        //}
    }
}
