namespace TP1.GraphReader
{
	public class GraphBuilder
	{
		private readonly BaseGraphReader reader;
		public GraphBuilder(BaseGraphReader reader)
		{
			this.reader = reader;
		}

		public FacebookGraph Build()
		{
			var graph = new FacebookGraph();
			
			// start reading
			reader.Read(
				// process a new node
				values =>
				{
					var id = long.Parse(values[0]);
					var name = values[1];
					graph.AddNode(new FacebookUser(id, name));
				},
				// process a new edge
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