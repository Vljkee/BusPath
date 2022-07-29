using BusPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
