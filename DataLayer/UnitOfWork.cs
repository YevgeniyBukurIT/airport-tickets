using System;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public MainDbContext db { get; set; }
        public IAirportRep airorts { get; set; }
        public IFlightRep flights { get; set; }
        public IPassangerRep passangers { get; set; }
        public IPlaneRep planes { get; set; }
        public ITicketRep tickets { get; set; }
        public IDelayReasonRep reasons { get; set; }
        public IPlaceRep places { get; set; }

        public UnitOfWork(MainDbContext db, IAirportRep airorts, 
                        IFlightRep flights, IPassangerRep passangers, 
                        IPlaneRep planes, ITicketRep tickets, IDelayReasonRep reasons, IPlaceRep places)
        {
            this.db = db;
            this.airorts = airorts;
            this.flights = flights;
            this.passangers = passangers;
            this.planes = planes;
            this.tickets = tickets;
            this.reasons = reasons;
            this.places = places;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
