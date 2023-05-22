using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models.Basket
{
    public class BasketPostDto
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
