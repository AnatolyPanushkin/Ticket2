using System;

namespace Ticket2.Models
{
    public class Route
    {
        public string Airline_Code { get; set; }
        public int Flight_Num { get; set; }
        public string Depart_Place { get; set; }
        public string Depart_Datetime { get; set; }
        public string Arrive_Place { get; set; }
        public string Arrive_Datetime { get; set; }
        public string Pnr_Id { get; set; }
    }
}