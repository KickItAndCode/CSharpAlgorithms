using System;
using System.Collections.Generic;
namespace InterviewCode
{
	public static class ArrayCode
	{



		//Number of triangles possible from a set of numbers  
		//http://www.geeksforgeeks.org/find-number-of-triangles-possible/
		public static int numberOfTriangles(int[] input)
		{
			Array.Sort(input);

			int count = 0;
			for (int i = 0; i < input.Length - 2; i++)
			{
				int k = i + 2;
				for (int j = i + 1; j < input.Length; j++)
				{
					while (k < input.Length && input[i] + input[j] > input[k])
					{
						k++;
					}
					count += k - j - 1;
				}
			}
			return count;

		}

		public static int[] PlusOne(int[] digits)
		{

			int n = digits.Length;
			for (int i = n - 1; i >= 0; i--)
			{
				// anything less then 9 doesn't overflow
				if (digits[i] < 9)
				{
					digits[i]++;
					return digits;
				}

				// if it does overflow i is decremented
				//and its previous number is increased
				digits[i] = 0;
			}

			int[] newNumber = new int[n + 1];
			newNumber[0] = 1;

			return newNumber;
		}

		// Container With Most Water
		/**
 * Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai).
 * n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines,
 * which together with x-axis forms a container, such that the container contains the most water.
 *
 * https://leetcode.com/problems/container-with-most-water/
 */
		public static int maxArea(int[] height)
		{
			int i = 0;
			int j = height.Length - 1;
			int maxArea = 0;
			while (i < j)
			{
				if (height[i] < height[j])
				{
					int area = (height[i]) * (j - i);
					maxArea = Math.Max(maxArea, area);
					i++;
				}
				else
				{
					int area = (height[j]) * (j - i);
					maxArea = Math.Max(maxArea, area);
					j--;
				}
			}
			return maxArea;
		}

		/*
		 * O(log (m+n) Time
		https://leetcode.com/problems/median-of-two-sorted-arrays/?tab=Description*/
		public static double FindMedianSortedArrays(int[] arr1, int[] arr2)
		{

			int low1 = 0;
			int high1 = arr1.Length - 1;

			int low2 = 0;
			int high2 = arr2.Length - 1;

			while (true)
			{

				if (high1 == low1)
				{
					return (arr1[low1] + arr2[low2]) / 2;
				}

				if (high1 - low1 == 1)
				{
					return (double)(Math.Max(arr1[low1], arr2[low2])
						+ Math.Min(arr1[high1], arr2[high2])) / 2;
				}

				double med1 = GetMedian(arr1, low1, high1);
				double med2 = GetMedian(arr2, low1, high2);

				if (med1 <= med2)
				{
					if ((high1 - low1 + 1) % 2 == 0)
					{
						low1 = (high1 + low1) / 2;
						high2 = (high2 + low2) / 2 + 1;
					}
					else
					{
						low1 = (low1 + high1) / 2;
						high2 = (low2 + high2) / 2;
					}
				}
				else
				{
					if ((high1 - low1 + 1) % 2 == 0)
					{
						low2 = (high2 + low2) / 2;
						high1 = (high1 + low1) / 2 + 1;
					}
					else
					{
						low2 = (low2 + high2) / 2;
						high1 = (low1 + high1) / 2;
					}
				}
			}
		}

		public static double GetMedian(int[] arr, int low, int high)
		{
			int len = high - low + 1;
			if (len % 2 == 0)
			{
				return (arr[low + len / 2] + arr[low + len / 2 - 1]) / 2;
			}
			else
			{
				return arr[low + len / 2];
			}
		}

		/*Given a large array of integers and a window of size 'w', find the
		 * current maximum in the window as the window slides through the
		 * entire array.
		 * Time O (n)
		 * Space O (w)
		*/


		public static int[] FindMaxSlidingWindow(int[] input, int windowSize)
		{
			if (input.Length == 0) return new int[0];

			LinkedList<int> list = new LinkedList<int>();

			int[] result = new int[input.Length + 1 - windowSize];


			for (int i = 0; i < windowSize - 1; i++)
			{
				AddDescList(list, input[i]);
			}

			for (int i = 0; i < result.Length; i++)
			{
				AddDescList(list, input[i + windowSize]);
				result[i] = list.First.Value;

				if (input[i] == list.First.Value)
					list.RemoveFirst(); // deletes the left most
			}

			return result;


		}
		public static void AddDescList(LinkedList<int> descList, int inputVal)
		{
			while (descList.Count > 0 && inputVal > descList.Last.Value)
			{
				descList.RemoveLast();
			}
			descList.AddLast(inputVal);
		}

		public static int FindLeastCommonNumber(int[] a1, int[] a2, int[] a3)
		{

			int i = 0, j = 0, k = 0;

			while (i < a1.Length && j < a2.Length && k < a3.Length)
			{

				if (a1[i] == a2[j] && a2[j] == a3[k])
				{
					return a1[i];
				}

				if (a1[i] <= a2[j] && a1[i] <= a3[k])
				{
					i++;
				}
				else if (a2[j] <= a1[i] && a2[j] <= a3[k])
				{
					j++;
				}
				else if (a3[k] <= a1[i] && a3[k] <= a2[j])
				{
					k++;
				}

			}
			return -1;
		}

		/*Runtime O(n) Memory O(1)*/
		public static void RotateArrayInPlace(List<int> arr, int n)
		{
			int len = arr.Count;


			n = n % len;

			if (n < 0)
			{
				n = n + len;
			}

			ReverseArray(arr, 0, len - 1);
			ReverseArray(arr, 0, n - 1);
			ReverseArray(arr, n, len - 1);

		}

		// O(n) Space
		// O(n) Time
		//public static void RotateArray(List<int> arr, int n)
		//{
		//	int len = arr.Count;
		//	// Let's normalize rotations
		//	// if n > array size or n is negative.
		//	n = n % len;
		//	if (n < 0)
		//	{
		//		// calculate the positive rotations needed.
		//		n = n + len;
		//	}

		//	List<int> temp = Arrays.asList(new Integer[n]);

		//	// copy last N elements of array into temp
		//	for (int i = 0; i < n; i++)
		//	{
		//		temp.set(i, arr.get(len - n + i));
		//	}

		//	// shift original array
		//	for (int i = len - 1; i >= n; i--)
		//	{
		//		arr.set(i, arr.get(i - n));
		//	}

		//	// copy temp into original array
		//	for (int i = 0; i < n; i++)
		//	{
		//		arr.set(i, temp.get(i));
		//	}
		//}

		public static int[] LeftRotate(int[] a, int rotations)
		{
			int[] abc = new int[a.Length];
			int n = a.Length;
			for (int i = 0; i < a.Length; i++)
			{
				int temp = i - rotations;
				if (temp < 0)
				{
					temp = temp + n;
				}
				abc[temp] = a[i];
			}
			return abc;
		}


		public static void LeftRotateByOne(int[] a, int size)
		{

			int i, temp;
			temp = a[0];
			for (i = 0; i < size - 1; i++)
			{
				a[i] = a[i + 1];
			}
			a[i] = temp;
		}
		// handle null
		// O(1) Space
		// O (n*m) time
		public static int[] LeftRotate2(int[] a, int d)
		{

			if (d < 0)
			{
				d = d + a.Length;
			}
			for (int i = 0; i < d; i++)
			{
				LeftRotateByOne(a, a.Length);
			}
			return a;
		}

		public static void ReverseArray(List<int> arr, int start, int end)
		{

			while (start < end)
			{
				int temp = arr[start];
				arr[start] = arr[end];
				arr[end] = temp;
				++start;
				--end;
			}
		}

		public static int FindLowIndex(List<int> arr, int key)
		{

			int low = 0;
			int high = arr.Count - 1;
			int mid = high / 2;
			while (low <= high)
			{

				if (arr[mid] < key)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
				mid = low + (high - low) / 2;
			}

			if (arr[low] == key) return low;

			return -1;

		}

		public static int FindHighIndex(List<int> arr, int key)
		{

			int low = 0;
			int high = arr.Count - 1;
			int mid = high / 2;
			while (low <= high)
			{

				if (arr[mid] <= key)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
				mid = low + (high - low) / 2;
			}

			if (arr[high] == key) return high;

			return -1;

		}

		public static void MoveZerosLeft(int[] arr)
		{

			if (arr == null) return;

			int read = arr.Length - 1;
			int write = arr.Length - 1;

			while (read >= 0)
			{
				if (arr[read] != 0)
				{

					arr[write] = arr[read];
					write--;
				}
				read--;
			}
			while (write >= 0)
			{
				arr[write] = 0;
				write--;
			}
		}

		/**

		* Find the contiguous subarray within an array (containing 
		* at least one number) which has the largest product.
		*
		* Time complexity is O(n)
		* Space complexity is O(1)
		*
		* http://www.geeksforgeeks.org/maximum-product-subarray/
		* https://leetcode.com/problems/maximum-product-subarray/
		*/

		public static int MaxProductSubarray(int[] nums)
		{
			int min = 1;
			int max = 1;
			int maxSoFar = nums[0];
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] > 0)
				{
					max = max * nums[i];
					min = Math.Min(min * nums[i], 1);
					maxSoFar = Math.Max(maxSoFar, max);
				}
				else if (nums[i] == 0)
				{
					min = 1;
					max = 1;
					maxSoFar = Math.Max(maxSoFar, 0);
				}
				else
				{
					int t = max * nums[i];
					maxSoFar = Math.Max(maxSoFar, min * nums[i]);
					max = Math.Max(1, min * nums[i]);
					min = t;
				}
			}
			return maxSoFar;
		}

		/*
		Step1. Select the middle element of the array.
		So the maximum subarray may contain that middle element or not.

		Step 2.1 If the maximum subarray does not contain the middle element,
		then we can apply the same algorithm to the the subarray to the left 
		of the middle element and the subarray to the right of the middle element.

		Step 2.2 If the maximum subarray does contain the middle element, 
		then the result will be simply the maximum suffix subarray of the
		left subarray plus the maximum prefix subarray of the right subarray

		Step 3 return the maximum of those three answer.*/
		public static int maxSubArray(int[] A, int n)
		{
			// IMPORTANT: Please reset any member data you declared, as
			// the same Solution instance will be reused for each test case.
			if (n == 0) return 0;
			return maxSubArrayHelperFunction(A, 0, n - 1);
		}

		// O(nlogN) slower than iterative version 
		public static int maxSubArrayHelperFunction(int[] A, int left, int right)
		{
			if (right == left) return A[left];
			int middle = (left + right) / 2;
			int leftans = maxSubArrayHelperFunction(A, left, middle);
			int rightans = maxSubArrayHelperFunction(A, middle + 1, right);
			int leftmax = A[middle];
			int rightmax = A[middle + 1];
			int temp = 0;
			for (int i = middle; i >= left; i--)
			{
				temp += A[i];
				if (temp > leftmax) leftmax = temp;
			}
			temp = 0;
			for (int i = middle + 1; i <= right; i++)
			{
				temp += A[i];
				if (temp > rightmax) rightmax = temp;
			}
			return Math.Max(Math.Max(leftans, rightans), leftmax + rightmax);
		}


		// O(n)
		public static int MaxSubArray(int[] A, int n)
		{
			int sum = 0, min = 0, res = A[0];
			for (int i = 0; i < n; i++)
			{
				sum += A[i];
				if (sum - min > res) res = sum - min;
				if (sum < min) min = sum;
			}
			return res;
		}

		public static int MaxSubArrayClear(int[] nums)
		{

			int sum = nums[0];
			int max = sum;
			for (int i = 1; i < nums.Length; i++)
			{
				sum = nums[i] + (sum > 0 ? sum : 0);
				max = Math.Max(max, sum);
			}
			return max;
		}

		// Max Profit selling stock given int []
		// 7,1,5,3,6,4 result would be 6-1 as selling prices must be larger then buying price

		public static int MaxProfit(int[] prices)
		{
			int min = int.MaxValue, max = 0;
			foreach (int t in prices)
			{
				min = Math.Min(min, t);
				max = Math.Max(max, t - min);
			}
			return max;

		}


		public static Tuple<int, int> FindBuySellStockPrices(int[] array)
		{

			if (array == null || array.Length < 2)
			{
				return null;
			}

			int currentBuy = array[0];
			int globalSell = array[1];
			int globalProfit = globalSell - currentBuy;

			int currentProfit = int.MinValue;

			for (int i = 1; i < array.Length; i++)
			{
				currentProfit = array[i] - currentBuy;

				if (currentProfit > globalProfit)
				{
					globalProfit = currentProfit;
					globalSell = array[i];
				}

				if (currentBuy > array[i])
				{
					currentBuy = array[i];
				}
			}

			Tuple<int, int> result = new Tuple<int, int>(globalSell - globalProfit, globalSell);
			return result;
		}




		/*Given an array (list) of intervals as input where each interval has a 
		 * start and end timestamps  Input array is sorted by starting timestamps. 
		 * You are required to merge overlapping intervals and return output array (list).
		*/
		public static List<Tuple<int, int>> MergeIntervals(List<Tuple<int, int>> list)
		{

			if (list == null || list.Count == 0) return null;

			List<Tuple<int, int>> newList = new List<Tuple<int, int>>();
			newList.Add(new Tuple<int, int>(list[0].Item1, list[0].Item2));


			for (int i = 1; i < list.Count; i++)
			{
				int x1 = list[i].Item1;
				int y1 = list[i].Item2;
				int x2 = newList[newList.Count - 1].Item1;
				int y2 = newList[newList.Count - 1].Item2;


				if (y2 >= x1)
				{
					newList[newList.Count - 1] = new Tuple<int, int>(newList[newList.Count - 1].Item1
																	, Math.Max(y1, y2));
				}
				else
				{
					newList.Add(new Tuple<int, int>(x1, y1));
				}
			}
			return newList;
		}

		public static bool SumOfTwo(int[] arr, int val)
		{

			HashSet<int> foundValues = new HashSet<int>();
			foreach (int num in arr)
			{
				if (foundValues.Contains(val - num))
				{
					return true;
				}
				foundValues.Add(num);
			}
			return false;
		}


		/* return the shortest distance between these two words in the list.*/
		public static int ShortestDistance(string[] words, string word1, string word2)
		{

			int index1 = -1;
			int index2 = -1;

			int minDistance = words.Length;

			for (int i = 0; i < words.Length; i++)
			{

				if (words[i].Equals(word1))
				{
					index1 = i;
				}
				else if (word1[i].Equals(word2))
				{
					index2 = i;
				}

				if (index1 != -1 && index2 != -1)
				{
					minDistance = Math.Min(minDistance, Math.Abs(index1 - index2));
				}
			}
			return minDistance;
		}

		// Word 1 and word2 could be the same
		public static int ShortestDistanceIII(String[] words, String word1, String word2)
		{
			int min = int.MaxValue;
			int p1 = -1;
			int p2 = -1;
			bool same = word1.Equals(word2);
			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Equals(word1))
				{
					if (same)
					{
						p2 = p1;  // Deal with another pointer too
					}
					p1 = i;
				}
				else if (words[i].Equals(word2))
				{
					p2 = i;
				}

				if (p1 != -1 && p2 != -1)
				{
					min = Math.Min(min, Math.Abs(p1 - p2));
				}
			}
			return min;
		}

		/*when we need to find the shortest path of two string, just get the two list
		 * of these two string. Use two pointers and scan the two lists at the same 
		 * time. When any pointer reach the end. Stop the loop. When we found out that
		 * the first position is greater than the second one. We add one to the second 
		 * pointer. Else, add to the first pointer. This idea is like always keep 
		 * minimum difference between the two position and move the two pointers.*/
		// shortest distance 2 create a class so this can happen over and over
		public class WordDistance
		{
			private Dictionary<string, List<int>> map;

			public WordDistance(string[] words)
			{

				map = new Dictionary<string, List<int>>();
				for (int i = 0; i < words.Length; i++)
				{
					string w = words[i];
					if (map.ContainsKey(w))
					{
						map[w].Add(i);
					}
					else
					{
						List<int> list = new List<int>();
						list.Add(i);
						map.Add(w, list);
					}
				}
			}

			public int ShortestDistance(string word1, string word2)
			{
				List<int> list1 = map[word1];
				List<int> list2 = map[word2];
				int result = int.MaxValue;
				int i = 0, j = 0;
				while (i < list1.Count && j < list2.Count)
				{
					int index1 = list1[i];
					int index2 = list2[j];
					if (index1 < index2)
					{
						result = Math.Min(result, index2 - index1);
						i++;
					}
					else
					{
						result = Math.Min(result, index1 - index2);
						j++;
					}
				}
				return result;
			}
		}


		public interface NestedInteger
		{
			bool IsInteger();
			int GetInteger();
			List<NestedInteger> GetList();
		}


		public static int depthSum(List<NestedInteger> nestedList)
		{
			return depthSum(nestedList, 1);
		}

		public static int depthSum(List<NestedInteger> list, int depth)
		{
			int sum = 0;
			foreach (NestedInteger n in list)
			{
				if (n.IsInteger())
				{
					sum += n.GetInteger() * depth;
				}
				else
				{
					sum += depthSum(n.GetList(), depth + 1);
				}
			}
			return sum;
		}

		public static int DepthSumInverseWorking(List<NestedInteger> nestedList)
		{

			return Helper(nestedList, 0);
		}
		public static int Helper(List<NestedInteger> nestedList, int pre)
		{
			if (nestedList.Count == 0) return 0;

			List<NestedInteger> nextLevel = new List<NestedInteger>();

			foreach (NestedInteger nestedInteger in nestedList)
			{
				if (nestedInteger.IsInteger())
				{
					pre += nestedInteger.GetInteger();
				}
				else
				{
					nextLevel.AddRange(nestedInteger.GetList());
				}
			}
			pre += Helper(nextLevel, pre);
			return pre;
		}

		public class TwoSum
		{

			private Dictionary<int, int> map = new Dictionary<int, int>();
			public void Add(int number)
			{

				if (map.ContainsKey(number))
				{

					map[number]++;
				}
				else
				{
					map.Add(number, 1);

				}
			}

			public bool Find(int value)
			{
				foreach (var entry in map)
				{
					int i = entry.Key;
					int j = value - i;

					if ((i == j && entry.Value > 1) || i != j && map.ContainsKey(j))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static int LengthLongestPath(string input)
		{
			string[] paths = input.Split('\n');
			int[] stack = new int[paths.Length + 1];
			int maxLen = 0;
			foreach (string s in paths)
			{
				int lev = s.LastIndexOf("\t") + 1;
				int curLen = stack[lev + 1] = stack[lev] + s.Length - lev + 1;

				// if you find file extention compare current length with max lenth
				if (s.Contains("."))
					maxLen = Math.Max(maxLen, curLen - 1);
			}
			return maxLen;
		}



		//public static int LongestZigZag(int[] arr)
		//{

		//	int result = 0;

		//	for (int i = 0; i < arr.Length; i++)
		//	{
		//		if (arr[)

		//	}

		//}

	}
}
