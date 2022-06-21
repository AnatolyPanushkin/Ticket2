using System;
using Ticket2.Validation;

namespace Ticket2.Models
{
    public class Passenger
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Doc_Type { get; set; }
        public string Doc_Number { get; set; }
       
        [BirthdateValidator]
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string Passenger_Type { get; set; }
        
        [TicketNumberValidator]
        public string Ticket_Number { get; set; }
        public string Ticket_Type { get; set; }
    }
}