// Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

// Note:
// You are not suppose to use the library's sort function for this problem.

public class SortColors
{
    // Big O o(n) two iterations of the same list 2n
    public void sortcolors(int[] nums)
    {
        /* iterate through array and start with the first color using one pointer and 
        iterate to the next color with a second pointer. 
*/      int wall = 0;

        // 0 1
        //    iw

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = 0;

            if (nums[i] < 1)
            {
                temp = nums[i];
                nums[i] = nums[wall];
                nums[wall] = temp;
                wall++;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = 0;
            if (nums[i] == 1)
            {
                temp = nums[i];
                nums[i] = nums[wall];
                nums[wall] = temp;
                wall++;
            }
        }
        return;
    }



// 0 0 1 1 1 1 2 2 2
//   s     e
//             i

    // Big O O (n) Single pass
    // move all the 0's to the front keeping a front wall and 
    //move all 2's to the end using an end wall
    public void sortColors2(int[] nums)
    {

        int start = 0, end = nums.Length - 1;
        for (int i = 0; i <= end; i++)
        {
            if (nums[i] == 0)
            {
                nums[i] = nums[start];
                nums[start] = 0;
                start++;
            }
            else if (nums[i] == 2)
            {
                nums[i] = nums[end];
                nums[end] = 2;
                i--;
                end--;
            }

        }
    }
}
