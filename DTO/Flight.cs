using System;
using System.Collections.Generic;
using System.Linq;

namespace DTO
{
    public class Flight
    {
        public int id { get; set; }
        public string number { get; set; }
        public List<Ticket> tickets { get; set; }
        public Plane plane { get; set; }
        public DateTime flightDate { get; set; }

        public DateTime normalizedFlightDate
        {
	        get
	        {
		        if (delayReasons.Count == 0)
			        return flightDate;
		        return flightDate + delayReasons
			        .Select(reason => reason.delay)
			        .Aggregate((r1, r2) => r1 + r2);
	        }
        }

        public DateTime ticketsPurchaseEnd { get; set; }
        public List<DelayReason> delayReasons { get; set; } = new List<DelayReason>();

        public List<Passanger> passengers => tickets.Select(ticket => ticket.passanger).ToList(); 
    }
}
