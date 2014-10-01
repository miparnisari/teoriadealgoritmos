using System;
using TP1;
using TP1.Graph;
using TP1.Sort;
using TP1.GraphReader;

namespace ConsoleApplication
{
	class MainClass
	{
		public static void Main ()
		{
			var builder = new GraphBuilder(new GraphReader(@"../../Input/cbuffevant.gdf"));
			var graph = builder.Build();

			foreach (var node in graph.Sort((nodeA, nodeB) => nodeA.Degree >= nodeB.Degree))
			{
				System.Console.WriteLine(node.Data.Name + " [" + node.Degree + "]");
			}
			
			System.Console.ReadKey();
		}
	}
}
