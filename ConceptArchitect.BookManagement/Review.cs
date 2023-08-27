using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ExistingUser]
        [Email]
        public string UserEmail { get; set; }

        [ExistingBook]
        public string bookId { get; set; }

        public int Rating { get; set; }

        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}
