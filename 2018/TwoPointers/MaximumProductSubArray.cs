using System;
// Find the contiguous subarray within an array (containing at least one
//  number) which has the largest product.
// For example, given the array [2,3,-2,4],
// the contiguous subarray [2,3] has the largest product = 6.

public class MaximumProductSubArray1
{


// 2 3 -2 4
// i

// 
    public int MaxProductSubArray1(int[] nums)
    {
        return 1;
    }


 /*

 Store the max and min product and the max result while iterating over the list
 if the current number get the max product by taking the max of the max product 
 times the current number and the same for the min product and visa versa for the min

 if the number is negative it could cause a swap becaue of the signs
 
  */
   public  int MaxProduct(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int maxProduct = nums[0];
        int minProduct =nums[0];
        int maxRes = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] >= 0)
            {
                maxProduct = Math.Max(maxProduct * nums[i], nums[i]);
                minProduct = Math.Min(minProduct * nums[i], nums[i]);
            }
            else
            {
                int temp = maxProduct;
                maxProduct = Math.Max(minProduct * nums[i], nums[i]);
                minProduct = Math.Min(temp * nums[i], nums[i]);
            }
            maxRes = Math.Max(maxRes, maxProduct);
        }
        return maxRes;
    }


// I figure out this solution by thinking that: what we need to know to
//  calculate maximum product at i? Recall what we did in Maximum Subarray 
//Sum (Kadane algorithm), only known maximum ends at i-1 is not enough for this one.


// Due to negative number and property of multiply, we need max and min
//  ends at i-1 in case negative number at i causes them swap. Therefore, 
//we maintain two local optimal variables, update them in each iteration and the global maximum as well.

    public int maxProduct(int[] nums)
    {
        int max = int.MaxValue;    // global max
        int maxloc = 1, minloc = 1;     // max or min end here

        foreach (int num in nums)
        {          // negative could cause maxloc and minloc swap
            int prod1 = maxloc * num, prod2 = minloc * num;
            maxloc = Math.Max(num, Math.Max(prod1, prod2));
            minloc = Math.Min(num, Math.Min(prod1, prod2));
            max = Math.Max(max, maxloc);
        }
        return max;
    }
}