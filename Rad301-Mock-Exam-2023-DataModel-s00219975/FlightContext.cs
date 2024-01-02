using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;

namespace Rad301_Mock_Exam_2023_DataModel_s00219975
{
    public class FlightContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public FlightContext()
            : base()
        {
            ActivityAPIClient.Track(StudentID: "s00219975", StudentName: "Denys Musatov", activityName: "Rad301 Mock Exam 2023", Task: "Seeding Data Model");
        }

        public static FlightContext Create()
        {
            return new FlightContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RadExamMockDB-S00219975";
            optionsBuilder.UseSqlServer(myconnectionstring)
            //optionsBuilder.UseSqlServer()
              .LogTo(Console.WriteLine,
                     new[] { DbLoggerCategory.Database.Command.Name },
                     LogLevel.Information).
                        EnableSensitiveDataLogging(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasData(new Flight[]
                {
                    new Flight { FlightId = 1, FlightNumber = "IT-001", DepartureDate = DateTime.Parse("12/01/2021 22:00"), Origin = "Dublin", Destination = "Rome", Country = "Italy", MaxSeats = 110 },
                    new Flight { FlightId = 2, FlightNumber = "EN-002", DepartureDate = DateTime.Parse("23/01/2022 12:50"), Origin = "Dublin", Destination = "London", Country = "England", MaxSeats = 110 },
                    new Flight { FlightId = 3, FlightNumber = "FR-001", DepartureDate = DateTime.Parse("04/01/2022 06:00"), Origin = "Dublin", Destination = "Paris", Country = "France", MaxSeats = 120 },
                    new Flight { FlightId = 4, FlightNumber = "BE-001", DepartureDate = DateTime.Parse("05/01/2022 16:30"), Origin = "Dublin", Destination = "Brussels", Country = "Belgium", MaxSeats = 88 },
                    new Flight { FlightId = 5, FlightNumber = "DU-001", DepartureDate = DateTime.Parse("24/01/2022 11:00"), Origin = "London", Destination = "Dublin", Country = "Ireland", MaxSeats = 110 },
                });

            modelBuilder.Entity<Passenger>()
                .HasData(new Passenger[]
                {
                    new Passenger { PassengerId = 1, Name = "Fred Farnell", TicketType = "Economy", TicketCost = 51.83m, BaggageCharge = 30.00m, FlightId = 1 },
                    new Passenger { PassengerId = 2, Name = "Tom Mc Manus", TicketType = "First Class", TicketCost = 127.00m, BaggageCharge = 10.00m, FlightId = 2 },
                    new Passenger { PassengerId = 3, Name = "Bill Trimble", TicketType = "First Class", TicketCost = 140.00m, BaggageCharge = 10.00m, FlightId = 3 },
                    new Passenger { PassengerId = 4, Name = "Freda Mc Donald", TicketType = "Economy", TicketCost = 50.92m, BaggageCharge = 15.00m, FlightId = 4 },
                    new Passenger { PassengerId = 5, Name = "Mary Malone", TicketType = "Economy", TicketCost = 66.22m, BaggageCharge = 15.00m, FlightId = 1 },
                    new Passenger { PassengerId = 6, Name = "Tom Mc Manus", TicketType = "First Class", TicketCost = 127.00m, BaggageCharge = 10.00m, FlightId = 5 },
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
