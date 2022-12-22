using BusinessCardSiteBackendDemo.Models;

namespace BusinessCardSiteBackendDemo.Repositories
{
    public interface IReviewRepository
    {
        Review GetReview(int id);
        IEnumerable<Review> GetAllReviews();
        int AddReview(Review review);
        int UpdateReview(Review review);
        void DeleteReview(int id);
    }
}
