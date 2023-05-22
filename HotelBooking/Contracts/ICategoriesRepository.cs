using HotelBooking.Data;

namespace HotelBooking.Contracts
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        Task<Category> GetDetails(int id);
    }
}
