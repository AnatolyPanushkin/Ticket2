using System.ComponentModel.DataAnnotations;
using Ticket2.Models;

namespace Ticket2.Validation
{
    public class TicketNumberValidator:ValidationAttribute
    {
        public string GetErrorMessage() => "invalid ticket number!";
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticketNumber = value.ToString();

            if (ticketNumber.Length!=13 || ticketNumber==default)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}