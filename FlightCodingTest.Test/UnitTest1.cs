using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelRepublic.FlightCodingTest;

namespace FlightCodingTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFlightFilterPastFlights()
        {
            FlightBuilder fb = new FlightBuilder();
            Dictionary<IFlightFilter, object> customFilters = new Dictionary<IFlightFilter, object>();
            customFilters.Add(new FlightFilterPastFlights(), DateTime.Now);

            CustomerFilterFlightSchedular flightSchedular = new CustomerFilterFlightSchedular(fb.GetFlights(), customFilters);
            IList<Flight> flights = flightSchedular.GetFlights();

            Assert.AreEqual(5, flights.Count);
        }

        [TestMethod]
        public void TestFlightFilterInvalidArrivalDate()
        {
            FlightBuilder fb = new FlightBuilder();
            Dictionary<IFlightFilter, object> customFilters = new Dictionary<IFlightFilter, object>();
            customFilters.Add(new FlightFilterInvalidArrivalDate(), null);

            CustomerFilterFlightSchedular flightSchedular = new CustomerFilterFlightSchedular(fb.GetFlights(), customFilters);
            IList<Flight> flights = flightSchedular.GetFlights();

            Assert.AreEqual(5, flights.Count);
        }

        [TestMethod]
        public void TestFlightFilterGroundedGreaterThan2()
        {
            FlightBuilder fb = new FlightBuilder();
            Dictionary<IFlightFilter, object> customFilters = new Dictionary<IFlightFilter, object>();
            customFilters.Add(new FlightFilterGroundedGreaterThan(), 2);

            CustomerFilterFlightSchedular flightSchedular = new CustomerFilterFlightSchedular(fb.GetFlights(), customFilters);
            IList<Flight> flights = flightSchedular.GetFlights();

            Assert.AreEqual(4, flights.Count);
        }

        [TestMethod]
        public void TestFlightFilterAll()
        {
            FlightBuilder fb = new FlightBuilder();
            Dictionary<IFlightFilter, object> customFilters = new Dictionary<IFlightFilter, object>();

            FlightSchedular flightSchedular = new FlightSchedular(fb.GetFlights());
            IList<Flight> flights = flightSchedular.GetFlights();

            Assert.AreEqual(2, flights.Count);
        }

    }
}
