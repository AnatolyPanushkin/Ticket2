using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Ticket2.Validation
{
    public class BirthdateValidator: ValidationAttribute
    {
        private static string GetErrorMessage() => "Invalid birthdate value!";
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthYear = Convert.ToDateTime(value).Year;

            if (birthYear > DateTime.Now.Year || DateTime.Now.Year - birthYear>100)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}