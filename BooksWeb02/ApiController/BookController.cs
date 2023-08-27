using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.ApiController
{
    [ApiController]
    [Route("/api/books")]
    public class BookController : Controller
    {
        IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }



        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            var books = await bookService.GetAllBooks();
            return books;
        }



        [HttpGet("{id}", Name = "SelectedBookRoute")]   //  /api/books/{id}
        public async Task<IActionResult> GetBookById(string id)
        {
            var book = await bookService.GetBookById(id);



            if (book != null)
                return Ok(book); //Status 200
            else
                return NotFound(book);  //Status 404
        }





        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await bookService.AddBook(book);



            return CreatedAtAction(nameof(GetBookById), new { Id = book.Id }, book);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await bookService.DeleteBook(id);



            return NoContent(); //204
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(string id, EditBookViewModel vm)
        {
            var book = new Book()
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                CoverPhoto = vm.CoverPhoto,
                AuthorId = vm.AuthorId
            };



            var result = await bookService.UpdateBook(book);



            return Accepted(result);
        }
    }
}
