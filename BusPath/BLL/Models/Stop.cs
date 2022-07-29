using System;

namespace BusPath.BLL.Models
{
    public class Stop
    {
        public Stop(int stopId, DateTime arrivalDepartureTime)
        {
            StopId = stopId;
            ArrivalDepartureTime = arrivalDepartureTime;
        }

        public int StopId { get; }
        public DateTime ArrivalDepartureTime { get; }
    }
}
