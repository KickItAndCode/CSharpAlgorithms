using System;
using System.Collections.Generic;
using System.Linq;
namespace InterviewCode
{
	public class CycleInDirectedGraph
	{

		public bool hasCycle(Graph<int> graph)
		{
			HashSet<Vertex<int>> whiteSet = new HashSet<Vertex<int>>();
			HashSet<Vertex<int>> graySet = new HashSet<Vertex<int>>();
			HashSet<Vertex<int>> blackSet = new HashSet<Vertex<int>>();

			foreach (Vertex<int> vertex in graph.GetAllVertex())
			{
				whiteSet.Add(vertex);
			}

			while (whiteSet.Count > 0)
			{
				Vertex<int> current = whiteSet.FirstOrDefault();
				if (dfs(current, whiteSet, graySet, blackSet))
				{
					return true;
				}
			}
			return false;
		}

		private bool dfs(Vertex<int> current, HashSet<Vertex<int>> whiteSet,
						 HashSet<Vertex<int>> graySet, HashSet<Vertex<int>> blackSet)
		{
			//move current to gray set from white set and then explore it.
			moveVertex(current, whiteSet, graySet);
			foreach (Vertex<int> neighbor in current.GetAdjacentVertexes())
			{
				//if in black set means already explored so continue.
				if (blackSet.Contains(neighbor))
				{
					continue;
				}
				//if in gray set then cycle found.
				if (graySet.Contains(neighbor))
				{
					return true;
				}
				if (dfs(neighbor, whiteSet, graySet, blackSet))
				{
					return true;
				}
			}
			//move vertex from gray set to black set when done exploring.
			moveVertex(current, graySet, blackSet);
			return false;
		}

		private void moveVertex(Vertex<int> vertex, HashSet<Vertex<int>> sourceSet,
								HashSet<Vertex<int>> destinationSet)
		{
			sourceSet.Remove(vertex);
			destinationSet.Add(vertex);
		}
	}
}
