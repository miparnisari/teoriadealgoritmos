using System;
using System.IO;

namespace ConsoleApplication
{
    public class Logger : IDisposable
    {
        private static StreamWriter streamWriter;

        public Logger(string fileName)
        {
            streamWriter = new StreamWriter(fileName);
        }

        public void Log(string message)
        {
            System.Console.WriteLine(message);
            streamWriter.WriteLine(message);
            streamWriter.Flush();
        }

        public void Dispose()
        {
            streamWriter.Close();
            streamWriter.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
