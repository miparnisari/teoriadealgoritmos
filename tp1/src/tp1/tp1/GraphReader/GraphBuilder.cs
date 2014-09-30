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
			var g = new FacebookGraph();
			// star reading
			reader.Read(
				// process a new node
				values =>
				{
				g.AddNode(new FacebookUser(long.Parse(values[0]))
				          {
					Label = values[1]
				});
			},
			// process a new edge
			values => {
				var nodeSource = g[long.Parse(values[0])];
				var nodeDest = g[long.Parse(values[1])];
				if (nodeSource != null && nodeDest != null)
				{
					nodeSource.AddAdjacentNode(nodeDest);
					nodeDest.AddAdjacentNode(nodeSource);
				}
			});

			return g;
		}
	}
}