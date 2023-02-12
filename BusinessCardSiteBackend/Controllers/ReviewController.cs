using BusinessCardSiteBackend.Models.ApiModels;
using BusinessCardSiteBackend.Models.DataModels;
using BusinessCardSiteBackend.Repositories;
using BusinessCardSiteBackend.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardSiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repository;
        private readonly ILogger<ReviewController> _logger;
        private readonly ReviewValidator _reviewValidator;

        public ReviewController(IReviewRepository repository, ILogger<ReviewController> logger, ReviewValidator reviewValidator)
        {
            _repository = repository;
            _logger = logger;
            _reviewValidator = reviewValidator;
        }

        // GET review
        [HttpGet]
        public async Task<ListResponse<Review>> Get([FromQuery] ListReviewRequest request)
        {
            _logger.LogInformation($"Retrieving reviews with parameters");

            (IEnumerable<Review> entries, int count, int totalCount) = await _repository.GetReviewsAsync(
                request.AuthorName,
                request.Pagination,
                request.Sort);

            return new()
            {
                items = entries,
                ItemsCount = count,
                TotalItemsCount = totalCount,
            };
        }

        // GET review/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Retrieving review with id {id}");

            Review? review = await _repository.GetReviewAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"{nameof(Review)} with id {id} not found");
            }

            return Ok(review);
        }

        // POST review
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Review review)
        {
            _logger.LogInformation("Adding review");

            ValidationResult validation = _reviewValidator.Validate(review);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            int reviewId = await _repository.AddReviewAsync(review);

            return CreatedAtAction(nameof(Get), new { id = reviewId }, reviewId);
        }

        // PUT review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Review review)
        {
            _logger.LogInformation($"Updating review with id {id}");

            Review? existingReview = await _repository.GetReviewAsync(id);

            if (existingReview == null)
            {
                throw new KeyNotFoundException($"{nameof(Review)} with id {id} not found");
            }

            review.Id = id;
            int reviewId = await _repository.UpdateReviewAsync(review);

            return NoContent();
        }

        // DELETE review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Deleting review with id {id}");

            await _repository.DeleteReviewAsync(id);

            return NoContent();
        }
    }
}
