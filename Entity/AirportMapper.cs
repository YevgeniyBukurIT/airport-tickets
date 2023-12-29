using DTO;
using System.Collections.Generic;

namespace Entity
{
    public static class AirportMapper
    {
        public static AirportEntity ModelToEntity(this Airport airport)
        {
            List<FlightEntity> flights = new List<FlightEntity>();
            foreach (Flight s in airport.flights)
            {
                flights.Add(s.ModelToEntity());
            }
            return new AirportEntity
            {
                id = airport.id,
                name = airport.name,
                flights = flights,
            };
        }
        public static Airport EntityToModel(this AirportEntity airport)
        {
            List<Flight> flights = new List<Flight>();
            if (airport.flights != null)
            {
                foreach (FlightEntity s in airport.flights)
                {
                    flights.Add(s.EntityToModel());
                }
            }
            return new Airport
            {
                id = airport.id,
                name = airport.name,
                flights = flights,
            };
        }
    }
}
