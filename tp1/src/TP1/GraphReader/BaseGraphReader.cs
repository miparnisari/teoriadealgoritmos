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
                return value >= 1;
            return false;
        }

        public abstract Stream Stream
        {
            get;
        }

		/// <remarks>O(N) - N = number of lines in the file - O(K+M) K = number of nodes, M = number of edges
		/// </remarks>
		public void Read(Action<string[]> onNodeRead, Action<string[]> onEdgeRead)
        {
            if (onNodeRead == null)
                throw new ArgumentNullException("onNodeRead");
            if (onEdgeRead == null)
                throw new ArgumentNullException("onEdgeRead");

            // open the file
            using (var stream = Stream)
            {
                using (var reader = new StreamReader(stream))
                {
                    // skip the first line
                    reader.ReadLine();
                    // process node definitions
                    while (!reader.EndOfStream) // O(K) - K = number of nodes
                    {
                        var values = reader.ReadLine().Split(',');
                        if (!StillInNodeDefinition(values))
                            break;
                        // call handler to process a new node
                        onNodeRead(values);
                    }
                    // process edge definitions
                    while (!reader.EndOfStream) // O(M) - M = number of edges
                    {
                        var values = reader.ReadLine().Split(',');
                        if (values.Length == 2)
                        {
                            // call handler to process a new edge
                            onEdgeRead(values);
                        }
                    }
                }
            }
        }
    }
}

