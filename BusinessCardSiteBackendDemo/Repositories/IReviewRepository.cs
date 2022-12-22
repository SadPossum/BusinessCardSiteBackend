using BusinessCardSiteBackendDemo.Models;

namespace BusinessCardSiteBackendDemo.Repositories
{
    public interface IReviewRepository
    {
        Task<Review?> GetReviewAsync(int id);
        Task<IEnumerable<Review?>> GetAllReviewsAsync();
        Task<int> AddReviewAsync(Review review);
        Task<int> UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
    }
}
