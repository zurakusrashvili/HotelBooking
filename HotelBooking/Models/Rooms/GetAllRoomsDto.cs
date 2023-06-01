using HotelBooking.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models.Rooms
{
    public class GetAllRoomsDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public decimal PricePerNight { get; set; }
        public bool Available { get; set; }
        public int MaximumGuests { get; set; }
        public string FeaturedImage { get; set; }
    }
}