using System;
using System.Collections.Generic;
namespace InterviewCode
{
	/**

	 *  
	 * Video link - https://youtu.be/ID00PMy0-vE
	 *  
	 * Disjoint sets using path compression and union by rank
	 * Supports 3 operations
	 * 1) makeSet
	 * 2) union
	 * 3) findSet
	 * 
	 * For m operations and total n elements time complexity is O(m*f(n)) where f(n) is 
	 * very slowly growing function. For most cases f(n) <= 4 so effectively
	 * total time will be O(m). Proof in Coreman book.
	 */
	public class DisjointSet
	{

		private Dictionary<long, Node> map = new Dictionary<long, Node>();

		public class Node
		{
			public long data;
			public Node parent;
			public int rank;
		}

		/**
		 * Create a set with only one element.
		 */
		public void makeSet(long data)
		{
			Node node = new Node();
			node.data = data;
			node.parent = node;
			node.rank = 0;
			map.Add(data, node);
		}

		/**
		 * Combines two sets together to one.
		 * Does union by rank
		 *
		 * @return true if data1 and data2 are in different set before union else false.
		 */
		public bool union(long data1, long data2)
		{
			Node node1 = map[data1];
			Node node2 = map[data2];

			Node parent1 = findSet(node1);
			Node parent2 = findSet(node2);

			//if they are part of same set do nothing
			if (parent1.data == parent2.data)
			{
				return false;
			}

			//else whoever's rank is higher becomes parent of other
			if (parent1.rank >= parent2.rank)
			{
				//increment rank only if both sets have same rank
				parent1.rank = (parent1.rank == parent2.rank) ? parent1.rank + 1 : parent1.rank;
				parent2.parent = parent1;
			}
			else
			{
				parent1.parent = parent2;
			}
			return true;
		}

		/**
		 * Finds the representative of this set
		 */
		public long findSet(long data)
		{
			return findSet(map[data]).data;
		}

		/**
		 * Find the representative recursively and does path
		 * compression as well.
		 */
		private Node findSet(Node node)
		{
			Node parent = node.parent;
			if (parent == node)
			{
				return parent;
			}
			node.parent = findSet(node.parent);
			return node.parent;
		}
	}
}
