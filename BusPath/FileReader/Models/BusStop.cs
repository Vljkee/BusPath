using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.Models
{
    public class BusStop
    {
        public BusStop(int stopId, int minutsToNextStop)
        {
            StopId = stopId;
            MinutsToNextStop = minutsToNextStop;
        }

        public int StopId { get; }
        public int MinutsToNextStop { get; }
    }
}
