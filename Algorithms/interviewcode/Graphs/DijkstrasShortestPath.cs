using System;
using System.Collections.Generic;

namespace InterviewCode
{

	/**

 *
 * Find single source shortest path using Dijkstra's algorithm
 *
 * Space complexity - O(E + V)
 * Time complexity - O(ElogV)
*/
	public class DijkstraShortestPath<T>
	{

		public int MinDistance(List<int> distance, List<bool> sptSet, int nodeCount)
		{
			int min = int.MaxValue;
			int minIndex = -1;

			for (int v = 0; v < nodeCount; v++)
			{
				if (sptSet[v] == false && distance[v] <= min)
				{
					min = distance[v];
					minIndex = v;
				}
			}
			return minIndex;
		}

		public List<int> Dijkstra(int[,] graph, int src, int nodeCount)
		{

			// holds the shortest distance from src to i
			List<int> distance = new List<int>();

			List<bool> sptSet = new List<bool>();


			// initialize distances to infinite and sptset as false
			for (int i = 0; i < nodeCount; i++)
			{
				distance[i] = int.MaxValue;
				sptSet[i] = false;
			}

			// distance of source vertex from itself is 0
			distance[src] = 0;

			// find shortest path for all vertices
			for (int count = 0; count < nodeCount - 1; count++)
			{

				// pick min distnace vertex from set of vertices
				// not yet processed
				int u = MinDistance(distance, sptSet, nodeCount);

				// mark the picked vertex as processed
				sptSet[u] = true;


				// update distance value of the adjacent vertices of the picked vertex
				for (int v = 0; v < nodeCount; v++)
				{

					// update distance[b] only if is not in sptSet, there is an edge
					// from u to v and total weight of path from src to v through u
					// is smaller than the current value of dist[v]

					int pathDistance = distance[u] + graph[u, v];

					if (!sptSet[v] && graph[u, v] != 0 &&
						distance[u] != int.MaxValue &&
						pathDistance < distance[v])
					{

						distance[v] = pathDistance;
					}


				}

			}
			return distance;
		}

		public Dictionary<Vertex<T>, int> shortestPath(Graph<T> graph, Vertex<T> sourceNode)
		{

			//heap + map data structure
			BinaryMinHeap<Vertex<T>> minHeap = new BinaryMinHeap<Vertex<T>>();

			//stores shortest distance from root to every Node
			Dictionary<Vertex<T>, int> distance = new Dictionary<Vertex<T>, int>();

			//stores parent of every Node in shortest distance
			Dictionary<Vertex<T>, Vertex<T>> parent = new Dictionary<Vertex<T>, Vertex<T>>();

			//initialize all Node with infinite distance from source Node
			foreach (Vertex<T> Node in graph.GetAllVertex())
			{
				minHeap.Add(int.MaxValue, Node);
			}

			//set distance of source Node to 0
			minHeap.decrease(sourceNode, 0);

			//put it in map
			distance.Add(sourceNode, 0);

			//source Node parent is null
			parent.Add(sourceNode, null);

			//iterate till heap is not empty
			while (!minHeap.empty())
			{
				//get the min value from heap node which has Node and distance of that Node from source Node.
				BinaryMinHeap<Vertex<T>>.Node heapNode = minHeap.extractMinNode();
				Vertex<T> current = heapNode.key;

				//update shortest distance of current Node from source Node
				distance.Add(current, heapNode.weight);

				//iterate through all edges of current Node
				foreach (Edge<T> edge in current.GetEdges())
				{

					//get the adjacent Node
					Vertex<T> adjacent = getNodeForEdge(current, edge);

					//if heap does not contain adjacent Node means adjacent
					//Node already has shortest distance from source Node
					if (!minHeap.containsData(adjacent))
					{
						continue;
					}

					//add distance of current Node to edge weight to get
					//distance of adjacent Node from source Node
					//when it goes through current Node
					int newDistance = distance[current] + edge.GetWeight();

					//see if this above calculated distance is less than current 
					//distance stored for adjacent Node from source Node
					if (minHeap.GetWeight(adjacent) > newDistance)
					{
						minHeap.decrease(adjacent, newDistance);
						parent.Add(adjacent, current);
					}
				}
			}
			return distance;
		}

		private Vertex<T> getNodeForEdge(Vertex<T> v, Edge<T> e)
		{
			return e.GetVertex1().equals(v) ? e.GetVertex2() : e.GetVertex1();
		}

		//public static void main(String args[])
		//{
		//	Graph<int> graph = new Graph<>(false);
		//	/*graph.addEdge(0, 1, 4);
		//	graph.addEdge(1, 2, 8);
		//	graph.addEdge(2, 3, 7);
		//	graph.addEdge(3, 4, 9);
		//	graph.addEdge(4, 5, 10);
		//	graph.addEdge(2, 5, 4);
		//	graph.addEdge(1, 7, 11);
		//	graph.addEdge(0, 7, 8);
		//	graph.addEdge(2, 8, 2);
		//	graph.addEdge(3, 5, 14);
		//	graph.addEdge(5, 6, 2);
		//	graph.addEdge(6, 8, 6);
		//	graph.addEdge(6, 7, 1);
		//	graph.addEdge(7, 8, 7);*/

		//	graph.addEdge(1, 2, 5);
		//	graph.addEdge(2, 3, 2);
		//	graph.addEdge(1, 4, 9);
		//	graph.addEdge(1, 5, 3);
		//	graph.addEdge(5, 6, 2);
		//	graph.addEdge(6, 4, 2);
		//	graph.addEdge(3, 4, 3);

		//	DijkstraShortestPath dsp = new DijkstraShortestPath();
		//	Node sourceNode = graph.getNode(1);
		//	Map<Node, int> distance = dsp.shortestPath(graph, sourceNode);
		//	System.out.print(distance);
		//}
	}
}
