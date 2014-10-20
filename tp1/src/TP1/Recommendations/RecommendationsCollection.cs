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

		/// <remarks>O(1) best case, O(N) worst case
		/// Source: http://msdn.microsoft.com/es-AR/library/3wcytfd1(v=vs.110).aspx
		/// </remarks>
        public void Add(Recommendation<TData, TId> recommendation)
        {
            if (recommendation.PersonToRecommend != null)
            {
                this.Recommendations.Add(recommendation);
            }
        }

		/// <remarks>O(1)
		/// Source: http://msdn.microsoft.com/en-us/library/27b47ht3%28v=vs.110%29.aspx
		/// </remarks>
        public int Count { get { return this.Recommendations.Count; } }


	
		/// <remarks>O(1)
		/// Source: http://msdn.microsoft.com/en-us/library/0ebtbkkc%28v=vs.110%29.aspx
		/// </remarks>
        public Recommendation<TData, TId> this[int index]
        {
            get { return this.Recommendations[index]; }
        }

		/// <remarks>O(1)
		/// Source: http://msdn.microsoft.com/en-us/library/b0yss765%28v=vs.110%29.aspx
		/// </remarks>
        public IEnumerator GetEnumerator()
        {
            return this.Recommendations.GetEnumerator();
        }
    }
}
