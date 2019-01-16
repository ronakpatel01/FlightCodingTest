using System;
using System.Collections.Generic;
using System.Linq;


namespace TravelRepublic.FlightCodingTest
{
    public class FlightSchedular : FlightScheduleBase 
    {
        public FlightSchedular(IList<Flight> flights) : base(flights)
        {
            flightFilters.Add(new FlightFilterPastFlights(), DateTime.Now);
            flightFilters.Add(new FlightFilterInvalidArrivalDate(), null);
            flightFilters.Add(new FlightFilterGroundedGreaterThan(), 2);
        }
    }
}
