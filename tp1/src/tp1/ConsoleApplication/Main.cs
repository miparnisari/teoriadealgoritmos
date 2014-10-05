using tp1.Influences;
using TP1.Sort;
using TP1.Recommendations;
using TP1.GraphReader;

namespace ConsoleApplication
{
    class MainClass
    {
        public static void Main()
        {
            var builder = new GraphBuilder(new GraphReader(@"../../Input/miparnisari.gdf"));
            var graph = builder.Build();

            // Punto 1
            foreach (var node in graph.Sort((nodeA, nodeB) => nodeA.Degree >= nodeB.Degree))
            {
                System.Console.WriteLine(node.Data.Name + " [" + node.Degree + "]");
            }

            System.Console.ReadKey();

            // Punto 2
            foreach (var influence in graph.Influences())
            {
                System.Console.WriteLine(influence.Item1.Data.Name + " [" + influence.Item2 + "]");
            }

            System.Console.ReadKey();

            // Punto 3
            foreach (var r in graph.Recommendations())
            {
                System.Console.WriteLine(r.Person.Data.Name + " => " + r.PersonToRecommend.Data.Name + " [" + r.FriendCount + "]");
            }

            System.Console.ReadKey();
        }
    }
}
