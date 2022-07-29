using BusPath.FileReader.Contracts;
using BusPath.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPath.FileReader.Implementations
{
    public class Reader : IReader
    {
        public List<BusRoute> GetRoutes(string path)
        {
            var routeDescription = File.ReadAllLines(path);

            var routesQty = int.Parse(routeDescription[0]);
            //var uniqueStopsQty = int.Parse(routeDescription[2]);
            var departureTimes = GetDepartureTimes(routeDescription[4]);
            var prices = GetPrices(routeDescription[6]);
            var busStops = GetBusStops(routeDescription[8..(routeDescription.Length)]);

            var result = new List<BusRoute>();
            
            for (int i = 1; i <= routesQty; i++)
            {
                var route = new BusRoute(
                    busId: i,
                    departureTime: departureTimes.GetValueOrDefault(i),
                    price: prices.GetValueOrDefault(i),
                    busStops: busStops.GetValueOrDefault(i));

                result.Add(route);
            }

            return result;
        }

        private Dictionary<int, DateTime> GetDepartureTimes(string departuresString)
        {
            var splitedDepartures = departuresString.Split(' ');
            var result = new Dictionary<int, DateTime>();

            foreach (var split in splitedDepartures)
            {
                result.Add(result.Count + 1, DateTime.Parse(split));
            }

            return result;
        }

        private Dictionary<int, int> GetPrices(string pricesString)
        {
            var splitedPrices = pricesString.Split(' ');
            var result = new Dictionary<int, int>();

            foreach (var split in splitedPrices)
            {
                result.Add(result.Count + 1, int.Parse(split));
            }

            return result;
        }

        private Dictionary<int, List<BusStop>> GetBusStops(string[] stopStrings)
        {
            var result = new Dictionary<int, List<BusStop>>();

            foreach (var stopString in stopStrings)
            {
                if (stopString.Length == 0)
                    continue;

                var stops = new List<BusStop>();
                var splitedStopString = stopString.Split(' ');
                var stopQty = int.Parse(splitedStopString[0]);
                
                for (int i = 0; i < stopQty; i++)
                {
                    stops.Add(new BusStop(
                        int.Parse(splitedStopString[1 + i]),
                        int.Parse(splitedStopString[1 + i + stopQty])));
                }

                result.Add(result.Count + 1, stops);
            }

            return result;
        }
    }
}
