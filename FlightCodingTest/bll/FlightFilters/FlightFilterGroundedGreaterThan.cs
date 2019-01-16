using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRepublic.FlightCodingTest
{
    public class FlightFilterGroundedGreaterThan : IFlightFilter
    {
        public IList<Flight> Filter(IList<Flight> flights, object arg)
        {
            if (arg == null || !(arg is int))
                throw new Exception("Expected time on the ground");

            int maxGroundedTime = (int)arg;

            List<Flight> filteredFlights = new List<Flight>();
            foreach (Flight flight in flights)
            {
                TimeSpan totalGroundedTime = new TimeSpan(0);
                DateTime? landedTime = null;
                foreach(Segment segment in flight.Segments)
                {
                    if (landedTime != null)
                        totalGroundedTime += (segment.DepartureDate - landedTime.Value);

                    if (totalGroundedTime.Hours >= maxGroundedTime)
                        break;

                    landedTime = segment.ArrivalDate;
                }
                if (totalGroundedTime.Hours < maxGroundedTime)
                    filteredFlights.Add(flight);
            }

            return filteredFlights;
        }
    }
}
