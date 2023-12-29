using System;
using System.Collections.Generic;

namespace Entity
{
    public class FlightEntity : BaseEntity<int>
    {
        public string name { get; set; }
        public DateTime flightDate { get; set; }
        public DateTime ticketsPurchaseEnd { get; set; }
        public virtual PlaneEntity plane { get; set; }
        public int planeId { get; set; }
        public virtual List<DelayReasonEntity> delayReasons { get; set; }
        public virtual List<TicketEntity> tickets { get; set; }
    }
}
