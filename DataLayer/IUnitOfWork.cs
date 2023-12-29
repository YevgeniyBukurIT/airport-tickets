using System;

namespace DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        MainDbContext db { get; set; }
        IAirportRep airorts { get; set; }
        IFlightRep flights { get; set; }
        IPassangerRep passangers { get; set; }
        IPlaneRep planes { get; set; }
        ITicketRep tickets { get; set; }
        IDelayReasonRep reasons { get; set; }
        IPlaceRep places { get; set; }
        void Save();
    }
}
