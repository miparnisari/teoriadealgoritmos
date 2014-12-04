using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TP3.Model
{
	public class PlannerReader
	{
		public List<Task> Read(StreamReader file)
		{
			var tasks = new List<Task>();
			var id = 1;
			while (!file.EndOfStream)
			{
				var line = file.ReadLine();
				var parts = line.Split(',');
				if (parts.Length == 3)
				{
					tasks.Add(new Task(id, Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2])));
					id++;
				}
			}
			return tasks;
		}
	}
}
