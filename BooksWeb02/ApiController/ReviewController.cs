using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.ApiController
{
    [ApiController]
    [Route("/api/reviews")]
    public class ReviewController : Controller
    {
        IReviewService reviewService;
        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        [HttpGet]
        public async Task<List<Review>> GetAllReviews()
        {
            var reviews = await reviewService.GetAllReviews();
            return reviews;
        }// 
        [HttpGet("{id}", Name = "SelectedReviewRoute")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await reviewService.GetReviewById(id);



            if (author != null)
                return Ok(author); //Status 200
            else
                return NotFound(author);  //Status 404
        }



        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            await reviewService.AddReview(review);



            return CreatedAtAction(nameof(GetById), new { Id = review.Id }, review);
        }
    }
}
