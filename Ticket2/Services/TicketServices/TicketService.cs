using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ticket2.ErrorsSupport;
using Ticket2.Models;
using Ticket2.Services.Dto;
using Ticket2.Services.Dto.AutoMapperProfiles;

namespace Ticket2.Services.TicketServices
{
    public class TicketService:ITicketService
    {
        const int Timeout = 12_000;
        
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

                var source = new CancellationTokenSource();
                source.CancelAfter(Timeout);
                
                await _context.SaveChangesAsync(source.Token);
            
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
            try
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

                var countOfUpdates = await _context.SaveChangesAsync();
            
                if (countOfUpdates == 0)
                {
                    throw new Exception("ticket already is refunded!");
                }

                return refundTicketDto;

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
    }
}