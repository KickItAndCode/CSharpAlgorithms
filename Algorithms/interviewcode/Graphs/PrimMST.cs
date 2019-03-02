using System;
using System.Collections.Generic;
using System.Linq;
namespace InterviewCode
{
	public class PrimMST
	{


		private Vertex<int> getVertexForEdge(Vertex<int> v, Edge<int> e)
		{
			return e.GetVertex1().equals(v) ? e.GetVertex2() : e.GetVertex1();
		}

		public List<Edge<int>> PrimMSTAlgo(Graph<int> graph)
		{
			// heap + map
			BinaryMinHeap<Vertex<int>> heap = new BinaryMinHeap<Vertex<int>>();

			// vertex to edge which gave min weight to this vertex
			Dictionary<Vertex<int>, Edge<int>> vertexToEdge = new
				Dictionary<Vertex<int>, Edge<int>>();

			List<Edge<int>> result = new List<Edge<int>>();

			// init with infinity
			foreach (Vertex<int> v in graph.GetAllVertex())
			{
				heap.Add(int.MaxValue, v);
			}

			// start from random vertex
			Vertex<int> startVertex = graph.GetAllVertex().FirstOrDefault();

			heap.decrease(startVertex, 0);

			while (!heap.empty())
			{

				Vertex<int> current = heap.extractMin();

				// get corresponding edge for this vertex if present and add it to 
				//the final result
				Edge<int> spanningTreeEdge = vertexToEdge[current];

				if (spanningTreeEdge != null)
				{
					result.Add(spanningTreeEdge);
				}

				foreach (Edge<int> edge in current.GetEdges())
				{

					Vertex<int> adjacent = getVertexForEdge(current, edge);

					// check if adjacent vertex exist in heap + map and 
					// weight attached with this vertex si greater than
					// this edge weight

					if (heap.containsData(adjacent) && heap.GetWeight(adjacent) > edge.GetWeight())
					{

						// decreate the value of adjacent vertex to this edge weight
						heap.decrease(adjacent, edge.GetWeight());

						// add vertex-> edge mapping in the graph
						vertexToEdge.Add(adjacent, edge);

					}
				}

			}
			return result;

		}

	}
}
