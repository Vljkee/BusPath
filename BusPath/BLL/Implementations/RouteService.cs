using BusPath.BLL.Contracts;
using BusPath.BLL.Models;
using BusPath.FileReader.Contracts;
using BusPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusPath.BLL.Implementations
{
    public class RouteService : IRouteService
    {
        IReader fileReader;

        public RouteService(IReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public List<Schedule> GetScheduleFromFile(string filePath)
        {
            var routes = fileReader.GetRoutes(filePath);
            var result = new List<Schedule>();

            foreach (var route in routes)
            {
                var schedule = new Schedule(route.BusId, FillStopsSchedule(route), route);
                result.Add(schedule);
            }

            return result;
        }

        public List<int> GetBusStopIds(List<Schedule> schedules)
        {
            var result = new List<int>();
            foreach (var sch in schedules)
            {
                result.AddRange(sch.Stops.Select(s => s.StopId));
            }

            return result.Distinct().ToList();
        }

        public List<int> GetEndBusStopIds(List<Schedule> schedules, int startStopId)
        {
            var filteredSchedules = schedules.Where(sch => sch.Stops.Any(s => s.StopId == startStopId)).ToList();
            return GetBusStopIds(filteredSchedules);
        }

        public List<(int busId, DateTime arrivalTime)> GetFastestBusIdAndArrivalTime(
            DateTime startTime,
            List<Schedule> schedules,
            int startStopId,
            int endStopId)
        {
            var filteredSchedules = schedules.Where(s => s.Stops.Any(s => s.StopId == startStopId)
                                                         && s.Stops.Any(s => s.StopId == endStopId));

            var fastestArrivalTime = DateTime.MaxValue;
            var busIdAndArrivalTimes = new List<(int busId, DateTime arrivalTime)>();
            foreach (var fs in filteredSchedules)
            {
                var departureTime = fs.Stops
                    .FirstOrDefault(s => s.StopId == startStopId && s.ArrivalDepartureTime >= startTime)
                    .ArrivalDepartureTime;

                var arrivalTime = fs.Stops
                    .FirstOrDefault(s => s.StopId == endStopId && s.ArrivalDepartureTime >= departureTime)
                    .ArrivalDepartureTime;
                
                if (arrivalTime < fastestArrivalTime)
                {
                    fastestArrivalTime = arrivalTime;
                }

                busIdAndArrivalTimes.Add((fs.BusId, arrivalTime));
            }

            return busIdAndArrivalTimes.Where(b => b.arrivalTime == fastestArrivalTime).ToList();
        }

        public List<(int busId, int price)> GetCheapestBusId(
            List<Schedule> schedules,
            int startStopId,
            int endStopId)
        {
            var filteredSchedules = schedules.Where(s => s.Stops.Any(s => s.StopId == startStopId)
                                                        && s.Stops.Any(s => s.StopId == endStopId));

            var lowestPrice = filteredSchedules.Min(fs => fs.Route.Price);

            return filteredSchedules
                .Where(fs => fs.Route.Price == lowestPrice)
                .Select(fs => (fs.BusId, fs.Route.Price))
                .ToList();
        }

        private List<Stop> FillStopsSchedule(BusRoute route)
        {
            var result = new List<Stop>();

            var nextStopArrivalTime = route.DepartureTime;
            var maxTime = DateTime.Today.AddDays(1);

            while (nextStopArrivalTime < maxTime)
            {
                foreach (var stop in route.BusStops)
                {
                    if (nextStopArrivalTime >= maxTime)
                        break;

                    result.Add(new Stop(stop.StopId, nextStopArrivalTime));
                    nextStopArrivalTime = nextStopArrivalTime.AddMinutes(stop.MinutsToNextStop);
                }
            }

            return result;
        }
    }
}
