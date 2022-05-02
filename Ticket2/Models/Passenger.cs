using System;

namespace Ticket2.Models
{
    public class Passenger
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Doc_Type { get; set; }
        public string Doc_Number { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string Passenger_Type { get; set; }
        public string Ticket_Number { get; set; }
        public int Ticket_Type { get; set; }
    }
}