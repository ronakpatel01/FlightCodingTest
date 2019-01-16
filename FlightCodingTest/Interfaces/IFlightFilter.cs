using System;
using System.Collections.Generic;

// I was considering using delegates rather than interfaces to pass in the filter, but decided that Interfaces
// would be sufficient.
namespace TravelRepublic.FlightCodingTest
{
    public interface IFlightFilter
    {
        IList<Flight> Filter(IList<Flight> flights, object arg);
    }
}
