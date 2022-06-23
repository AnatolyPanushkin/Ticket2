﻿using System.Threading.Tasks;
using Ticket2.Models;
using Ticket2.Services.Dto;

namespace Ticket2.Services.TicketServices
{
    public interface ITicketService
    {
       Task<dynamic> SalePost(TicketDto ticketDto);
        Task<dynamic> RefundPost(RefundTicketDto refundTicketDto);
    }
}