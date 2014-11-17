using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using TP2;
using TP2.CityProfile;
using TP2.InventoryManager;

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
                System.Console.Write("Ingrese el nombre del archivo para el punto 1:");
                var fileName = System.Console.ReadLine();
                using (var stream = File.OpenRead(fileName))
                {
                    var buildings = BuildingsFileReader.ReadFileContent(new StreamReader(stream));
                    var profileCityCalculator = new ProfileCityCalculator();
                    var profile = profileCityCalculator.GetProfile(buildings);
                    System.Console.WriteLine("City Profile...");
                    for (var i = 0; i < profile.Count - 1; i++)
                    {
                        System.Console.Write(profile[i]);
                        System.Console.Write(",");
                    }
                    System.Console.Write(profile[profile.Count - 1]);
                    System.Console.WriteLine("");
                }

                // Punto 2
                System.Console.Write("Ingrese el nombre del archivo para el punto 2:");
                var path = System.Console.ReadLine();
                var reader = new InventoryManagerReader();
                var inputData = reader.GetDataFromFile(Path.Combine(Environment.CurrentDirectory, path));

                var inventoryManager = new InventoryManager();
                inventoryManager.CalculateCosts(inputData);

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
