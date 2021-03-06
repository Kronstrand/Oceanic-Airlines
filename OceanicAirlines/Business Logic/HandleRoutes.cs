using OceanicAirlines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Programmerare.ShortestPaths.Core.Api;
using Programmerare.ShortestPaths.Adapter.Bsmock;
using Programmerare.ShortestPaths.Adapter.YanQi;
using static Programmerare.ShortestPaths.Core.Impl.VertexImpl;  // CreateVertex
using static Programmerare.ShortestPaths.Core.Impl.WeightImpl;  // CreateWeight
using static Programmerare.ShortestPaths.Core.Impl.EdgeImpl;    // CreateEdge
using static Programmerare.ShortestPaths.Core.Impl.GraphImpl;   // CreateGraph
using System.Text;
using OceanicAirlines.DataAccessLayer;
using OceanicAirlines.Business_Logic;

namespace OceanicAirlines.Business_Logic
{
	public class HandleRoutes : IHandleRoutes
	{
		List<Vertex> vertices;
		IList<Edge> edges;
        private List<OceanicAirlines.Models.City> cities;
        private Dictionary<String, Vertex> vortexSet;
		List<ResultPathDTO> finalResultPaths;
		private OceanicAirlinesContext db = new OceanicAirlinesContext();

		public HandleRoutes()
		{

			vertices = new List<Vertex>();
			edges = new List<Edge>();
			finalResultPaths = new List<ResultPathDTO>();
		}

        private void SetupTheGraph()
        {
            cities = db.Cities.ToList();
			vortexSet = new Dictionary<string, Vertex>();

			foreach (OceanicAirlines.Models.City city in cities)
            {
                Vertex a = CreateVertex(city.Name);
                vertices.Add(a);
                vortexSet.Add(city.Name, a);
            }

            foreach (OceanicAirlines.Models.City city in cities)
			{
				List<OceanicAirlines.Models.Route> routes = city.OriginCityRoutes.ToList();
				foreach (OceanicAirlines.Models.Route route in routes)
                {
                    Edge newEdge = CreateEdge(vortexSet[city.Name], vortexSet[route.Destination.Name], CreateWeight(8));
                    if (!edges.Contains(newEdge))
                    {
                        if (route.Available)
                        {
                            edges.Add(newEdge);
						}
					}
				}
				
			}
        }

		private void setupTestData()
		{
			Vertex a = CreateVertex("ST. HELENA");
			Vertex b = CreateVertex("SIERRRA LEONE");
			Vertex c = CreateVertex("MARRAKESH");
			Vertex d = CreateVertex("TANGER");
			Vertex e = CreateVertex("TRIPOLI");
			Vertex f = CreateVertex("KAPSTADEN");
			Vertex g = CreateVertex("KABALD");
			Vertex h = CreateVertex("DARFUR");
			Vertex i = CreateVertex("GULDKYSTEN");

			vertices.Add(a);
			vertices.Add(b);
			vertices.Add(c);
			vertices.Add(d);
			vertices.Add(e);
			vertices.Add(f);
			vertices.Add(g);
			vertices.Add(h);
			vertices.Add(i);

			//This is necessary to add both directions.
			int hoursPerPath = 8;

			edges.Add(CreateEdge(a, b, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(b, a, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(a, f, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(f, a, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(b, c, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(c, b, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(c, d, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(d, c, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(d, e, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(e, d, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(e, h, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(h, e, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(h, g, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(g, h, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(g, f, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(f, g, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(i, c, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(c, i, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(i, e, CreateWeight(hoursPerPath)));
			edges.Add(CreateEdge(e, i, CreateWeight(hoursPerPath)));
		}

		public String PrepareKShortestPaths(string originCity, string destinationCity)
		{
			PathFinderFactory pathFinderFactory = new PathFinderFactoryYanQi();
			//setupTestData();
			SetupTheGraph();
			Graph graph = CreateGraph(edges);

			PathFinder pathFinder = pathFinderFactory.CreatePathFinder(graph);

			IList<Path> shortestPathsFromAtoD = pathFinder.FindShortestPaths(vortexSet[originCity], vortexSet[destinationCity], 3);

			String resultPaths = "", currentPath;

			foreach (Path pathFromAtoD in shortestPathsFromAtoD)
			{
				currentPath = pathFromAtoD.GetPathAsPrettyPrintedStringForConsoleOutput(this);
				resultPaths = string.Concat(resultPaths, currentPath, '\n');
				Console.WriteLine(currentPath);
			}

			return resultPaths;
		}

		public List<ResultPathDTO> GetResultPathDTOs()
		{
			return finalResultPaths;
		}

        public List<OceanicAirlines.Models.City> GetCitiesList()
        {
            return cities;
        }

		public void SetAnotherFinalResultPathDTO(ResultPathDTO newDTOPath)
		{
			finalResultPaths.Add(newDTOPath);
		}
	}
}
public class ResultPathDTO
{
	public TimeSpan totalCostInHours;
	public double totalCostInDollars = 0;
	List<SinglePathDTO> singlePaths;

	public ResultPathDTO()
	{
		singlePaths = new List<SinglePathDTO>();
		totalCostInHours = new TimeSpan(0, 0, 0, 0, 0);
	}

	public void addSinglePath(String originVertexIdSingle, String destinationVertexIdSingle, TimeSpan costInHours, double costInDollars)
	{
		SinglePathDTO newSinglePath = new SinglePathDTO();
		newSinglePath.originVertexId = originVertexIdSingle;
		newSinglePath.destinationVertexId = destinationVertexIdSingle;
		singlePaths.Add(newSinglePath);
		totalCostInHours = totalCostInHours.Add(costInHours);
		totalCostInDollars += costInDollars;

	}

	public string getMessageString()
	{
		String message = totalCostInHours + " ";

		foreach (SinglePathDTO currentPath in singlePaths)
		{
			message = string.Concat(message, currentPath.getMessageString());

		}

		return message;

	}

}

public class SinglePathDTO
{
	public string originVertexId;
	public string destinationVertexId;

	public string getMessageString()
	{
		return "(" + originVertexId + " -> " + destinationVertexId + ") ";
	}
}

public static class MyExtensionMethods
{
	public static string GetPathAsPrettyPrintedStringForConsoleOutput(this Path path, HandleRoutes handleRoutes)
	{
		ResultPathDTO pathDTO = new ResultPathDTO();
		//TODO to check the origin and if not Flight then add custom value
		//pathDTO.totalCostInHours.Add(TimeSpan.FromHours(path.TotalWeightForPath.WeightValue));

		var sb = new StringBuilder();
		IList<Edge> edges = path.EdgesForPath;
		sb.Append(path.TotalWeightForPath.WeightValue + " ( ");
		for (int i = 0; i < edges.Count; i++)
		{
			if (i > 0) sb.Append(" + ");
			sb.Append(edges[i].GetEdgeAsPrettyPrintedStringForConsoleOutput());
			double costInHours = edges[i].EdgeWeight.WeightValue;
			pathDTO.addSinglePath(edges[i].StartVertex.VertexId, edges[i].EndVertex.VertexId, TimeSpan.FromHours(costInHours), 40);
		}
		sb.Append(")");
		handleRoutes.SetAnotherFinalResultPathDTO(pathDTO);
		return sb.ToString();
	}
	private static string GetEdgeAsPrettyPrintedStringForConsoleOutput(this Edge edge)
	{
		return edge.EdgeWeight.WeightValue + " [" + edge.StartVertex.VertexId + "--->" + edge.EndVertex.VertexId + "] ";
	}
}