using BusPath.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.FileReader.Contracts
{
    public interface IReader
    {
        List<BusRoute> GetRoutes(string path);
    }
}
