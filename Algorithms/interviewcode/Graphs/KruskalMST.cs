using System;
using System.Collections.Generic;

namespace InterviewCode
{

	// Find Minimum spanning tree using Kruskals Algorithm
	// Time Complexity - O (ElogE)
	// Space Complexity - O (E+V)
	public class KruskalMST
	{



		public class EdgeComparator : IComparer<Edge<int>>
		{

			public int Compare(Edge<int> edge1, Edge<int> edge2)
			{
				if (edge1.GetWeight() <= edge2.GetWeight())
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
		}


		public List<Edge<int>> getMST(Graph<int> graph)
		{
			List<Edge<int>> allEdges = graph.GetAllEdges();
			EdgeComparator edgeComparator = new EdgeComparator();
			List<Edge<int>> resultEdge = new List<Edge<int>>();

			//sort all edges in ascending order
			DisjointSet disjointSet = new DisjointSet();

			allEdges.Sort(edgeComparator);


			//create as many disjoint sets as the total vertices
			foreach (Vertex<int> vertex in graph.GetAllVertex())
			{
				disjointSet.makeSet(vertex.GetId());
			}


			foreach (Edge<int> edge in allEdges)
			{
				//get the sets of two vertices of the edge
				long root1 = disjointSet.findSet(edge.GetVertex1().GetId());
				long root2 = disjointSet.findSet(edge.GetVertex2().GetId());

				//check if the vertices are in same set or different set
				//if verties are in same set then ignore the edge
				if (root1 == root2)
				{
					continue;
				}
				else
				{
					//if vertices are in different set then add the edge to result and union these two sets into one
					resultEdge.Add(edge);
					disjointSet.union(edge.GetVertex1().GetId(), edge.GetVertex2().GetId());
				}

			}
			return resultEdge;
		}

	}
}
