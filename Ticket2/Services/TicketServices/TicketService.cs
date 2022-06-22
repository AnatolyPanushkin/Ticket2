using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Ticket2.ErrorsSupport;
using Ticket2.Models;
using Ticket2.Services.Dto;
using Ticket2.Services.Dto.AutoMapperProfiles;

namespace Ticket2.Services.TicketServices
{
    public class TicketService:ITicketService
    {
        private readonly Ticket2Context _context;
        private readonly IMapper _mapper;
        

        public TicketService(Ticket2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<dynamic> SalePost(TicketDto ticketDto)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDto);

                var ticketToSegment = new TicketToSegmentMapMethod();

                await _context.Segments.AddRangeAsync(ticketToSegment.MapTicketToSegment(ticket));

                await _context.SaveChangesAsync();
            
                return _mapper.Map<TicketDto>(ticket);
            }
            catch (Exception e)
            {
                var error = e.ToErrorObject();

                return new[]
                {
                    error.ErrorCode,
                    error.ErrorMessage,
                    error.ErrorCodeDb
                };
            }
        }

        public async Task<dynamic> RefundPost(RefundTicketDto refundTicketDto)
        {
            
                var refundTicket = _mapper.Map<RefundTicket>(refundTicketDto);

                var tickets = await _context.Segments
                    .Where(t => t.TicketNumber == refundTicket.Ticket_Number)
                    .ToListAsync();
            
                foreach (var ticket in tickets)
                {
                    ticket.OperationType = "refund";
                    ticket.OperationTime = Convert.ToDateTime(refundTicket.Operation_Time);
                    ticket.OperationPlace = refundTicket.Operation_Place;
                    ticket.Refund = true;
                }

                _context.Segments.UpdateRange(tickets);

                await _context.SaveChangesAsync();

                return refundTicketDto;
            
            /*catch (Exception e)
            {
                var error = e.ToErrorObject();

                return new[]
                {
                    error.ErrorCode,
                    error.ErrorMessage,
                    error.ErrorCodeDb
                };
            }*/
            

            /*public virtual async Task InsertRangeAsync(IEnumerable<Segment> segments)
            {
                await _context.Segments.AddRangeAsync(segments);
                await _context.SaveChangesAsync();
            }
    
            public async Task<ICollection<Segment>> FindRefundSegmentsWithSameTicketNumberAsync(string ticketNumber)
            {
                return await _context.Segments
                    .Where(s => s.TicketNumber == ticketNumber && s.OperationType != "refund")
                    .ToListAsync();
            }
    
            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
                
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
                }*/
        }
    }
}