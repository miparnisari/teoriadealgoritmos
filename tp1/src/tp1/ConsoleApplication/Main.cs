using System.Configuration;
using System.Diagnostics;
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var logger = new Logger(ConfigurationManager.AppSettings["logFileName"]);
            try
            {
                var filePath = ConfigurationManager.AppSettings["inputFilePath"];
                var builder = new GraphBuilder(new GraphReader(filePath));
                var graph = builder.Build();

                // Punto 1
                logger.Log("POPULARIDAD:");
                foreach (var node in graph.Sort((nodeA, nodeB) => nodeA.Degree >= nodeB.Degree))
                {
                    logger.Log(node.Data.Name + " [" + node.Degree + "]");
                }

                // Punto 2
                logger.Log("INFLUENCIAS:");
                foreach (var influence in graph.GetInfluences().OrderByDescending())
                {
                    logger.Log(influence.Node.Data.Name + " [" + influence.Value + "]");
                }

                // Punto 3
                logger.Log("RECOMENDACIONES DE AMIGOS:");
                foreach (var r in graph.GetRecommendations().Recommendations)
                {
                    logger.Log(r.Person.Data.Name + " => " + r.PersonToRecommend.Data.Name + " [" + r.FriendCount + "]");
                }
            }
            catch (System.Exception)
            {
                logger.Log("Error al leer el archivo de entrada.");
            }
            finally
            {
                stopwatch.Stop();
                logger.Log("Tiempo de ejecucion total (en segundos): " + stopwatch.Elapsed.TotalSeconds);
                logger.Dispose();
                System.Console.Write("Presione una tecla para finalizar...");
                System.Console.ReadLine();
            }
        }
    }
}
