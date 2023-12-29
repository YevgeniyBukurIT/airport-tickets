using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer
{
    public class MainDbContext : DbContext
    {
        public DbSet<AirportEntity> ports { get; set; }
        public DbSet<FlightEntity> flights { get; set; }
        public DbSet<PassangerEntity> passengers { get; set; }
        public DbSet<PlaneEntity> planes { get; set; }
        public DbSet<TicketEntity> tickets { get; set; }
        public DbSet<PlaceEntity> places { get; set; }
        public DbSet<DelayReasonEntity> reasons { get; set; }

        public MainDbContext() : base("airportDb")
        {
	        Database.SetInitializer(new DbInitializer());
        }
    }
}
