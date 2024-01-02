using Microsoft.EntityFrameworkCore;
using Rad301_Mock_Exam_2023_DataModel_s00219975;
using Tracker.WebAPIClient;

namespace Rad301_Mock_Exam_2023_Console_App__s00219975
{
    public class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "s00219975", StudentName: "Denys Musatov", activityName: "Rad301 Mock Exam 2023", Task: "Running Console Queries");

            FlightContext db = new FlightContext(new DbContextOptions<FlightContext>());

            using (db)
            {
                ListPassengers(1);
                ListFlightRevenue();
                AddNewFlightAndPassenger();
            }

            void ListPassengers(int flightId)
            {
                var passengers = db.Passengers
                .Include(p => p.Flight)
                .Where(p => p.FlightId == flightId)
                .ToList();

                if (passengers.Count > 0)
                {
                    Console.WriteLine($"Passenger Details for Flight ID {flightId}:");
                    foreach (var passenger in passengers)
                    {
                        Console.WriteLine($"Name: {passenger.Name}, Ticket Type: {passenger.TicketType}, Destination: {passenger.Flight.Destination}");
                    }
                }
                else
                {
                    Console.WriteLine($"No passengers found for Flight ID {flightId}.");
                }
            }

            void ListFlightRevenue()
            {

                var flights = db.Flights
                        .Include(f => f.Passengers)
                        .ToList();

                if (flights.Count > 0)
                {
                    Console.WriteLine("Flight Revenue Details:");

                    foreach (var flight in flights)
                    {
                        // Calculate total revenue for the flight
                        decimal totalRevenue = flight.Passengers.Sum(p => p.TicketCost + p.BaggageCharge);

                        Console.WriteLine($"Flight Number: {flight.FlightNumber}, Destination: {flight.Destination}, Departure Date: {flight.DepartureDate}, Total Revenue: {totalRevenue:C}");
                    }
                }
                else
                {
                    Console.WriteLine("No flights found in the database.");
                }

            }

            void AddNewFlightAndPassenger()
            {
                // Create a new flight
                var newFlight = new Flight
                {
                    FlightNumber = "DU-002",
                    DepartureDate = DateTime.Parse("29/06/2022 11:00"),
                    Origin = "Dublin",
                    Destination = "Sydney",
                    Country = "Australia",
                    MaxSeats = 210
                };

                // Add the new flight to the context and save changes to the database
                db.Flights.Add(newFlight);
                db.SaveChanges();

                // Create a new passenger associated with the new flight
                var newPassenger = new Passenger
                {
                    Name = "Martha Rotter",
                    TicketType = "Business",
                    TicketCost = 399.0m,
                    BaggageCharge = 30.00m,
                    FlightId = newFlight.FlightId // Set the FlightId to associate the passenger with the new flight
                };

                // Add the new passenger to the context and save changes to the database
                db.Passengers.Add(newPassenger);
                db.SaveChanges();

                Console.WriteLine("New flight and passenger added successfully.");
            }
        }
    }
}