using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public class InfluencesCollection<TData, TId>
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        public InfluencesCollection()
        {
            this.Values = new List<Influence<TData, TId>>();
        }

        public List<Influence<TData, TId>> Values { get; set; }

        public void Add(Influence<TData, TId> influence)
        {
            this.Values.Add(influence);
        }

        public IEnumerable<Influence<TData, TId>> OrderByDescending()
        {
            return this.Values.OrderByDescending(i => i.Value);
        }
    }
}
