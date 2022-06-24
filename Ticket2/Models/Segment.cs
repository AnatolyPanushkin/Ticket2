using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket2.Models
{
    public partial class Segment
    {
        public string SerialNumber { get; set; }
        public string OperationType { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DocType { get; set; }
        public string DocNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string PassengerType { get; set; }
        public string TicketNumber { get; set; }
        public string TicketType { get; set; }
        public string AirlineCode { get; set; }
        public string FlightNum { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartDatetime { get; set; }
        public string ArrivePlace { get; set; }
        public DateTime ArriveDatetime { get; set; }
        public string PnrId { get; set; }
        public bool Refund { get; set; }
    }
}
