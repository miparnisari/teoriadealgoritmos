using System;
using System.IO;
using System.Text;
using TP1.GraphReader;

namespace TP1.Test
{
	public class StringGraphReader : BaseGraphReader
	{
		private readonly string content;

		public StringGraphReader (string content)
		{
			this.content = content;
		}

		public override Stream Stream 
		{
			get {
				return new MemoryStream (Encoding.ASCII.GetBytes(this.content));
			}
		}
	}
}