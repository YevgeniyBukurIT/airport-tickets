using System.Collections.Generic;

namespace DTO
{
    public class Airport
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Flight> flights { get; set; }
    }
}
