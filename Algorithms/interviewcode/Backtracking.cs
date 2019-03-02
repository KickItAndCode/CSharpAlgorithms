using System;
using System.Collections.Generic;
namespace InterviewCode
{
	public class Backtracking
	{

		//https://leetcode.com/problems/subsets/

		public List<List<int>> subsets(int[] nums)
		{
			List<List<int>> list = new List<List<int>>();
			Array.Sort(nums);
			backtrackSubsets(list, new List<int>(), nums, 0);
			return list;
		}

		private void backtrackSubsets(List<List<int>> list, List<int> tempList,
							   int[] nums, int start)
		{
			list.Add(new List<int>(tempList));
			for (int i = start; i < nums.Length; i++)
			{
				tempList.Add(nums[i]);
				backtrackSubsets(list, tempList, nums, i + 1);
				tempList.Remove(tempList.Count - 1);
			}
		}

		// https://leetcode.com/problems/subsets-ii/ contains duplicates
		public List<List<int>> SubsetsWithDup(int[] nums)
		{
			List<List<int>> list = new List<List<int>>();
			Array.Sort(nums);
			BacktrackSubsetsWithDup(list, new List<int>(), nums, 0);
			return list;
		}

		private void BacktrackSubsetsWithDup(List<List<int>> list, List<int> tempList,
							   int[] nums, int start)
		{
			list.Add(new List<int>(tempList));
			for (int i = start; i < nums.Length; i++)
			{
				if (i > start && nums[i] == nums[i - 1]) continue; // skip dups
				tempList.Add(nums[i]);
				BacktrackSubsetsWithDup(list, tempList, nums, i + 1);
				tempList.Remove(tempList.Count - 1);
			}
		}

		//Permutations : https://leetcode.com/problems/permutations/
		public static List<List<int>> Permute(int[] nums)
		{
			List<List<int>> list = new List<List<int>>();
			BacktrackPermute(list, new List<int>(), nums);
			return list;
		}

		private static void BacktrackPermute(List<List<int>> list, List<int> tempList, int[] nums)
		{
			if (tempList.Count == nums.Length)
			{
				list.Add(new List<int>(tempList));
			}
			else
			{

				for (int i = 0; i < nums.Length; i++)
				{
					if (tempList.Contains(nums[i])) continue; // already exist, skip
					tempList.Add(nums[i]);
					BacktrackPermute(list, tempList, nums);
					tempList.RemoveAt(tempList.Count - 1);
				}
			}
		}


		//Permutations (contains duplicates) : https://leetcode.com/problems/permutations-ii/
		public static List<List<int>> PermuteUnique(int[] nums)
		{
			List<List<int>> list = new List<List<int>>();
			Array.Sort(nums);
			BacktrackPermuteII(list, new List<int>(), nums, new bool[nums.Length]);
			return list;
		}

		private static void BacktrackPermuteII(List<List<int>> list, List<int> tempList, int[] nums,
									   bool[] used)
		{
			if (tempList.Count == nums.Length)
			{
				list.Add(new List<int>(tempList));
			}
			else
			{

				for (int i = 0; i < nums.Length; i++)
				{
					if (used[i] || i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue; // already exist, skip
					used[i] = true;
					tempList.Add(nums[i]);
					BacktrackPermuteII(list, tempList, nums, used);
					used[i] = false;
					tempList.RemoveAt(tempList.Count - 1);
				}
			}
		}


	}
}
