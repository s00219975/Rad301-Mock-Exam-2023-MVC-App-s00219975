using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_Mock_Exam_2023_DataModel_s00219975
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string TicketType { get; set; }
        public decimal TicketCost { get; set; }
        public decimal BaggageCharge { get; set; }

        // Foreign key property to represent the relationship with Flights
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }

}
