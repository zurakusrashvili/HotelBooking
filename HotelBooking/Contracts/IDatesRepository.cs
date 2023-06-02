using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Contracts
{
    public interface IDatesRepository : IGenericRepository<BookedDate>
    {
        List<BookedDate> GenerateMockAvailableDates(int roomId, DateTime startDate, DateTime endDate);
    }
}
