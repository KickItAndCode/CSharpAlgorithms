using System.Collections.Generic;

public class RemoveDups
{

    // Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

// Do not allocate extra space for another array, you must do this in place with constant memory.

// For example,
// Given input array nums = [1,1,2],

// Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the new length.

    // Add each number to hash table 
    // number as the key and value = 1
    // if you encounter the number again you have a dup 

// 1 4 5 2 X 0
//             i 

// 
    public void RemoveDupsSortedArray(int[] nums)
    {

        Dictionary<int, int> seenSet = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {

            if (seenSet.ContainsKey(nums[i]))
            {
                // remove
                nums[i] = int.MaxValue;
            }
            else
            {
                seenSet[nums[i]]++;
            }
        }
    }


//   1 2 3 4 7 4 4
//               i
//           j
// big O (n)
    public int RemoveDupsSortedArray2(int []nums){

        if (nums == null) return 0;
        if (nums.Length <= 1) return nums.Length;
        int index = 1;
        for (int i = 1; i < nums.Length; i++){

            if (nums[i] != nums[i - 1]){
                nums[index] = nums[i];
                index++;
            }

        }
        return index;

    }
}