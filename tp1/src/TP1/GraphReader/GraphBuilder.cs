namespace TP1.GraphReader
{
	public class GraphBuilder
	{
		private readonly BaseGraphReader reader;
		public GraphBuilder(BaseGraphReader reader)
		{
			this.reader = reader;
		}

		/// <remarks>O(N) - N = number of lines in the file - O(K+M) K = number of nodes, M = number of edges
		/// </remarks>
		public FacebookGraph Build()
		{
			var graph = new FacebookGraph();
			
			// start reading
			reader.Read(
				// process a new node - O(1)
				values =>
				{
					var id = long.Parse(values[0]);
					var name = values[1];
					graph.AddNode(new FacebookUser(id, name));
				},
				// process a new edge - O(1)
				values => 
				{
					var nodeSource = graph[long.Parse(values[0])];
					var nodeDest = graph[long.Parse(values[1])];
					if (nodeSource != null && nodeDest != null)
					{
						nodeSource.AddAdjacentNode(nodeDest);
						nodeDest.AddAdjacentNode(nodeSource);
					}
				});

			return graph;
		}
	}
}