using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class User
    {
        [Required]
        [Key]
        [Email]
        public string Email { get; set; }   
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        [Column("PhotoUrl")]
        public string? ProfilePhoto { get; set; }

    }
}
