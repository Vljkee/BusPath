using BusPath.BLL.Contracts;
using BusPath.BLL.Models;
using BusPath.FileReader.Contracts;
using BusPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusPath.BLL.Implementations
{
    public class RouteService : IRouteService
    {
        //IFileReader fileReader;

        //public RouteService(IFileReader fileReader)
        //{
        //    this.fileReader = fileReader;
        //}

        IFileReader fileReader = new BusPath.FileReader.FileReader();

        public List<Schedule> GetScheduleFromFile(string filePath)
        {
            var routes = fileReader.GetRoutes(filePath);
            var result = new List<Schedule>();

            foreach (var route in routes)
            {
                var schedule = new Schedule(route.BusId, FillStopsSchedule(route));
                result.Add(schedule);
            }

            return result;
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
