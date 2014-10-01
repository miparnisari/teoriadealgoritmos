using System;
using TP1;
using TP1.Graph;
using TP1.Sort;
using TP1.Recommendations;
using TP1.GraphReader;

namespace ConsoleApplication
{
	class MainClass
	{
		public static void Main ()
		{
			var builder = new GraphBuilder(new GraphReader(@"../../Input/cbuffevant.gdf"));
			var graph = builder.Build();

			// Punto 1
			foreach (var node in graph.Sort((nodeA, nodeB) => nodeA.Degree >= nodeB.Degree))
			{
				System.Console.WriteLine(node.Data.Name + " [" + node.Degree + "]");
			}
			
			System.Console.ReadKey();

			// Punto 3
			foreach (var r in graph.Recommendations()) 
			{
				Console.WriteLine (r.Item1.Data.Name + " => " + r.Item2.Data.Name + " [" + r.Item3 + "]");
			}

			System.Console.ReadKey();
		}
	}
}
