using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IAirportService
    {
        List<Airport> GetAll();
        List<Flight> GetFlights(int id);
        Airport Get(int id);
    }
}
