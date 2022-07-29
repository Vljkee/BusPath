using BusPath.Models;
using System.Collections.Generic;

namespace BusPath.BLL.Models
{
    public class Schedule
    {
        public Schedule(int busId, List<Stop> stops, BusRoute route)
        {
            BusId = busId;
            Stops = stops;
            Route = route;
        }

        public int BusId { get; }
        public List<Stop> Stops { get; }
        public BusRoute Route { get; }
    }
}
