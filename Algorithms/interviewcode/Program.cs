using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCode
{
	public class Program
	{
		public static int[] amounts = { 1, 7, 30 };
		public static int[] costPerAmounts = { 2, 7, 25 };
		/* Target minus current number = value to look for. Ones you find that value 
         * in the map then get the index of both
         */

		// 1, 10, 5, 7
		// 7-1 
		public static int[] TwoSum(int[] numbers, int target)
		{
			Dictionary<int, int> map = new Dictionary<int, int>();
			int[] result = new int[2];

			for (int i = 0; i < numbers.Length; i++)
			{
				if (map.ContainsKey(numbers[i]))
				{
					int index = map[numbers[i]];
					result[0] = index;
					result[1] = i;
					break;
				}
				else
				{
					map[target - numbers[i]] = i;
				}
			}

			return result;
		}

		// Sorted Array 
		public static int[] TwoSum2(int[] numbers, int target)
		{
			if (numbers == null || numbers.Length == 0)
				return null;
			int i = 0;
			int j = numbers.Length - 1;
			while (i < j)
			{
				int x = numbers[i] + numbers[j];
				if (x < target)
				{
					++i;
				}
				else if (x > target)
				{
					j--;
				}
				else
				{
					return new int[] { i + 1, j + 1 };
				}
			}
			return null;
		}

		static Dictionary<int, int> elements = new Dictionary<int, int>();

		public static void add(int number)
		{
			if (elements.ContainsKey(number))
			{
				elements.Add(number, elements[number] + 1);
			}
			else
			{
				elements.Add(number, 1);
			}
		}

		public static bool find(int value)
		{
			foreach (int i in elements.Keys)
			{
				int target = value - i;
				if (elements.ContainsKey(target))
				{
					if (i == target && elements[target] < 2)
					{
						continue;
					}
					return true;
				}
			}
			return false;
		}


		// -1, 2, 1, 4 target 1
		// -1 ,1 ,2, 4
		//  ^  ^  ^
		public static int threeSumClosest(int[] arr, int target)
		{

			int min = Int32.MaxValue;
			int result = 0;

			Array.Sort(arr);

			for (int i = 0; i < arr.Length - 2; i++)
			{

				if (i == 0 || arr[i] > arr[i - 1])
				{
					int start = i + 1;
					int end = arr.Length - 1;

					while (start < end)
					{
						int sum = arr[i] + arr[start] + arr[end];
						int diff = sum - target;

						// success case
						if (diff == 0)
						{
							return sum;
						}
						// updates current result and min
						if (diff < min)
						{
							min = diff;
							result = sum;
						}

						// increments
						if (sum <= target)
						{
							start++;
						}
						else
						{
							end--;
						}
					}


				}
			}
			return result;
		}
		//
		public static int minSubArrayLen2(int target, int[] arr)
		{

			int start = -1;
			int end = -1;
			int min = int.MaxValue;

			for (int i = 0; i < arr.Length; i++)
			{

				int currentSum = 0;
				for (int j = i; j < arr.Length && j - i + 1 < min; j++)
				{
					currentSum += arr[j];
					if (currentSum == target)
					{
						start = i;
						end = j;
						min = end - start + 1;
						break;
					}
				}
			}
			if (min != int.MaxValue)
				return min;
			else return 0;
		}


		// 2,3,1,2, 4, 3 S=7
		public int minSubArrayLen(int target, int[] arr)
		{
			if (arr == null || arr.Length == 1)
				return 0;

			int result = arr.Length;
			int start = 0;
			int sum = 0;
			int i = 0;
			bool exist = false;

			while (i < arr.Length)
			{

				if (sum >= target)
				{
					exist = true;

					if (start == i - 1)
					{
						return 1;
					}

					result = Math.Min(result, i - start);
					sum = sum - arr[start];
					start++;
				}
				else
				{
					if (i == arr.Length)
						break;

					sum = sum + arr[i];
					i++;
				}
			}
			if (exist)
			{
				return result;
			}
			else
			{
				return 0;
			}
		}

		public static int removeDuplicated(int[] nums)
		{

			if (nums.Length == 0) return 0;

			int i = 0;
			for (int j = 1; j < nums.Length; j++)
			{
				if (nums[j] != nums[i])
				{
					i++;
					nums[i] = nums[j];
				}
			}
			return i + 1;

		}

		public static int removeDuplicated2(int[] nums)
		{

			if (nums.Length == 0) return 0;

			int i = 0;
			for (int j = 1; j < nums.Length; j++)
			{
				if (nums[j] != nums[i])
				{
					i++;
					nums[i] = nums[j];
				}
			}
			return i + 1;

		}

		public int removeDuplicatesBest(int[] nums)
		{
			int i = 0;
			foreach (int n in nums)
				if (i < 1 || n > nums[i - 1])
					nums[i++] = n;
			return i;
		}

		// allow duplicates up to 2
		public int removeDuplicatesIIBest(int[] nums)
		{
			int i = 0;
			foreach (int n in nums)
				if (i < 2 || n > nums[i - 2])
					nums[i++] = n;
			return i;
		}


		public void moveZeros(int[] nums)
		{
			int j = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != 0)
				{
					nums[j++] = nums[i];
				}
			}
			while (j < nums.Length)
			{
				nums[j++] = 0;
			}
		}

		public void moveZeros2(int[] nums)
		{
			int j = 0;
			foreach (int n in nums)
			{
				if (n != 0)
				{
					nums[j++] = n;
				}
			}
			while (j < nums.Length)
			{
				nums[j++] = 0;
			}
		}



		public char FindTheDifference(string s, string t)
		{
			char rst = 'a';
			rst ^= 'a';

			foreach (char elm in s)
			{
				rst ^= elm;
			}

			foreach (char elm in t)
			{
				rst ^= elm;
			}

			return rst;
		}













		public static string PrintResult(int[] result)
		{



			if (result.Any(x => x == null || x < 0))
				return "NOT POSSIBLE";
			return result[0].ToString() + result[1].ToString() + ":" +
							result[2].ToString() + result[3].ToString();

		}



		public static string solution(int A, int B, int C, int D)
		{


			// write your code in C# 6.0 with .NET 4.5 (Mono)

			List<int> list = new List<int>() { A, B, C, D };

			var sortedList = list.OrderByDescending(x => x).ToList();

			int[] result = new int[] { -1, -1, -1, -1 };


			for (int i = 0; i < sortedList.Count; i++)
			{

				if (sortedList[i] <= 2)
				{
					result[0] = sortedList[i];
					break;
				}

			}
			if (result[0] != null) sortedList.Remove(result[0]);


			for (int i = 0; i < sortedList.Count; i++)
			{

				if (result[0] == 0)
				{

					if (sortedList[i] <= 9)
					{
						result[1] = sortedList[i];
						break;
					}

				}
				else
				{

					if (sortedList[i] <= 3)
					{
						result[1] = sortedList[i];
						break;
					}
				}
			}

			if (result[1] != null) sortedList.Remove(result[1]);

			for (int i = 0; i < sortedList.Count; i++)
			{

				if (sortedList[i] <= 6)
				{
					result[2] = sortedList[i];
					break;
				}

			}

			if (result[2] != null) sortedList.Remove(result[2]);



			for (int i = 0; i < sortedList.Count; i++)
			{

				if (sortedList[i] <= 9)
				{
					result[3] = sortedList[i];
					break;
				}

			}

			if (result[3] != null) sortedList.Remove(result[3]);
			return PrintResult(result);


		}

		public static int minCost(int[] A)
		{


			int[,] matrix = new int[A.Length, amounts.Length];

			for (int row = 0; row < A.Length; row++)
			{

				for (int col = 0; col < amounts.Length; col++)
				{

					int previousCost;
					var index = GetIndex(A, row, col);

					if (index >= 0)
						previousCost = matrix[index, amounts.Length - 1];
					else
						previousCost = 0;

					// added total to current cost
					var currentCost = costPerAmounts[col] + previousCost;

					// if not off grid
					if (col - 1 >= 0)
					{
						var val = matrix[row, col - 1];

						// new current cost is cheapest between these
						currentCost = Math.Min(currentCost, val);
					}
					// Update with current cost
					matrix[row, col] = currentCost;
				}
			}
			// bottom right would be the result because of the running total 
			//and iterating through all
			var result = matrix[A.Length - 1, amounts.Length - 1];
			new double();
			return result;
		}

		private static int GetIndex(int[] arr, int row, int col)
		{

			if (arr[row] - amounts[col] < 1) return -1;

			for (int c = row - 1; c >= 0; c--)
			{
				if (arr[c] <= arr[row] - amounts[col]) return c;
			}

			return -1;
		}




		public static void Main(string[] args)
		{
			TwoSum(new int[] { 1, 7, 6, 10 }, 16);
			//	ArrayCode.FindBuySellStockPrices(new int[] { 100, 180, 260, 310, 40, 535, 695 });
			//	StringManipulation.GetSumFromString("aa23sdsaadsfsd200sdfsf");
			//	Backtracking.Permute(new int[] { 1, 2, 3 });          //BitManipulation.CountSetBits(4);
			//BitManipulation.HammingWeight(8);
			//	ArrayCode.MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 10);                                                   //StackAndQueues.TowerOfHanoi.Init();
			//StringManipulation.longestPalindromeBest("babad");

			//var cost = minCost(new int[] { 1, 2, 4, 5, 7, 29, 30 });

			//minSubArrayLen2(7, new[] { 2, 3, 1, 2, 4, 3 });
			//var result = longestPalindrome("abccccdd");
			//var result2 = firstUniqChar("sdafdsafewta");
			//var reesult3 = MaxProfit(new[] { 1, 5, 6, 4, 7, 8 });
			//var r4 = IsUgly(27);
			//var str = StringManipulation.StrStr("ball", "baseball");
			//var s = StringManipulation.StringReverse2("llab");
			//var r = StringManipulation.AllUnique("ball");
			//var e = StringManipulation.removeDupChars(new char[] { 'b', 'a', 'l', 'l' });
			//var j = StringManipulation.ReverseSentence("Ran Dog The");
			//var jj = StringManipulation.ReverseSentence2("Ran Dog The");
			//StringManipulation.GetPer(new char[] { 'a', 'b', 'c', 'd' });
			//var b = StringManipulation.IsAnagram("aadd", "add");
			//var a = StringCodeCode.reverseWords2("Ran");
			//StringCodeCode.MergeSort1(new int[] { 7, 4, 2, 1, 0 });
			//var quickSort = SearchAlgos.QuickSort()
			//   SearchAlgos.InsertionSort2(new int[] {5, 10, 1, 4, 8});

			//string[] iparray = new string[] { "2", "This line has junk text.", "121.18.19.20" };
			//var x = StringCodeCode.checkIPs(iparray)


			//ListNode node = new ListNode(1);
			//Insert(2, node);
			//Insert(3, node);
			//Insert(4, node);
			//Insert(5, node);
			//DisplayList(node);
			//var head = rotateRight(node, 5);
			//NumberAlgos.FindComplement(5);
			//StackAndQueues.NextGreaterElement(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 });
			//DisplayList(head);
			//StringManipulation.ReverseWords("dog. lazy the over jumped fox brown quick The");
			//	string s = "abcabe";
			//	StringManipulation.removeDuplicates(s.ToCharArray());
		}
	}
}
