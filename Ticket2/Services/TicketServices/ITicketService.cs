using System.Threading.Tasks;
using Ticket2.Models;
using Ticket2.Services.Dto;

namespace Ticket2.Services.TicketServices
{
    public interface ITicketService
    {
       Task<TicketDto> SalePost (TicketDto ticketDto);
        RefundTicketDto RefundPost(RefundTicket refundTicket);
    }
}