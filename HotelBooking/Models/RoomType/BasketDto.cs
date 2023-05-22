using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models.Basket
{
    public class BasketDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
