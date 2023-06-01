using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Data
{
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }

        [ForeignKey(nameof(RoomId))]
        public int RoomId { get; set; }
    }
}
