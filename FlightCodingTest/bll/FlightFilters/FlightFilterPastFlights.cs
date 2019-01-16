using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelRepublic.FlightCodingTest
{
    public class FlightFilterPastFlights : IFlightFilter
    {
        public IList<Flight> Filter(IList<Flight> flights, object arg)
        {
            if (arg == null || !(arg is DateTime))
                throw new Exception("Expected processingDateTime");

            DateTime processingDateTime = (DateTime)arg;

            List<Flight> filteredFlights = new List<Flight>(flights);
            filteredFlights.RemoveAll(
                    f => f.Segments.ToList().Find(
                    s => s.DepartureDate < processingDateTime) != null);

            return filteredFlights;
        }
    }
}
