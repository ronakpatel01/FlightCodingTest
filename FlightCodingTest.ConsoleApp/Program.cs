using System;
using System.Collections.Generic;
using System.Linq;
using TravelRepublic.FlightCodingTest;

namespace FlightCodingTest.ConsoleApp
{
    class Program
    {
        static void DisplayFlightInfo(string infoType, IList<Flight> flights)
        {
            Console.WriteLine(infoType);
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine($"\r\nflight {i + 1}");
                foreach (Segment s in flights[i].Segments)
                {
                    Console.WriteLine($"Depart:{s.DepartureDate} Arrive:{s.ArrivalDate}");
                }
            }
        }

        static void Main(string[] args)
        {
            FlightBuilder fb = new FlightBuilder();
            IList<Flight> flights = fb.GetFlights();

            DisplayFlightInfo("All Flights", flights);

            FlightSchedular flightSchedular = new FlightSchedular(flights);
            IList<Flight> filteredFlights = flightSchedular.GetFlights();
            DisplayFlightInfo("After Filter", filteredFlights);

            Console.ReadKey();
        }
    }
}
