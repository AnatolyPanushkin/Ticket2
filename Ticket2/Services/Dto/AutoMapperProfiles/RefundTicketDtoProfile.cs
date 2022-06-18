using AutoMapper;
using Ticket2.Models;

namespace Ticket2.Services.Dto.AutoMapperProfiles
{
    public class RefundTicketDtoProfile:Profile
    {
        public RefundTicketDtoProfile()
        {
            CreateMap<RefundTicket, RefundTicketDto>().ReverseMap();
        }
    }
}