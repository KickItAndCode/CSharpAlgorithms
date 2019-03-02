public class BinaryTree
{
    public int Value;
    public BinaryTree Left { get; set; }
    public BinaryTree Right { get; set; }
} 


public bool BreadthFirstSearch(BinaryTree node, int searchFor)
{
    Queue<BinaryTree> queue = new Queue<BinaryTree>();

    queue.Enqueue(node);

    int count = 0;

    while (queue.Count > 0)
    {
        BinaryTree current = queue.Dequeue();

        if (current == null)
            continue;
        queue.Enqueue(current.Left);
        queue.Enqueue(current.Right);

        if (current.Value == searchFor)
            return true;
    }

    return false;
}

public bool DepthFirstSearch(BinaryTree node, int searchFor)
{

    if (node == null)
        return false;

    if (node.Value == searchFor)

        return true;

    return DepthFirstSearch(node.Left, searchFor)

        || DepthFirstSearch(node.Right, searchFor);

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

public static List<string> Permutations(string str)
{
    // Each permutation is stored in a List of strings
    var result = new List<string>();

    // The base case...
    if (str.Length == 1)

        result.Add(str);

    else

        // For each character in the string...
        for (int i = 0; i < str.Length; i++)

            // For each permutation of everything else...
            foreach (var p in Permutations(EverythingElse(str, i)))

                // Add the current char + each permutation
                result.Add(str[i] + p);

    return result;
}

// Return everything in a string except the char at IndexToIgnore
private static string EverythingElse(string str, int IndexToIgnore)
{
    StringBuilder result = new StringBuilder();

    for (int j = 0; j < str.Length; j++)
        if (IndexToIgnore != j)
            result.Append(str[j]);

    return result.ToString();
}

public static List<int> GeneratePrimes(int n ){

var primes = new List<int>();

    int nextCandidatePrime = 2;

    primes.Add(nextCandidatePrime);

    while (primes.Count < n)
    {
        if (isPrime (nextCandidatePrime))
            primes.Add(nextCandidatePrime);

        nextCandidatePrime += 1;
    }
    return primes;
} 

private static bool isPrime (int n)
{
    for (int i = 2; i < n; i++)
    {
        if (n % i == 0)
            return false;
    }
    return true;
}

// More optimised approached based on the fact that you don't need to go further then n^2
private static bool isPrime(int n)
{
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0)
            return false;
    }
    return true;
}

// Then optimise by removing even numbers because they aren't prime 
// No multiples of 2
private static bool isPrime(int n)
{
    if (n % 2 == 0) return false;
    for (int i = 3; i <= Math.Sqrt(n); i += 2)
    {
        if (n % i == 0)
            return false;
    }
    return true;
}

// Super optimized
public static List<int> GeneratePrimesOptimized(int n)
{
    var primes = new List<int>();

    // Prime our list of primes
    primes.Add(2);
            
    // Start from 3, since we already know 2 is a prime
    int nextCandidatePrime = 3;

    // Keep going until we have generated n primes
    while (primes.Count < n)
    {
        // Assume the number is prime
        bool isPrime = true;

        // Test if the candidate is evenly divisible
        // by any of the primes up to sqrt(candidate)
        for (int i = 0; 
             primes[i] <= Math.Sqrt(nextCandidatePrime); 
             i++)
        {
            if (nextCandidatePrime % primes[i] == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            primes.Add(nextCandidatePrime);
                
        // We proceed in steps of 2, avoiding the even numbers
        nextCandidatePrime += 2;
    }
    return primes;
}


