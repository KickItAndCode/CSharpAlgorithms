public class BinaryTree
{
    public int Value;
    public BinaryTree Left { get; set; }
    public BinaryTree Right { get; set; }
} 



public bool DepthFirstSearchIterative(BinaryTree node, int searchFor)
{

    Stack<BinaryTree> nodeStack = new Stack<BinaryTree>();

    nodeStack.Push(node);

    while (nodeStack.Count > 0)
    {
        BinaryTree current = nodeStack.Pop();

        if (current.Value == searchFor)
            return true;

        if (current.Right != null)
            nodeStack.Push(current.Right);

        if (current.Left != null)
            nodeStack.Push(current.Left);
    }

    return false;
}