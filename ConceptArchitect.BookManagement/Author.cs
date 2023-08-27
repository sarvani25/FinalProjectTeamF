using ConceptArchitect.Utils;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.BookManagement
{
    public class Author
    {
        [UniqueAuthorId]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [WordCount(10)]
        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string Biography { get; set; }
        public string Photo { get; set; }
        [Email]
        public string? Email { get; set; }

        public List<Book> Book { get; set; } = new List<Book>();

        //public DateTime BirthDate { get; set; }

    }
}