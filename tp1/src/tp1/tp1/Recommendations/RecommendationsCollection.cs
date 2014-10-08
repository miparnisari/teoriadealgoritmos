using System;
using System.Collections;
using System.Collections.Generic;
using TP1.Graph;

namespace TP1.Recommendations
{
    public class RecommendationsCollection<TData, TId> : IEnumerable
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        public RecommendationsCollection()
        {
            this.Recommendations = new List<Recommendation<TData, TId>>();
        }

        public List<Recommendation<TData, TId>> Recommendations { get; private set; }

        public void Add(Recommendation<TData, TId> recommendation)
        {
            if (recommendation.PersonToRecommend != null)
            {
                this.Recommendations.Add(recommendation);
            }
        }

        public int Count { get { return this.Recommendations.Count; } }

        public Recommendation<TData, TId> this[int index]
        {
            get { return this.Recommendations[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            return this.Recommendations.GetEnumerator();
        }
    }
}
