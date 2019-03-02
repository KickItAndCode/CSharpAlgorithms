// Sorting Algorithms
// Selection Sort starts at the beginning of the array and finds the min and swaps it 
// Then moves over one index and does the process again
// Runtime is O(n^2) in all cases
// In place sorting algorithm

public void SelectionSortRC (int [] data ){
	SelectionSortRC(data, 0);
}

public void SelectionSortRC (int [] data, int start){
	if (start < data.length -1 ){
		Swap(data, start, findMinIndex(data,start));
		SelectionSortRC(data, start + 1);
	}
}

public int findMinIndex(int [] data, int start){
	int minPos = start;
	for(int i = start; i<data.length - 1; ++;){
		if (data[i] < data[minPos]){
			minPos = i;
		}
	}
	return minPos;
}
public void Swap (int [] data , int index1, int index2){
	if (index1 != index2){
		int tmp = data[index1];
		data[index1] = data[index2];
		data[index2] = tmp;
	}
}


// Insertion Sort- Creates sorted array by moving one element at a time(through unsorted array)
// and comparing it with the values in the sorted array
// Runtime O(n) if the list is already sorted 
// Average and worst case O(n^2) so not great for large data sets and randomly ordered data
// In place sorting algorithm 

public void InsertionSort(int [] data){
	for (int which = 1; which < data.length; ++which){
		int val = data[which];
		for(int i = 0; i< which; ++i){
			System.arraycopy(data, i, data, i+1, which - 1);
			data[i] = val;
			break;
		}
	}
}

// Quicksort- divide and conquer algorithm 
// Coose a pivot point and split into two subsets
// first set is less then the pivot and second is greater then the pivot
// recursively pivot/split each subset until there are no more subsets to split
// Average Runtime is O(n log n) in the middle 
// Worst case is O(n^2) picking the lowest value would be the worst


public int [] Quicksort( int [] data){
	if (data.length < 2) return data;

	int pivotIndex = data.length / 2;
	int pivotValue = data[pivotIndex];
	int leftCount - 0;

	// Count how many are less then the pivot
	for (int i = 0; i < data.length; ++i){
		if (data[i] < pivotValue) ++leftCount;		
	}

	// Allocate the arrays and create the subsets
	int [] left = new int [leftCount];
	int [] right = new int[data.length -  leftCount - 1];

	int l = 0;
	int r = 0;


	for (int i = 0; i< data.length; ++i){
		//  skip the pivotValue
		if (i == pivotIndex) continue;

		// current valuue
		int val = data[i];

		// if the value is less than the pivot add it to the 
		//left subset and increment its counter and same for the right side
		if (val < pivotValue){
			left [l++] = val;
		}else {
			right [r++] = val;
		}
	}

	// Sort the subsets
	left = Quicksort(left);
	right = Quicksort(right);

	// combine the sorted arrays and the pivot back into the orinal array
	System.arraycopy(left,0, data, 0, left.length);
	data[left.length] = pivotValue;
	System.arraycopy(right, 0, data, left.length + 1, right.length);

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






