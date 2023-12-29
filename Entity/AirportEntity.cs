using System.Collections.Generic;

namespace Entity
{
    public class AirportEntity : BaseEntity<int>
    {
        public string name { get; set; }
        public virtual List<FlightEntity> flights { get; set; }
    }
}
