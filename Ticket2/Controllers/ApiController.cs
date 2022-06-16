using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Ticket2.Models;


namespace Ticket2.Controllers
{
    [ApiController]
    [Route("v1/process")]
    
    public class ApiController:ControllerBase
    {
        private readonly TicketContext _context;

        public ApiController(TicketContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Метод продажи белета, с валидацией от повторной продажи одного и того же билета
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [HttpPost("sale")]
        [RequestSizeLimit(2048)]
        public IActionResult SalePost(JObject _json)
        {
            Ticket ticket = _json.ToObject<Ticket>();
                //достаем билет с таким же номером
            var saledTicket = _context.Segments.FirstOrDefault(
                    t => t.Ticket_Number == Convert.ToInt64(ticket.Passenger.Ticket_Number));

                // если таких нет, то выполняем опрацию 
                if (saledTicket == null)
                {
                    var arrSegment = new Segment[ticket.Routes.Length];

                    int count = 0;

                    foreach (var t in ticket.Routes)
                    {
                        Segment segment = new Segment();
                        segment.Operation_Type = ticket.Operation_Type;
                        segment.Operration_Time = Convert.ToDateTime(ticket.Operration_Time);
                        segment.Operation_Place = ticket.Operation_Place;
                        segment.Name = ticket.Passenger.Name;
                        segment.Surname = ticket.Passenger.Surname;
                        segment.Patronymic = ticket.Passenger.Patronymic;
                        segment.Doc_Type = ticket.Passenger.Doc_Type;
                        segment.Doc_Number = Convert.ToInt64(ticket.Passenger.Doc_Number);
                        segment.Birthdate = Convert.ToDateTime(ticket.Passenger.Birthdate);
                        segment.Gender = ticket.Passenger.Gender;
                        segment.Passenger_Type = ticket.Passenger.Passenger_Type;
                        segment.Ticket_Number = Convert.ToInt64(ticket.Passenger.Ticket_Number);
                        segment.Ticket_Type = ticket.Passenger.Ticket_Type;
                        segment.Airline_Code = t.Airline_Code;
                        segment.Flight_Num = t.Flight_Num;
                        segment.Depart_Place = t.Depart_Place;
                        segment.Depart_Datetime = Convert.ToDateTime(t.Depart_Datetime);
                        segment.Arrive_Place = t.Arrive_Place;
                        segment.Arrive_Datetime = Convert.ToDateTime(t.Arrive_Datetime);
                        segment.Pnr_Id = t.Pnr_Id;
                        segment.Refund = false;
                        
                        arrSegment[count] = segment;
                        count++;
                    }

                    foreach (var t in arrSegment)
                    {
                        _context.Segments.Add(t);
                    }

                    _context.SaveChanges();
                    
                    return Ok(arrSegment);
                }

                else
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
        }
    



        /// <summary>
        /// метод для возврата билет, отслеживающий воврат цже сданного билета и сачи отсутствующего билета
        /// </summary>
        /// <param name="refundTicket"></param>
        /// <returns></returns>
        [HttpPost("refund")]
        public IActionResult RefundPost(RefundTicket refundTicket)
        {
            if (refundTicket.Operation_Type == "refund")
            {
                var refundTickets = _context.Segments
                    .Where(t => t.Ticket_Number == Convert.ToInt64(refundTicket.Ticket_Number)).Select(t=>t).ToList();
                

                foreach (var rt in refundTickets)
                {
                    if (rt == null || rt.Refund == true) 
                    {
                        return StatusCode((int) HttpStatusCode.Conflict);
                    }
                    rt.Operation_Type = "refund";
                    rt.Operration_Time = Convert.ToDateTime(refundTicket.Operation_Time);
                    rt.Operation_Place = refundTicket.Operation_Place;
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
        }

    }
    
}