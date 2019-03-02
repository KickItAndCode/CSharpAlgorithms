using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewCode
{
	public static class StringCodeCode
	{





		public static char returnFirstNonRepeatedChar(string str)
		{

			if (str == null) throw new ArgumentNullException();

			var repeatingChars = new List<char>();
			var candidates = new List<char>();

			foreach (var i in str)
			{
				var c = char.ToUpperInvariant(i);

				if (repeatingChars.Contains(c)) continue;

				if (candidates.Contains(c))
				{
					candidates.Remove(c);
					repeatingChars.Add(c);
				}
				else
				{
					candidates.Add(c);
				}
			}

			if (candidates.Count == 0) throw new Exception("No non-repeating characters");

			return candidates[0];

		}

		public static bool isAnagram(string s1, string s2)
		{
			if (s1.Length != s2.Length) return false;
			int[] matchArray = new int[256];
			for (int i = 0; i < s1.Length; i++)
			{

				matchArray[s1[i]]++;
				matchArray[s2[i]]--;
			}

			foreach (var s in matchArray)
			{
				if (s != 0) return false;
			}


			return true;
		}

		public static void permutate(char[] str, int index)
		{

		}


		// Ran Dog The
		public static string reverseWords2(string str)
		{


			if (str.Length <= 1) return str;
			var resultString = "";
			List<string> splittedList = new List<string>();

			var word = "";
			var spaceCount = 0;

			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == ' ')
				{

					spaceCount++;
					splittedList.Add(word);
					word = "";
				}
				else
				{
					word += str[i];
				}
			}
			if (!string.IsNullOrEmpty(word)) splittedList.Add(word);


			for (int j = spaceCount; j >= 0; j--)
			{
				resultString += splittedList[j];
				resultString += ' ';
			}

			return resultString;


		}

		public static string ReverseString(string str)
		{
			char[] sArray = new char[str.Length];
			for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
			{
				char temp = str[j];
				sArray[j] = sArray[i];
				sArray[i] = temp;
			}

			return sArray.ToString();

		}


		public static void QuickSort(int[] array)
		{
			QuickSort(array, 0, array.Length - 1);
		}

		public static void QuickSort(int[] array, int left, int right)
		{
			if (left <= right)
			{
				int pivot = array[(left + right) / 2];
				int index = Partition(array, left, right, pivot);
				QuickSort(array, left, index - 1);
				QuickSort(array, index, right);
			}



		}

		public static int Partition(int[] array, int left, int right, int pivot)
		{
			while (left <= right)
			{
				while (array[left] < pivot)
				{
					left++;
				}
				while (array[right] > pivot)
				{
					right++;
				}
				if (left <= right)
				{
					Swap(ref array, left, right);
					left++;
					right--;
				}
			}
			return left;
		}

		public static void Swap(ref int[] array, int left, int right)
		{
			int temp = array[left];
			array[left] = array[right];
			array[right] = temp;
		}


		public static void QuickSort1(int[] array)
		{
			QuickSort1(array, 0, array.Length - 1);

		}

		public static void QuickSort1(int[] array, int left, int right)
		{

			if (left >= right)
			{
				return;
			}
			int pivot = array[(left + right) / 2];
			int index = Partition1(array, left, right, pivot);
			QuickSort1(array, left, index - 1);
			QuickSort1(array, index, right);
		}

		public static int Partition1(int[] array, int left, int right, int pivot)
		{

			while (left <= right)
			{

				while (array[left] < pivot)
				{
					left++;
				}
				while (array[right] > pivot)
				{
					right--;
				}

				if (left <= right)
				{
					Swap(ref array, left, right);
					left++;
					right--;
				}
			}
			return left;

		}




		public static void MergeSort1(int[] array)
		{
			MergeSort1(array, new int[array.Length], 0, array.Length - 1);
		}

		public static void MergeSort1(int[] array, int[] temp, int leftStart, int rightEnd)
		{
			if (leftStart >= rightEnd) return;

			int middle = (leftStart + rightEnd) / 2;
			MergeSort1(array, temp, leftStart, middle);
			MergeSort1(array, temp, middle + 1, rightEnd);
			MergeHalves(array, temp, leftStart, rightEnd);
		}

		public static void MergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
		{
			int leftEnd = (rightEnd + leftStart) / 2;
			int rightStart = leftEnd + 1;
			int size = rightEnd - leftStart + 1;

			int left = leftStart;
			int right = rightStart;
			int index = leftStart;


			while (left <= leftEnd && right <= rightEnd)
			{
				if (array[left] <= array[right])
				{
					temp[index] = array[left];
					left++;
				}
				else
				{
					temp[index] = array[right];
					right++;
				}
				index++;
			}

			Array.Copy(array, left, temp, index, leftEnd - left + 1);
			Array.Copy(array, right, temp, index, rightEnd - right + 1);
			// copy temp array back into original array
			Array.Copy(temp, leftStart, array, leftStart, size);
		}


		public static void MergeSort2(int[] array)
		{
			MergeSort2(array, new int[array.Length], 0, array.Length - 1);
		}

		public static void MergeSort2(int[] array, int[] temp, int leftStart, int rightEnd)
		{
			// Split list into two halves and call merge sort on both of those
			// then merge those list using mergehalves

			if (leftStart >= rightEnd) return;

			int middle = (leftStart + rightEnd) / 2;
			MergeSort2(array, temp, leftStart, middle);
			MergeSort2(array, temp, middle + 1, rightEnd);
			MergeHalves2(array, temp, leftStart, rightEnd);

		}

		public static void MergeHalves2(int[] array, int[] temp, int leftStart, int rightEnd)
		{

			int leftEnd = (leftStart + rightEnd) / 2;
			int rightStart = leftEnd + 1;
			int size = (rightEnd - leftStart) + 1;


			int left = leftStart;
			int right = rightStart;
			int index = leftStart;

			while (left <= leftEnd && right <= rightEnd)
			{
				if (array[left] < array[right])
				{
					temp[index] = array[left];
					left++;
				}
				else
				{
					temp[index] = array[right];
					right++;
				}
				index++;
			}

			// Copy back into the proper places
			Array.Copy(array, left, temp, index, leftEnd - left + 1);
			Array.Copy(array, right, temp, index, rightEnd - right + 1);

			// Copy temp back into the original array
			Array.Copy(temp, leftStart, array, leftStart, size);

		}





		/*
		 * 5.
		 * DNS Server allows for websites to be accessed with just a name when in actualilty its an ip address. It finds the corresponding IP Address for 
		 * the name of the website
		*/

		/*
		* 6.
		* Graph 
		*/

		public class Node
		{
			public String Name;
			public int Value;
			public List<Edge> Connections;

			public Node(string name)
			{
				Name = name;

				Connections = new List<Edge>();
				Random r = new Random();
				Value = r.Next(0, 60000);
			}

			public class Edge
			{
				public Node Start;
				public Node End;

				public Edge(Node start, Node end)
				{
					Start = start;
					End = end;
				}
			}

			public class Graph
			{
				private Dictionary<string, Node> NodeDictionary = new Dictionary<string, Node>();



				public Node getNode(String nodeName)
				{
					Node node = (Node)NodeDictionary[nodeName];
					if (node == null)
					{
						node = new Node(nodeName);
						NodeDictionary.Add(nodeName, node);
					}
					return node;
				}


				public void addEdge(String sourceName, String destName)
				{
					if (sourceName.Equals(destName))
						throw new Exception("can't refer to itself");
					Node a = getNode(sourceName);
					Node b = getNode(destName);
					a.Connections.Add(new Edge(a, b));
				}

				public void PrintGraph(Node startNode)
				{
					List<Node> visited = new List<Node>();
					Stack<Node> stack = new Stack<Node>();

					stack.Push(startNode);

					while (stack.Count > 0)
					{
						Node current = stack.Pop();
						if (!visited.Contains(current))
						{
							current.Connections.ForEach(e => stack.Push(e.End));
							Console.WriteLine("Node Name: " + current.Name + "Node Value: " + current.Value);
							visited.Add(current);
						}
					}
				}
			}
		}


		public static string[] checkIPs(string[] ip_array)
		{
			int numberOfIps = Convert.ToInt16(ip_array[0]);
			string[] results = new string[numberOfIps];

			for (int i = 1; i <= numberOfIps; i++)
			{

				System.Net.IPAddress address;
				if (System.Net.IPAddress.TryParse(ip_array[i], out address))
				{
					switch (address.AddressFamily)
					{
						case System.Net.Sockets.AddressFamily.InterNetwork:
							results[i - 1] = "IPv4";
							break;
						case System.Net.Sockets.AddressFamily.InterNetworkV6:
							results[i - 1] = "IPv6";
							break;
						default:
							results[i - 1] = "Neither";
							break;
					}
				}
				results[i - 1] = "Neither";
			}
			return results;

		}


	}
}
