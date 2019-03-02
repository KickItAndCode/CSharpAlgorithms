using System;
using System.Collections.Generic;
namespace InterviewCode
{

	/**
	 *
	 * Data structure to support following operations
	 * extracMin - O(logn)
	 * AddToHeap - O(logn)
	 * containsKey - O(1)
	 * decreaseKey - O(logn)
	 * GetKeyWeight - O(1)
	 *
	 * It is a combination of binary heap and hash map
	 *
	 */
	public class BinaryMinHeap<T>
	{

		private List<Node> allNodes = new List<Node>();
		private Dictionary<T, int> nodePosition = new Dictionary<T, int>();

		public class Node
		{
			public int weight;
			public T key;
		}

		/**
		 * Checks where the key exists in heap or not
		 */
		public bool containsData(T key)
		{
			return nodePosition.ContainsKey(key);
		}

		/**
		 * Add key and its weight to they heap
		 */
		public void Add(int weight, T key)
		{
			Node node = new Node();
			node.weight = weight;
			node.key = key;
			allNodes.Add(node);
			int size = allNodes.Count;
			int current = size - 1;
			int parentIndex = (current - 1) / 2;
			nodePosition.Add(node.key, current);

			while (parentIndex >= 0)
			{
				Node parentNode = allNodes[parentIndex];
				Node currentNode = allNodes[current];
				if (parentNode.weight > currentNode.weight)
				{
					swap(parentNode, currentNode);
					updatePositionMap(parentNode.key, currentNode.key, parentIndex, current);
					current = parentIndex;
					parentIndex = (parentIndex - 1) / 2;
				}
				else
				{
					break;
				}
			}
		}

		/**
		 * Get the heap min without extracting the key
		 */
		public T min()
		{
			return allNodes[0].key;
		}

		/**
		 * Checks with heap is empty or not
		 */
		public bool empty()
		{
			return allNodes.Count == 0;
		}

		/**
		 * Decreases the weight of given key to newWeight
		 */
		public void decrease(T data, int newWeight)
		{
			int position = nodePosition[data];
			allNodes[position].weight = newWeight;
			int parent = (position - 1) / 2;
			while (parent >= 0)
			{
				if (allNodes[parent].weight > allNodes[position].weight)
				{
					swap(allNodes[parent], allNodes[position]);
					updatePositionMap(allNodes[parent].key,
									  allNodes[position].key, parent, position);
					position = parent;
					parent = (parent - 1) / 2;
				}
				else
				{
					break;
				}
			}
		}

		/**
		 * Get the weight of given key
		 */
		public int GetWeight(T key)
		{
			int position = nodePosition[key];
			if (position == null)
			{
				return int.MinValue;
			}
			else
			{
				return allNodes[position].weight;
			}
		}

		/**
		 * Returns the min node of the heap
		 */
		public Node extractMinNode()
		{
			int size = allNodes.Count - 1;
			Node minNode = new Node();
			minNode.key = allNodes[0].key;
			minNode.weight = allNodes[0].weight;

			int lastNodeWeight = allNodes[size].weight;
			allNodes[0].weight = lastNodeWeight;
			allNodes[0].key = allNodes[size].key;
			nodePosition.Remove(minNode.key);
			nodePosition.Remove(allNodes[0].key);
			nodePosition.Add(allNodes[0].key, 0);

			allNodes.RemoveAt(size);

			int currentIndex = 0;
			size--;
			while (true)
			{
				int left = 2 * currentIndex + 1;
				int right = 2 * currentIndex + 2;
				if (left > size)
				{
					break;
				}
				if (right > size)
				{
					right = left;
				}
				int smallerIndex = allNodes[left].weight <=
												 allNodes[right].weight ? left : right;
				if (allNodes[currentIndex].weight > allNodes[smallerIndex].weight)
				{
					swap(allNodes[currentIndex], allNodes[smallerIndex]);
					updatePositionMap(allNodes[currentIndex].key, allNodes[smallerIndex].key,
									  currentIndex, smallerIndex);
					currentIndex = smallerIndex;
				}
				else
				{
					break;
				}
			}
			return minNode;
		}
		/**
		 * Extract min value key from the heap
		 */
		public T extractMin()
		{
			Node node = extractMinNode();
			return node.key;
		}

		private void printPositionMap()
		{
			Console.WriteLine(nodePosition);
		}

		private void swap(Node node1, Node node2)
		{
			int weight = node1.weight;
			T data = node1.key;

			node1.key = node2.key;
			node1.weight = node2.weight;

			node2.key = data;
			node2.weight = weight;
		}

		private void updatePositionMap(T data1, T data2, int pos1, int pos2)
		{
			nodePosition.Remove(data1);
			nodePosition.Remove(data2);
			nodePosition.Add(data1, pos1);
			nodePosition.Add(data2, pos2);
		}

		//public void printHeap()
		//{
		//	for (Node n : allNodes)
		//	{
		//		System.out.println(n.weight + " " + n.key);
		//	}
		//}

		//public static void main(String args[])
		//{
		//	BinaryMinHeap<String> heap = new BinaryMinHeap<String>();
		//	heap.Add(3, "Tushar");
		//	heap.Add(4, "Ani");
		//	heap.Add(8, "Vijay");
		//	heap.Add(10, "Pramila");
		//	heap.Add(5, "Roy");
		//	heap.Add(6, "NTF");
		//	heap.Add(2, "AFR");
		//	heap.decrease("Pramila", 1);
		//	heap.printHeap();
		//	heap.printPositionMap();
		//}
	}

}
