using DTO;
using System.Collections.Generic;

namespace Entity
{
    public static class FlightMapper
    {
        public static FlightEntity ModelToEntity(this Flight flight)
        {
            List<TicketEntity> tickets = new List<TicketEntity>();
            foreach (Ticket s in flight.tickets)
            {
                tickets.Add(s.ModelToEntity());
            }
            List<DelayReasonEntity> delays = new List<DelayReasonEntity>();
            foreach (DelayReason s in flight.delayReasons)
            {
                delays.Add(s.ModelToEntity());
            }
            
            return new FlightEntity
            {
                id = flight.id,
                name = flight.number,
                flightDate = flight.flightDate,
                ticketsPurchaseEnd = flight.ticketsPurchaseEnd,
                plane = flight.plane.ModelToEntity(),
                planeId = flight.plane.id,
                delayReasons = delays,
                tickets = tickets,
            };
        }
        public static Flight EntityToModel(this FlightEntity flight)
        {
            List<Ticket> tickets = new List<Ticket>();
            foreach (TicketEntity s in flight.tickets)
            {
                tickets.Add(s.EntityToModel());
            }
            List<DelayReason> delays = new List<DelayReason>();
            if (flight.delayReasons != null)
            {
                foreach (DelayReasonEntity s in flight.delayReasons)
                {
                    delays.Add(s.EntityToModel());
                }
            }
            return new Flight
            {
                id = flight.id,
                number = flight.name,
                flightDate = flight.flightDate,
                ticketsPurchaseEnd = flight.ticketsPurchaseEnd,
                plane = flight.plane.EntityToModel(),
                delayReasons = delays,
                tickets = tickets,
            };
        }
    }
}
