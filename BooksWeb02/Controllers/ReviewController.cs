using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService reviewService;
        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        [HttpGet]
        public async Task<ViewResult> AddReview()
        {
            return View(new Review());
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                await reviewService.AddReview(review);
                return RedirectToAction("Details", "Book");
            }
            else
            {
                return View(review);
            }
        }
    }
}
