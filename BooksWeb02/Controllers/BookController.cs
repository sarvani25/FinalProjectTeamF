using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class BookController:Controller
    {
        IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }


        public async Task<ViewResult> Index()
        {
            var books = await bookService.GetAllBooks();
            return View(books);
        }

        public async Task<ViewResult> Details(string id)
        {
            var author = await bookService.GetBookById(id);
            return View(author);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Book());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
            
        }

        [HttpGet]
        public async Task<ViewResult> Edit(string id)
        {
            var book = await bookService.GetBookById(id);
            var vm = new EditBookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId,
                CoverPhoto = book.CoverPhoto
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditBookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var book = new Book()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    Description = vm.Description,
                    AuthorId = vm.AuthorId,
                    CoverPhoto = vm.CoverPhoto
                };
                await bookService.UpdateBook(book);

                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            await bookService.DeleteBook(id);
            //Index();
            return RedirectToAction("Index");
            
        }

        

        //[HttpPost]
        //public async Task<ActionResult> Delete()
        //{
            
            
        //}

    }
}
