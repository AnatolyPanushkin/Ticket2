using Ticket2.Models;
using Ticket2.Validation;

namespace Ticket2.Services.Dto
{
    public class TicketDto
    {
        public string Operation_Type { get; set; }
        
        public string Operation_Time { get; set; }
        
        public string Operation_Place { get; set; }
        
        public Passenger Passenger { get; set; }
        
        public Route[] Routes { get; set; }
    }
}