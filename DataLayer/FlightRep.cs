using DTO;
using Entity;
using System.Collections.Generic;

namespace DataLayer
{
    public class FlightRep : GenericRepository<FlightEntity, int>, IFlightRep
    {
        public FlightRep(MainDbContext context) : base(context)
        {   
        }
        public void UpdateFlight(FlightEntity fl)
        {
            FlightEntity flight = Get(fl.id);
            flight.id = fl.id;
            flight.delayReasons = fl.delayReasons;
            flight.flightDate = fl.flightDate;
            flight.name = fl.name;
            flight.plane = fl.plane;
            flight.planeId = fl.planeId;
            flight.tickets = fl.tickets;
            flight.ticketsPurchaseEnd = fl.ticketsPurchaseEnd;
            
            _context.SaveChanges();
        }
    }
}
