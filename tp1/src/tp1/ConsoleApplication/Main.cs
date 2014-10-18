using System.Configuration;
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
            try
            {
                var filePath = ConfigurationManager.AppSettings["inputFilePath"];
                var builder = new GraphBuilder(new GraphReader(filePath));
                var graph = builder.Build();

                // Punto 1
                System.Console.WriteLine("POPULARIDAD:");
                foreach (var node in graph.Sort((nodeA, nodeB) => nodeA.Degree >= nodeB.Degree))
                {
                    System.Console.WriteLine(node.Data.Name + " [" + node.Degree + "]");
                }

                // Punto 2
                System.Console.WriteLine("INFLUENCIAS:");
                foreach (var influence in graph.GetInfluences().OrderByDescending())
                {
                    System.Console.WriteLine(influence.Node.Data.Name + " -" + influence.Value);
                }

                // Punto 3
                System.Console.WriteLine("RECOMENDACIONES DE AMIGOS:");
                foreach (var r in graph.GetRecommendations().Recommendations)
                {
                    System.Console.WriteLine(r.Person.Data.Name + " => " + r.PersonToRecommend.Data.Name + " [" + r.FriendCount + "]");
                }

                System.Console.Write("Presione una tecla para finalizar...");
                System.Console.ReadLine();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error al leer el archivo de entrada.");
            }
        }
    }
}
