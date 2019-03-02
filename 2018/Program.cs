using System;

namespace _2018
{
    public class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            var result = p.TestMaximumSumSubArray();
            Console.WriteLine($"Result {result}");

            result = p.TestMergeSortedArrays();
            Console.WriteLine($"Result {result}");

            result = p.TestMergeSortedArraysIntoAnother();
            Console.WriteLine($"Result {result}");
        }

        private bool TestMergeSortedArraysIntoAnother()
        {
            MergeSortedArray c = new MergeSortedArray();
            int [] nums1 = new int [] {1,2, 2,5,7, 0, 0, 0, 0};
            int [] nums2 = new int [] {4,2,9,10};
            nums1 = c.MergeSortedArrayIntoAnother(nums1, 5, nums2, 4);
            int [] expectedResult = new int [] {1,2,2,2,4,5,7,9,10};
            if (nums1 == expectedResult) return true; 
            else return false;
        }

        public bool TestMaximumProductSubArray()
        {
            MaximumProductSubArray1 c = new MaximumProductSubArray1();

            // MaximumProductSubArray c = new MaximumProductSubArray();
            // int [] nums = new int [] {-1 , 2,3,2,-5}; //
            int[] nums = new int[] { 2, -5, }; // 20

            int result = c.MaxProduct(nums);
            int expectedResult = 6;

            if (expectedResult == result) return true;
            else return false;
        }

        public bool TestMaximumSumSubArray()
        {
            MaximumSubArray c = new MaximumSubArray();

            int[] nums = new int[] { 2, -3, 1, -2, 4 }; // 20

            int result = c.maxSubArrayTwo(nums);
            int expectedResult = 4;

            if (expectedResult == result) return true;
            else return false;
        }

        public bool TestMergeSortedArrays()
        {

            MergeSortedArray c = new MergeSortedArray();

            int[] nums1 = new int[] { 5, 6, 6, 8 };
            int[] nums2 = new int[] { 1, 3, 10 };
            var result = c.MergeSortedArrayOne(nums1, nums2);
            var expectedResult = new int[] { 1, 3, 5, 6, 6, 8, 10 };

            if (expectedResult == result) return true;
            else return false;
        }
    }



}



// -2 5  2 -1
//          i
// max  20
// min  -10
// res  20

// 10 