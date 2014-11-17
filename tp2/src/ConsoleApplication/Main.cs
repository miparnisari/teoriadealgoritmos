using System;
using System.Configuration;
using System.Diagnostics;
using TP2;

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
                // Punto 1

                // Punto 2
                System.Console.Write("Ingrese el nombre del archivo:");
                var path = System.Console.ReadLine();
                var reader = new InventoryManagerReader();
                var inputData = reader.GetDataFromFile(path);

                var inventoryManager = new InventoryManager();
                inventoryManager.CalculateResults(inputData);

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
