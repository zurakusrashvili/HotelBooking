using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Data
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(HotelId))]
        public int HotelId { get; set; }

        public int PricePerNight { get; set; }

        public bool Available { get; set; }

        public int MaximumGuests { get; set; }

        public virtual IList<BookedDate> BookedDates { get; set; }

        public virtual IList<Image> Images { get; set; }

    }
}
