using System;
using System.Collections.Generic;
using System.Linq;
namespace InterviewCode
{
	public static class StackAndQueues
	{

		//"3 4 +" rather than "3 + 4"
		//"3 − 4 + 5" in conventional notation would be written "3 4 − 5 +"
		public static int EvaluateReversePolishNotation(string[] tokens)
		{
			int a, b;
			Stack<int> S = new Stack<int>();
			foreach (string s in tokens)
			{
				if (s.Equals("+"))
				{
					S.Push(S.Pop() + S.Pop());
				}
				else if (s.Equals("/"))
				{
					b = S.Pop();
					a = S.Pop();
					S.Push(a / b);
				}
				else if (s.Equals("*"))
				{
					S.Push(S.Pop() * S.Pop());
				}
				else if (s.Equals("-"))
				{
					b = S.Pop();
					a = S.Pop();
					S.Push(a - b);
				}
				else
				{
					S.Push(int.Parse(s));
				}
			}
			return S.Pop();
		}

		/*A bracket is considered to be any one of the following characters: (, ), {, }, [, or ].
		*/
		public static bool isBalanced(string expression)
		{
			Dictionary<char, char> map = new Dictionary<char, char>();
			map.Add('(', ')');
			map.Add('[', ']');
			map.Add('{', '}');

			if ((expression.Length % 2) != 0) return false;

			Stack<char> stack = new Stack<char>();
			foreach (char c in expression)
			{
				if (map.ContainsKey(c))
				{
					stack.Push(c);

				}
				else if (stack.Count == 0 || c != map[stack.Pop()])
				{
					return false;
				}
			}
			return stack.Count == 0;
		}

		public class TowerOfHanoi
		{

			public static int N;
			/* Creating Stack array  */
			public static Stack<int>[] tower = new Stack<int>[4];


			public static void Init()
			{
				tower[1] = new Stack<int>();
				tower[2] = new Stack<int>();
				tower[3] = new Stack<int>();

				// Disk number 
				Push(3);
			}

			public static void Push(int n)
			{
				for (int d = n; d > 0; d--)
					tower[1].Push(d);

				// Move n disk from tower 1 to 2 using 3 as intermediate tower
				Move(n, 1, 2, 3);

			}

			public static void Move(int n, int a, int b, int c)
			{
				if (n > 0)
				{

					Move(n - 1, a, c, b);
					// move from top of tower 1
					int d = tower[a].Pop();
					// to top of tower c
					tower[c].Push(d);
					Move(n - 1, b, a, c);
				}
			}
		}


		public static Stack<int> Sort(Stack<int> s)
		{
			Stack<int> r = new Stack<int>();
			while (s.Count() > 0)
			{
				int temp = s.Pop();
				while (r.Count() > 0 && r.Peek() > temp)
				{
					s.Push(r.Pop());
				}
				r.Push(temp);
			}
			return r;
		}


		/*you are given two arrays (without duplicates) nums1 and nums2
		 * where nums1’s elements are subset of nums2. Find all the next
		 * greater numbers for nums1's elements in the corresponding places
		 * of nums2. 
		 * The Next Greater Number of a number x in nums1 is the first greater
		 * number to its right in nums2. If it does not exist, output -1 for 
		 * this number.*/


		public static int[] NextGreaterElement(int[] findNums, int[] nums)
		{
			Dictionary<int, int> map = new Dictionary<int, int>();
			Stack<int> stack = new Stack<int>();

			foreach (int num in nums)
			{
				while (stack.Count > 0 && stack.Peek() < num)
				{
					map.Add(stack.Pop(), num);

				}
				stack.Push(num);
			}
			for (int i = 0; i < findNums.Length; i++)
			{
				int val = 0;
				if (!map.TryGetValue(findNums[i], out val))
				{
					val = -1;
				}
				findNums[i] = val;
			}
			return findNums;

		}


		/*Given a circular array (the next element of the last element 
		 * is the first element of the array), print the Next Greater
		 * Number for every element. The Next Greater Number of a number
		 * x is the first greater number to its traversing-order next 
		 * in the array, which means you could search circularly to find
		 * its next greater number. If it doesn't exist, output -1 for 
		 * this number.*/
		public static int[] NextGreaterElement(int[] nums)
		{
			int n = nums.Length;
			int[] next = Enumerable.Repeat(-1, n).ToArray();
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < n * 2; i++)
			{
				int num = nums[i % n];
				while (stack.Count > 0 && nums[stack.Peek()] < num)
					next[stack.Pop()] = num;

				if (i < n) stack.Push(i);
			}
			return next;
		}


		/**
	 
	 * Given an array representing height of bar in bar graph, find max histogram
	 * area in the bar graph. Max histogram will be max rectangular area in the
	 * graph.
	 * 
	 * Maintain a stack
	 * 
	 * If stack is empty or value at index of stack is less than or equal to value at current 
	 * index, push this into stack.
	 * Otherwise keep removing values from stack till value at index at top of stack is 
	 * less than value at current index.
	 * While removing value from stack calculate area
	 * if stack is empty 
	 * it means that till this point value just removed has to be smallest element
	 * so area = input[top] * i
	 * if stack is not empty then this value at index top is less than or equal to 
	 * everything from stack top + 1 till i. So area will
	 * area = input[top] * (i - stack.peek() - 1);
	 * Finally maxArea is area if area is greater than maxArea.
	 * 
	 * 
	 * Time complexity is O(n)
	 * Space complexity is O(n)

	 */

		// maxhistogram 
		// largest rectangle
		public static int LargestRectangle(int[] input)
		{
			Stack<int> stack = new Stack<int>();
			int maxArea = 0;
			int area = 0;
			int i;
			for (i = 0; i < input.Length;)
			{
				if (stack.Count == 0 || input[stack.Peek()] <= input[i])
				{
					stack.Push(i++);
				}
				else
				{
					int top = stack.Pop();
					//if stack is empty means everything till i has to be
					//greater or equal to input[top] so get area by
					//input[top] * i;
					if (stack.Count == 0)
					{
						area = input[top] * i;
					}
					//if stack is not empty then everythin from i-1 to input.peek() + 1
					//has to be greater or equal to input[top]
					//so area = input[top]*(i - stack.peek() - 1);
					else
					{
						area = input[top] * (i - stack.Peek() - 1);
					}
					if (area > maxArea)
					{
						maxArea = area;
					}
				}
			}
			while (stack.Count > 0)
			{
				int top = stack.Pop();
				//if stack is empty means everything till i has to be
				//greater or equal to input[top] so get area by
				//input[top] * i;
				if (stack.Count == 0)
				{
					area = input[top] * i;
				}
				//if stack is not empty then everything from i-1 to input.peek() + 1
				//has to be greater or equal to input[top]
				//so area = input[top]*(i - stack.peek() - 1);
				else
				{
					area = input[top] * (i - stack.Peek() - 1);
				}
				if (area > maxArea)
				{
					maxArea = area;
				}
			}
			return maxArea;
		}

	}

	/*Create two queues and dequeue one stack until there is 1
	element in the queue and then grab that as the value
	Then make queue2 queue1 again*/
	public class StackUsingQueue
	{
		Queue<int> queue1 = new Queue<int>();
		Queue<int> queue2 = new Queue<int>();

		void push(int data)
		{
			queue1.Enqueue(data);
		}

		bool isEmpty()
		{
			return queue1.Count + queue2.Count == 0;
		}
		int pop()
		{
			if (isEmpty())
			{
				throw new Exception("Stack Is Empty");
			}
			while (queue1.Count > 1)
			{
				queue2.Enqueue(queue1.Dequeue());
			}

			int value = queue1.Dequeue();

			// swap queues so queue1 is the main again
			swapQueues();

			return value;
		}

		void swapQueues()
		{
			Queue<int> temp = queue1;
			queue1 = queue2;
			queue2 = temp;
		}
	}

	public class QueueUsingStack
	{
		Stack<int> stack1 = new Stack<int>();
		Stack<int> stack2 = new Stack<int>();

		public void enqueue(int data)
		{
			stack1.Push(data);

		}
		public int dequeue()
		{
			if (isEmpty())
			{
				throw new Exception("Queue is empty");
			}

			if (stack2.Count == 0)
			{
				while (stack1.Count > 0)
				{
					stack2.Push(stack1.Pop());
				}
			}
			return stack2.Pop();

		}

		bool isEmpty()
		{
			return stack1.Count + stack2.Count == 0;
		}
	}

	public class MinStack
	{
		int min = int.MaxValue;
		Stack<int> stack = new Stack<int>();
		public void push(int x)
		{
			// only push the old minimum value when the current 
			// minimum value changes after pushing the new value x
			if (x <= min)
			{
				stack.Push(min);
				min = x;
			}
			stack.Push(x);
		}

		public void pop()
		{
			// if pop operation could result in the changing of the current minimum value, 
			// pop twice and change the current minimum value to the last minimum value.
			if (stack.Pop() == min) min = stack.Pop();
		}

		public int top()
		{
			return stack.Peek();
		}

		public int getMin()
		{
			return min;
		}
	}



}

