using System;
using System.Collections.Generic;

namespace BusPath.Models
{
    public class BusRoute
    {
        public BusRoute(int busId, DateTime departureTime, int price, List<BusStop> busStops)
        {
            BusId = busId;
            DepartureTime = departureTime;
            Price = price;
            BusStops = busStops;
        }

        public int BusId { get; }
        public DateTime DepartureTime { get; }
        public int Price { get; }
        public List<BusStop> BusStops { get; }
    }
}
