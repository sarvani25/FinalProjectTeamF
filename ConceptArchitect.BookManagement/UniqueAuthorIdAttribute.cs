using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class UniqueAuthorIdAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var authorService = (IAuthorService) validationContext.GetService(typeof(IAuthorService));


            if (authorService == null)
                throw new ArgumentException("Author service not configured");

            try
            {
                var author = authorService.GetAuthorById(value as string).Result;
                if(author == null)
                    return ValidationResult.Success;
                return new ValidationResult($"Duplicate Id: {value}. Currently associated with {author.Name}");
            }
            catch (Exception ex)
            {
                
                // success
            }
            return ValidationResult.Success;
            //return new ValidationResult($"Duplicate Id: {value}");
        }
    }
}