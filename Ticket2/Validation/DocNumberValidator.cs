using System;
using System.ComponentModel.DataAnnotations;

namespace Ticket2.Validation
{
    public class DocNumberValidator: ValidationAttribute
    {
        private static string GetErrorMessage() => "Invalid document data!";
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var docNumber = (string)value;

            if (docNumber.Length<6)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}