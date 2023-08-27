using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.ApiController
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorController : Controller
    {
        IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }



        [HttpGet]
        public async Task<List<Author>> GetAllAuthors()
        {
            var authors = await authorService.GetAllAuthors();
            return authors;
        }



        [HttpGet("{id}", Name = "SelectedAuthorRoute")]   //  /api/authors/{id}
        public async Task<IActionResult> GetAuthorById(string id)
        {
            var author = await authorService.GetAuthorById(id);



            if (author != null)
                return Ok(author); //Status 200
            else
                return NotFound(author);  //Status 404
        }





        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            await authorService.AddAuthor(author);



            return CreatedAtAction(nameof(GetAuthorById), new { Id = author.Id }, author);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            await authorService.DeleteAuthor(id);



            return NoContent(); //204
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(string id, EditAuthorViewModel vm)
        {
            var author = new Author()
            {
                Id = vm.Id,
                Name = vm.Name,
                Biography = vm.Biography,
                Photo = vm.Photo,
                Email = vm.Email
            };



            var result = await authorService.UpdateAuthor(author);



            return Accepted(result);
        }
    }
}
