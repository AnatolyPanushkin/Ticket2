using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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
        public async Task<TicketDto> SalePost(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);

            TicketToSegmentMapMethod ticketToSegment = new TicketToSegmentMapMethod();
            
            foreach (var segment in ticketToSegment.MapTicketToSegment(ticket))
            {
                _context.Segments.Add(segment);
            }
            
            try
            {
                await _context.SaveChangesAsync();

                return _mapper.Map<TicketDto>(ticket);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is PostgresException npgex && npgex.SqlState == PostgresErrorCodes.UniqueViolation )
                {
                    throw new BadHttpRequestException("ticket already is payed!", 409);
                }
                throw new BadHttpRequestException("unknown exception from db!", 409);
            }
        }

        public RefundTicketDto RefundPost(RefundTicket refundTicket)
        {
            throw new System.NotImplementedException();
        }
    }
}