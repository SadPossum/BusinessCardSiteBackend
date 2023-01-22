using BusinessCardSiteBackend.Data;
using BusinessCardSiteBackend.Models;
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

        public async Task<Review?> GetReviewAsync(int id)
        {
            _logger.LogInformation("Retrieving review with id {0}", id);
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review?>> GetAllReviewsAsync()
        {
            _logger.LogInformation("Retrieving all reviews");
            return await _context.Reviews.ToListAsync();
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
            _logger.LogInformation("Updating review with id {0}", review.Id);
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task DeleteReviewAsync(int id)
        {
            _logger.LogInformation("Deleting review with id {0}", id);
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
