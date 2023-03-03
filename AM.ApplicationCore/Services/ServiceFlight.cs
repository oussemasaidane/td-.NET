using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < flights.Count; i++)
            //{
            //    if (flights[i].Destination == destination)
            //    {
            //        result.Add(flights[i].FlightDate);
            //    }
            //}
            //return result;
            //foreach(var flight in flights)
            //{
            //    if(flight.Destination== destination)
            //    {
            //        result.Add(flight.FlightDate);
            //    }
            //}
            //return result;


            //syntaxe de requete
            //var query = from f in flights
            //            where f.Destination == destination
            //            select f.FlightDate;
            //return query;
            //// ou query.toList()

            //syntaxe de methode
            var query = flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();
            return query;

        }


        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in flights
            //            where f.MyPlane == plane
            //            select f;
            //foreach(var f in query)
            //{
            //    Console.WriteLine("destination : " + f.Destination + "flight Date :" + f.FlightDate);
            //}
            //var queryLambda = flights
            //    .Where(f => f.MyPlane == plane)
            //    .Select(p => p);
            //foreach (var v in queryLambda)
            //    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);

            // syntaxe de requete
            //var req= from f in flights
            //         where(f.plane== plane)
            //         select new { f.FlightDate,f.Destination };
            //foreach(var item in req)
            //{
            //    Console.WriteLine(item.Destination +""+item.FlightDate);
            //}

            // syntaxe de methode 
            var req1 = flights
                .Where(f => f.plane == plane)
                .Select(f => new { f.FlightDate, f.Destination });
            foreach (var item in req1)
            {
                Console.WriteLine(item.Destination + "" + item.FlightDate);
            }
        }


        public int ProgrammedFlightNumber(DateTime startDate)
        {

            //var query = from f in flights
            //            where (DateTime.Compare(f.FlightDate, startDate) > 0
            //            && (f.FlightDate - startDate).TotalDays < 7)
            //            select f;

            // syntaxe de requete
            //var query = from f in flights
            //            // mathode1
            //            where ( f.FlightDate> startDate && f.FlightDate < startDate.AddDays(7))
            //            //mathode2
            //            //  where (f.FlightDate > startDate && (f.FlightDate - startDate ).TotalDays < 7)
            //            select f ;
            //return query.Count();

            // sytaxe de methode 
            return flights
                .Where(f => f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7))
                .Count();

        }

        public void GetFlights(string filterType, string filterValue)
        {
            //switch (filterType)
            //{
            //    case "Destination":
            //        foreach (Flight flight in flights)
            //        {
            //            if (flight.Destination.Equals(filterValue))
            //            {
            //                Console.WriteLine(flight);
            //            }
            //        }
            //        break;
            //    case "FlightDate":
            //        foreach (Flight flight in flights)
            //        {
            //            if (flight.FlightDate == DateTime.Parse(filterValue))
            //            {
            //                Console.WriteLine(flight);
            //            }
            //        }
            //        break;
            //    case "EstimatedDuration":
            //        foreach (Flight flight in flights)
            //        {
            //            if (flight.EstimatedDuration == int.Parse(filterValue))
            //            {
            //                Console.WriteLine(flight);
            //            }
            //        }
            //        break;
            //}


        }


        public double DurationAverage(string destination)
        {
            //var query = from f in flights
            //            where f.Destination == destination
            //            select f.EstimatedDuration;

            //return query.Average();

            // syntaxe de requete 
            //var query = from f in flights
            //            where f.Destination == destination
            //            select f.EstimateDuration;
            //return query.Average();

            // ou 
            //..
            //select f;
            // return query.Average(f=>  f.EstimateDuration);


            //syntaxe de methode 
            var query = flights
                .Where(f => f.Destination == destination)
                .Average(f => f.EstimateDuration);
            return query;




        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in flights
            //            orderby f.EstimatedDuration descending
            //            select f;

            //return query;

            // syntaxe de requete
            //var query = from f in flights
            //            orderby f.EstimateDuration descending
            //            select f;
            //return query;

            // syntaxe de methode
            return flights
               .OrderByDescending(f => f.FlightDate);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from p in flight.Passengers.OfType<Traveller>()
            //            orderby p.BirthDate ascending //par defaut
            //            select p;

            //return query.Take(3);

            //syntaxe de requete
            var query = (from f in flights
                         where f.FlightId == flight.FlightId
                         select f).Single();

            // on peut supprimer quere 
            return query.Passengers//on remplace query par flight 
                .OfType<Traveller>()
                .OrderBy(p => p.BirthDate).Take(3);
            // .skip(query, 3); ignorer les 3 premiers

        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var reqLambda = flights.GroupBy(f => f.Destination);
            //foreach (var group in reqLambda)
            //{
            //    Console.WriteLine("Destination " + group.Key);
            //    foreach(var v in group)
            //    {
            //        Console.WriteLine("Decollage: " + v.FlightDate);
            //    }
            //}
            //return reqLambda;

            var req = flights
                .GroupBy(f => f.Destination);
            foreach (var item in req)
            {
                Console.WriteLine("destination:" + item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine("decollage:" + item1.FlightDate);
                }
            }
            return req;
        }

        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public ServiceFlight()
        {
            FlightDetailsDel = plane =>
        {

            // syntaxe de methode 
            var req1 = flights
                .Where(f => f.plane == plane)
                .Select(f => new { f.FlightDate, f.Destination });
            foreach (var item in req1)
            {
                Console.WriteLine(item.Destination + "" + item.FlightDate);
            }
        };
            DurationAverageDel = destination =>
        {
            //syntaxe de methode 
            var query = flights
                .Where(f => f.Destination == destination)
                .Average(f => f.EstimateDuration);
            return query;

        };

        }
    }
}