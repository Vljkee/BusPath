using BusPath.Models;
using System.Collections.Generic;

namespace BusPath.FileReader.Contracts
{
    public interface IReader
    {
        List<BusRoute> GetRoutes(string path);
    }
}
