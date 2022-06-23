using System;
using System.Collections.Generic;
using Ticket2.Models;

namespace Ticket2.Services.Dto.AutoMapperProfiles
{
    public class TicketToSegmentMapMethod
    {
        public List<Segment> MapTicketToSegment(Ticket ticket)
        {
            var arrSegment = new List<Segment>();

            int count = 0;
            foreach (var t in ticket.Routes)
            {
                Segment segment = new Segment
                {
                    SerialNumber = Convert.ToString(count),
                    OperationType = ticket.Operation_Type,
                    OperationTime = Convert.ToDateTime(ticket.Operation_Time),
                    OperationPlace = ticket.Operation_Place,
                    Name = ticket.Passenger.Name,
                    Surname = ticket.Passenger.Surname,
                    Patronymic = ticket.Passenger.Patronymic,
                    DocType = ticket.Passenger.Doc_Type,
                    DocNumber = ticket.Passenger.Doc_Number,
                    Birthdate = Convert.ToDateTime(ticket.Passenger.Birthdate),
                    Gender = ticket.Passenger.Gender,
                    PassengerType = ticket.Passenger.Passenger_Type,
                    TicketNumber = ticket.Passenger.Ticket_Number,
                    TicketType = ticket.Passenger.Ticket_Type,
                    AirlineCode = t.Airline_Code,
                    FlightNum = t.Flight_Num,
                    DepartPlace = t.Depart_Place,
                    DepartDatetime = Convert.ToDateTime(t.Depart_Datetime),
                    ArrivePlace = t.Arrive_Place,
                    ArriveDatetime = Convert.ToDateTime(t.Arrive_Datetime),
                    PnrId = t.Pnr_Id,
                    Refund = false
                };
                
                arrSegment.Add(segment);
                count++;
            }

            return arrSegment;
        }
    }
}