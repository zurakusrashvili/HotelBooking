using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Data
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public int RoomTypeId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public int HotelId { get; set; }

        public decimal PricePerNight { get; set; }

        public bool Available { get; set; }

        public int MaximumGuests { get; set; }
        public List<DateTime> AvailableDates { get; set; }

        public virtual IList<string> Images { get; set; }

    }
}
