using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode
{
	public static class NumberAlgos
	{

		public static bool IsPerfectSquare(int n)
		{

			for (int i = 1; i * i <= n; i++)
			{
				if (i * i == n)
					return true;
			}
			return false;
		}


		private static bool powerOfTwo(int number)
		{
			int square = 1;
			while (number >= square)
			{
				if (number == square)
				{
					return true;
				}
				square = square * 2;
			}
			return false;
		}

		public static bool isPowerOfFour(int num)
		{
			if (num <= 0) return false;
			int count = 0;
			int temp = num;
			while (temp > 0)
			{
				if ((temp & 1) == 0)
				{
					count++;
				}
				else
				{
					break;
				}
				temp = temp >> 1;
			}
			return (count % 2 == 0) && ((num & (num - 1)) == 0);
		}

		private static bool isPalindrome(int number)
		{
			if (number == reverse(number))
			{
				return true;
			}
			return false;
		}

		private static int reverse(int number)
		{
			int reverse = 0;

			while (number != 0)
			{
				reverse = reverse * 10 + number % 10;
				number = number / 10;
			}

			return reverse;
		}


		public static int power(int n, int m)
		{
			if (m == 0)
			{
				return 1;
			}
			int pow = power(n, m / 2);
			if (m % 2 == 0)
			{
				return pow * pow;
			}
			else
			{
				return n * pow * pow;
			}
		}

		public static double power2(double x, int n)
		{
			if (n == 0) return 1;
			if (n == 1) return x;
			if (n == -1) return 1 / x;

			var a = power2(x, n / 2);
			return a * a * power2(x, n % 2);
		}

		public static double power3(int a, int b)
		{

			if (b == 1)
			{
				return a;
			}

			if (b == 0)
			{
				return 1;
			}

			if (b < 0)
			{
				return 1 / power3(a, Math.Abs(b));

			}
			else
			{

				double pow = power3(a, b / 2);

				if (b % 2 == 0)
				{
					return pow * pow;
				}
				else
				{
					return a * pow * pow;
				}

			}
		}

		public static double powerUsingBit(double x, int n)
		{
			if (n == 0)
			{
				return 1;
			}
			long r = n;
			if (r < 0)
			{
				x = 1 / x;
				r = -r;
			}
			double power = x;
			double result = x;
			double result1 = 1;
			while (r > 1)
			{
				result *= result;
				if ((r & 1) != 0)
				{
					result1 = result1 * power;
				}
				r = r >> 1;
				power = power * power;
			}
			return result * result1;
		}

		public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
		{
			Dictionary<int, int> indexOfValue = new Dictionary<int, int>();
			for (int i = 0; i < list.Count; i++)
			{
				indexOfValue[list[i]] = i;
			}

			for (int i = 0; i < list.Count; i++)
			{
				int value = list[i];
				int needed = sum - value;
				if (indexOfValue.ContainsKey(needed))
				{
					return new Tuple<int, int>(i, indexOfValue[needed]);
				}
			}

			return null;
		}

		/*
        * Prime number is not divisible by any number other than 1 and itself
        * @return true if number is prime
        */
		public static bool isPrime(int number)
		{
			for (int i = 2; i < number; i++)
			{
				if (number % i == 0)
				{
					return false; //number is divisible so its not prime
				}
			}
			return true; //number is prime now
		}

		public static string IsPrime(int n)
		{
			if (n % 2 == 0) return "Not prime";
			for (int i = 3; i <= Math.Sqrt(n); i += 2)
			{
				if (n % i == 0)
					return "Not prime";
			}
			return "Prime";
		}



		/*Fibonacci series is series of natural number where next number is
         equivalent to sum of previous two number e.g. fn = fn-1 + fn-2*/

		/*
        * Java program for Fibonacci number using recursion.
        * This program uses tail recursion to calculate Fibonacci number for a given number
        * @return Fibonacci number
        */
		public static int fibonacci(int number)
		{
			if (number == 1 || number == 2)
			{
				return 1;
			}

			return fibonacci(number - 1) + fibonacci(number - 2); //tail recursion
		}



		public static int evenNumbers(int[] numbers)
		{
			return numbers.Where(x => x % 2 == 0).Sum(x => x);
		}

		public static int GetNthFibonacci_Rec(int n)
		{
			if ((n == 0) || (n == 1))
			{
				return n;
			}
			else
				return GetNthFibonacci_Rec(n - 1) + GetNthFibonacci_Rec(n - 2);
		}

		public static int GetNthFibonacci_Ite(int n)
		{
			int number = n - 1; //Need to decrement by 1 since we are starting from 0
			int[] Fib = new int[number + 1];
			Fib[0] = 0;
			Fib[1] = 1;

			for (int i = 2; i <= number; i++)
			{
				Fib[i] = Fib[i - 2] + Fib[i - 1];
			}
			return Fib[number];
		}

		// Print fib

		public static void Fibonacci_Iterative(int len)
		{
			int a = 0, b = 1, c = 0;
			Console.Write("{0} {1}", a, b);

			for (int i = 2; i < len; i++)
			{
				c = a + b;
				Console.Write(" {0}", c);
				a = b;
				b = c;
			}
		}

		public static void Fibonacci_Recursive(int len)
		{
			Fibonacci_Rec_Temp(0, 1, 1, len);
		}

		private static void Fibonacci_Rec_Temp(int a, int b, int counter, int len)
		{
			if (counter <= len)
			{
				Console.Write("{0} ", a);
				Fibonacci_Rec_Temp(b, a + b, counter + 1, len);
			}
		}

		public static int totaleven(int[] nums)
		{
			int ret = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] % 2 == 0)
				{
					ret++;
				}
			}
			return ret;
		}

		// How to swap two numbers without using a temp variable
		// 100 , 200 
		// 300
		// 100
		// 200
		public static void SwapWithoutTemp(int first, int second)
		{
			first = first + second;
			second = first - second;
			first = first - second;
		}

		// Recursive Factorial
		public static int factorial_RC(int number)
		{
			if (number == 1)
			{
				return 1;
			}
			else return number * factorial_RC(number - 1);
		}


		// Iterative
		public static int factorial(int number)
		{
			int result = 1;
			while (number != 1)
			{
				result = result * number;
				number = number - 1;

			}
			return result;
		}

		// Write a program that takes two integers and returns the remainder

		public static int GetRemainder(int x, int y)
		{
			if (y == 0) throw new Exception("Can't divide by zero");
			if (x < y) throw new Exception("Number being divided can't be less then zero");
			else return (x % y);
		}

		/*An Armstrong number of three digit is a number whose sum of cubes of its 
        digit is equal to its number. For example 153 is an Armstrong number of 
        3 digit because 1^3+5^3+3^3 or   1+125+27=153*/
		private static bool isArmStrong(int number)
		{
			int result = 0;
			int orig = number;
			while (number != 0)
			{
				int remainder = number % 10;
				result = result + remainder * remainder * remainder;
				number = number / 10;
			}
			//number is Armstrong return true
			if (orig == result)
			{
				return true;
			}

			return false;
		}

		private static bool isArmStrong2(int number)
		{
			int remainder, sum = 0;

			for (int i = number; i > 0; i = i / 10)
			{
				remainder = i % 10;
				sum = sum + remainder * remainder * remainder;
			}
			if (sum == number) return true;
			return false;
		}

		public static int GetGCD(int num1, int num2)
		{
			while (num1 != num2)
			{
				if (num1 > num2)
					num1 = num1 - num2;

				if (num2 > num1)
					num2 = num2 - num1;
			}
			return num1;
		}

		public static int GetLCM(int num1, int num2)
		{
			return (num1 * num2) / GetGCD(num1, num2);
		}


		public static List<List<int>> GetFactors(int n)
		{

			List<List<int>> result = new List<List<int>>();
			Helper(result, new List<int>(), n, 2);
			return result;
		}

		public static void Helper(List<List<int>> result, List<int> item,
								   int n, int start)
		{
			int limit = (int)Math.Sqrt(n);

			if (n <= 1 && item.Count > 1)
				result.Add(new List<int>(item));



			for (int i = start; i <= limit; ++i)
			{
				if (n % i == 0)
				{
					item.Add(i); ;
					Helper(result, item, n / i, i);
					item.Remove(item.Count - 1);
				}
			}
		}


		//public List<List<Integer>> getFactors(int n)
		//{
		//	List<List<Integer>> result = new ArrayList<List<Integer>>();
		//	if (n <= 3) return result;
		//	helper(n, -1, result, new ArrayList<Integer>());
		//	return result;
		//}

		//public void helper(int n, int lower, List<List<Integer>> result, List<Integer> cur)
		//{
		//	if (lower != -1)
		//	{
		//		cur.add(n);
		//		result.add(new ArrayList<Integer>(cur));
		//		cur.remove(cur.size() - 1);
		//	}
		//	int upper = (int)Math.sqrt(n);
		//	for (int i = Math.max(2, lower); i <= upper; ++i)
		//	{
		//		if (n % i == 0)
		//		{
		//			cur.add(i);
		//			helper(n / i, i, result, cur);
		//			cur.remove(cur.size() - 1);
		//		}
		//	}
		//}

		static bool IsPythagoreanTriplet(int a, int b, int c)
		{
			int sqra = a * a;
			int sqrb = b * b;
			int sqrc = c * c;

			if (sqra + sqrb == sqrc ||
				sqra + sqrc == sqrb ||
				sqrb + sqrc == sqra)
			{
				return true;
			}

			return false;
		}

		public static List<int[]> FindPythagoreanTriplet(int[] arr)
		{
			int n = arr.Length;
			List<int[]> triplets = new List<int[]>();
			for (int i = 0; i < n - 2; ++i)
			{
				if (arr[i] == 0) continue;

				for (int j = i + 1; j < n - 1; ++j)
				{
					if (arr[j] == 0) continue;

					for (int k = j + 1; k < n; ++k)
					{
						if (IsPythagoreanTriplet(arr[i], arr[j], arr[k]))
						{
							int[] triplet = { arr[i], arr[j], arr[k] };
							triplets.Add(triplet);
						}
					}
				}
			}

			return triplets;
		}
	}
}
