using HotelBooking.Data;

namespace HotelBooking.Models.Hotels
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string FeaturedImage { get; set; }
        public virtual IList<Room> Rooms { get; set; }

    }
}
