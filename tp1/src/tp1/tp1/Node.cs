using System;

namespace Model
{
	public class Node<T>
	{
		public Node(T data)
		{
			this.Data = data;
		}
		
		public T Data 
		{
			get; 
			private set;
		}
	}
}

