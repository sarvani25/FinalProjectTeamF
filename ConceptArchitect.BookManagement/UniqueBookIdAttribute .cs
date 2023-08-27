using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class UniqueBookIdAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var bookService = (IBookService) validationContext.GetService(typeof(IBookService));
            if (bookService == null)
                throw new ArgumentException("Book service not configured");
            try
            {
                var book = bookService
                             .GetBookById(value as string)
                             .Result;
                //if(book == null)
                //    return ValidationResult.Success;
                return new ValidationResult($"Duplicate Id: {value}. Currently associated with {book.Title}");
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