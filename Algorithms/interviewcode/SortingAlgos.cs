using System;

namespace InterviewCode
{



	public static class SortingAlgos
	{

		//	public static void QuickSort(int[] array)
		//{
		//	QuickSort(array, 0, array.Length - 1);
		//}

		//public static void QuickSort(int[] array, int left, int right)
		//{
		//	if (left <= right)
		//	{
		//		int pivot = array[(left + right) / 2];
		//		int index = Partition(array, left, right, pivot);
		//		QuickSort(array, left, index - 1);
		//		QuickSort(array, index, right);
		//	}
		//}

		//public static int Partition(int[] array, int left, int right, int pivot)
		//{
		//	while (left <= right)
		//	{
		//		while (array[left] < pivot)
		//		{
		//			left++;
		//		}
		//		while (array[right] > pivot)
		//		{
		//			right--;
		//		}
		//		if (left <= right)
		//		{
		//			Swap( array, left, right);
		//			left++;
		//			right--;
		//		}
		//	}
		//	return left;
		//}



		public static void Swap(int[] data, int index1, int index2)
		{
			if (index1 != index2)
			{
				int tmp = data[index1];
				data[index1] = data[index2];
				data[index2] = tmp;
			}
		}

		// Sorting Algorithms
		// Selection Sort starts at the beginning of the array and finds the min and swaps it 
		// Then moves over one index and does the process again
		// Runtime is O(n^2) in all cases
		// In place sorting algorithm

		public static void SelectionSortRC(int[] data)
		{
			SelectionSortRC(data, 0);
		}

		public static void SelectionSortRC(int[] data, int start)
		{
			if (start < data.Length - 1)
			{
				Swap(data, start, findMinIndex(data, start));
				SelectionSortRC(data, start + 1);
			}
		}

		public static int findMinIndex(int[] data, int start)
		{
			int minPos = start;
			for (int i = start; i < data.Length - 1; i++)
			{
				if (data[i] < data[minPos])
				{
					minPos = i;
				}
			}
			return minPos;
		}



		// Insertion Sort- Creates sorted array by moving one element at a time(through unsorted array)
		// and comparing it with the values in the sorted array
		// Runtime O(n) if the list is already sorted 
		// Average and worst case O(n^2) so not great for large data sets and randomly ordered data
		// In place sorting algorithm 

		public static void InsertionSort2(int[] array)
		{
			for (int i = 1; i < array.Length; i++)
			{
				for (int j = i; j > 0 && array[j - 1] > array[j]; j--)
				{
					Swap(array, j, j - 1);
				}

			}
		}

		// Quicksort- divide and conquer algorithm 
		// Coose a pivot point and split into two subsets
		// first set is less then the pivot and second is greater then the pivot
		// recursively pivot/split each subset until there are no more subsets to split
		// Average Runtime is O(n log n) in the middle 
		// Worst case is O(n^2) picking the lowest value would be the worst


		public static int[] Quicksort(int[] data)
		{
			if (data.Length < 2) return data;

			int pivotIndex = data.Length / 2;
			int pivotValue = data[pivotIndex];
			int leftCount = 0;

			// Count how many are less then the pivot
			for (int i = 0; i < data.Length; ++i)
			{
				if (data[i] < pivotValue) ++leftCount;
			}

			// Allocate the arrays and create the subsets
			int[] left = new int[leftCount];
			int[] right = new int[data.Length - leftCount - 1];

			int l = 0;
			int r = 0;


			for (int i = 0; i < data.Length; ++i)
			{
				//  skip the pivotValue
				if (i == pivotIndex) continue;

				// current valuue
				int val = data[i];

				// if the value is less than the pivot add it to the 
				//left subset and increment its counter and same for the right side
				if (val < pivotValue)
				{
					left[l++] = val;
				}
				else
				{
					right[r++] = val;
				}
			}

			// Sort the subsets
			left = Quicksort(left);
			right = Quicksort(right);

			// combine the sorted arrays and the pivot back into the orinal array
			Array.Copy(left, 0, data, 0, left.Length);
			data[left.Length] = pivotValue;
			Array.Copy(right, 0, data, left.Length + 1, right.Length);

			return data;
		}



		public static void Quicksort(IComparable[] elements, int left, int right)
		{
			int i = left, j = right;
			IComparable pivot = elements[(left + right) / 2];

			while (i <= j)
			{
				while (elements[i].CompareTo(pivot) < 0)
				{
					i++;
				}

				while (elements[j].CompareTo(pivot) > 0)
				{
					j--;
				}

				if (i <= j)
				{
					// Swap
					IComparable tmp = elements[i];
					elements[i] = elements[j];
					elements[j] = tmp;

					i++;
					j--;
				}
			}

			// Recursive calls
			if (left < j)
			{
				Quicksort(elements, left, j);
			}

			if (i < right)
			{
				Quicksort(elements, i, right);
			}
		}


		// Quick sort select a pivot then partition such that the pivot all values to the left are less than it and all to the right are greater then it 
		// runtime O(n log n ) avg 
		// worst  o (n^2)

		public static void QuickSort2(int[] input, int left, int right)
		{

			// check inputs
			if (left < right)
			{

				int index = Partition2(input, left, right);
				QuickSort2(input, left, index - 1);
				QuickSort2(input, index + 1, right);
			}
		}

		public static int Partition2(int[] input, int left, int right)
		{

			int pivot = input[right];
			int i = left;
			for (int j = left; j < right; j++)
			{
				if (input[j] <= pivot)
				{
					Swap(input, i, j);
					i++;
				}
			}
			input[right] = input[i];
			input[i] = pivot;

			return i;
		}


		public static void QuickSort(int[] input, int left, int right)
		{
			if (left < right)
			{
				int q = Partition(input, left, right);
				QuickSort(input, left, q - 1);
				QuickSort(input, q + 1, right);
			}
		}

		private static int Partition(int[] input, int left, int right)
		{
			int pivot = input[right];
			int temp;

			int i = left;
			for (int j = left; j < right; j++)
			{
				if (input[j] <= pivot)
				{
					temp = input[j];
					input[j] = input[i];
					input[i] = temp;
					i++;
				}
			}

			input[right] = input[i];
			input[i] = pivot;

			return i;
		}

		public static void MergeSort(int[] input, int left, int right)
		{
			if (left < right)
			{
				int middle = (left + right) / 2;

				MergeSort(input, left, middle);
				MergeSort(input, middle + 1, right);

				//Merge
				int[] leftArray = new int[middle - left + 1];
				int[] rightArray = new int[right - middle];

				Array.Copy(input, left, leftArray, 0, middle - left + 1);
				Array.Copy(input, middle + 1, rightArray, 0, right - middle);

				int i = 0;
				int j = 0;
				for (int k = left; k < right + 1; k++)
				{
					if (i == leftArray.Length)
					{
						input[k] = rightArray[j];
						j++;
					}
					else if (j == rightArray.Length)
					{
						input[k] = leftArray[i];
						i++;
					}
					else if (leftArray[i] <= rightArray[j])
					{
						input[k] = leftArray[i];
						i++;
					}
					else
					{
						input[k] = rightArray[j];
						j++;
					}
				}
			}
		}

		/**
		 * Heap Sort
		 * Given an array sort it using heap sort
		 * 
		 * Solution :
		 * First convert the original array to create the heap out of the array
		 * Then move the max element to last position and do heapify to recreate the heap
		 * with rest of the array element. Repeat this process
		 * 
		 * Time complexity
		 * O(nlogn)
		 * 
		 * Test cases
		 * Null array
		 * 1 element array
		 * 2 element array
		 * sorted array
		 * reverse sorted array
		 */
		public static void HeapSort(int[] arr)
		{
			for (int i = 1; i < arr.Length; i++)
			{
				HeapAdd(arr, i);
			}

			for (int i = arr.Length - 1; i > 0; i--)
			{
				Swap(arr, 0, i);
				Heapify(arr, i - 1);
			}
		}

		private static void Heapify(int[] arr, int end)
		{
			int i = 0;
			int leftIndex;
			int rightIndex;
			while (i <= end)
			{
				leftIndex = 2 * i + 1;
				if (leftIndex > end)
				{
					break;
				}
				rightIndex = 2 * i + 2;
				if (rightIndex > end)
				{
					rightIndex = leftIndex;
				}
				if (arr[i] >= Math.Max(arr[leftIndex], arr[rightIndex]))
				{
					break;
				}
				if (arr[leftIndex] >= arr[rightIndex])
				{
					Swap(arr, i, leftIndex);
					i = leftIndex;
				}
				else
				{
					Swap(arr, i, rightIndex);
					i = rightIndex;
				}
			}
		}


		public static void HeapAdd(int[] arr, int end)
		{
			int i = end;
			while (i > 0)
			{
				if (arr[i] > arr[(i - 1) / 2])
				{
					Swap(arr, i, (i - 1) / 2);
					i = (i - 1) / 2;
				}
				else
				{
					break;
				}
			}
		}
	}
}