// Delete Node from linked list

public Node deleteNode(Node head, int d){
       Node node = head;
       if(node.data == d)
          return head.next;

       while(node.next! = null){
            if(node.next.data == d){
                node.next = node.next.next;
                return head;
            }
            node = node.next;
       }
  }

  // write a function that deletes and returns the last link of a linked list
  public Node deleteLast(){

      /* If the list is empty, function returns null */
      if(first == null)
          return null;

      else{
          Node current = first;
          Node previous = null;
          while(current.next! = null){
                previous = current;
                current = current.next;
          }

          /* If the list has one element, update 'first' */
          if(previous == null)
                first = null;
          else
                previous.next = null;
      }

      return current;   
  }

  // Detect a loop in linked list
  /*Create two references - slowslow and fastfast. 
Start from the beginning of the list. slowslow hops one node while fastfast hops two.
If they meet, loop is found.*/
public boolean  hasLoop(Node first){

      /* Linked List doesn't exist - so no loop */
      if(first == null)
          return false;

      /* Create two reference */
      Node slow, fast;

      /* Both start from the beginning of the Linked List */
      slow = fast = first;
      while(true){
          /* One hop */
          slow = slow.next;
          if(fast.next! = null)
              /* Two hops */
              fast = fast.next.next;
          else
              return false;

          /* If slow or fast either hits null - no loop */
          if(slow == null || fast == null)
              return false;

          /* if slow and fast meet - Bingo! loop found */
          if(slow == fast)
              return true;
      }
  }

  // Remove duplicates in unsorted linked list
  public static void deleteDuplicate(LinkedListNode node){

      Hashtable table = new Hashtable();
      LinkedListNode previous = null;

      while(node! = null){
          if(table.containsKey(node.data))
              previous.next = node.next;
          else{
              table.put(node.data, true);
              previous = n;
          }

          node = node.next;
      }
  }
// Without additional buffer
  public static void deleteDuplicate(LinkedListNode head){

      if(head == null)
          return;
      LinkedListNode previous = head;
      LinkedListNode current = previous.next;

      while(current! = null){
          LinkedListNode runner = head;
          while(runner! = current){
              if(runner.data == current.data){
                  /* Remove current */
                  LinkedListNode temp = current.next;
                  previous.next = temp;
                  current = temp;
                  break;
              }
              runner = runner.next;
          }
          if(runner == current){
              previous = current;
              current = current.next;
          }
      }
  }

  // Reverse a linked list with recursion 
  public ListNode Reverse(Node node){

      /* If the list is empty */
      if(node == null)
          return null;

      /* If the list has only one node */
      if(node.next == null)
          return list;

      Node secondElement = node.next;
      node.next = null;
      Node reverseRest = Reverse(secondElement);

      /* Join the two lists */
      secondElement.next = node;
      return reverseRest;
  }

  // Reverse a doubly linked list
//Swap head and tail pointer. For each node of the doubly linked list, swap the previous and next pointer.
public static void reverseDoublyLL(LinkedListNode head, LinkedListNode tail){

     /* Swap head and tail pointer */
     LinkedListNode temp = head; 
     head = tail; 
     tail = temp;

     /* Create a node pointing to head */
     LinkedListNode current = head; 

     while(current != null){
         /* Swap previous and next pointer of each node */
         temp = current.next;
         current.next = current.prev;
         current.prev = temp;

    }    
 }

//Find 'n' th last element in a singly Linked list 
/*Take two pointers pointer1pointer1 and pointer2pointer2 pointing at the head of the Linked List.
Increment pointer2pointer2 by (n−1n−1) locations such that the distance between pointer1pointer1 and pointer2pointer2 becomes nn, i.ei.e, pointer2pointer2 now points nthnth node.
Increment pointer1pointer1 and pointer2pointer2 by 11 until pointer2pointer2 reaches the last node of the list.
pointer1pointer1 now points to the nthnth node from the last node of the list.
*/
LinkedListNode findNthNodeFromEnd(LinkedListNode head, int n){

      /* Empty linked list */
      if (head == null || n  <  1) 
          return null;

      /* Initialize two pointers at the beginning of the list */
      LinkedListNode pointer1 = head;
      LinkedListNode pointer2 = head;

     /* Increment pointer2 by (n-1) locations */
     for (int j = 0; j  <  n - 1; ++j){
         /* When the length of the list is less than n */
         if (pointer2 == null) 
             return null;
         /* Increment 1 location */
         pointer2 = pointer2.next;
     }

     /* Increment both the pointers until pointer2 reaches the last node */
     while (pointer2.next != null){
         pointer1 = pointer1.next;
         pointer2 = pointer2.next;
     }

     /* pointer1 is now the nth node from the end - return it */
     return pointer1;
 }

// Delete a node in a singly Linked List having access to that node
/* Since we have only access to the node to be deleted (let's call it current node) and 
this is a singly Linked List, the pointer to the previous node of the current node is 
not available. The below algorithm is not applicable if the current node is the last 
node of the Linked List. The algorithm works as :

Copy the data from the next node to the current node.
Keep the pointer of the next of the next node of the current node in a temporary variable.
Delete the next node of the current node.*/
 public static boolean deleteNodeInASinglyLL(Node node){

     /* Error condition check */
     /* If the node is null or the last node of the LL */
     if(node == null || node.next == null)
         return false;

     /* Copy the data from the next node to the current node */
     node.data = node.next.data;

     /* Copy the next of the next node of the current node in a temporary
        variable */
     Node tempNode = node.next.next;
     /* Delete the next node of the current node. */
     delete(node.next);
     /* Pointer reset - link the current node */
     node.next = tempNode;
 }


// Merge Sort on linkedlist
/*If the list is empty or only one element in it, then return the list.
Divide the linked list into two parts.
Sort these two parts recursively.
Merge the sorted parts.*/
public node mergeSort (node list1){ 
       /* Check for empty or single list */
       if (list1 == null || list1.next == null) 
             return list1;
       node list2 = split (list1); 
       list1 = mergeSort (list1); 
       list2 = mergeSort (list2); 
       return merge (list1, list2); 
}

public node split (node list1){
      node list2 = list1.next; 
      list1.next = list2.next; 
      list2.next = split (list2.next);
      return list2; 
}

public node merge (node list1, node list2){
       /* if list1 or list2 is null, return the other */
       if (list1 == null)
           return list2; 
       if (list2 == null)
           return list1; 
       /* Merging */
       if (list1.data  <  list2.data){
           list1.next = merge (list1.next, list2);
           return list1;
       }
       else{
           list2.next = merge (list1, list2.next);
           return list2;
       }
}


//Print Binary Tree level by level 
/*
Create an empty queue
The root of the tree is added in the queue.
The queue is removed and printed. If the removed item has any child(ren), add it/them in the queue.
Repeat the last step untill the queue is empty.*/

public static void printBinaryTreeByLevel(Node node){

    Queue   queue = new LinkedList  ();
    queue.add(node);

    while(queue.size() > 0){
        Node currentNode = queue.remove();
        System.out.println(currentNode.value + “ ”);

        if(currentNode.left! = null)
                queue.add(currentNode.left);

        if(currentNode.right! = null)
                queue.add(currentNode.right);
    }

 }

 //Queue using stack 
 //Enqueue : Push elements to stack1stack1.
//Dequeue : If stack2stack2 is not empty, pop elements from stack2stack2. 
 //Otherwise, pop elements from stack1stack1 and push them to stack2stack2 first. Then, pop elements from  stack2stack2.

 public class implementQueueUsingStacks   {

    /* two stacks - stack1 and stack2 */
    private Stack   stack1 = new Stack  ();
    private Stack   stack2 = new Stack  ();

    /* Enqueue - add the element in stack1 */
    public void enqueue(int element)
        stack1.push(element);
    
    /* Dequeue - remove the element from stack2 */
    public E dequeue(){
        if (stack2.isEmpty()){
            while (!stack1.isEmpty())
               stack2.push(stack1.pop());
            
        }
        return stack2.pop();
    }
 }

 /*Stack using queue 
 Push : Enqueue elements to queue1queue1.
Pop : Dequeue all the elements except the last one from queue1queue1 into queue2queue2.
 Return the last element of queue1queue1. 
 Interchange the names of queue1queue1 and queue2queue2.*/
 public class implementStackUsingQueues   {

     /* two queues - queue1 and queue2 */
     private Queue   queue1 = new LinkedList  ();
     private Queue   queue2 = new LinkedList  ();

     /* push : add the element in queue1 */
     public void push(int element)
          queue1.enqueue(element);
           
     /* Pop : Move all the elements except the last one from queue1 into queue2
     and remove the last element in queue1 */
     public int pop(){

          /* copying all but last element from queue1 into queue2 */
          while( queue1.size() != 1){
             int element = queue1.dequeue();
             queue2.enqueue(element);
          }

          /* Return the last element of queue1 */
          int element = queue1.dequeue();

          /* Interchange queue1 and queue2 */
          while( !queue2.isEmpty() )
             queue1.enqueue(queue2.dequeue());
              
          /* Return the popped element */
          return value;
           
      }
 }