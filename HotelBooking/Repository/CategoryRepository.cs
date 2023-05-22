using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Data;

namespace HotelBooking.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoriesRepository
    {
        private readonly HotelBookingDbContext _context;

        public CategoryRepository(HotelBookingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Category> GetDetails(int id)
        {
            return await _context.Categories
                .Include(q => q.Products)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
