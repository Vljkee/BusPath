using BusPath.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.BLL.Contracts
{
    public interface IRouteService
    {
        List<Schedule> GetScheduleFromFile(string filePath);
        List<int> GetBusStopIds(List<Schedule> schedules);
        List<int> GetEndBusStopIds(List<Schedule> schedules, int startStopId);
        public List<(int busId, DateTime arrivalTime)> GetFastestBusIdAndArrivalTime(
            DateTime startTime,
            List<Schedule> schedules,
            int startStopId,
            int endStopId);
        public List<(int busId, int price)> GetCheapestBusId(List<Schedule> schedules,
            int startStopId,
            int endStopId);
    }
}
