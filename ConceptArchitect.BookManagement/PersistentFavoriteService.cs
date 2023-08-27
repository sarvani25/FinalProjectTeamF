using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentFavoriteService : IFavoriteService
    {
        IRepository<Favorite, int> repository;

        public PersistentFavoriteService(IRepository<Favorite, int> repository)
        {
            this.repository = repository;
        }

        public async Task<Favorite> AddFavorite(Favorite favorite)
        {
            if (favorite == null)
            {
                throw new InvalidDataException("Favorite cannot be null");
            }
            if (string.IsNullOrEmpty(favorite.Id.ToString()))
            {
                favorite.Id = await GenerateFavoriteId();
            }
            return await repository.Add(favorite);
        }

        private async Task<int> GenerateFavoriteId()
        {
            var favorite = await repository.GetAll();
            if (favorite.Count == 0)
            {
                return 1;
            }

            return favorite.Count + 1;
        }

        public async Task DeleteFavorite(int id)
        {
            await repository.Delete(id);
        }

        public async Task<List<Favorite>> GetAllFavorites()
        {
            return await repository.GetAll();
        }

        public async Task<Favorite> GetFavoriteById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<Favorite>> GetFavoriteByUserId(string userId)
        {
            return await repository.GetAll(r => r.UserEmail == userId);
        }

        public async Task<List<Favorite>> SearchFavorites(string term)
        {
            term = term.ToLower();
            return await repository.GetAll(r => r.Status.ToLower().Contains(term));
        }

        public async Task<Favorite> UpdateFavorite(Favorite favorite)
        {
            return await repository.Update(favorite, (old, newDetails) =>
            {
                old.Id = newDetails.Id;
                old.UserEmail = newDetails.UserEmail;
                old.Status = newDetails.Status;
                old.BookId = newDetails.BookId;
            });
        }
    }
}
