using BusinessCardSiteBackendDemo.Data;
using BusinessCardSiteBackendDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessCardSiteBackendDemo.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Find(id) ?? new();
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public int AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review.Id;
        }

        public int UpdateReview(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();
            return review.Id;
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
    }
}
