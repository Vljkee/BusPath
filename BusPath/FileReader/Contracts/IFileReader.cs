using BusPath.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusPath.FileReader.Contracts
{
    public interface IFileReader
    {
        List<BusRoute> GetRoutes(string path);
    }
}
