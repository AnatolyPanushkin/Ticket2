using Ticket2.Validation;

namespace Ticket2.Models
{
    public class RefundTicket
    {
        public string Operation_Type { get; set; }
        public string Operation_Time { get; set; }
        public string Operation_Place { get; set; }
        
        [TicketNumberValidator]
        public string Ticket_Number { get; set; }
    }
}