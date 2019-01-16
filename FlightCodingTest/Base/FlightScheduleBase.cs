using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRepublic.FlightCodingTest
{
    public abstract class FlightScheduleBase
    {
        protected IList<Flight> flights;
        protected Dictionary<IFlightFilter, object> flightFilters = new Dictionary<IFlightFilter, object>();

        public FlightScheduleBase(IList<Flight> flights)
        {
            this.flights = new List<Flight>(flights);
        }        
        
        public IList<Flight> GetFlights()
        {
            FilterFlights();

            return flights;
        }

        protected void FilterFlights()
        {
            if (flightFilters != null)
            {
                foreach (KeyValuePair<IFlightFilter, object> flightFilter in flightFilters)
                {
                    flights = flightFilter.Key.Filter(flights, flightFilter.Value);
                }
            }
        }
    }
}
