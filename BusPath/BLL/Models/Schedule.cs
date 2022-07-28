using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.BLL.Models
{
    public class Schedule
    {
        public Schedule(int busId, List<Stop> stops)
        {
            BusId = busId;
            Stops = stops;
        }

        public int BusId { get; }
        public List<Stop> Stops { get; }
    }
}
