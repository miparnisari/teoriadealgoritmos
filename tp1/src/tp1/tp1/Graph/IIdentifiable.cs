using System;

namespace TP1.Graph
{
	public interface IIdentifiable<TId> where TId : IComparable
	{
		TId Id
		{
			get;
		}
	}
}