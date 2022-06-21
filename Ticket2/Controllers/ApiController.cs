using System;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Ticket2.Filters;
using Ticket2.Models;
using Ticket2.Services.Dto;
using Ticket2.Services.TicketServices;
using Ticket2.Validation;


namespace Ticket2.Controllers
{
    [ApiController]
    [Route("v1/process")]
    
    public class ApiController:ControllerBase
    {
        private readonly ITicketService _service;
        private readonly IMapper _mapper;

        public ApiController(ITicketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Метод продажи белета, с валидацией от повторной продажи одного и того же билета
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [HttpPost("sale")]
        [RequestSizeLimit(2048)] 
        
        public IActionResult SalePost(Ticket ticket)
        {
            _service.SalePost(_mapper.Map<TicketDto>(ticket));
            return Ok();
        }
    



        /// <summary>
        /// метод для возврата билет, отслеживающий воврат цже сданного билета и сачи отсутствующего билета
        /// </summary>
        /// <param name="refundTicket"></param>
        /// <returns></returns>
        /*[HttpPost("refund")]
        public IActionResult RefundPost(RefundTicket refundTicket)
        {
            if (refundTicket.Operation_Type == "refund")
            {
                var refundTickets = _context.Segments
                    .Where(t => t.TicketNumber == refundTicket.Ticket_Number).Select(t=>t).ToList();
                

                foreach (var rt in refundTickets)
                {
                    if (rt == null || rt.Refund == true) 
                    {
                        return StatusCode((int) HttpStatusCode.Conflict);
                    }
                    rt.OperationType = "refund";
                    rt.OperationTime = Convert.ToDateTime(refundTicket.Operation_Time);
                    rt.OperationPlace = refundTicket.Operation_Place;
                    rt.Refund = true;
                    _context.Segments.Update(rt);
                    _context.SaveChanges();
                        
                }
                return Ok(refundTickets);
            }
            else
            {
                return StatusCode((int) HttpStatusCode.Conflict);
            }
        }*/

    }
    
}