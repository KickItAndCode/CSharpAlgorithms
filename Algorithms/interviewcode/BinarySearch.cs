using System;
namespace InterviewCode
{
	public class BinarySearchAlgos
	{

		public int floor(int[] input, int x)
		{
			int low = 0;
			int high = input.Length - 1;
			while (low <= high)
			{
				int middle = (low + high) / 2;
				if (input[middle] == x || (input[middle] < x &&
				   (middle == input.Length - 1 || input[middle + 1] > x)))
				{
					return middle;
				}
				else if (input[middle] < x)
				{
					low = middle + 1;
				}
				else
				{
					high = middle - 1;
				}
			}
			return -1;
		}

		public int ceiling(int[] input, int x)
		{
			int low = 0;
			int high = input.Length - 1;
			while (low <= high)
			{
				int middle = (low + high) / 2;
				if (input[middle] == x || (input[middle] > x && (middle == 0 || input[middle - 1] < x)))
				{
					return middle;
				}
				else if (input[middle] < x)
				{
					low = middle + 1;
				}
				else
				{
					high = middle - 1;
				}
			}
			return -1;
		}

		/**
		 * A peak element is an element that is greater than its neighbors. Find index of peak element in the array.
		 *
		 * Space complexity is O(1)
		 * Time complexity is O(n)
		 *
		 * https://leetcode.com/problems/find-peak-element/
		 */

		public static int findPeakElement(int[] nums)
		{
			int low = 0;
			int high = nums.Length - 1;
			int middle = 0;
			while (low <= high)
			{
				middle = (low + high) / 2;
				int before = int.MinValue;
				if (middle > 0)
				{
					before = nums[middle - 1];
				}
				int after = int.MinValue;
				if (middle < nums.Length - 1)
				{
					after = nums[middle + 1];
				}
				if (nums[middle] > before && nums[middle] > after)
				{
					return middle;
				}
				else if (before > after)
				{
					high = middle - 1;
				}
				else
				{
					low = middle + 1;
				}
			}
			return middle;
		}


		/*RunTime O (Logn) Memory O (1) 
		Divides the input by half at every step either we have found the index 
		or half of the array can be discared

 		* https://leetcode.com/problems/search-in-rotated-sorted-array/
 
		*/
		public static int BinarySearchIterative(int[] array, int key)
		{

			int low = 0;
			int high = array.Length - 1;

			while (low <= high)
			{

				int mid = low + ((high - low) / 2);

				if (array[mid] == key) return mid;

				if (key < array[mid]) high = mid - 1;
				else low = mid + 1;

			}
			return -1;
		}

		/*Runtime O (logn) memory O (Logn) */
		public static int BinarySearchHelper(int[] array, int key, int low, int high)
		{

			if (low > high) return -1;

			int mid = low + ((high - low) / 2);
			if (array[mid] == key)
			{
				return mid;
			}
			else if (key < array[mid])
			{
				return BinarySearchHelper(array, key, low, mid - 1);
			}
			else
			{
				return BinarySearchHelper(array, key, mid + 1, high);
			}
		}

		public static int BinarySearch(int[] array, int key)
		{
			return BinarySearchHelper(array, key, 0, array.Length - 1);
		}

		/*Binary Search Rotated Array*/

		public static int BinarySearchRotated(int[] array, int key)
		{

			return BinarySearchRotatedHelper(array, key, 0, array.Length - 1);
		}

		public static int BinarySearchRotatedHelper(int[] array, int key, int low, int high)
		{
			if (low > high) return -1;

			int mid = low + ((high - low) / 2);

			if (array[mid] == key)
			{
				return mid;
			}
			if (array[low] < array[mid] && key < array[mid] && key >= array[low])
			{
				return BinarySearchRotatedHelper(array, key, low, mid - 1);

			}
			else if (array[mid] < array[high] && key > array[mid] && key <= array[high])
			{
				return BinarySearchRotatedHelper(array, key, mid + 1, high);
			}
			else if (array[low] > array[mid])
			{
				return BinarySearchRotatedHelper(array, key, low, mid - 1);
			}
			else if (array[high] < array[mid])
			{
				return BinarySearchRotatedHelper(array, key, mid + 1, high);
			}
			return -1;
		}



		public int BSRotated(int[] arr, int key)
		{

			int low = 0;
			int high = arr.Length - 1;

			while (low <= high)
			{

				int mid = (high - low) / 2;

				if (arr[mid] < arr[high])
				{

					if (key > arr[mid] && key <= arr[high])
					{
						low = mid + 1;

					}
					else
					{
						high = mid - 1;
					}

				}
				else
				{
					if (key >= arr[low] && key < arr[mid])
					{
						high = mid - 1;
					}
					else
					{
						low = mid + 1;

					}

				}
			}
			return -1;
		}




























		/**
	* Duplicates are not allowed in arr.
	*/
		public int BinarySearchRotatedTushor(int[] arr, int search)
		{
			int low = 0;
			int high = arr.Length - 1;
			while (low <= high)
			{
				int mid = (low + high) / 2;
				if (arr[mid] == search)
				{
					return mid;
				}

				if (arr[mid] < arr[high])
				{
					if (arr[mid] < search && search <= arr[high])
					{
						low = mid + 1;
					}
					else
					{
						high = mid - 1;
					}
				}
				else
				{
					if (search >= arr[low] && search < arr[mid])
					{
						high = mid - 1;
					}
					else
					{
						low = mid + 1;
					}
				}
			}
			return -1;
		}

		/**
		 * Duplicates are allowed in arr.
		 * Time complexity with duplicates - O(n)
		 * https://leetcode.com/problems/search-in-rotated-sorted-array-ii/
		 */
		public bool BinarySearchRotatedDups(int[] arr, int search)
		{
			int low = 0;
			int high = arr.Length - 1;
			while (low <= high)
			{
				int mid = (low + high) / 2;
				if (arr[mid] == search)
				{
					return true;
				}
				//if low is same as mid then increment low.
				if (arr[mid] == arr[low])
				{
					low++;
				}
				else if (arr[mid] == arr[high])
				{ //if high is same as mid then decrement high.
					high--;
				}
				else if (arr[mid] < arr[high])
				{
					if (arr[mid] < search && search <= arr[high])
					{
						low = mid + 1;
					}
					else
					{
						high = mid - 1;
					}
				}
				else
				{
					if (search >= arr[low] && search < arr[mid])
					{
						high = mid - 1;
					}
					else
					{
						low = mid + 1;
					}
				}
			}
			return false;
		}

	}
}
