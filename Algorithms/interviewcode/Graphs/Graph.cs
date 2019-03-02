using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewCode
{
	public class Graph<T>
	{

		private List<Edge<T>> allEdges;
		private Dictionary<long, Vertex<T>> allVertex;
		bool isDirected = false;

		public Graph(bool isDirected)
		{
			allEdges = new List<Edge<T>>();
			allVertex = new Dictionary<long, Vertex<T>>();
			this.isDirected = isDirected;
		}

		public void AddEdge(long id1, long id2)
		{
			AddEdge(id1, id2, 0);
		}

		//This works only for directed graph because for undirected graph we can end up
		//Adding edges two times to allEdges
		public void AddVertex(Vertex<T> vertex)
		{
			if (allVertex.ContainsKey(vertex.GetId()))
			{
				return;
			}
			allVertex.Add(vertex.GetId(), vertex);
			foreach (Edge<T> edge in vertex.GetEdges())
			{
				allEdges.Add(edge);
			}
		}

		public Vertex<T> AddSingleVertex(long id)
		{
			if (allVertex.ContainsKey(id))
			{
				return allVertex[id];
			}
			Vertex<T> v = new Vertex<T>(id);
			allVertex.Add(id, v);
			return v;
		}

		public Vertex<T> GetVertex(long id)
		{
			return allVertex[id];
		}

		public void AddEdge(long id1, long id2, int weight)
		{
			Vertex<T> vertex1 = null;
			if (allVertex.ContainsKey(id1))
			{
				vertex1 = allVertex[id1];
			}
			else
			{
				vertex1 = new Vertex<T>(id1);
				allVertex.Add(id1, vertex1);
			}
			Vertex<T> vertex2 = null;
			if (allVertex.ContainsKey(id2))
			{
				vertex2 = allVertex[id2];
			}
			else
			{
				vertex2 = new Vertex<T>(id2);
				allVertex.Add(id2, vertex2);
			}

			Edge<T> edge = new Edge<T>(vertex1, vertex2, isDirected, weight);
			allEdges.Add(edge);
			vertex1.AddAdjacentVertex(edge, vertex2);
			if (!isDirected)
			{
				vertex2.AddAdjacentVertex(edge, vertex1);
			}

		}

		public List<Edge<T>> GetAllEdges()
		{
			return allEdges;
		}

		public List<Vertex<T>> GetAllVertex()
		{
			return allVertex.Values.ToList();
		}
		public void setDataForVertex(long id, T data)
		{
			if (allVertex.ContainsKey(id))
			{
				Vertex<T> vertex = allVertex[id];
				vertex.setData(data);
			}
		}


		//public String toString()
		//{
		//	StringBuilder buffer = new StringBuilder();
		//	for (Edge<T> edge : GetAllEdges())
		//	{
		//		buffer.append(edge.GetVertex1() + " " + edge.GetVertex2() + " " + edge.GetWeight());
		//		buffer.append("\n");
		//	}
		//	return buffer.toString();
		//}
	}


	public class Vertex<T>
	{
		long id;
		private T data;
		private List<Edge<T>> edges = new List<Edge<T>>();
		private List<Vertex<T>> adjacentVertex = new List<Vertex<T>>();

		public Vertex(long id)
		{
			this.id = id;
		}

		public long GetId()
		{
			return id;
		}

		public void setData(T data)
		{
			this.data = data;
		}

		public T GetData()
		{
			return data;
		}

		public void AddAdjacentVertex(Edge<T> e, Vertex<T> v)
		{
			edges.Add(e);
			adjacentVertex.Add(v);
		}

		//public string toString()
		//{
		//	return string.valueOf(id);
		//}

		public List<Vertex<T>> GetAdjacentVertexes()
		{
			return adjacentVertex;
		}

		public List<Edge<T>> GetEdges()
		{
			return edges;
		}

		public int GetDegree()
		{
			return edges.Count;
		}


		public int hashCode()
		{
			int prime = 31;
			int result = 1;
			result = prime * result + (int)(id ^ (id >> 32));
			return result;
		}


		public bool equals(Object obj)
		{
			if (this == obj)
				return true;
			if (obj == null)
				return false;
			if (GetType() != obj.GetType())
				return false;

			return true;
		}
	}

	public class Edge<T>
	{
		private bool isDirected = false;
		private Vertex<T> vertex1;
		private Vertex<T> vertex2;
		private int weight;

		public Edge(Vertex<T> vertex1, Vertex<T> vertex2)
		{
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
		}

		public Edge(Vertex<T> vertex1, Vertex<T> vertex2, bool isDirected, int weight)
		{
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
			this.weight = weight;
			this.isDirected = isDirected;
		}

		public Edge(Vertex<T> vertex1, Vertex<T> vertex2, bool isDirected)
		{
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
			this.isDirected = isDirected;
		}

		public Vertex<T> GetVertex1()
		{
			return vertex1;
		}

		public Vertex<T> GetVertex2()
		{
			return vertex2;
		}

		public int GetWeight()
		{
			return weight;
		}

		public bool IsDirected()
		{
			return isDirected;
		}


		public int hashCode()
		{
			int prime = 31;
			int result = 1;
			result = prime * result + ((vertex1 == null) ? 0 : vertex1.hashCode());
			result = prime * result + ((vertex2 == null) ? 0 : vertex2.hashCode());
			return result;
		}


		public bool equals(Object obj)
		{
			if (this == obj)
				return true;
			if (obj == null)
				return false;
			if (GetType() != obj.GetType())
				return false;
			Edge<object> other = (Edge<object>)obj;
			if (vertex1 == null)
			{
				if (other.vertex1 != null)
					return false;
			}
			else if (!vertex1.equals(other.vertex1))
				return false;
			if (vertex2 == null)
			{
				if (other.vertex2 != null)
					return false;
			}
			else if (!vertex2.equals(other.vertex2))
				return false;
			return true;
		}


		public String toString()
		{
			return "Edge [isDirected=" + isDirected + ", vertex1=" + vertex1
					+ ", vertex2=" + vertex2 + ", weight=" + weight + "]";
		}
	}
}