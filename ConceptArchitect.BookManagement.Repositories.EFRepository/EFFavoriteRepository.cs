using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.EFRepository
{
    public class EFFavoriteRepository : IRepository<Favorite, int>
    {
        BMSContext context;
        public EFFavoriteRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<Favorite> Add(Favorite entity)
        {
            context.Favorites.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var favorite = await GetById(id);
            context.Favorites.Remove(favorite);
            await context.SaveChangesAsync();
        }

        public async Task<List<Favorite>> GetAll()
        {
            await Task.CompletedTask;
            return context.Favorites.ToList();
        }

        public async Task<List<Favorite>> GetAll(Func<Favorite, bool> predicate)
        {
            await Task.CompletedTask;
            var query = from favorite in context.Favorites
                        where predicate(favorite)
                        select favorite;
            return query.ToList();
        }

        public async Task<Favorite> GetById(int id)
        {
            await Task.CompletedTask;
            return context.Favorites.FirstOrDefault(favorite => favorite.Id == id);
        }

        public async Task<Favorite> Update(Favorite entity, Action<Favorite, Favorite> mergeOldNew)
        {
            var favorite = await GetById(entity.Id);
            if (favorite != null)
            {
                mergeOldNew(favorite, entity);
                await context.SaveChangesAsync();
            }
            return favorite;
        }
    }
}
