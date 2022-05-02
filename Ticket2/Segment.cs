using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket2
{
    public partial class Segment
    {
        public int Id { get; set; }
        public string Operation_Type { get; set; }
        public DateTime Operration_Time { get; set; }
        public string Operation_Place { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Doc_Type { get; set; }
        public long Doc_Number { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Passenger_Type { get; set; }
        public long Ticket_Number { get; set; }
        public int Ticket_Type { get; set; }
        public string Airline_Code { get; set; }
        public int Flight_Num { get; set; }
        public string Depart_Place { get; set; }
        public DateTime Depart_Datetime { get; set; }
        public string Arrive_Place { get; set; }
        public DateTime Arrive_Datetime { get; set; }
        public string Pnr_Id { get; set; }
        public bool Refund { get; set; }
    }
}
