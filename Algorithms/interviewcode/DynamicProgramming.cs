using System;
namespace InterviewCode
{
	public class DynamicProgramming
	{
		public static int GetNthFibonacci_Ite(int n)
		{
			int number = n - 1; //Need to decrement by 1 since we are starting from 0
			int[] Fib = new int[number + 1];
			Fib[0] = 0;
			Fib[1] = 1;

			for (int i = 2; i <= number; i++)
			{
				Fib[i] = Fib[i - 2] + Fib[i - 1];
			}
			return Fib[number];
		}

		// Print fib

		public static void Fibonacci_Iterative(int len)
		{
			int a = 0, b = 1, c = 0;
			Console.Write("{0} {1}", a, b);

			for (int i = 2; i < len; i++)
			{
				c = a + b;
				Console.Write(" {0}", c);
				a = b;
				b = c;
			}
		}

		// Loop through array and keep a running count of the current sum
		// and the global sum. Update global when its less then current
		// return global when you traverse the array
		// time  O (n);
		// space O (1);
		public static int FindMaxSumSubArray(int[] a)
		{
			if (a.Length < 1) return 0;

			int curr = a[0];
			int globalS = a[0];


			for (int i = 1; i < a.Length; i++)
			{

				if (curr < 0)
				{
					curr = a[i];
				}
				else
				{
					curr += a[i];
				}

				if (globalS < curr)
				{
					globalS = curr;
				}
			}
			return globalS;
		}


		/*Find an efficient algorithm to find maximum sum of a 
		 * subsequence in an array such that no consecutive elements
		 * are part of this subsequence.
		Time O (n) and Space O (n) */

		public static int FindMaxSumNonAdjacent(int[] a)
		{
			if (a == null || a.Length == 0)
				return 0;

			if (a.Length == 1) return a[0];

			int[] result = new int[a.Length];

			result[0] = a[0];

			for (int i = 1; i < a.Length; i++)
			{
				result[i] = Math.Max(a[i], result[i - 1]);

				if (i - 2 >= 0)
				{
					result[i] = Math.Max(result[i], a[i] + result[i - 2]);
				}
			}
			return result[a.Length - 1];
		}

		/*Imagine a game (like baseball) where a player can score
		 * 1,2 or 4 runs. Given a score "n", find the total number 
		 * of ways score "n" can be reached.
		Time O (n) Space O (n) */
		public static int ScoringOptions(int n)
		{
			if (n <= 0)
			{
				return 0;
			}

			int[] result = new int[n + 1];
			result[0] = 1;

			ScoringOptionsRec(n, result);

			return result[n];
		}

		public static int ScoringOptionsRec(int n, int[] result)
		{

			if (n < 0)
			{
				return 0;
			}

			// use result from previously stored value as it has been 
			//calculated already
			if (result[n] > 0)
			{
				return result[n];
			}

			// Memorization
			result[n] =
				ScoringOptionsRec(n - 1, result) +
				ScoringOptionsRec(n - 2, result) +
				ScoringOptionsRec(n - 4, result);

			return result[n];
		}

		// Scoring options are 1, 2, 4
		public static int ScoringOptionsDP(int n)
		{
			if (n <= 0)
				return 0;

			// Max score is 4. Hence we need to save 
			// last 4 ways to calculate the number of ways
			// for a given n
			int[] result = new int[4];

			//save the base case on last index of the vector
			result[3] = 1;

			for (int i = 1; i <= n; i++)
			{
				int sum = result[3] + result[2] + result[0];

				//slide left all the results in each iteration
				//result for current i will be saved at last index
				result[0] = result[1];
				result[1] = result[2];
				result[2] = result[3];
				result[3] = sum;
			}

			return result[3];
		}

		public static int DavisStairCase(int n)
		{
			int[] map = new int[n + 1];
			return DavisStairCaseDP(n, map);

		}

		public static int DavisStairCaseDP(int n, int[] map)
		{
			if (n < 0) return 0;
			if (n <= 1) return 1;


			map[0] = 1;
			map[1] = 1;
			map[2] = 2;

			for (int i = 3; i <= n; i++)
			{
				map[i] = map[i - 1] + map[i - 2] + map[i - 3];
			}

			return map[n];

		}

		/*Print a single integer denoting the number of ways we can 
		 * make change for  dollars using an infinite supply of our  
		 * types of coins.*/
		public static long MakeChange(int dollars, int[] coins)
		{

			if (dollars == 0) return 1;
			if (coins.Length == 0) return 0;

			long[] store = new long[dollars + 1];
			store[0] = 1;

			foreach (int coin in coins)
			{
				for (int i = 0; i < store.Length - coin; i++)
				{
					store[i + coin] += store[i];
				}
			}
			return store[dollars];
		}

		public static int SolveCoinChangeDP(int[] denominations, int amount)
		{
			// this solution requires O(amount) space to store solution
			// until current amount.
			int[] solution = new int[amount + 1];
			solution[0] = 1;

			foreach (int den in denominations)
			{
				for (int i = den; i < (amount + 1); ++i)
				{
					solution[i] += solution[i - den];
				}
			}
			return solution[solution.Length - 1];
		}

		/*Edit Distance
		 * Given two strings, compute the Levenshtein distance between them 
		 * i.e. the minimum number of edits required to convert one string 
		 * into the other.

		For example, the Levenshtein distance between "kitten" and "sitting" 
		is 3.*/

		public class LevenshteinDistance
		{
			public static int Minimum(int a, int b, int c)
			{
				return Math.Min(Math.Min(a, b), c);
			}


			// Time O (n^2) space o (n^2)
			public static int ComputeLevenshteinDistance(string s1, string s2)
			{

				if (s1 == s2) return 0;

				if (s1.Length == 0) return s2.Length;

				if (s2.Length == 0) return s1.Length;

				// make a matrix to hold each distance 
				int[,] d = new int[s1.Length + 1, s2.Length];

				// source prefixes can be transformed into empty string by 
				// dropping all characters
				for (int i = 0; i <= s1.Length; i++)
				{
					d[i, 0] = i;
				}

				// target prefixes can be transformed into empty string by 
				// inserting all characters
				for (int j = 0; j <= s2.Length; j++)
				{
					d[0, j] = j;
				}


				int cost;
				for (int i = 1; i < s2.Length; i++)
				{
					for (int j = 1; j < s2.Length; j++)
					{

						if (s1[i - 1] == s2[j - 1])
						{
							cost = 0;
						}
						else { cost = 1; }


						d[i, j] = Minimum(
							d[i, j - 1] + 1,
							d[i - 1, j] + 1,
							d[i - 1, j - 1] + cost);
					}
				}
				return d[s1.Length, s2.Length];

			}

			// Time O (n^2) space o (n)
			public static int compute_levenshtein_distance(String str1, String str2)
			{

				//degenerate cases
				if (str1 == str2)
					return 0;

				if (str1.Length == 0)
					return str2.Length;

				if (str2.Length == 0)
					return str1.Length;

				// create two work arrays of integer distances
				int[] d1 = new int[str2.Length + 1];
				int[] d2 = new int[str2.Length + 1];

				// initialize d1 (the previous row of distances)
				// this row is A[0][i]: edit distance for an empty str1
				// the distance is just the number of characters to delete from str2
				for (int i = 0; i < d1.Length; i++)
					d1[i] = i;

				int cost;
				for (int i = 0; i < str1.Length; i++)
				{

					// calculate d2 (current row distances) from the previous row d1

					// first element of d2 is A[i+1][0]
					// edit distance is delete (i+1) chars from str1 to match empty str2
					d2[0] = i + 1;

					// use formula to fill in the rest of the row 
					for (int j = 0; j < str2.Length; j++)
					{

						if (str1[i] == str2[j])
							cost = 0;
						else
							cost = 1;

						d2[j + 1] = Minimum(d2[j] + 1, d1[j + 1] + 1, d1[j] + cost);
					}

					// copy d2(current row) to d1(previous row) for next iteration
					for (int j = 0; j < d1.Length; j++)
						d1[j] = d2[j];
				}

				return d2[str2.Length];
			}
		}

		public static int KnapSack(int Cap, int[] wt, int[] val, int numItems)
		{

			int[,] Matrix = new int[numItems + 1, Cap + 1];

			for (int i = 0; i <= numItems; i++)
			{
				for (int w = 0; w <= Cap; w++)
				{
					if (i == 0 || w == 0)
					{
						Matrix[i, w] = 0;
					}
					else if (wt[i - 1] <= w)
					{
						Matrix[i, w] =
							Math.Max(val[i - 1] + Matrix[i - 1, w - wt[i - 1]],
											   Matrix[i - 1, w]);
					}
					else
					{
						Matrix[i, w] = Matrix[i - 1, w];
					}
				}
			}
			return Matrix[numItems, Cap];

		}

		// Min Cost to pain house
		/*The cost of painting each house with a certain color is represented 
		 * by a n x 3 cost matrix. For example, costs[0][0] is the cost of 
		 * painting house 0 with color red; costs[1][2] is the cost of 
		 * painting house 1 with color green, and so on... Find the minimum 
		 * cost to paint all houses.*/

		public static int PaintHouseCost(int[,] costs)
		{
			if (costs.GetLength(0) == 0) return 0;

			int houses = costs.GetLength(0);
			int minRed = costs[0, 0];
			int minBlue = costs[0, 1];
			int minGreen = costs[0, 2];

			for (int house = 1; house < houses; house++)
			{
				int currRed = Math.Min(minBlue, minGreen) + costs[house, 0];
				int currBlue = Math.Min(minGreen, minRed) + costs[house, 1];
				int currGreen = Math.Min(minBlue, minRed) + costs[house, 2];
				minRed = currRed;
				minBlue = currBlue;
				minGreen = currGreen;
			}

			return Math.Min(Math.Min(minRed, minBlue), minGreen);
		}

		/*Robbing houses each has money but adjacent houses will sound alarms
		find the maximum amout of money you can rob tonight without sounding alarms*/
		public int Rob(int[] nums)
		{
			int prevMax = 0;
			int currMax = 0;
			foreach (int x in nums)
			{
				int temp = currMax;
				currMax = Math.Max(prevMax + x, currMax);
				prevMax = temp;
			}
			return currMax;

		}
	}
}
