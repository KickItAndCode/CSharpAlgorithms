using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode
{
	public static class LinkedListAlgos
	{

		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x)
			{
				val = x;
				next = null;
			}
		}

		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}

		/*Given a linked list, determine if it has a cycle in it.*/
		public static bool HasCycle(ListNode head)
		{
			HashSet<ListNode> nodesSeen = new HashSet<ListNode>();

			while (head != null)
			{
				if (nodesSeen.Contains(head))
				{
					return true;
				}
				else
				{
					nodesSeen.Add(head);
				}
				head = head.next;
			}
			return false;
		}

		public static bool hasCycle2(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return false;
			}
			ListNode slow = head;
			ListNode fast = head.next;
			while (slow != fast)
			{
				if (fast == null || fast.next == null)
				{
					return false;
				}
				slow = slow.next;
				fast = fast.next.next;
			}
			return true;
		}

		public static ListNode DetectCycle(ListNode head)
		{
			ListNode slow = head;
			ListNode fast = head;

			while (fast != null && fast.next != null)
			{
				fast = fast.next.next;
				slow = slow.next;

				if (fast == slow)
				{
					while (head != slow)
					{
						slow = slow.next;
						head = head.next;
					}
					return slow;
				}
			}
			return null;
		}

		/*Delete node from linked list*/
		public static void DeleteNode(ListNode node)
		{

			if (node != null && node.next != null)
			{
				node.val = node.next.val;
				node.next = node.next.next;
			}
		}

		public static ListNode DeleteNode2(ListNode head, int key)
		{

			ListNode prev = null;
			ListNode curr = head;

			while (curr != null)
			{

				if (curr.val == key)
				{
					break;
				}
				prev = curr;
				curr = curr.next;
			}

			if (curr == null) return head;

			if (curr == head) return curr.next;

			prev.next = curr.next;
			return head;
		}

		/*Given a sorted linked list, delete all duplicates such that 
		 * each element appear only once.*/
		public static ListNode DeleteDuplicates(ListNode head)
		{
			ListNode curr = head;

			while (curr != null)
			{
				if (curr.next == null)
				{
					break;
				}
				else if (curr.val == curr.next.val)
				{
					curr.next = curr.next.next;
				}
				else
				{
					curr = curr.next;
				}
			}
			return head;

		}



		/*Write a program to find the node at which the intersection
		 * of two singly linked lists begins.*/

		public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		{
			int aLength = Length(headA);
			int bLength = Length(headB);

			// Align pointers based on length
			while (aLength > bLength)
			{
				headA = headA.next;
				aLength--;
			}

			while (bLength < aLength)
			{
				headB = headB.next;
				bLength--;
			}

			//increment both until they are equal or null
			while (headA != headB)
			{

				headA = headA.next;
				headB = headB.next;
			}
			return headA;
		}
		// 3 - 2- 1
		// Reverse a linked list	
		public static ListNode ReverseList(ListNode head)
		{
			ListNode current = head;
			ListNode next;
			ListNode prev = null;
			while (current != null)
			{
				next = current.next;
				current.next = prev;
				prev = current;
				current = next;

			}
			head = prev;
			return head;
		}

		// better O (n) time and 0 (1) space
		public static ListNode ReverseIt(ListNode head)
		{

			if (head == null || head.next == null) return head;

			ListNode toDo = head.next;
			ListNode revsersedList = head;

			revsersedList.next = null;

			while (toDo != null)
			{

				ListNode temp = toDo;
				toDo = toDo.next;

				temp.next = revsersedList;
				revsersedList = temp;
			}
			return revsersedList;
		}

		public static ListNode ReverseListRec(ListNode head)
		{
			return ReverseListHelper(head, null);
		}

		public static ListNode ReverseListHelper(ListNode head, ListNode newHead)
		{
			if (head == null) return newHead;
			ListNode next = head.next;
			head.next = newHead;
			return ReverseListHelper(next, head);
		}

		public static ListNode ReverseRec(ListNode head)
		{

			if (head == null || head.next == null)
			{
				return head;
			}

			ListNode recList = ReverseRec(head.next);
			ListNode temp = head.next;
			temp.next = head;
			head = null;

			return recList;
		}


		public static bool IsPalindrome(ListNode head)
		{

			if (head == null || head.next == null) return true;

			ListNode mid = FindMiddle(head);
			ListNode midHead = mid.next;

			ListNode reverseHead = ReverseList(midHead);

			while (reverseHead != null)
			{
				if (reverseHead.val == head.val)
				{
					head = head.next;
					reverseHead = reverseHead.next;
				}
				else
				{
					return false;
				}
			}
			return true;
		}


		public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
		{
			if (l1 == null) return l2;
			if (l2 == null) return l1;

			if (l1.val < l2.val)
			{
				l1.next = MergeTwoLists(l1.next, l2);
				return l1;
			}
			else
			{
				l2.next = MergeTwoLists(l2.next, l1);
				return l2;
			}
		}

		public static ListNode MergeIterative(ListNode l1, ListNode l2)
		{

			ListNode head = new ListNode(0);
			ListNode p = head;

			while (l1 != null && l2 != null)
			{

				if (l1.val < l2.val)
				{
					p.next = l1;
					l1 = l1.next;
				}
				else
				{
					p.next = l2;
					l2 = l2.next;
				}
				p = p.next;
			}
			if (l1 != null)
				p.next = l1;
			if (l2 != null)
				p.next = l2;

			return head.next;
		}

		public static ListNode MergeAlternating(ListNode l1, ListNode l2)
		{
			if (l1 == null) return l2;
			if (l2 == null) return l1;

			ListNode head = l1;

			while (l1.next != null && l2 != null)
			{
				ListNode temp = l2;
				l2 = l2.next;

				temp.next = l1.next;
				l1.next = temp;
				l1 = temp.next;
			}


			if (l1.next == null)
			{
				l1.next = l2;
			}
			return head;
		}

		public static ListNode AddLists(ListNode list1, ListNode list2, int carry)
		{
			if (list1 == null && list2 == null && carry == 0)
			{
				return null;
			}

			var result = new ListNode(0);
			var value = carry;

			if (list1 != null)
			{
				value += list1.val;
			}
			if (list2 != null)
			{
				value += list2.val;
			}

			result.val = value % 10;

			if (list1 != null || list2 != null)
			{
				var more = AddLists(list1 == null ? null : list1.next,
									list2 == null ? null : list2.next,
											   value >= 10 ? 1 : 0);
				result.next = more;
			}

			return result;
		}

		public static ListNode ReverseEvenNodes(ListNode head)
		{
			// Create two list one even and one reversed even

			ListNode curr = head;
			ListNode listEven = null;

			while (curr != null && curr.next != null)
			{

				ListNode even = curr.next;
				curr.next = even.next;

				// push at the head of new list
				even.next = listEven;
				listEven = even;

				curr = curr.next;


			}

			return MergeAlternating(head, listEven);
		}

		// 1->2->3->4->5->NULL K = 2
		// 4->5->1->2->3->NULL
		public static ListNode rotateRight(ListNode head, int k)
		{
			if (head == null)
				return null;

			int size = 1; // since we are already at head node
			ListNode fast = head;
			ListNode slow = head;

			while (fast.next != null)
			{
				size++;
				fast = fast.next;
			}

			for (int i = size - k % size; i > 1; i--) // i>1 because we need to put slow.next at the start.
				slow = slow.next;

			// No dummy variable.
			fast.next = head;
			head = slow.next;
			slow.next = null;

			return head;
		}

		private static ListNode FindMiddle(ListNode head)
		{

			ListNode slow, fast;
			slow = head;
			fast = head.next;

			while (fast != null && fast.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;

			}
			return slow;
		}


		public static ListNode DeleteMiddleNode(ListNode head)
		{

			ListNode slow, fast, prev;
			prev = null;
			slow = head;
			fast = head.next;

			if (head == null) return null;

			if (head.next == null) return null;

			while (fast != null && fast.next != null)
			{

				prev = slow;
				slow = slow.next;
				fast = fast.next.next;
			}

			// fast at the end and slow in the middle and prev is one behind slow
			prev.next = slow.next;
			return head;
		}
		private static int Length(ListNode node)
		{

			int length = 0;
			while (node != null)
			{
				length++;
				node = node.next;

			}
			return length;
		}

		public static void Insert(int v, ListNode head)
		{

			ListNode newNode = new ListNode(v);
			ListNode curr = head;
			while (curr.next != null)
			{
				curr = curr.next;
			}

			curr.next = newNode;
			return;
		}

		public static void DisplayList(ListNode head)
		{
			ListNode p;
			if (head == null)
			{
				Console.WriteLine("Your list is empty, idiot");
				return;
			}
			Console.WriteLine("List is :  ");
			p = head;
			while (p != null)
			{
				Console.WriteLine(p.val + " ");
				p = p.next;
			}
			Console.WriteLine();
		}

		public static ListNode sortList(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return head;
			}

			ListNode slow = head;
			ListNode fast = head;
			ListNode prev = null;

			// Cut list in half
			while (fast != null && fast.next != null)
			{
				prev = slow;
				slow = slow.next;
				fast = fast.next.next;
			}

			prev.next = null;

			ListNode l1 = sortList(head);
			ListNode l2 = sortList(slow);

			return MergeIterative(l1, l2);
		}

		public static ListNode InsertionSortList(ListNode head)
		{
			if (head == null) return head;

			ListNode helper = new ListNode(0); // start of the sorted linked list
			ListNode pre;
			ListNode cur = head;


			while (cur != null)
			{
				pre = helper;

				// find place to insert
				while (pre.next != null && pre.next.val < cur.val)
				{
					pre = pre.next;
				}

				// insert between pre and pre.next
				ListNode pNext = pre.next;
				pre.next = cur;
				ListNode next = cur.next;
				cur.next = pNext;
				cur = next;

			}
			return helper.next;
		}

		public static ListNode InsertionSort2(ListNode head)
		{
			ListNode sorted = null;
			ListNode curr = head;

			while (curr != null)
			{

				ListNode temp = curr.next;
				sorted = SortedInsert(sorted, curr);
				curr = temp;
			}
			return sorted;
		}

		public static ListNode SortedInsert(ListNode head, ListNode node)
		{
			if (node == null) return head;

			if (head == null || node.val <= head.val)
			{
				node.next = head;
				return node;
			}

			ListNode curr = head;

			while (curr.next != null && (curr.next.val < node.val))
			{
				curr = curr.next;
			}

			node.next = curr.next;
			curr.next = node;

			return head;
		}

		// Swaps adjacent pairs  nodes not values
		public static ListNode SwapPairs(ListNode head)
		{
			if (head == null || head.next == null) return head;

			ListNode n = head.next;
			head.next = SwapPairs(head.next.next);
			n.next = head;
			return n;

		}

		public static ListNode RemoveNthFromEnd(ListNode head, int n)
		{

			ListNode start = new ListNode(0);
			ListNode slow = start;
			ListNode fast = start;
			slow.next = head;


			while (n > 0)
			{
				fast = fast.next;
				n--;
			}

			while (fast.next != null)
			{
				slow = slow.next;
				fast = fast.next;
			}

			slow.next = slow.next.next;
			return start.next;

		}

		public static ListNode removeNthFromEnd2(ListNode head, int n)
		{
			ListNode newHead = new ListNode(0);
			newHead.next = head;
			ListNode p = newHead;
			ListNode runner = newHead;
			while (n > 0)
			{
				runner = runner.next;
				n--;
			}
			while (runner.next != null)
			{
				runner = runner.next;
				p = p.next;
			}
			p.next = p.next.next;
			return newHead.next;
		}

		public static ListNode SwapNthWithHead(ListNode head, int n)
		{

			ListNode slow = head;
			ListNode fast = head;

			while (n < 0)
			{
				fast = fast.next;
				n--;
			}

			while (fast != null)
			{
				fast = fast.next;
				slow = slow.next;
			}

			// swap slow with head
			ListNode temp = head.next; ;
			head.next = slow.next;
			slow.next = temp;

			return slow;
		}

		public static void DeleteDupsA(ListNode node)
		{
			var table = new Dictionary<int, bool>();
			ListNode previous = null;

			while (node != null)
			{
				if (table.ContainsKey(node.val))
				{
					if (previous != null)
					{
						previous.next = node.next;
					}
				}
				else
				{
					table.Add(node.val, true);
					previous = node;
				}

				node = node.next;
			}
		}

		public static void DeleteDupsB(ListNode head)
		{
			if (head == null) return;

			var current = head;

			while (current != null)
			{
				/* Remove all future nodes that have the same value */
				var runner = current;

				while (runner.next != null)
				{

					if (runner.next.val == current.val)
					{
						runner.next = runner.next.next;
					}
					else
					{
						runner = runner.next;
					}
				}
				current = current.next;
			}
		}

		public static ListNode DeleteAllDuplicates(ListNode head)
		{
			if (head == null)
			{
				return null;
			}

			ListNode dummy = new ListNode(0 == head.val ? 1 : 0);// to guarantee the dummy node is not same as the original head.
			dummy.next = head;

			ListNode pre = dummy;
			ListNode cur = head;

			ListNode first = dummy; // the first node in the new unduplicated(result) list.

			while (cur != null && cur.next != null)
			{
				if (cur.val != pre.val && cur.val != cur.next.val)
				{ // we found a unique node, we connect it at the tail of the unduplicated list, and update the first node.
					first.next = cur;
					first = first.next;
				}
				pre = cur;
				cur = cur.next;
			}

			if (pre.val != cur.val)
			{  // the last node needs to be dealt with independently
				first.next = cur;
				first = first.next;
			}

			first.next = null;  // the subsequent list is duplicate.

			return dummy.next;
		}


		// Converts a sorted linked list into a BST
		public static TreeNode SortedListToBST(ListNode head)
		{
			if (head == null) return null;
			return ToBSTHelper(head, null);
		}

		public static TreeNode ToBSTHelper(ListNode head, ListNode tail)
		{
			ListNode slow = head;
			ListNode fast = head;

			if (head == tail) return null;

			while (fast != tail && fast.next != tail)
			{
				slow = slow.next;
				fast = fast.next.next;

			}

			TreeNode root = new TreeNode(slow.val);
			root.left = ToBSTHelper(head, slow);
			root.right = ToBSTHelper(slow.next, tail);

			return root;
		}

		//Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
		//Output: 7 -> 0 -> 8

		// result in reverse order
		public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			ListNode dummyHead = new ListNode(0);
			ListNode p = l1, q = l2, curr = dummyHead;
			int carry = 0;
			while (p != null || q != null)
			{
				int x = (p != null) ? p.val : 0;
				int y = (q != null) ? q.val : 0;
				int sum = carry + x + y;

				carry = sum / 10;

				// Create new nodes for result and adjust current
				curr.next = new ListNode(sum % 10);
				curr = curr.next;

				// increment both pointers
				if (p != null) p = p.next;
				if (q != null) q = q.next;
			}
			// 999 +1 case
			if (carry > 0)
			{
				curr.next = new ListNode(carry);
			}
			return dummyHead.next;
		}
	}
}