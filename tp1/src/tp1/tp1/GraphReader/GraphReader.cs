using System;
using System.IO;

namespace TP1.GraphReader
{
	public class GraphReader : BaseGraphReader
	{
		private readonly string filePath;

		public GraphReader(string filePath)
		{
			this.filePath = filePath;
		}

		public override Stream Stream 
		{
			get 
			{
				return File.OpenRead (this.filePath);
			}
		}
	}
}