using System.Linq;
using TP1.Influences;
using TP1.Sort;
using TP1.Recommendations;
using TP1.GraphReader;

namespace ConsoleApplication
{
    class MainClass
    {
        public static void Main()
        {
            var builder = new GraphBuilder(new GraphReader(@"../../Input/cbuffevant.gdf"));
            var graph = builder.Build();

            // Punto 1
            //foreach (var node in graph.Sort((nodeA, nodeB) => nodeA.Degree >= nodeB.Degree))
            //{
            //    System.Console.WriteLine(node.Data.Name + " [" + node.Degree + "]");
            //}

            //System.Console.ReadKey();

            // Punto 2
            foreach (var influence in graph.Influences().OrderByDescending())
            {
                System.Console.WriteLine(influence.Node.Data.Name + " -" + influence.Value);
            }

            System.Console.ReadKey();

            // Punto 3
            //foreach (var r in graph.Recommendations())
            //{
            //    System.Console.WriteLine(r.Person.Data.Name + " => " + r.PersonToRecommend.Data.Name + " [" + r.FriendCount + "]");
            //}

            //System.Console.ReadKey();
        }
    }
}
