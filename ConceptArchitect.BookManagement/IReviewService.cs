using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task<Review> AddReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task DeleteReview(int id);
        Task<List<Review>> SearchReview(string term);
        Task<List<Review>> GetReviewsByBookId(string bookId);

    }
}
