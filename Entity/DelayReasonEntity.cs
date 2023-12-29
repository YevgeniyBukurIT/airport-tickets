using System;
using System.Collections.Generic;

namespace Entity
{
    public class DelayReasonEntity : BaseEntity<int>
    {
        public string name { get; set; }
        public TimeSpan delay { get; set; }
        public virtual List<FlightEntity> flights { get; set; }
    }
}
