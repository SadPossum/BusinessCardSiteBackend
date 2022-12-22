using BusinessCardSiteBackendDemo.Models;
using BusinessCardSiteBackendDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardSiteBackendDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewRepository _repository;

        public ReviewController(ReviewRepository repository)
        {
            _repository = repository;
        }

        // GET api/review
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get()
        {
            return Ok(_repository.GetAllReviews());
        }

        // GET api/review/5
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            var review = _repository.GetReview(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST api/review
        [HttpPost]
        public ActionResult<int> Post([FromBody] Review review)
        {
            var reviewId = _repository.AddReview(review);
            return CreatedAtAction(nameof(Get), new { id = reviewId }, reviewId);
        }

        // PUT api/review/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] Review review)
        {
            var existingReview = _repository.GetReview(id);
            if (existingReview == null)
            {
                return NotFound();
            }

            review.Id = id;
            var reviewId = _repository.UpdateReview(review);
            return Ok(reviewId);
        }

        // DELETE api/review/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _repository.GetReview(id);
            if (review == null)
            {
                return NotFound();
            }

            _repository.DeleteReview(id);
            return NoContent();
        }
    }
}
