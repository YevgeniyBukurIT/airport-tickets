using System.Collections.Generic;

namespace Entity
{
    public class PlaneEntity : BaseEntity<int>
    {
        public string name { get; set; }
        public virtual List<PlaceEntity> places { get; set; }
    }
}
