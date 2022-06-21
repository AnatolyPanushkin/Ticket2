using System;
using Ticket2.Models;

namespace Ticket2.Services.Dto.AutoMapperProfiles
{
    public class TicketToSegmentMapMethod
    {
        public Segment[] MapTicketToSegment(Ticket ticket)
        {
            var arrSegment = new Segment[ticket.Routes.Length];

            int count = 0;
            foreach (var t in ticket.Routes)
            {
                Segment segment = new Segment();

                segment.SerialNumber = Convert.ToString(count);
                segment.OperationType = ticket.Operation_Type;
                segment.OperationTime = Convert.ToDateTime(ticket.Operation_Time);
                segment.OperationPlace = ticket.Operation_Place;
                segment.Name = ticket.Passenger.Name;
                segment.Surname = ticket.Passenger.Surname;
                segment.Patronymic = ticket.Passenger.Patronymic;
                segment.DocType = ticket.Passenger.Doc_Type;
                segment.DocNumber = ticket.Passenger.Doc_Number;
                segment.Birthdate = Convert.ToDateTime(ticket.Passenger.Birthdate);
                segment.Gender = ticket.Passenger.Gender;
                segment.PassengerType = ticket.Passenger.Passenger_Type;
                segment.TicketNumber = ticket.Passenger.Ticket_Number;
                segment.TicketType = ticket.Passenger.Ticket_Type;
                segment.AirlineCode = t.Airline_Code;
                segment.FlightNum = t.Flight_Num;
                segment.DepartPlace = t.Depart_Place;
                segment.DepartDatetime = Convert.ToDateTime(t.Depart_Datetime);
                segment.ArrivePlace = t.Arrive_Place;
                segment.ArriveDatetime = Convert.ToDateTime(t.Arrive_Datetime);
                segment.PnrId = t.Pnr_Id;
                segment.Refund = false;
                        
                arrSegment[count] = segment;
                count++;
            }

            return arrSegment;
        }
    }
}