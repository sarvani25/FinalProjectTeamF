using ConceptArchitect.BookManagement;
using ConceptArchitect.Utils;
using System.ComponentModel.DataAnnotations;

namespace BooksWeb02.ViewModels
{
    public class EditBookViewModel:Book
    {
        public string Id { get; set; }
        public string Title { get; set; }

        [WordCount(10)]
        [StringLength(2000, MinimumLength = 10)]
        public string Description { get; set; }

        [ExistingAuthor]
        public string AuthorId { get; set; }

        public string CoverPhoto { get; set; }
    }
}
