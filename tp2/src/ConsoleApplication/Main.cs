using System.Text;

namespace ConsoleApplication
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using TP2.CityProfile;
    using TP2.InventoryManager;

    public class MainClass
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            
            var logger = new Logger(ConfigurationManager.AppSettings["logFileName"]);
            try
            {
                // Punto 1
                logger.Log("Ingrese el nombre del archivo para el punto 1: ");
                var fileName = System.Console.ReadLine();
                stopwatch.Start();
                using (var stream = File.OpenRead(fileName))
                {
                    var buildings = BuildingsFileReader.ReadFileContent(new StreamReader(stream));
                    var profileCityCalculator = new ProfileCityCalculator();
                    var profile = profileCityCalculator.GetProfile(buildings);
                    logger.Log("City Profile...");
                    logger.Log(BuildProfile(profile));
                    logger.Log(profile[profile.Count - 1].ToString());
                }
                stopwatch.Stop();

                // Punto 2
                logger.Log("Ingrese el nombre del archivo para el punto 2: ");
                fileName = System.Console.ReadLine();
                stopwatch.Start();
                var reader = new InventoryManagerFileReader();
                var inputData = reader.GetDataFromFile(Path.Combine(Environment.CurrentDirectory, fileName));

                int[] orderQuantities = InventoryManager.CalculateOrderQuantities(inputData);
                for (int month = 0; month < inputData.Months; month ++)
                {
                    logger.Log(string.Format("Mes {0}: comprar {1}", month, orderQuantities[month]));
                }
                stopwatch.Stop();

            }
            catch (System.Exception)
            {
                logger.Log("Error al leer el archivo de entrada.");
            }
            finally
            {
                stopwatch.Stop();
                logger.Log("Tiempo de ejecucion total (en segundos): " + stopwatch.Elapsed.TotalSeconds);
                logger.Log("Presione una tecla para finalizar...");
                logger.Dispose();
                System.Console.ReadLine();
            }
        }

        private static string BuildProfile(System.Collections.Generic.List<int> profile)
        {
            var result = new StringBuilder();
            for (var i = 0; i < profile.Count - 1; i++)
            {
                result.Append(profile[i].ToString());
                result.Append(",");
            }
            return result.ToString();
        }
    }
}
