using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public class AirInfo
    {
        public int Count { get { return Passengers.Count; } }
        public List<Passenger> Passengers = new List<Passenger>();
        public FlightInformation FlightI;
        public AirInfo(FlightInformation flight, List<Passenger> passengers)
        {
            FlightI = flight;
            Passengers = passengers;
        }

      
    }
}
