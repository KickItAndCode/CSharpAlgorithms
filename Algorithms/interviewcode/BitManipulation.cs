using System;
namespace InterviewCode
{
	public static class BitManipulation
	{
		public static int IsSetBit(int x, int position)
		{
			int shifted = x >> position;
			return shifted & 1;
		}

		public static int Modify(int x, int position, int state)
		{
			int mask = 1 << position;
			return (x & mask) | -state & mask;
		}

		public static int SetBit(int x, int position)
		{
			int mask = 1 << position;
			return x | mask;
		}

		public static int ClearBit(int x, int position)
		{
			int mask = 1 << position;
			return x & ~mask;
		}

		public static int FlipBit(int x, int position)
		{
			int mask = 1 << position;
			return x ^ mask;
		}

		public static bool IsEven(int x)
		{
			return (x & 1) == 0;
		}

		// convert to binary
		public static void bin(uint n)
		{
			int i;
			for (i = 1 << 31; i > 0; i = i / 2)
			{
				if ((n & 1) == 1)
				{
					Console.Write("1");
				}
				else Console.Write("0");
			}
		}
		//   1000
		// & 0111
		//   0000
		// subtract one sets all bits behind it to one and 
		// all power of two only have one binary number set
		public static bool IsPowerOfTwo(int x)
		{
			return (x & (x - 1)) == 0;
		}

		/*Hamming Distance is between two integers is the number of 
	 * positions at which the corresponding bits are different.*/
		public static int HammingDistance(int x, int y)
		{
			int xor = x ^ y; // bit difference;
			int count = 0;

			while (xor != 0)
			{
				xor &= (xor - 1);
				count++;
			}
			return count;
		}


		public static int sumBitDifferences(int[] arr, int n)
		{
			int ans = 0;  // Initialize result

			// traverse over all bits
			for (int i = 0; i < 32; i++)
			{
				// count number of elements with i'th bit set
				int count = 0;
				for (int j = 0; j < n; j++)
					if ((arr[j] & (1 << i)) == 1)
						count++;

				// Add "count * (n - count) * 2" to the answer
				ans += (count * (n - count) * 2);
			}

			return ans;
		}

		/*rite a function that takes an unsigned integer
		 * and returns the number of ’1' bits it has */
		public static int HammingWeight(uint n)
		{
			int count = 0;

			while (n != 0)
			{
				n = n & (n - 1);
				count++;
			}

			return count;
		}


		/* num = 5  101 Flip bits no trailing zeros
				 	  10*/
		public static int FindComplement(int num)
		{
			int copy = num, i = 0;
			while (copy != 0)
			{
				copy >>= 1;
				num ^= (1 << i++);
			}
			return num;
		}


		public static int SingleNumber(int[] nums)
		{
			int j = 0;
			foreach (int n in nums)
			{
				j = j ^ n;
			}
			return j;
		}

		public static int getSum(int a, int b)
		{
			if (a == 0) return b;
			if (b == 0) return a;

			while (b != 0)
			{

				int carry = a & b; // & finds a carry 
				a = a & b; // XOR finds the different bit and assigns it
				b = carry << 1; // shift one position left and assign it
			}
			return a;
		}

		public static int getSubtract(int a, int b)
		{
			while (b != 0)
			{
				int borrow = (~a) & b; // ~ Not operation flips the bits 0010 -> 1101
				a = a & b;
				b = borrow << 1;
			}
			return a;
		}

		public static bool IsUgly(int num)
		{
			if (num == 0)
			{
				return false;
			}

			while (num % 5 == 0)
			{
				num /= 5;
			}
			while (num % 3 == 0)
			{
				num /= 3;
			}
			while (num % 2 == 0)
			{
				num /= 2;
			}

			return num == 1;
		}

		public static int IntegerDivide(int x, int y)
		{

			// We will return -1 if the
			// divisor is '0'.
			if (y == 0)
			{
				return -1;
			}

			if (x < y)
			{
				return 0;
			}
			else if (x == y)
			{
				return 1;
			}
			else if (y == 1)
			{
				return x;
			}

			int q = 1;
			int val = y;

			while (val < x)
			{
				val <<= 1;
				// we can also use 'val = val + val;'
				q <<= 1;
				// we can also use 'q = q + q;'
			}

			if (val > x)
			{
				val >>= 1;
				q >>= 1;

				return q + IntegerDivide(x - val, y);
			}

			return q;
		}


		public static int maxSubarrayXOR(int[] arr, int n)
		{
			int ans = int.MinValue;   // Initialize result

			// Pick starting points of subarrays
			for (int i = 0; i < n; i++)
			{
				int curr_xor = 0; // to store xor of current subarray

				// Pick ending points of subarrays starting with i
				for (int j = i; j < n; j++)
				{
					curr_xor = curr_xor ^ arr[j];
					ans = Math.Max(ans, curr_xor);
				}
			}
			return ans;
		}
		/* magic number is defined as a number which can be expressed as a power
		 * of 5 or sum of unique powers of 5. First few magic numbers are
		 * 5, 25, 30(5 + 25), 125, 130(125 + 5), ….

		Write a function to find the nth Magic number.*/
		public static int nthMagicNo(int n)
		{
			int pow = 1, answer = 0;

			// Go through every bit of n
			while (n >= 1)
			{
				pow = pow * 5;

				// If last bit of n is set
				if ((n & 1) == 1)
					answer += pow;

				// proceed to next bit
				n >>= 1;  // or n = n/2
			}
			return answer;
		}

		public static uint SwapBits(uint x)
		{


			// 0xAAAA 1010 1010 1010 1010 even
			// 0x5555 0101 0101 0101 0101 odd
			uint evenBits = x & 0xAAAA;
			uint oddBits = x & 0x5555;

			// Set odd bits
			// set even bits
			// swap positions by moving even to the right and odd to the left

			evenBits >>= 1;
			oddBits <<= 1;

			return evenBits | oddBits;
		}

		public static int getSingle(int[] arr, int n)
		{
			int ones = 0, twos = 0;

			int common_bit_mask;

			// Let us take the example of {3, 3, 2, 3} to understand this
			for (int i = 0; i < n; i++)
			{
				/* The expression "one & arr[i]" gives the bits that are
				   there in both 'ones' and new element from arr[].  We
				   add these bits to 'twos' using bitwise OR

				   Value of 'twos' will be set as 0, 3, 3 and 1 after 1st,
				   2nd, 3rd and 4th iterations respectively */
				twos = twos | (ones & arr[i]);


				/* XOR the new bits with previous 'ones' to get all bits
				   appearing odd number of times

				   Value of 'ones' will be set as 3, 0, 2 and 3 after 1st,
				   2nd, 3rd and 4th iterations respectively */
				ones = ones ^ arr[i];


				/* The common bits are those bits which appear third time
				   So these bits should not be there in both 'ones' and 'twos'.
				   common_bit_mask contains all these bits as 0, so that the bits can 
				   be removed from 'ones' and 'twos'   

				   Value of 'common_bit_mask' will be set as 00, 00, 01 and 10
				   after 1st, 2nd, 3rd and 4th iterations respectively */
				common_bit_mask = ~(ones & twos);


				/* Remove common bits (the bits that appear third time) from 'ones'

				   Value of 'ones' will be set as 3, 0, 0 and 2 after 1st,
				   2nd, 3rd and 4th iterations respectively */
				ones &= common_bit_mask;


				/* Remove common bits (the bits that appear third time) from 'twos'

				   Value of 'twos' will be set as 0, 3, 1 and 0 after 1st,
				   2nd, 3rd and 4th itearations respectively */
				twos &= common_bit_mask;

				// uncomment this code to see intermediate values
				//printf (" %d %d \n", ones, twos);
			}

			return ones;
		}


		public static int CountSetBits(uint x)
		{
			int bitCount = 0;

			for (int i = 1; i <= x; x++)
			{
				bitCount += CountSetBitsUtil(i);
			}
			return bitCount;
		}
		public static int CountSetBitsUtil(int x)
		{

			if (x <= 0) return 0;

			return (x % 2 == 0 ? 0 : 1) + CountSetBitsUtil(x / 2);

		}

		public static int Leftrotate(int n, int d)
		{
			return (n << d) | (n << (32 - d));
		}

		public static int RightRotate(int n, int d)
		{

			return (n >> d) | (n >> (32 - d));
		}
	}
}
