using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_Mock_Exam_2023_DataModel_s00219975
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Country { get; set; }
        public int MaxSeats { get; set; }

        // Navigation property to represent the relationship with Passengers
        public ICollection<Passenger> Passengers { get; set; }
    }

}
