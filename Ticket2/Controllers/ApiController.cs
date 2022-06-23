using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ticket2.Filters;
using Ticket2.Models;
using Ticket2.Services.Dto;
using Ticket2.Services.TicketServices;



namespace Ticket2.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/process")]
    [ApiVersion("4.0")]
    [RequestSizeLimit(2048)] 
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
        /// Метод продажи белета
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [HttpPost("sale")]
        public IActionResult SalePost(Ticket ticket)
        {
            var taskResult = _service.SalePost(_mapper.Map<TicketDto>(ticket));
            return Ok(taskResult.Result);
        }

        /// <summary>
        /// метод для возврата билет
        /// </summary>
        /// <param name="refundTicket"></param>
        /// <returns></returns>
        [HttpPost("refund")]
        public IActionResult RefundPost(RefundTicket refundTicket)
        {
            var taskResult = _service.RefundPost(_mapper.Map<RefundTicketDto>(refundTicket));
            return Ok(taskResult.Result);
        }
    }
}