using HotelBooking.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool Available { get; set; }
        public int MaximumGuests { get; set; }
        public List<DateTime> AvailableDates { get; set; }
        public virtual IList<string> Images { get; set; }
    }
}
