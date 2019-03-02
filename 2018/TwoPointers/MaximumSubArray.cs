using System;


//     Find the contiguous subarray within an array (containing at least 
//     one number) which has the largest sum.
// For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
// the contiguous subarray [4,-1,2,1] has the largest sum = 6.
//4
// -2 5 -3 -2 6 2 -8 -3

//                    i
// maxSub = 8
// leftpos = 0


public class MaximumSubArray
{

    public int MaxSubArrayOne(int[] nums)
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
   public int maxSubArrayTwo(int[] nums)
    {
        int maxSub = int.MinValue;
        int leftPositive = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            maxSub = Math.Max(maxSub, leftPositive + nums[i]);
            leftPositive = Math.Max(0, leftPositive + nums[i]);
        }
        return maxSub;
    }

    public int maxSubArray3(int[] nums)
    {

        int n = nums.Length;
        int max = nums[0];
        int sum = nums[0];
        int i = 1;

        while (i < n)
        {
            sum = Math.Max(sum, 0);
            max = Math.Max(sum + nums[i], max);
            i++;
        }

        return max;
    }
}