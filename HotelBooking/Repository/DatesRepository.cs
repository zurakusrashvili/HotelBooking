using HotelBooking.Contracts;
using HotelBooking.Data;

namespace HotelBooking.Repository
{
    public class DatesRepository : GenericRepository<BookedDate>, IDatesRepository
    {
        private readonly HotelBookingDbContext _context;

        public DatesRepository(HotelBookingDbContext context) : base(context)
        {
            this._context = context;
        }
        public List<BookedDate> GenerateMockAvailableDates(int roomId, DateTime startDate, DateTime endDate)
        {
            List<BookedDate> availableDates = new List<BookedDate>();
          
            
                DateTime currentDate = startDate;

                while (currentDate <= endDate)
                {
                    BookedDate availableDate = new BookedDate
                    {
                        Date = currentDate.Date,
                        RoomId = roomId,
                    };

                    availableDates.Add(availableDate);
                    currentDate = currentDate.AddDays(1);
                }
            

            return availableDates;
        }
    }
}
