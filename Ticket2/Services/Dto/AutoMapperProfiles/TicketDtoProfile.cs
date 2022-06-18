﻿using AutoMapper;
using Ticket2.Models;

namespace Ticket2.Services.Dto.AutoMapperProfiles
{
    public class TicketDtoProfile:Profile
    {
        public TicketDtoProfile()
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}