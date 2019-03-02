//209. Minimum Size Subarray Sum


// Given an array of n positive integers and a positive integer s, 
// find the minimal length of a contiguous subarray of which the sum ≥ s. 
// If there isn't one, return 0 instead.

// For example, given the array [2,3,1,2,4,3] and s = 7,
// the subarray [4,3] has the minimal length under the problem constraint.


// [2,3,1,2,4,3]

// 2 3 1 2 4 3
//           i
//       j
// 6

// 2

//O(N) - keep a moving window expand until sum>=s, then shrink util 
//sum<s. Each time after shrinking, update length. 
using System;

public class MinSizeSubArray
{

    // O (n)
    public int MinSizeSubArrayOne(int s, int[] nums)
    {

        if (nums == null && nums.Length == 0) return 0;
        int j = 0, i = 0, sum = 0, win = int.MaxValue;

        while (i < nums.Length)
        {

            sum += nums[i++];

            while (sum >= s)
            {

                win = Math.Min(win, i - j);
                sum -= nums[j++];

            }
        }
        return win == int.MaxValue ? 0 : win;
    }




   
}