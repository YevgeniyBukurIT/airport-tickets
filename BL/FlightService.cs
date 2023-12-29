using DataLayer;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
	public class FlightService : IFlightService
	{
		private readonly IUnitOfWork _unitOfWork;

		public FlightService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Passanger> GetPassengers(Flight flight) =>
			flight.tickets
				.Where(ticket => ticket.isSold)
				.Select(ticket => ticket.passanger)
				.ToList();


		public List<Flight> GetAll() =>
			_unitOfWork.flights
				.GetAll()
				.Select(flightEntity => flightEntity.EntityToModel())
				.ToList();


		public Flight SetUpPlane(Flight fl, int planeId)
		{
			fl.plane = _unitOfWork.planes
				.Get(planeId)
				.EntityToModel();
			
			fl.plane.places
				.Select(pl => new Ticket {
						place = pl,
						flight = fl,
						isSold = false})
				.ToList()
				.ForEach(ticket => fl.tickets.Add(ticket));
			
			return fl;
		}

		public void AddFlight(Flight flight)
		{
			FlightEntity fl = flight.ModelToEntity();
			
			fl.plane = _unitOfWork.planes
				.Get(flight.plane.id);
			
			_unitOfWork.flights
				.Add(fl)
				.SaveChanges();
		}

		public void ChangeTicketPurchaseEndTime(Flight fl, DateTime dt)
		{
			fl.ticketsPurchaseEnd = dt;
			
			_unitOfWork.flights
				.Update(fl.ModelToEntity())
				.SaveChanges();
		}

		public void SetDelay(Flight fl, DelayReason delayReason)
		{
			DelayReasonEntity delayReasonEntity = delayReason.ModelToEntity();
			FlightEntity flight = _unitOfWork.flights.Get(fl.id);
			
			flight.delayReasons.Add(delayReasonEntity);
			
			_unitOfWork.flights
				.Update(flight)
				.SaveChanges();
			var v = _unitOfWork.flights.GetAll();
		}

		public Flight Get(int id) =>
			_unitOfWork.flights
				.Get(id)
				.EntityToModel();
	}
}
