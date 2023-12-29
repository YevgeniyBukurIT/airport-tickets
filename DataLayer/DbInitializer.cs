using System;
using System.Collections.Generic;
using System.Data.Entity;
using Entity;

namespace DataLayer
{
	public class DbInitializer : DropCreateDatabaseAlways<MainDbContext>
	{
		protected override void Seed(MainDbContext context)
		{
			AirportEntity port1 = new AirportEntity
            {
                id = 1,
                flights = new List<FlightEntity>(),
                name = "Бориспіль"
            };
            AirportEntity port2 = new AirportEntity
            {
                id = 2,
                flights = new List<FlightEntity>(),
                name = "Антонов-2"
            };
            AirportEntity port3 = new AirportEntity
            {
                id = 3,
                name = "Жульяни"
            };


            PlaceEntity pl1 = new PlaceEntity 
            { 
                id = 1, 
                number = 1
            };
            PlaceEntity pl2 = new PlaceEntity
            {
                id = 2,
                number = 2
            };
            PlaceEntity pl3 = new PlaceEntity
            {
                id = 3,
                number = 3
            };
            PlaceEntity pl4 = new PlaceEntity
            {
                id = 4,
                number = 1
            };
            PlaceEntity pl5 = new PlaceEntity
            {
                id = 5,
                number = 2
            };

            context.places.Add(pl1);
            context.places.Add(pl2);
            context.places.Add(pl3);
            context.places.Add(pl4);
            context.places.Add(pl5);
					

            PlaneEntity plane1 = new PlaneEntity
            {
                id = 1,
                places = new List<PlaceEntity>(),
                name = "АН-225"
            };
            PlaneEntity plane2 = new PlaneEntity
            {
                id = 2,
                places = new List<PlaceEntity>(),
                name = "АН-228"
            }; 

            plane1.places.Add(pl1);
            plane1.places.Add(pl2);
            plane1.places.Add(pl3);

            plane2.places.Add(pl4);
            plane2.places.Add(pl5);

            context.planes.Add(plane1);
            context.planes.Add(plane2);
					

            FlightEntity flight1 = new FlightEntity
            {
                id = 1,
                name = "FM-210",
                plane = plane1,
                flightDate = DateTime.Parse("2021-04-08T13:45:30"),
                ticketsPurchaseEnd = DateTime.Parse("2021-04-07T13:45:30"),
                tickets = new List<TicketEntity>(),
                delayReasons = new List<DelayReasonEntity>(),
            };
            FlightEntity flight2 = new FlightEntity
            {
                id = 2,
                name = "FM-211",
                plane = plane2,
                flightDate = DateTime.Parse("2021-04-09T13:45:30"),
                ticketsPurchaseEnd = DateTime.Parse("2021-04-08T13:45:30"),
                tickets = new List<TicketEntity>(),
                delayReasons = new List<DelayReasonEntity>(),
            };

            port1.flights.Add(flight1);
            port2.flights.Add(flight2);

            context.ports.Add(port1);
            context.ports.Add(port2);
            context.ports.Add(port3);
					
            PassangerEntity pass1 = new PassangerEntity 
            {
                id =1,
                name = "Антон",
                surname = "Антонюк"
            };
            PassangerEntity pass2 = new PassangerEntity
            {
                id = 2,
                name = "Іван",
                surname = "Іванов"
            };
            PassangerEntity pass3 = new PassangerEntity
            {
                id = 3,
                name = "Сергій",
                surname = "Кулініч"
            };

            TicketEntity t1 = new TicketEntity
            {
                id = 1,
                name = "GHM1222232",
                placeId = pl1.id,
                price = 1200,
                passangerId = pass1.id,
                isSold = true,
            };
            TicketEntity t2 = new TicketEntity
            {
                id = 2,
                name = "GHM1223232",
                placeId = pl2.id,
                price = 1200,
                passangerId = pass2.id,
                isSold = true,
            };
            TicketEntity t3 = new TicketEntity
            {
                id = 3,
                name = "GHM1222252",
                placeId = pl3.id,
                price = 1000,
                passangerId = pass3.id,
                isSold = true,
            };

            TicketEntity t4 = new TicketEntity
            {
                id = 4,
                name = "GHM1223232",
                placeId = pl4.id,
                price = 1200,
                passangerId = pass2.id,
                isSold = true,
            };
            TicketEntity t5 = new TicketEntity
            {
                id = 5,
                name = "GHM1222252",
                placeId = pl5.id,
                price = 1200,
                passangerId = pass3.id,
                isSold = true,
            };


            flight1.tickets.Add(t1);
            flight1.tickets.Add(t2);
            flight1.tickets.Add(t3);

            flight2.tickets.Add(t4);
            flight2.tickets.Add(t5);

            context.flights.Add(flight1);
            context.flights.Add(flight2);

            context.passengers.Add(pass1);
            context.passengers.Add(pass2);
            context.passengers.Add(pass3);

            context.tickets.Add(t1);
            context.tickets.Add(t2);
            context.tickets.Add(t3);
            context.tickets.Add(t4);
	
            DelayReasonEntity dr1 = new DelayReasonEntity
            {
                id = 1,
                name = "Погода",
                delay = TimeSpan.FromMinutes(30)
            };
            DelayReasonEntity dr2 = new DelayReasonEntity
            {
                id = 2,
                name = "Поломка літака",
                delay = TimeSpan.FromMinutes(60)
            };

            context.reasons.Add(dr1);
            context.reasons.Add(dr2);

            context.SaveChanges();
		}
	}
}