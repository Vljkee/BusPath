using BusPath.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.BLL.Contracts
{
    public interface IRouteService
    {
        List<Schedule> GetScheduleFromFile(string filePath);

    }
}
