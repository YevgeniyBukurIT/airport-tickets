using DTO;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IFlightService
    {
	    List<Flight> GetAll();
        void SetDelay(Flight fl, DelayReason drid);
        void ChangeTicketPurchaseEndTime(Flight fl, DateTime dt);
        List<Passanger> GetPassengers(Flight fl);
        Flight SetUpPlane(Flight fl, int plid);
        void AddFlight(Flight flight);
        Flight Get(int id);
    }
}
