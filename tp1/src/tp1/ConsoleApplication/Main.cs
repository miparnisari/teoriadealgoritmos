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
			var builder = new GraphBuilder(new GraphReader(@"../../data.gdf"));
			var g = builder.Build();

			foreach (var e in g.Sort((a, b) => a.Degree >= b.Degree))
			{
				System.Console.WriteLine(e.Data.Label + " [" + e.Degree + "]");
			}
			System.Console.ReadKey();
		}
	}
}
