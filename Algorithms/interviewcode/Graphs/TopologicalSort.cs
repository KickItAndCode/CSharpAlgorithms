using System;
using System.Collections.Generic;
namespace InterviewCode
{
	public class TopologicalSort<T>
	{


		/**
		* Given a directed acyclic graph, do a topological sort on this graph.
		*
		*
		*Linear ordering of vertices such that for every directed edge uv, 
		*vertex u comes before v in the ordering. Not possible if the graph is not a DAG
		* Do DFS by keeping visited. Put the vertex which are completely explored
		* into a stack Pop from stack to get sorted order.
		*
		* Space and time complexity is O(n).
		*/
		public Stack<Vertex<T>> topSort(Graph<T> graph)
		{
			Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
			HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
			foreach (Vertex<T> vertex in graph.GetAllVertex())
			{
				if (visited.Contains(vertex))
				{
					continue;
				}
				topSortUtil(vertex, stack, visited);
			}
			return stack;
		}

		private void topSortUtil(Vertex<T> vertex, Stack<Vertex<T>> stack,
								 HashSet<Vertex<T>> visited)
		{
			visited.Add(vertex);
			foreach (Vertex<T> childVertex in vertex.GetAdjacentVertexes())
			{
				if (visited.Contains(childVertex))
				{
					continue;
				}
				topSortUtil(childVertex, stack, visited);
			}
			stack.Push(vertex);
		}

		public void ShortestPath(Stack<Vertex<int>> stack)
		{

			int[] dist = new int[stack.Count];

			for (int i = 0; i < stack.Count; i++)
			{
				dist[i] = int.MaxValue;

			}



			while (stack.Count > 0)
			{
				Vertex<int> node = stack.Pop();
				var u = node.GetData();
				if (dist[u] != int.MaxValue)
				{

					foreach (Vertex<int> n in node.GetAdjacentVertexes())
					{
						int v = n.GetData();

						// update distance 
						//if (dist[v] > dist[u] + 

						//  if (dist[i.getV()] > dist[u] + i.getWeight())
						//dist[i.getV()] = dist[u] + i.getWeight();
					}
				}
			}
		}




	}

}


