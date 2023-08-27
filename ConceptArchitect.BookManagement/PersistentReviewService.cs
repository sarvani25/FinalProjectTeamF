using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentReviewService : IReviewService
    {
        IRepository<Review, int> repository;

        public PersistentReviewService(IRepository<Review, int> repository)
        {
            this.repository = repository;
        }

        public async Task<Review> AddReview(Review review)
        {
            if (review == null)
                throw new InvalidDataException("Review can't be  null");
            if (string.IsNullOrEmpty(review.Id.ToString()))
            {
                review.Id = await GenerateReviewId();
            }
            return await repository.Add(review);

        }

        private async Task<int> GenerateReviewId()
        {
            var reviews = await repository.GetAll();
            if (reviews.Count == 0)
            {
                return 1;
            }

            return reviews.Count + 1;
        }

        public async Task DeleteReview(int id)
        {
            await repository.Delete(id);
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await repository.GetAll();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<Review>> SearchReview(string term)
        {
            term = term.ToLower();
            return await repository.GetAll(r => r.Title.ToLower().Contains(term) || r.Details.ToLower().Contains(term));
        }

        public async Task<Review> UpdateReview(Review review)
        {
            return await repository.Update(review, (old, newDetails) =>
            {
                old.Id = newDetails.Id;
                old.UserEmail = newDetails.UserEmail;
                old.bookId = newDetails.bookId;
                old.Rating = newDetails.Rating;
                old.Title = newDetails.Title;
                old.Details = newDetails.Details;
            });
        }

        public async Task<List<Review>> GetReviewsByBookId(string bookId)
        {
            return await repository.GetAll(r => r.bookId == bookId);
        }
    }
}
