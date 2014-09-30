using System;
using System.IO;

namespace TP1.GraphReader
{
	public abstract class BaseGraphReader
	{
		private bool StillInNodeDefinition(string[] values)
		{
			int value;
			if (Int32.TryParse(values[values.Length - 1], out value))
				return value  >= 1;
			return false;
		}

		public abstract Stream Stream {
			get;
		}

		public void Read(Action<string[]> onNodeRead, Action<string[]> onEdgeRead)
		{
			if (onNodeRead == null)
				throw new ArgumentNullException ("onNodeRead");
			if (onEdgeRead == null)
				throw new ArgumentNullException ("onEdgeRead");

			// open the file
			using (var stream = Stream) {
				using (var reader = new StreamReader(stream)) {
					// skip the first line
					reader.ReadLine ();
					// process node definitions
					while (!reader.EndOfStream) {
						var values = reader.ReadLine ().Split (',');
						if (!StillInNodeDefinition (values))
							break;
						// call handler to process a new node
						onNodeRead (values);
					}
					// process edge definitions
					while (!reader.EndOfStream) {
						var values = reader.ReadLine ().Split (',');
						if (values.Length == 2) {
							// call handler to process a new edge
							onEdgeRead (values);
						}
					}
				}
			}
		}
	}
}

