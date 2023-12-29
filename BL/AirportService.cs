using DataLayer;
using DTO;
using Entity;
using System.Collections.Generic;

namespace BL
{
    public class AirportService : IAirportService
    {
        public IUnitOfWork data { get; set; }
        public AirportService(IUnitOfWork data)
        {
            this.data = data;
        }
       public List<Flight> GetFlights(int id) 
        {
            List<Flight> flights = new List<Flight>();
            foreach (FlightEntity r in data.airorts.Get(id).flights)
            {
                flights.Add(r.EntityToModel());
            }
            return flights;
        }

        public List<Airport> GetAll()
        {
            List<Airport> airports = new List<Airport>();
            foreach (AirportEntity r in data.airorts.GetAll())
            {
                airports.Add(r.EntityToModel());
            }
            return airports;
        }

        public Airport Get(int id)
        {
            return data.airorts.Get(id).EntityToModel();
        }
    }
}
