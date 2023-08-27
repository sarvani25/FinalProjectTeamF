﻿using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class AuthorController:Controller
    {
        IAuthorService authorService;

        public AuthorController(IAuthorService authors)
        {
            this.authorService = authors;
        }

        public async Task<ViewResult> Index()
        {
            var authors = await authorService.GetAllAuthors();

            return View(authors);
        }

        public async Task<ViewResult> Details(string id)
        {
            var author = await authorService.GetAuthorById(id);

            return View(author);
        }



        [HttpGet]
        public ViewResult Add()
        {
            return View(new Author());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Author author)
        {
            if (ModelState.IsValid)
            {
                await authorService.AddAuthor(author);

                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }

        }

        [HttpGet]
        public async Task<ViewResult> Edit(string id)
        {
            var author = await authorService.GetAuthorById(id);
            var vm = new EditAuthorViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Email = author.Email,
                Photo = author.Photo
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditAuthorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var author = new Author()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Biography = vm.Biography,
                    Email = vm.Email,
                    Photo = vm.Photo
                };

                await authorService.UpdateAuthor(author);
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
            await authorService.DeleteAuthor(id);
            // Index();
            return RedirectToAction("Index");

        }


        public async Task<ActionResult> SaveV2(Author author)
        {
            await authorService.AddAuthor(author);

            return RedirectToAction("Index");
        }



        public Author SaveV1(string id, string name, string bio, string email, string photourl, DateTime dob)
        {
            var author = new Author()
            {
               Id=id,
               Name=name,
               Biography=bio,
               Email=email,
               Photo=photourl
            };

            return author;
        }

        public Author SaveV0()
        {
            var author = new Author()
            {
                Id = Request.Form["id"],
                Name = Request.Form["name"],
                Biography = Request.Form["bio"],
                Email = Request.Form["email"],
                Photo = Request.Form["photourl"]
            };

            return author;
        }

        public async Task<ActionResult> DropDown()
        {
            var authors = await authorService.GetAllAuthors();
            return PartialView(authors);
        }
    }
}
