using Ticket2.Models;
using Ticket2.Services.Dto;

namespace Ticket2.Services.TicketServices
{
    public interface ITicketService
    {
        TicketDto SalePost(Ticket ticket);
        RefundTicketDto RefundPost(RefundTicket refundTicket);
    }
}