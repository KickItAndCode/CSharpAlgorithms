using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode
{
	public static class TreeAlgos
	{

		public class AVLTree
		{

			private Node LeftRotate(Node root)
			{
				Node newRoot = root.right;
				root.right = root.right.left;
				newRoot.left = root;
				root.height = SetHeight(root);
				root.size = SetSize(root);
				newRoot.height = SetHeight(newRoot);
				newRoot.size = SetSize(newRoot);
				return newRoot;
			}

			private Node RightRotate(Node root)
			{
				Node newRoot = root.left;
				root.left = root.left.right;
				newRoot.right = root;
				root.height = SetHeight(root);
				root.size = SetSize(root);
				newRoot.height = SetHeight(newRoot);
				newRoot.size = SetSize(newRoot);
				return newRoot;
			}

			private int SetHeight(Node root)
			{
				if (root == null)
				{
					return 0;
				}
				return 1 + Math.Max((root.left != null ? root.left.height : 0), (root.right != null ? root.right.height : 0));
			}

			private int Height(Node root)
			{
				if (root == null)
				{
					return 0;
				}
				else
				{
					return root.height;
				}
			}

			private int SetSize(Node root)
			{
				if (root == null)
				{
					return 0;
				}
				return 1 + Math.Max((root.left != null ? root.left.size : 0), (root.right != null ? root.right.size : 0));
			}


			public Node Insert(Node root, int data)
			{

				// Standard binary search tree insertion
				if (root == null)
				{
					return new Node(data);
				}
				if (root.value <= data)
				{
					root.right = Insert(root.right, data);
				}
				else
				{
					root.left = Insert(root.left, data);
				}

				// Check balance each insert
				int balance = Balance(root.left, root.right);

				// left side is larger then right
				if (balance > 1)
				{
					if (Height(root.left.left) >= Height(root.left.right))
					{
						root = RightRotate(root);
					}
					else
					{
						root.left = LeftRotate(root.left);
						root = RightRotate(root);
					}
				}
				// right side is large then left
				else if (balance < -1)
				{
					if (Height(root.right.right) >= Height(root.right.left))
					{
						root = LeftRotate(root);
					}
					else
					{
						root.right = RightRotate(root.right);
						root = LeftRotate(root);
					}
				}
				else
				{
					root.height = SetHeight(root);
					root.size = SetSize(root);
				}
				return root;
			}

			private int Balance(Node rootLeft, Node rootRight)
			{
				return Height(rootLeft) - Height(rootRight);
			}
		}


		//Binary Search Tree Questions
		// Search, Insertion, Deletion is O(Log(n)) very fast
		// Print in order is O(n)
		// Given a node you can find the next highest node in O(log(n)) time
		// When Searching a tree that isn't ordered the lookup is O(n)
		// log 2(1000000000) = 30 
		// If each Node only has one child lookup is O(n) and 
		//is basically a linked list
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode parent;

			public TreeNode(int x)
			{
				val = x;
			}
		}
		public class Node
		{
			public int value, height, size;
			public Node left, right, parent;


			public Node(int value)
			{
				this.value = value;
				left = null;
				right = null;
			}
		}
		// Recursive DFS

		public static bool CheckBST(Node root)
		{
			return CheckBSTHelper(root, 0, int.MaxValue);
		}

		public static bool CheckBSTHelper(Node root, int min, int max)
		{

			if (root == null) return true;

			if (root.value < min || root.value > max) return false;

			return CheckBSTHelper(root.left, min, root.value - 1) &&
				CheckBSTHelper(root.right, root.value + 1, max);
		}


		public static int Size(Node node)
		{
			if (node == null) return 0;

			return (Size(node.left) + 1 + Size(node.right));
		}

		public static TreeNode InvertTree(TreeNode root)
		{
			if (root == null) return null;

			TreeNode left = root.left;
			TreeNode right = root.right;

			root.left = InvertTree(right);
			root.right = InvertTree(left);
			return root;
		}


		public static TreeNode InvertTreeIterative(TreeNode root)
		{
			if (root == null) return null;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);

			while (stack.Count > 0)
			{
				TreeNode node = stack.Pop();

				// Swap
				TreeNode left = node.left;
				node.left = node.right;
				node.right = left;

				if (node.left != null) stack.Push(left);

				if (node.right != null) stack.Push(node.right);
			}

			return root;
		}

		public static TreeNode InvertTreeIterativeBFS(TreeNode root)
		{
			if (root == null) return null;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				TreeNode node = queue.Dequeue();

				// swap 
				TreeNode left = node.left;
				node.left = node.right;
				node.right = left;

				if (node.left != null) queue.Enqueue(node.left);
				if (node.right != null) queue.Enqueue(node.right);

			}

			return root;
		}

		public static int SumLeftLeaves(TreeNode root)
		{
			if (root == null) return 0;

			int ans = 0;
			if (root.left != null)
			{
				if (root.left.left == null && root.left.right == null)
					ans += root.left.val;
				else ans += SumLeftLeaves(root.left);
			}
			if (root.right != null)
			{
				ans += SumLeftLeaves(root.right);
			}
			return ans;
		}


		public static int SumLeftLeavesIterative(TreeNode root)
		{

			if (root == null) return 0;
			int ans = 0;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);

			while (stack.Count > 0)
			{

				TreeNode node = stack.Pop();

				if (node.left != null)
				{
					if (node.left.left == null && node.left.right == null) ans += node.left.val;

					else stack.Push(node.left);


				}
				else if (node.right != null)
				{
					if (node.right.left != null || node.right.right != null) stack.Push(node.right);
				}
			}
			return ans;
		}

		public static int CheckHeight(TreeNode root)
		{
			if (root == null)
			{
				return -1;
			}
			int leftHeight = CheckHeight(root.left);
			if (leftHeight == int.MinValue) return int.MinValue; // Propagate error up

			int rightHeight = CheckHeight(root.right);
			if (rightHeight == int.MinValue) return int.MinValue; // Propagate error up

			int heightDiff = leftHeight - rightHeight;
			if (Math.Abs(heightDiff) > 1)
			{
				return int.MinValue; // Found error -> pass it back
			}

			return Math.Max(leftHeight, rightHeight) + 1;

		}

		public static bool isBalanced(TreeNode root)
		{
			return CheckHeight(root) != int.MinValue;
		}

		public static int MaxDepth(Node root)
		{
			if (root == null) return 0;
			return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
		}

		public static int MinDepth(Node root)
		{
			if (root == null) return 0;
			return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
		}

		// balanced tree if the min depth and max depth difference doesn't exceed 1
		public static bool IsBalance(Node root)
		{
			return (MaxDepth(root) - MinDepth(root) <= 1);
		}


		public static bool AreIdentical(TreeNode root1, TreeNode root2)
		{
			if (root1 == null && root2 == null)
				return true;

			if (root1 != null && root2 != null)
			{
				return ((root1.val == root2.val) &&
						AreIdentical(root1.left, root2.left)
						&& AreIdentical(root1.right, root2.right));
			}
			return false;
		}

		public static bool IsBalanced(TreeNode root)
		{
			if (root == null) return true;
			int depth = Depth(root);
			if (depth == -1) return false;
			else return true;
		}
		private static int Depth(TreeNode root)
		{
			if (root == null) return 0;
			int left = Depth(root.left);
			int right = Depth(root.right);
			if (left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;
			return Math.Max(left, right) + 1;
		}

		public static TreeNode TreeMin_Rec(TreeNode root)
		{
			TreeNode current = root;
			if (current.left == null)
			{
				return current;
			}
			return TreeMin_Rec(current.left);
		}

		public static Node TreeMin_Rec(Node root)
		{
			Node current = root;
			if (current.left == null)
			{
				return current;
			}
			return TreeMin_Rec(current.left);
		}
		public static TreeNode TreeMax_Rec(TreeNode root)
		{
			TreeNode current = root;
			if (current.right == null)
			{
				return current;
			}
			return TreeMax_Rec(current.right);
		}

		public static Node TreeMax_Rec(Node root)
		{
			Node current = root;
			if (current.right == null)
			{
				return current;
			}
			return TreeMax_Rec(current.right);
		}
		public static Boolean HasPathSum(Node node, int sum)
		{
			if (node == null) return (sum == 0);

			else
			{
				int subSum = sum - node.value;
				return (HasPathSum(node.left, subSum) || HasPathSum(node.right, subSum));
			}
		}

		public static void PrintPaths(Node root)
		{
			int[] path = new int[1000];
			PrintPaths(root, path, 0);
		}

		public static void PrintPaths(Node node, int[] path, int pathLength)
		{
			if (node == null) return;

			// append this node to the path array
			path[pathLength] = node.value;
			pathLength++;

			// its a leaf, so print the path that led here
			if (node.left == null && node.right == null)
			{
				PrintArray(path, pathLength);
			}
			else
			{
				//otherwise try both subtrees
				PrintPaths(node.left, path, pathLength);
				PrintPaths(node.right, path, pathLength);
			}
		}

		private static void PrintArray(int[] path, int pathLeghth)
		{
			foreach (int i in path)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
		}

		/*Given a sorted (increasing order) array, write an algorithm 
		 * to create a binary tree with minimal height*/
		public static Node AddToTree(int[] arr, int start, int end)
		{
			if (end < start) return null;

			int mid = (start + end) / 2;
			Node n = new Node(arr[mid]);
			n.left = AddToTree(arr, start, mid - 1);
			n.right = AddToTree(arr, mid + 1, end);
			return n;
		}

		public static Node CreateMinimalBST(int[] array)
		{
			return AddToTree(array, 0, array.Length - 1);
		}


		/*Given a binary search tree, design an algorithm which creates
		 * a linked list of all the nodes at each depth (eg, if you have a
		 * tree with depth D, you’ll have D linked lists)*/
		public static List<LinkedList<TreeNode>> FindLevelLinkList(TreeNode root)
		{

			int level = 0;
			List<LinkedList<TreeNode>> result = new List<LinkedList<TreeNode>>();
			LinkedList<TreeNode> list = new LinkedList<TreeNode>();


			// Add root to list for first level
			list.AddLast(root);
			result[level] = list;
			while (true)
			{
				list = new LinkedList<TreeNode>();

				for (int i = 0; i < result[level].Count; i++)
				{

					// grab from linked list ie stack
					TreeNode n = result[level].ElementAt(i);
					if (n != null)
					{
						if (n.left != null) list.AddLast(n.left);
						if (n.right != null) list.AddLast(n.right);
					}
				}
				if (list.Count > 0)
				{
					result[level + 1] = list;
				}
				else
				{
					break;
				}
				level++;
			}
			return result;
		}

		// Path Sum III

		public static int PathSum(TreeNode root, int sum)
		{
			if (root == null) return 0;
			return PathSum(root, sum) + pathSumFrom(root.left, sum) + pathSumFrom(root.right, sum);
		}

		public static int pathSumFrom(TreeNode node, int sum)
		{
			if (node == null) return 0;
			return (node.val == sum ? 1 : 0) + pathSumFrom(node.left, sum - node.val) + pathSumFrom(node.right, sum - node.val);
		}



		public static void PreOrder_Rec(Node root)
		{
			if (root != null)
			{
				Console.Write(root.value + " ");
				PreOrder_Rec(root.left);
				PreOrder_Rec(root.right);
			}
		}

		public static void preorderTraversal(Node root)
		{
			Stack<Node> stack = new Stack<Node>();
			stack.Push(root);
			while (stack.Count > 0)
			{
				Node curr = stack.Pop();
				Console.Write(curr.value);
				Node n = curr.right;
				if (n != null) stack.Push(n);
				n = curr.left;
				if (n != null) stack.Push(n);
			}
		}

		public static void InOrder_Rec(Node root)
		{
			if (root != null)
			{
				InOrder_Rec(root.left);
				Console.Write(root.value + " ");
				InOrder_Rec(root.right);
			}
		}

		public static void InOrderTraversal(TreeNode root)
		{

			if (root == null) return;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);
			while (stack.Count > 0 && root != null)
			{
				if (root != null)
				{
					stack.Push(root);
					root = root.left;
					continue;
				}
			}
			Console.Write(stack.Peek().val + " ");
			root = stack.Pop().right;
		}


		public static void InOrderTraversal2(TreeNode root)
		{

			if (root == null) return;

			Stack<TreeNode> stack = new Stack<TreeNode>();

			while (true)
			{
				if (root != null)
				{
					stack.Push(root);
					root = root.left;
				}
				else
				{
					if (stack.Count() == 0) break;
					root = stack.Pop();
					Console.Write(root.val);
					root = root.right;
				}
			}
		}

		// O(Logn)
		// Space O (1)
		public static TreeNode InOrderSuccessorBST(TreeNode root, int d)
		{
			if (root == null) return null;

			TreeNode successor = null;

			while (root != null)
			{

				if (root.val < d)
				{
					root = root.right;
				}
				else if (root.val > d)
				{
					successor = root;
					root = root.left;
				}
				else
				{
					if (root.right != null)
					{
						successor = TreeMin_Rec(root.right);
					}
					break;

				}

			}
			return successor;
		}

		public static TreeNode InOrderSuccessor2(TreeNode root)
		{
			if (root != null)
			{
				TreeNode successor;

				// Found right children -> return 1st inorder node on right
				if (root.parent == null || root.right != null)
				{
					successor = TreeMin_Rec(root.right);
				}
				else
				{
					// go up until we're on left instead of right
					while ((successor = root.parent) != null)
					{
						if (successor.left == root)
						{
							break;
						}
						root = successor;
					}
				}
				return successor;
			}
			return null;
		}


		public static void PostOrder_Rec(Node root)
		{
			if (root != null)
			{
				PostOrder_Rec(root.left);
				PostOrder_Rec(root.right);
				Console.Write(root.value + " ");
			}
		}

		public static void PostOrderTraversal(TreeNode root)
		{

			TreeNode current = root;
			Stack<TreeNode> stack = new Stack<TreeNode>();

			while (current != null || stack.Count > 0)
			{
				if (current != null)
				{
					stack.Push(current);
					current = current.left;
				}
				else
				{
					TreeNode temp = stack.Peek().right;
					if (temp == null)
					{
						temp = stack.Pop();
						Console.Write(temp.val + " ");
						while (stack.Count > 0 && temp == stack.Peek().right)
						{
							temp = stack.Pop();
							Console.Write(temp.val + " ");
						}
					}
					else
					{
						current = temp;
					}
				}
			}
		}

		public static void InsertNode(Node root, int val)
		{
			Node newNode = new Node(val);

			if (root.value == 0) //First node insertion  
				root = newNode;
			else
			{
				Node current = root;
				while (true)
				{
					Node tempParent = current;
					if ((newNode.value) < (current.value))
					{
						current = current.left;
						if (current == null)
						{
							tempParent.left = newNode;
							newNode.parent = tempParent;
							return;
						}
					}
					else
					{
						current = current.right;
						if (current == null)
						{
							tempParent.right = newNode;
							newNode.right = tempParent;
							return;
						}
					}
				}
			}
		}

		public static void DeleteNode(int data)
		{
			Node tempDelete = new Node(data);
			if (tempDelete != null)
			{
				Node tempParent, tempChild, predecessorNode;

				if ((tempDelete.left == null) && (tempDelete.right == null)) //Its a Leaf node
				{
					tempParent = tempDelete.parent;
					if (tempDelete == tempParent.left) //Justremove by making it null
						tempParent.left = null;
					else
						tempParent.left = null;
				}
				else if ((tempDelete.left == null) || (tempDelete.right == null)) //It has either Left orRight child
				{
					tempChild = tempDelete.left ?? tempDelete.right; //Get the child
					tempParent = tempDelete.parent; //Getthe parent
					if (tempDelete == tempParent.left)
						//Makeparent points to it's child so it will automatically deleted like Linked list
						tempParent.left = tempChild;
					else
						tempParent.right = tempChild;
				}
				else if ((tempDelete.left != null) || (tempDelete.right != null)) //It has both Left andRight child
				{
					predecessorNode = TreePredecessor_Ite(tempDelete); //Findit's predecessor
					if (predecessorNode.left != null)
					// Predecessor node canhave no or left child. Do below two steps only if it has left child
					{
						tempChild = predecessorNode.left;
						predecessorNode.parent.right = tempChild; //Assignleft child of predecessor to it's Parent's right.
					}
					tempDelete.value = predecessorNode.value;
					//Replace the value of predecessor node with the value of to be deleted node                 
				}
			}
		}

		///C# code to delete a node from the tree
		// Perform a search until you find the node you want to delete
		// When you do 

		public static void delete(Node Tree, int Tar)
		{

			Node Min, Temp;
			if (Tree == null) { return; }

			else if (Tar < Tree.value) delete(Tree.left, Tar);//look in the left
			else if (Tar > Tree.value) delete(Tree.right, Tar);//look in the right
			else
			{ //found node to delete

				if (Tree.left != null && Tree.right != null) //two children
				{
					Min = TreeMin_Rec(Tree.right);
					Tree.value = Min.value;
					delete(Tree.right, Tree.value);

				}
				else
				{ //one or zero child
					Node root;
					if (Tree.left == null)
					{
						if (Tree.parent == null) root = Tree.right; //The root node is to be deleted.
						else
						{

							if (Tree.right != null)
							{
								Tree.right.parent = Tree.parent;
							}

							if (Tree == Tree.parent.left)
								Tree.parent.left = Tree.right;
							else Tree.parent.right = Tree.right;
						}
					}
					else if (Tree.right == null)
					{
						if (Tree.parent == null) root = Tree.left;

						else
						{

							Tree.left.parent = Tree.parent;
							if (Tree == Tree.parent.left)
								Tree.parent.left = Tree.left;
							else Tree.parent.right = Tree.left;
						}
					}
				}
			}
		}


		public static Node Delete(Node root, int data)
		{

			if (root == null) return root;
			else if (data < root.value) root.left = Delete(root.left, data);
			else if (data > root.value) root.right = Delete(root.right, data);
			else // Found item to be delete
			{

				// Case 1 No Child
				if (root.left == null && root.right == null)
				{
					//delete root;
					root = null;

					// Case 2  One Child    
				}
				else if (root.left == null)
				{
					Node temp = root;
					root = root.right;

				}
				else if (root.right == null)
				{
					Node temp = root;
					root = root.left;
				}
				else
				{ // Case 3 2 Children
					Node temp = TreeMin_Rec(root.right);
					root.value = temp.value;
					root.right = Delete(root.right, temp.value);
				}
			}
			return root;
		}


		public static Node findNode(Node root, int value)
		{
			while (root != null)
			{
				int currval = root.value;
				if (currval == value) break;
				root = currval < value ? root.right : root.left;
			}

			return root;
		}


		public static Node search(Node node, int key)
		{
			if (node == null) return null;

			if (node.value == key)
				return node;

			if (key < node.value)
				return search(node.left, key);
			else
				return search(node.right, key);
		}



		public static Node TreeSuccessor_Ite(Node node)
		{
			////Get the Node object for an element
			Node current = node;
			if (current != null)
			{
				if (current.right != null)
					return TreeMin_Rec(current.right);
				else
				{
					Node tempParent = current.parent;
					while ((tempParent != null) && (current == tempParent.right))
					{
						current = tempParent;
						tempParent = tempParent.parent;
					}
					if (tempParent != null)
						return tempParent;
				}
			}
			return null;
		}

		public static Node TreePredecessor_Ite(Node node)
		{
			////Get the Node object for an element
			Node current = node;
			if (current != null)
			{
				if (current.left != null)
					return TreeMax_Rec(current.left);
				else
				{
					Node tempParent = current.parent;
					while ((tempParent != null) && (current == tempParent.left))
					{
						current = tempParent;
						tempParent = tempParent.parent;
					}
					if (tempParent != null)
						return tempParent;

				}
			}
			return null;
		}
		// Iterative DFS
		public static void dfs(TreeNode root)
		{
			if (root == null) return;
			Stack<TreeNode> res = new Stack<TreeNode>();
			res.Push(root);
			while (res.Count > 0)
			{
				TreeNode top = res.Pop();
				Console.Write(top.val + " ");
				if (top.right != null)
					res.Push(top.right);
				if (top.left != null)
					res.Push(top.left);
			}
		}
		// Recursive DFS
		public static void dfsRec(TreeNode root)
		{
			if (root == null) return;
			Stack<TreeNode> res = new Stack<TreeNode>();
			res.Push(root);
			while (res.Count > 0)
			{
				TreeNode top = res.Pop();
				Console.Write(top.val + " ");
				if (top.right != null)
					res.Push(top.right);
				if (top.left != null)
					res.Push(top.left);
			}
		}

		public static string Serialize(TreeNode root)
		{
			StringBuilder sb = new StringBuilder();
			Stack<TreeNode> stack = new Stack<TreeNode>();

			if (root == null) return null;

			stack.Push(root);
			while (stack.Count > 0)
			{
				TreeNode node = stack.Pop();
				sb.Append(node.val).Append(",");
				if (root.right != null) stack.Push(root.right);
				if (root.left != null) stack.Push(root.left);
			}
			return sb.ToString();
		}

		public static TreeNode DeSerialize(string s)
		{
			if (string.IsNullOrEmpty(s)) return null;
			Queue<int> queue = new Queue<int>();
			string[] nodeVals = s.Split(',');

			foreach (var ss in nodeVals)
			{
				queue.Enqueue(Convert.ToInt32(ss));
			}

			return GetNode(queue);

		}

		private static TreeNode GetNode(Queue<int> queue)
		{
			if (queue.Count == 0) return null;
			Queue<int> smallQueue = new Queue<int>();
			TreeNode root = new TreeNode(queue.Dequeue());
			while (queue.Count > 0 && queue.Peek() < root.val)
			{
				smallQueue.Enqueue(queue.Dequeue());
			}
			root.left = GetNode(smallQueue);
			root.right = GetNode(queue);
			return root;
		}


		public static TreeNode ArrayToTree(int[] array)
		{

			if (array.Length <= 0) return null;


			return ArrayToTreeHelper(array, 0, array.Length - 1);
		}

		private static TreeNode ArrayToTreeHelper(int[] array, int low, int high)
		{
			if (low > high) return null;
			int mid = (low + high) / 2;

			TreeNode node = new TreeNode(array[mid]);
			node.left = ArrayToTreeHelper(array, low, mid - 1);
			node.right = ArrayToTreeHelper(array, mid + 1, high);
			return node;
		}


		/*Given a binary tree, find its minimum depth.
		 * The minimum depth is the number of nodes along the shortest path 
		 * from the root node down to the nearest leaf node.*/
		public static int MinDepth(TreeNode root)
		{
			if (root == null) return 0;
			if (root.left == null) return MinDepth(root.right) + 1;
			if (root.right == null) return MinDepth(root.left) + 1;
			return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;

		}


		/**
		 * Given two nodes of a tree,
		 * method should return the deepest common ancestor of those nodes.
		 *
		 *          A        
		 *         / \        
		 *        B   C     
		 *       / \
		 *      D   E
		 *         / \
		 *        G   F
		 *
		 *  commonAncestor(D, F) = B
		 *  commonAncestor(C, G) = A
		 *  commonAncestor(E, B) = B
		 */
		/*Given a binary search tree (BST), find the lowest common ancestor (LCA) of two 
		 * given nodes in the BST.
		T that has both v and w as descendants (where we allow a node to be a descendant of itself).”
		the lowest common ancestor (LCA) of nodes 2 and 8 is 6. Another example is LCA of nodes 2 and 4 is 2*/
		public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{

			if (root.val > p.val && root.val > q.val)
			{
				return LowestCommonAncestor(root.left, p, q);
			}
			else if (root.val < p.val && root.val < q.val)
			{
				return LowestCommonAncestor(root.right, p, q);
			}
			else
			{
				return root;
			}
		}

		// No Root node
		public static TreeNode CommonAncestor(TreeNode one, TreeNode two)
		{
			HashSet<TreeNode> node1Ancestors = new HashSet<TreeNode>();
			for (TreeNode n1 = one; n1 != null; n1 = n1.parent)
			{
				node1Ancestors.Add(n1);
			}

			for (TreeNode n2 = two; n2 != null; n2 = n2.parent)
			{
				if (node1Ancestors.Contains(n2))
				{
					return n2;
				}
			}
			return null; // only if no common ancestor (input nodes are in disjoint trees)
		}


		public static IList<string> BinaryTreePaths(TreeNode root)
		{
			List<string> list = new List<string>();
			Helper(list, root, new StringBuilder());
			return list;
		}

		private static void Helper(List<string> list, TreeNode node, StringBuilder sb)
		{
			if (node == null)
				return;

			sb.Append(node.val);

			if (node.left == null && node.right == null)
			{
				list.Add(sb.ToString());
			}

			if (node.left != null)
			{
				sb.Append("->");
				Helper(list, node.left, sb);
				sb.Length -= node.left.val.ToString().Length + 2;
			}

			if (node.right != null)
			{
				sb.Append("->");
				Helper(list, node.right, sb);
				sb.Length -= node.right.val.ToString().Length + 2;
			}
		}

		public static IList<string> BinaryTreePaths2(TreeNode root)
		{

			List<string> paths = new List<string>();

			if (root == null) return paths;

			if (root.left == null && root.right == null)
			{
				paths.Add(root.val + "");
				return paths;
			}

			foreach (string path in BinaryTreePaths2(root.left))
			{
				paths.Add(root.val + "->" + path);
			}

			foreach (string path in BinaryTreePaths2(root.right))
			{
				paths.Add(root.val + "->" + path);
			}

			return paths;

		}

		/*Given a binary tree, return the bottom-up level order traversal of
		 * its nodes' values. (ie, from left to right, level by level from leaf to root).
		 * 
		 *  3
		   / \
		  9  20
		    /  \
		   15   7

		[
		  [15,7],
		  [9,20],
		  [3]
		]

		*/
		public static IList<IList<int>> LevelOrderBottom(TreeNode root)
		{
			IList<IList<int>> lists = new List<IList<int>>();
			Level(lists, root, 0);
			return lists.Reverse().ToList();
		}

		public static void Level(IList<IList<int>> lists, TreeNode node, int level)
		{
			if (node == null) return;
			if (lists.Count == level) lists.Add(new List<int>());
			lists[level].Add(node.val);
			Level(lists, node.left, level + 1);
			Level(lists, node.right, level + 1);
		}

		public static Boolean HasPathSum(TreeNode root, int sum)
		{

			if (root == null) return false;

			if (root.left == null && root.right == null && sum - root.val == 0) return true;

			return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
		}

		//public IList<IList<int>> PathSum(TreeNode root, int sum)
		//{
		//    List<List<int>> paths = new List<List<int>>();
		//    List<int> currPath = new List<int>();
		//    Helper(root, paths, currPath, sum);
		//    return paths;
		//}

		//private void Helper(TreeNode root, List<List<int>> paths, List<int> currPath, int sum)
		//{

		//    if (root == null) return;

		//    currPath.Add(root.val);

		//    if (root.left == null && root.right == null && sum == root.val)
		//    {
		//        paths.Add(new List<int>(currPaths));
		//        currPaths.Remove(currPaths.Count - 1);
		//        return;
		//    }
		//    else
		//    {
		//        Helper(root.left, paths, currPath, sum);
		//        Helper(root.right, paths, currPath, sum);
		//    }
		//    currPaths.Remove(currPaths.Count - 1);
		//}

		public class InOrderTraversalIterator
		{
			Stack<TreeNode> stack = new Stack<TreeNode>();

			public InOrderTraversalIterator(TreeNode root)
			{
				while (root != null)
				{
					stack.Push(root);
					root = root.left;
				}
			}

			public bool HasNext()
			{
				return stack.Count() > 0;
			}

			public TreeNode GetNext()
			{
				if (stack.Count() == 0) return null;

				TreeNode curr = stack.Pop();
				TreeNode temp = curr.right;
				while (temp != null)
				{
					stack.Push(temp);
					temp = temp.left;
				}

				return curr;
			}
		}

		public static TreeNode UpsideDownBinaryTree(TreeNode root)
		{
			if (root == null || root.left == null)
			{
				return root;
			}

			TreeNode newRoot = UpsideDownBinaryTree(root.left);
			root.left.left = root.right;   // node 2 left children
			root.left.right = root;         // node 2 right children
			root.left = null;
			root.right = null;
			return newRoot;
		}

		public static bool isSymmetric(TreeNode root)
		{
			return isMirror(root, root);
		}

		public static bool isMirror(TreeNode t1, TreeNode t2)
		{
			if (t1 == null && t2 == null) return true;
			if (t1 == null || t2 == null) return false;
			return (t1.val == t2.val)
				&& isMirror(t1.right, t2.left)
				&& isMirror(t1.left, t2.right);
		}

		public static List<IList<int>> FindLeave(TreeNode root)
		{
			List<IList<int>> result = new List<IList<int>>();
			Height(root, result);
			return result;
		}

		public static int Height(TreeNode node, List<IList<int>> result)
		{
			if (null == node) return -1;

			// Get Height
			int level = 1 + Math.Max(Height(node.left, result), Height(node.right, result));


			if (result.Count < level + 1) result.Add(new List<int>());

			// add value to level node
			result[level].Add(node.val);

			return level;
		}
	}
}
