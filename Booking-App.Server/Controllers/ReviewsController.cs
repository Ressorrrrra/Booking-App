using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{reviewId}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReview(int reviewId)
        {
            var review = await _reviewService.GetReview(reviewId);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> PostReview(CreateReviewRequest review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _reviewService.CreateReview(review);
            return Created();
        }      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            bool result = await _reviewService.DeleteReview(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] CreateReviewRequest review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _reviewService.UpdateReview(review, id);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
