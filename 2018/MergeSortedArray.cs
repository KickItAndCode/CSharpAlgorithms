using System;
using System.Collections.Generic;
public class MergeSortedArray
{


    public int[] MergeSortedArrayOne(int[] nums1, int[] nums2)
    {
        List<int> result = new List<int>();
        int j = 0, i = 0;

        if (nums1.Length > nums2.Length)
        {


            while (i < nums1.Length)
            {

                if (nums1[i] < nums2[j])
                {
                    result.Add(nums1[i++]);

                }
                else
                {
                    result.Add(nums2[j++]);
                }
            }

            while (j < nums2.Length)
            {
                result.Add(nums2[j++]);
            }

        }
        else
        {

            while (i < nums2.Length)
            {

                if (nums2[i] < nums1[j])
                {
                    result.Add(nums1[i++]);

                }
                else
                {
                    result.Add(nums1[j++]);
                }
            }
            while (j < nums1.Length)
            {
                result.Add(nums1[j++]);
            }

        }

        return result.ToArray();
    }

        public int[] MergeSortedArrayIntoAnother(int[] nums1, int n, int[] nums2, int m){

            int i = m -1, j = n-1, k = m +n -1;

            while (i >= 0 && j >= 0){

                nums1[k--] = nums1[1] > nums2[j] ? nums1[i--] : nums2[j--];
                
                // if (nums1[i] > nums2[j]){
                //     nums1[k--] = nums1[i--];
                // }else {
                //     nums1[k--] = nums2[j--];
                // }
            }
            while (j >= 0){
                nums1[k--] = nums2[j--];
            }

            return nums1;
        }

}