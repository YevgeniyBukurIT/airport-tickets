using Entity;

namespace DataLayer
{
    public interface IFlightRep : IGenericRepository<FlightEntity, int>
    {
        void UpdateFlight(FlightEntity fl);
    }
}
