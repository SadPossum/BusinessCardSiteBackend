using BusinessCardSiteBackendDemo.Models;
using BusinessCardSiteBackendDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardSiteBackendDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repository;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewRepository repository, ILogger<ReviewController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> Get()
        {
            _logger.LogInformation("Retrieving all reviews");
            return Ok(await _repository.GetAllReviewsAsync());
        }

        // GET review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> Get(int id)
        {
            _logger.LogInformation("Retrieving review with id {0}", id);
            var review = await _repository.GetReviewAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST review
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Review review)
        {
            _logger.LogInformation("Adding review");
            var reviewId = await _repository.AddReviewAsync(review);
            return CreatedAtAction(nameof(Get), new { id = reviewId }, reviewId);
        }

        // PUT review/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] Review review)
        {
            _logger.LogInformation("Updating review with id {0}", id);
            var existingReview = await _repository.GetReviewAsync(id);
            if (existingReview == null)
            {
                return NotFound();
            }

            review.Id = id;
            var reviewId = await _repository.UpdateReviewAsync(review);
            return Ok(reviewId);
        }

        // DELETE review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting review with id {0}", id);
            await _repository.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
