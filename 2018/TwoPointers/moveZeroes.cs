public class MoveZeroes {


// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

// For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].

// Note:
    // You must do this in-place without making a copy of the array.
    // Minimize the total number of operations.

// 

// 1 5 6 9 0 0

// 1 5 6 9 0 0
//             f
//           i 
    public void moveZeroes (int [] nums) {
        int index = 0;
        if (nums == null || nums.Length == 0 ) return;

        foreach(int num in nums){

            if (num != 0){

                nums[index] = num;
                index++;
            }
        }

        while (index < nums.Length){

            nums[index] = 0;
            index++;
        }
    }
}