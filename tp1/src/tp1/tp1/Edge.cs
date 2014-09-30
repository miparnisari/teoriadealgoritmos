using System;

namespace Model
{
	public class Edge<T>
	{
		public Edge (Node<T> startNode, Node<T> endNode)
		{
			this.StartNode = startNode;
			this.EndNode = endNode;
		}
		
		public Node<T> StartNode
		{
			get;
			private set;
		}
		
		public Node<T> EndNode 
		{
			get;
			private set;
		}
	}
}

