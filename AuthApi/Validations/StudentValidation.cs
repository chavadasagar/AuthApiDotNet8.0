using AuthApi.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthApi.Validations
{
    public class StudentValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var student = validationContext.ObjectInstance as Student;

            if (student?.Name == "sagar")
            {
                return new ValidationResult("name only be sagar");
            }

            return ValidationResult.Success;
        }
    }
}
