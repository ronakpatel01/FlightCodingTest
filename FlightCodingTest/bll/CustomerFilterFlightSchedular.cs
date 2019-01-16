using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRepublic.FlightCodingTest
{
    public class CustomerFilterFlightSchedular : FlightScheduleBase
    {
        public CustomerFilterFlightSchedular(IList<Flight> flights, Dictionary<IFlightFilter, object> customFilters) : base(flights)
        {
            flightFilters = customFilters;
        }
    }
}
