using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.Models
{
    public class BusRoute
    {
        public BusRoute(int busId, /*int stopQty,*/ DateTime departureTime, int price, List<BusStop> busStops)
        {
            BusId = busId;
            //StopQty = stopQty;
            DepartureTime = departureTime;
            Price = price;
            BusStops = busStops;
        }

        public int BusId { get; }
        //int StopQty { get; }
        public DateTime DepartureTime { get; }
        public int Price { get; }
        public List<BusStop> BusStops { get; }
    }
}
