using BusinessCardSiteBackend.Data;
using BusinessCardSiteBackend.Extensions;
using BusinessCardSiteBackend.Models.DataModels;
using BusinessCardSiteBackend.Models.LogicModels;
using Microsoft.EntityFrameworkCore;

namespace BusinessCardSiteBackend.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ReviewRepository> _logger;

        public ReviewRepository(ApplicationDbContext context, ILogger<ReviewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<(IEnumerable<Review> Entries, int Count, int TotalCount)> GetReviewsAsync(
            string? authorNameSearch = null,
            PaginationFilter? paginationFilter = null,
            List<SortCriteria>? sortCriterias = null)
        {
            _logger.LogInformation("Retrieving all reviews");

            IQueryable<Review> query = _context.Reviews.AsQueryable();
            int totalCount = await _context.Reviews.CountAsync();

            if (authorNameSearch != null)
            {
                query = query.Where(a => a.AuthorName.Contains(authorNameSearch));
            }

            if (paginationFilter != null)
            {
                query = query
                    .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                    .Take(paginationFilter.PageSize);
            }

            if (sortCriterias != null)
            {
                query = query.SortBy(sortCriterias);
            }

            int count = await query.CountAsync();

            IEnumerable<Review> entries = await query.ToListAsync();
            return (entries, count, totalCount);
        }

        public async Task<Review?> GetReviewAsync(int id)
        {
            _logger.LogInformation($"Retrieving review with id {id}");
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<int> AddReviewAsync(Review review)
        {
            _logger.LogInformation("Adding review");
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task<int> UpdateReviewAsync(Review review)
        {
            _logger.LogInformation($"Updating review with id {review.Id}");
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task DeleteReviewAsync(int id)
        {
            _logger.LogInformation($"Deleting review with id {id}");
            Review? review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
