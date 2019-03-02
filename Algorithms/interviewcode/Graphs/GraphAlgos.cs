using System;
using System.Collections.Generic;
using System.Linq;
namespace InterviewCode
{

	public class GraphAlgos
	{

		//	// BFS
		//	public void SearchBFS(Node root)
		//	{
		//		Queue<Node> queue = new Queue<Node>();
		//		root.state = State.Visited;
		//		queue.Enqueue(root);

		//		while (queue.Count > 0)
		//		{
		//			Node r = queue.Dequeue();
		//			Console.Write(r.name);
		//			foreach (Node n in r.getAdjacent())
		//			{
		//				if (n.state == State.Unvisited)
		//				{
		//					n.state = State.Visited;
		//					queue.Enqueue(n);
		//				}
		//			}

		//		}
		//	}


		//	// DFS
		//	public void Search(Node root)
		//	{
		//		if (root == null) return;
		//		Console.Write(root.name);
		//		root.state = State.Visited;
		//		foreach (Node n in root.getAdjacent())
		//		{
		//			if (n.state == State.Unvisited)
		//			{
		//				Search(n);
		//			}
		//		}
		//	}




		public void DFSIterative(Vertex<int> root)
		{
			if (root == null) return;
			List<Vertex<int>> visited = new List<Vertex<int>>();
			Stack<Vertex<int>> stack = new Stack<Vertex<int>>();

			stack.Push(root);

			while (stack.Count > 0)
			{

				var current = stack.Pop();
				Console.Write(current.GetData());
				visited.Add(current);
				foreach (var v in current.GetAdjacentVertexes())
				{
					if (!visited.Contains(v))
					{

						stack.Push(v);
					}

				}
			}
		}



		// Time Complexity: O(V+E) 
		public void SearchBFS(Vertex<int> root)
		{
			Queue<Vertex<int>> queue = new Queue<Vertex<int>>();
			List<Vertex<int>> visited = new List<Vertex<int>>();
			visited.Add(root);

			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				Vertex<int> r = queue.Dequeue();
				Console.Write(r.GetData());
				foreach (Vertex<int> n in r.GetAdjacentVertexes())
				{
					if (!visited.Contains(n))
					{
						visited.Add(n);
						queue.Enqueue(n);
					}

				}

			}
		}

		public void DFS(Vertex<int> root)
		{

			List<Vertex<int>> visited = new List<Vertex<int>>();
			if (root == null) return;

			DFSUtil(visited, root);
		}

		public void DFSUtil(List<Vertex<int>> visited,
							 Vertex<int> root)
		{

			visited.Add(root);
			Console.Write(root.GetData());
			foreach (Vertex<int> v in root.GetAdjacentVertexes())
			{
				if (!visited.Contains(v))
				{
					DFSUtil(visited, v);
				}
			}
		}







		/*http://tengfei.tech/2016/05/28/Leetcode-207-Course-Schedule/
		 * There are a total of n courses you have to take, labeled from 0 to n - 1.

		Some courses may have prerequisites, for example to take course 0 you 
		have to first take course 1, which is expressed as a pair: [0,1]

		Given the total number of courses and a list of prerequisite pairs, 
		is it possible for you to finish all courses?

		It’s a typical topological sorting problem.

		Use a NxN matrix (N is the number of course) to represent the courses 
		graph relationship. Use an array list to store the in-degree of every
		course. Use a queue to store the nodes which in-degree is 0.

		Firstly, go through the input array to construct the graph matrix and 
		record the in-degree of every node at the same time. Then go through 
		the in-degree list, put the nodes which in-degree is 0 into the queue. 
		*/
		public bool CanFinish(int numCourses, int[,] prerequisites)
		{


			int[,] matrix = new int[numCourses, numCourses];
			int[] indegree = new int[numCourses];

			for (int i = 0; i < prerequisites.Length; i++)
			{
				int current = prerequisites[i, 0];
				int pre = prerequisites[i, 1];

				// build indegree list and update matrix list 
				if (matrix[pre, current] == 0)
				{
					indegree[current]++;
				}
				matrix[pre, current] = 1;
			}

			Queue<int> queue = new Queue<int>();
			for (int i = 0; i < numCourses; i++)
			{

				// store 0 indegree nodes
				if (indegree[i] == 0)
				{
					queue.Enqueue(i);
				}
			}


			int count = 0;
			while (queue.Count > 0)
			{
				int current = queue.Dequeue();
				count++;

				for (int i = 0; i < numCourses; i++)
				{
					if (matrix[current, i] != 0)
					{
						if (--indegree[i] == 0)
						{
							queue.Enqueue(i);
						}
					}
				}
			}
			return numCourses == count;
		}


		public bool CanFinish2(int numCourses, int[,] prerequisites)
		{

			if (prerequisites == null) return false;
			int len = prerequisites.Length;

			if (numCourses == 0 || len == 0) return true;

			int[] visited = new int[numCourses];


			// map to store what cources depend on a course
			Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

			for (int i = 0; i < prerequisites.GetLength(0); i++)
			{
				// Add course first course as a pre req
				if (map.ContainsKey(prerequisites[i, 1]))
				{
					map[prerequisites[i, 1]].Add(prerequisites[i, 0]);
					// not in map so add it and make a list of that pre req
				}
				else
				{
					List<int> list = new List<int>();
					list.Add(prerequisites[i, 0]);
					map.Add(prerequisites[i, 1], list);
				}
			}

			for (int i = 0; i < numCourses; i++)
			{

				if (!DFS(map, visited, i))
					return false;
			}
			return true;
		}

		public bool DFS(Dictionary<int, List<int>> map, int[] visited, int i)
		{

			if (visited[i] == -1) return false;

			if (visited[i] == 1) return true;

			visited[i] = -1;

			if (map.ContainsKey(i))
			{
				foreach (int j in map[i])
				{
					if (!DFS(map, visited, j))
						return false;
				}
			}
			visited[i] = 1;
			return true;
		}
		//public class Graph
		//{

		//	// DFS
		//	public void Search(Node root)
		//	{
		//		if (root == null) return;
		//		Console.Write(root.name);
		//		root.state = State.Visited;
		//		foreach (Node n in root.getAdjacent())
		//		{
		//			if (n.state == State.Unvisited)
		//			{
		//				Search(n);
		//			}
		//		}
		//	}



		//	public void SearchDFS(int[][] matrix, Node root)
		//	{
		//		Stack<Node> stack = new Stack<Node>();
		//		stack.Push(root);
		//		root.state = State.Visited;
		//		while (stack.Count > 0)
		//		{
		//			Node node = stack.Pop();
		//			Console.Write(node.name);
		//			foreach (Node n in node.getAdjacent())
		//			{
		//				if (n.state != State.Visited)
		//				{
		//					stack.Push(n);
		//					n.state = State.Visited;
		//				}
		//			}
		//		}
		//	}

		//	// Given a directed graph, design an algorithm to  
		//	//find out whether there is a route be- tween two nodes

		//	public static bool FindLink(Graph g, Node start, Node end)
		//	{
		//		Stack<Node> stack = new Stack<Node>();

		//		// set all to univisited state
		//		foreach (Node n in g.getNodes())
		//		{
		//			n.state = State.Unvisited;
		//		}

		//		// push start on the stack
		//		start.state = State.Visited;
		//		stack.Push(start);
		//		Node node;

		//		while (stack.Count > 0)
		//		{

		//			// Grab top node
		//			node = stack.Pop();
		//			if (node != null)
		//			{

		//				//iterate through all adjacent nodes checking for end
		//				foreach (Node v in node.getAdjacent())
		//				{
		//					if (v.state == State.Unvisited)
		//					{
		//						if (v == end)
		//						{
		//							return true;
		//						}
		//						else
		//						{
		//							// if not end add to stack to be visited later
		//							v.state = State.Visiting;
		//							stack.Push(v);

		//						}
		//					}
		//				}
		//			}
		//			node.state = State.Visited;
		//		}
		//		return false;
		//	}






		//	private Dictionary<string, Node> nodes;

		//	public Graph()
		//	{
		//		nodes = new Dictionary<string, Node>();
		//	}

		//	public Node addNode(string name)
		//	{
		//		Node node = new Node(name);
		//		nodes.Add(name, node);
		//		return node;
		//	}

		//	public Node getNode(string name)
		//	{
		//		return nodes[name];
		//	}

		//	public List<Node> getNodes()
		//	{
		//		return nodes.Values.ToList();
		//	}





		//}

		//public class Edge
		//{

		//	public Node from;
		//	public Node to;

		//	public Edge(Node from, Node to)
		//	{
		//		this.from = from;
		//		this.to = to;
		//	}
		//}

		//public class Node
		//{
		//	public string name;
		//	public HashSet<Edge> inEdges;
		//	public HashSet<Edge> outEdges;
		//	public State state;

		//	public Node(string name)
		//	{
		//		this.name = name;
		//		inEdges = new HashSet<Edge>();
		//		outEdges = new HashSet<Edge>();
		//	}

		//	public Node addEdgeTo(Node node)
		//	{
		//		Edge e = new Edge(this, node);
		//		outEdges.Add(e);
		//		node.inEdges.Add(e);
		//		return this;
		//	}

		//	public HashSet<Node> getAdjacent()
		//	{
		//		HashSet<Node> adjacentNodes = new HashSet<Node>();
		//		foreach (Edge edge in outEdges)
		//		{
		//			adjacentNodes.Add(edge.to);
		//		}
		//		return adjacentNodes;
		//	}

		//	public String toString()
		//	{
		//		return name;
		//	}

		//}

		//public enum State
		//{
		//	Unvisited,
		//	Visited,
		//	Visiting
		//}

	}
}