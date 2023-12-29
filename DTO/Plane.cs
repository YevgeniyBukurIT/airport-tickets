using System.Collections.Generic;

namespace DTO
{
    public class Plane
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Place> places { get; set; }
    }
}
