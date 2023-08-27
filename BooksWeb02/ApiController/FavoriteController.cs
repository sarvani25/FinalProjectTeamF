using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.ApiController
{
    [ApiController]
    [Route("/api/Favorites")]
    public class FavoriteController : Controller
    {
        //IFavoriteService favoriteService;
        //public FavoriteController(IFavoriteService favoriteService)
        //{
        //    this.favoriteService = favoriteService;
        //}
        //[HttpGet("{userEmail}", Name = "SelectedUserRoute")]
        //public async Task<IActionResult> GetFavoriteByUserId(string userEmail)
        //{
        //    var favorite = await favoriteService.GetFavoriteByUserId(userEmail);



        //    if (favorite != null)
        //        return Ok(favorite); //Status 200
        //    else
        //        return NotFound(favorite);  //Status 404
        //}

        //[HttpGet("{id}", Name = "SelectedFavoriteRoute")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var favorite = await favoriteService.GetFavoriteById(id);



        //    if (favorite != null)
        //        return Ok(favorite); //Status 200
        //    else
        //        return NotFound(favorite);  //Status 404
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddFavourite(Favorite favorite)
        //{
        //    await favoriteService.AddFavorite(favorite);



        //    return CreatedAtAction(nameof(GetById), new { Id = favorite.Id }, favorite);
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFavorite(int id)
        //{
        //    await favoriteService.DeleteFavorite(id);



        //    return NoContent(); //204
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateFavorite(string id, Favorite vm)
        //{
        //    var favorite = new Favorite()
        //    {
        //        Id = vm.Id,

        //        BookId = vm.BookId,
        //        Status = vm.Status,
        //    };



        //    var result = await favoriteService.UpdateFavorite(favorite);



        //    return Accepted(result);
        //}
    }
}
