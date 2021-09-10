using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Interfaces
{
    public interface IHandleRoutes
    {
        void PrepareDijkstra();
        string PrepareKShortestPaths();
    }

}
