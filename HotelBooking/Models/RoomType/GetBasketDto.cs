using HotelBooking.Data;

namespace HotelBooking.Models.Basket
{
    public class GetBasketDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product Product { get; set; }
    }
}
