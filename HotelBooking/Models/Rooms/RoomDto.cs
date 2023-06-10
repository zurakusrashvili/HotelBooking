using HotelBooking.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public decimal PricePerNight { get; set; }
        public bool Available { get; set; }
        public int MaximumGuests { get; set; }
        public int RoomTypeId { get; set; }
        public virtual IList<BookedDate> BookedDates { get; set; }
        public virtual IList<Image> Images { get; set; }
    }
}
