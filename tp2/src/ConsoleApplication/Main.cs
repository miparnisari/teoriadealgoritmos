using System.Configuration;
using System.Diagnostics;

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
                // Code goes here
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
