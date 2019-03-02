//Binary Search Tree Questions
// Search, Insertion, Deletion is O(Log(n)) very fast
// Print in order is O(n)
// Given a node you can find the next highest node in O(log(n)) time
// When Searching a tree that isn't ordered the lookup is O(n)
// log 2(1000000000) = 30 
// If each Node only has one child lookup is O(n) and 
//is basically a linked list

public class Node {
	public int value;
	public Node left, right;

	public Node (int value){
		this.value = value;
		left = null;
		right = null;
	}
}

#region Is Balanced 
// Max Depth
public static int MaxDepth (Node root){
    if (root == null) return 0;
    return 1 + Math.Max( MaxDepth(root.left), MaxDepth(root.right));
}

public static int MinDepth(Node root){
    if (root == null) return 0;
    return 1. + Math.Min(MinDepth(root.left), MinDepth(root.right));
}

// balanced tree if the min depth and max depth difference doesn't exceed 1
public static bool IsBalance (Node root){
    return (MaxDepth(root) - MinDepth(root) <= 1);
}
#endregion

#region Created BST with min height
public static Node AddToTree(int arr[], int start, int end){
    if (end  < start) return null;

    int mid = (start + end) / 2;
    Node n = new Node(arr[mid]);
    n.left = AddToTree(arr, start, mid- 1);
    n.right = AddToTree(arr, mid+1, end);
    return n;
}

public static Node CreateMinimalBST (int array[]){
    return AddToTree(array, 0, array.length -1);
} 

#endregion

#region Given a BST your algorithm should create a linked list of all elements at each depth
List<LinkedList<Node>> FindLevelLinkedList (Node root){
    List<LinkedList<Node>> results = new List<LinkedList<Node>>();
    LinkedList<Node> list = new LinkedList<Node>();
    int level = 0;
    list.add(root);
    results.add(level, list);

    while (true){
        // create a new list check for null and add left and right nodes to the new list for the level below
        list = new LinkedList<node>();
        for (int i = 0; i< results[level].count; i++){
            Node n = (Node) results[level].find(i);
            if (n != null){
                if (n.left != null) list.add(n.left);
                if (n.right != null) list.add(n.right);
            }
        }
        if (list.count > 0){
            results.
        }
    }


}
#endregion

public void PreOrder_Rec (Node root)
{
    if (root != null)
    {
        Console.Write(root.Data + " ");
        PreOrder_Rec(root.Left);
        PreOrder_Rec(root.Right);
    }
}

public void preorderTraversal( Node root ){
    NodeStack stack = new NodeStack();
    stack.push( root );
    while( stack.size() > 0 ){
        Node curr = stack.pop();
        curr.printValue();
        Node n = curr.getRight();
        if( n != null ) stack.push( n );
        n = curr.getLeft();
        if( n != null ) stack.push( n );
    }
}

public void InOrder_Rec(Node root)
{
    if (root != null)
     {
          InOrder_Rec(root.Left);
          Console.Write(root.Data + " ");
          InOrder_Rec(root.Right);
    }
}

public void PostOrder_Rec(Node root)
{
    if (root != null)
   {
         PostOrder_Rec(root.Left);
         PostOrder_Rec(root.Right);
         Console.Write(root.Data + " ");
   }
}

public void InsertNode (int val)
{
    TNode newNode = new TNode(val);
 
    if (root.val == null) //First node insertion  
        root = newNode;       
    else
    {
       current = root;
       while (true)
       {
           tempParent = current;
           if ((newNode.val) < (current.val))
           {
               current = current.Left;
               if(current== null)
               {
                    tempParent.Left =newNode;
                    newNode.Parent =tempParent;
                    return;
                }
           }
           else
           {
               current = current.Right;
               if(current == null)
               {
                    tempParent.Right= newNode;
                    newNode.Parent =tempParent;
                    return;
               }
           }
        }
    }
}

public object DeleteNode (object data)
{
     TNode tempDelete = this.GetNode(data);
     if (tempDelete != null)
     {
        if ((tempDelete.Left == null ) &&(tempDelete.Right == null)) //Its a Leaf node
        {
           tempParent = tempDelete.Parent;
           if(tempDelete == tempParent.Left) //Justremove by making it null
               tempParent.Left = null;
           else
               tempParent.Right = null;
        }
        else if ((tempDelete.Left == null ) ||(tempDelete.Right == null)) //It has either Left orRight child
        {
           tempChild = tempDelete.Left == null? tempDelete.Right : tempDelete.Left; //Get the child
           tempParent = tempDelete.Parent; //Getthe parent
           if(tempDelete == tempParent.Left) //Makeparent points to it's child so it will automatically deleted like Linked list
               tempParent.Left = tempChild;
           else
               tempParent.Right = tempChild;
          }
          else if ((tempDelete.Left != null) ||(tempDelete.Right != null)) //It has both Left andRight child
         {
            TNodepredNode = this.GetNode(this.TreePredecessor_Ite(data));  //Findit's predecessor
            if(predNode.Left != null) // Predecessor node canhave no or left child. Do below two steps only if it has left child
            {
                 tempChild = predNode.Left;
                 predNode.Parent.Right = tempChild; //Assignleft child of predecessor to it's Parent's right.
             }
             tempDelete.Data = predNode.Data; //Replace the value of predecessor nodeto the value of to be deleted node
                   //predNode = null; //Remove predecessornode as it's no longer required.
         }
 
         return data + " Deleted";
     }
     else
          return "Please enter the valid tree element!";
}

///C# code to delete a node from the tree
// Perform a search until you find the node you want to delete
// When you do 

public void delete (TreeNode Tree,int Tar)
{

	TreeNode Min,Temp; 
	if(Tree==null) {return;} 

	else if(Tar<Tree.data) delete(Tree.left,Tar);//look in the left
	else if(Tar>Tree.data) delete(Tree.right, Tar);//look in the right
	else{ //found node to delete

	   if(Tree.left!=null && Tree.right!=null) //two children
	   {
	    Min=findmin(Tree.right);
	    Tree.data=Min.data; 
	    delete(Tree.right,Tree.data);

		}
	   else
	   { //one or zero child

		     if(Tree.left==null) 
		    {
			     if(Tree.parent==null) Root=Tree.right; //The root node is to be deleted.
			     else{

				     if(Tree.right!=null){
				     Tree.right.parent=Tree.parent; 
				     } 

					 if(Tree==Tree.parent.left) 
					     Tree.parent.left=Tree.right;
					 else Tree.parent.right=Tree.right;
		    } 
	    }
	   else if(Tree.right==null) 
	    {
	     if(Tree.parent==null) Root=Tree.left;

	      else{

	       Tree.left.parent=Tree.parent;
	       if(Tree==Tree.parent.left)
	          Tree.parent.left=Tree.left;
	       else Tree.parent.right=Tree.left; 
	               } 
	        }
	    }
	  }
}

public Node findNode( Node root, int value ){
    while( root != null ){
        int currval = root.getValue();
        if( currval == value ) break;
        if( currval < value ){
            root = root.right;
        } else { // currval > value
            root = root.left;
        }
    }

    return root;
}


public Node search (Node node, int key) {
   if (node == null) return null;

   if (node.value == key)
      return node

   if (key < node) 
      return search (node.left, key);
   else
      return search (node.right, key);
}

public Node TreeMin_Rec(Node root)
    {
       current = root;
        if (current.Left == null)
        {
            return current.value;
        }
        returnTreeMin_Rec(current.Left);
   }
public Node TreeMax_Rec(Node root)
    {
       current = root;
        if (current.Right == null)
        {
            return current.value;
        }
        returnTreeMax_Rec(current.Right);
   }

public Node TreeSuccessor_Ite(Node node)
    {
       ////Get the Node object for an element
       current = node
        if (current!=null)
        {
            if (current.Right!= null)
               return this.TreeMin_Rec(current.Right);               
            else
            {
               tempParent = current.Parent;
               while((tempParent != null) && (current == tempParent.Right))
               {
                   current = tempParent;
                   tempParent = tempParent.Parent;
               }
               if(tempParent != null)
                   returnt tempParent;
               else
                   return "Successor is not found!";
            }
        }
        else
        {
            return "Please enter the valid tree element!";
        }
   }

   public Node TreePredecessor_Ite(Node node)
        {
            ////Get the Node object for an element
           current = node;
            if (current != null)
            {
                if (current.Left != null)
                    return this.TreeMax_Rec(current.Left);           
                else
                {
                   tempParent = current.Parent;
                   while((tempParent != null) && (current == tempParent.Left))
                   {
                        current = tempParent;
                       tempParent = tempParent.Parent;
                   }
                   if(tempParent != null)
                       return tempParent;
                   else                  
                       return"Predecessor is not found!";
                }
            }
            else
            {
                return "Please enter the valid tree element!";
            }
       }
}
// Iterative DFS
public static void dfs(TreeNode root){
        if(root == null)    return;
        Stack<TreeNode> res = new Stack<TreeNode>();
        res.push(root);
        while(!res.isEmpty()){
            TreeNode top = res.pop();
            System.out.print(top.val + " ");
            if(top.right != null)
                res.push(top.right);
            if(top.left!= null)
                res.push(top.left);
        }
    }
// Recursive DFS
    public static void dfs(TreeNode root){
        if(root == null)    return;
        Stack<TreeNode> res = new Stack<TreeNode>();
        res.push(root);
        while(!res.isEmpty()){
            TreeNode top = res.pop();
            System.out.print(top.val + " ");
            if(top.right != null)
                res.push(top.right);
            if(top.left!= null)
                res.push(top.left);
        }
    }


public Node Delete (Node root, int data){
    
    if (root == null) return root;
    else if (data < root.data) root.left = Delete(root.left,data)
    else if (data > root.data) root.right = Delete(root.right, data)
    else // Found item to be delete
    {

    // Case 1 No Child
    if (root.left == null && root.right == null){
        //delete root;
        root = null;
        
    // Case 2  One Child    
    }else if (root.left == null){
        Node temp = root;
        root = root.right;
        
    }else if (root.right == null){
        Node temp = root;
        root = root.left;
    }else { // Case 3 2 Children
        Node temp = FindMin(root.right);
        root.data = temp.data;
        root.right = Delete(root.right, temp.data);
    }
    }
    return root;
}