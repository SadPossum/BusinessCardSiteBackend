using BusinessCardSiteBackend.Models.DataModels;
using BusinessCardSiteBackend.Models.LogicModels;

namespace BusinessCardSiteBackend.Repositories
{
    public interface IReviewRepository
    {
        Task<(IEnumerable<Review> Entries, int Count, int TotalCount)> GetReviewsAsync(
            string? authorNameSearch = null,
            PaginationFilter? paginationFilter = null,
            List<SortCriteria>? sortCriterias = null);

        Task<Review?> GetReviewAsync(int id);

        Task<int> AddReviewAsync(Review review);

        Task<int> UpdateReviewAsync(Review review);

        Task DeleteReviewAsync(int id);
    }
}
