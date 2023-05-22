using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Data;

namespace HotelBooking.Repository
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        private readonly HotelBookingDbContext _context;

        public BasketRepository(HotelBookingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Basket> GetDetails(int id)
        {
            return await _context.Basket
                .Include(q => q.Product)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Product> GetProductDetails(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Basket>> GetBasketsAsync()
        {
            return await _context.Basket.Include(q => q.Product).ToListAsync();
        }

        public async Task<Basket> GetBasketWithProductId(int id)
        {
            return await _context.Basket.FirstOrDefaultAsync(q => q.ProductId == id);
        }

        public async Task DeleteProductFromBasket(Basket basket)
        {
            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
        }

    }
}
