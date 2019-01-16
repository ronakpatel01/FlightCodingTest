using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelRepublic.FlightCodingTest
{
    public class FlightFilterInvalidArrivalDate : IFlightFilter
    {
        public IList<Flight> Filter(IList<Flight> flights, object arg)
        {
            List<Flight> filteredFlights = new List<Flight>(flights);

            filteredFlights.RemoveAll(
                        f => f.Segments.ToList().Find(
                        s => s.ArrivalDate < s.DepartureDate) != null);

            return filteredFlights;
        }
    }
}
