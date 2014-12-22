namespace TP3.ConsoleApplication
{
    using System.IO;
    using TP3.Model;

    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Por favor, especifique un archivo de entrada.");
                return;
            }
            System.Console.WriteLine("Planificacion:");
            var reader = new PlannerReader();
            using (var file = new FileStream(args[0], FileMode.Open))
            {
                var tasks = reader.Read(new StreamReader(file));
                var plan = Planner.GetPlan(tasks);
                foreach (var t in plan)
                {
                    System.Console.Write(t.ID + " ");
                }
            }
        }
    }
}
