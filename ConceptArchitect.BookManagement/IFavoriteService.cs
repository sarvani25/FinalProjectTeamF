using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public interface IFavoriteService
    {
        /*  Task<List<Favorite>> GetAllFavorites();*/
        Task<Favorite> GetFavoriteById(int id);
        Task<Favorite> AddFavorite(Favorite favorite);
        Task<Favorite> UpdateFavorite(Favorite favorite);
        Task DeleteFavorite(int id);

        Task<List<Favorite>> SearchFavorites(string term);
        Task<List<Favorite>> GetFavoriteByUserId(string userId);

    }
}
