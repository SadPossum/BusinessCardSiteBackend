using BusinessCardSiteBackendDemo.Data;
using BusinessCardSiteBackendDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessCardSiteBackendDemo.Repositories
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

        public Review GetReview(int id)
        {
            _logger.LogInformation("Retrieving review with id {0}", id);
            return _context.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            _logger.LogInformation("Retrieving all reviews");
            return _context.Reviews.ToList();
        }

        public int AddReview(Review review)
        {
            _logger.LogInformation("Adding review");
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review.Id;
        }

        public int UpdateReview(Review review)
        {
            _logger.LogInformation("Updating review with id {0}", review.Id);
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();
            return review.Id;
        }

        public void DeleteReview(int id)
        {
            _logger.LogInformation("Deleting review with id {0}", id);
            var review = _context.Reviews.Find(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
    }
}
