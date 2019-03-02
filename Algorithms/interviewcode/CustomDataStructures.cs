using System;
using System.Collections.Generic;
namespace InterviewCode
{
	public class CustomDataStructures
	{
		public CustomDataStructures()
		{
		}
	}


	public class StackNode
	{
		public int val;
		public StackNode next;
		public StackNode(int val)
		{
			this.val = val;

		}
	}

	public class QueueNode
	{
		public int val;
		public QueueNode next;
		public QueueNode(int val)
		{
			this.val = val;

		}
	}
	/*Graphs
	*/

	//public class Graph
	//{

	//	private List<int>[] childNodes;

	//	public Graph(int size)
	//	{
	//		this.childNodes = new List<int>[size];
	//		for (int i = 0; i < size; i++)
	//		{
	//			this.childNodes[i] = new List<int>();
	//		}
	//	}
	//	public Graph(List<int>[] childNodes)
	//	{
	//		this.childNodes = childNodes;
	//	}

	//	public int Size
	//	{
	//		get { return this.childNodes.Length; }

	//	}

	//	public void AddEdge(int u, int v)
	//	{
	//		childNodes[u].Add(v);
	//	}

	//	public void RemoveEdge(int u, int v)
	//	{
	//		childNodes[u].Remove(v);
	//	}

	//	public bool HasEdge(int u, int v)
	//	{
	//		return childNodes[u].Contains(v);
	//	}

	//	public List<int> GetSuccessors(int v)
	//	{
	//		return childNodes[v];

	//	}

	//}

	public class HashEntry
	{
		private int key;
		private int val;

		public HashEntry(int key, int val)
		{
			this.key = key;
			this.val = val;
		}

		public int GetKey()
		{
			return key;

		}

		public int GetValue()
		{
			return val;
		}
	}

	public class HashMap
	{

		private readonly int TABLESIZE = 128;

		HashEntry[] table;
		public HashMap()
		{
			table = new HashEntry[TABLESIZE];

			for (int i = 0; i < TABLESIZE; i++)
			{
				table[i] = null;
			}

		}

		public int Get(int key)
		{
			int hash = (key % TABLESIZE);

			while (table[hash] != null && table[hash].GetKey() != key)
				hash = (hash + 1) % TABLESIZE;

			if (table[hash] == null)
				return -1;
			else
				return table[hash].GetValue();
		}

		public void Put(int key, int val)
		{
			int hash = (key % TABLESIZE);
			while (table[hash] != null && table[hash].GetKey() != key)
				hash = (hash + 1) % TABLESIZE;

			table[hash] = new HashEntry(key, val);
		}
	}

	public class Stack
	{

		public StackNode top;

		public int Pop()
		{
			if (top == null) throw new Exception("Stack Empty");
			int item = top.val;
			top = top.next;
			return item;
		}

		public void Push(int item)
		{
			StackNode t = new StackNode(item);
			t.next = top;
			top = t;
		}

		public int Peek()
		{
			if (top == null) throw new Exception("Stack Enpty");
			return top.val;
		}

		public bool IsEmpty()
		{
			return top == null;
		}
	}

	public class Queue
	{
		public QueueNode first;
		public QueueNode last;

		public void Add(int item)
		{
			QueueNode t = new QueueNode(item);
			if (last != null)
			{
				last.next = t;
			}

			last = t;
			if (first == null)
			{
				first = last;
			}
		}

		public int Remove()
		{
			if (first == null) throw new Exception("No such element");
			int data = first.val;
			first = first.next;
			if (first == null)
			{
				last = null;
			}
			return data;
		}

		public int Peek()
		{
			if (first == null) throw new Exception("No such element");
			return first.val;
		}

		public bool IsEmpty()
		{
			return first == null;
		}

	}
}
