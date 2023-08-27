using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Favorite
    {
        public int Id { get; set; }

        [Email]
        [ExistingUser]
        public string UserEmail { get; set; }

        [ExistingBook]
        public string BookId { get; set; }

        public string Status { get; set; } = "Reading";
    }
}
