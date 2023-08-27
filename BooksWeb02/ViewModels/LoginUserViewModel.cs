using ConceptArchitect.BookManagement;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BooksWeb02.ViewModels
{
    public class LoginUserViewModel:User
    {
        
        public string Email { get; set; }
       
        public string Password { get; set; }

        public string? Name { get; set; }
    }
}
