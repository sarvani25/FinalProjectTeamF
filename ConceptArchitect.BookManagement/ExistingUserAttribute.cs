using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class ExistingUserAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var id = value as string;

            if (string.IsNullOrEmpty(id))
                return ValidationResult.Success;

            var userService = (IUserService)validationContext.GetService(typeof(IUserService));
            if (userService == null)
                throw new ArgumentException("User Service is NOT configured");

            var user = userService.GetUserByEmailId(id).Result;

            if (user == null)
                return new ValidationResult($"Invalid User Id :'{id}'");
            else
                return ValidationResult.Success;


        }
    }
}
