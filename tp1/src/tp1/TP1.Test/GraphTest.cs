using System;
using NUnit.Framework;
using TP1.GraphReader;

namespace TP1.Test
{
	[TestFixture]
	public class GraphTest
	{
		[Test]
		public void TestCase ()
		{
			// setup
			var fileContent = 
				"nodedef>name VARCHAR,label VARCHAR,sex VARCHAR,locale VARCHAR,agerank INT" + Environment.NewLine +
				"1,Juan,male,es_LA,2" + Environment.NewLine +
				"2,Maria,female,es_LA,1" + Environment.NewLine +
				"edgedef>node1 VARCHAR,node2 VARCHAR" + Environment.NewLine +
				"1,2";
			var builder = new GraphBuilder (new StringGraphReader (fileContent));

			// act
			var g = builder.Build ();

			// assert
			Assert.AreEqual (2, g.Count);
			Assert.AreEqual ("Juan", g [1].Data.Name);
			Assert.AreEqual ("Maria", g [2].Data.Name);
			Assert.AreEqual (1, g [1].Adjacents.Count);
			Assert.AreEqual (1, g [1].Degree);
			Assert.AreEqual (1, g [2].Adjacents.Count);
			Assert.AreEqual (1, g [2].Degree);
			Assert.IsTrue(g[1].Adjacents.ContainsKey(2));
			Assert.IsTrue(g[2].Adjacents.ContainsKey(1));
		}
	}
}

