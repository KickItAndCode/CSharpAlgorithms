
 private static boolean powerOfTwo(int number){
        int square = 1;
        while(number >= square){
            if(number == square){
                return true;
            }
            square = square*2;
        }
        return false;
    }

 private static boolean isPalindrome(int number) {
        if(number == reverse(number)){
            return true;
        }
        return false;
    }

    private static int reverse(int number){
        int reverse = 0;
      
        while(number != 0){
          reverse = reverse*10 + number%10; 
          number = number/10;
        }
              
        return reverse;
    }


    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
{
    Dictionary<int,int> indexOfValue= new Dictionary<int, int>();
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
    public static boolean isPrime(int number){
        for(int i=2; i<number; i++){
           if(number%i == 0){
               return false; //number is divisible so its not prime
           }
        }
        return true; //number is prime now
    }

    /*Fibonacci series is series of natural number where next number is
     equivalent to sum of previous two number e.g. fn = fn-1 + fn-2*/

     /*
     * Java program for Fibonacci number using recursion.
     * This program uses tail recursion to calculate Fibonacci number for a given number
     * @return Fibonacci number
     */
    public static int fibonacci(int number){
        if(number == 1 || number == 2){
            return 1;
        }
      
        return fibonacci(number-1) + fibonacci(number -2); //tail recursion
    }
  
 

    public int evenNumbers (int [] numbers){
        return numbers.where(x=>x % 2 == 0).sum(x=>(long)x);
    }

public static int GetNthFibonacci_Rec(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }
            else
                returnGetNthFibonacci_Rec(n - 1) + GetNthFibonacci_Rec(n - 2);
       }

public static int GetNthFibonacci_Ite(int n)
        {
            int number = n - 1; //Need to decrement by 1 since we are starting from 0
            int[] Fib = new int[number + 1];
            Fib[0]= 0;
            Fib[1]= 1;
 
            for (int i = 2; i <= number;i++)
            {
               Fib[i] = Fib[i - 2] + Fib[i - 1];
            }
            return Fib[number];
        }

// Print fib

public static void Fibonacci_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a,b);
 
            for (int i = 2; i < len; i++)
            {
                c= a + b;
                Console.Write(" {0}", c);
                a= b;
                b= c;
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
		Fibonacci_Rec_Temp(b, a + b, counter+1, len);
	}
}

public static int totaleven (int [] nums) {
 	int ret = 0;
	for (int i = 0; i< nums.length; i++){
		if (nums[i] % 2 == 0){
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
public void SwapWithoutTemp (int first, int second){
    first = first + second;
    second = first - second;
    first = first - second;
}

// Recursive Factorial
public int factorial_RC (int number) 
{
    if (number == 1){
        return 1;
    else return number * factorial_RC(number-1);
    }
}

// Iteratoive
public int factorial(int number)
{
    int result = 1;
    while (number != 1)
    {
        result = result * number;
        number = number -1;

    }
    return result;
}

// Write a program that takes two integers and returns the remainder

public static int GetRemainder (int x, int y)
{
    if (y == 0) throw new Exception ("Can't divide by zero");
    if (x < y) throw new Exception ("Number being divided can't be less then zero");
    else return (x % y);
}

    /*An Armstrong number of three digit is a number whose sum of cubes of its 
    digit is equal to its number. For example 153 is an Armstrong number of 
    3 digit because 1^3+5^3+3^3 or   1+125+27=153*/
    private static boolean isArmStrong(int number) {
        int result = 0;
        int orig = number;
        while(number != 0){
            int remainder = number%10;
            result = result + remainder*remainder*remainder;
            number = number/10;
        }
        //number is Armstrong return true
        if(orig == result){
            return true;
        }
      
        return false;
    } 
    
private static boolean isArmStrong(int number) {
 int remainder, sum = 0;        
            
    for (int i = number; i > 0; i = i / 10)
    {
        remainder = i % 10;
        sum = sum + remainder*remainder*remainder;
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


public static bool isPalindrome (int num)
{
    int temp, remainder, reverse = 0;
    temp = num;
    while (num &gt; 0)
    {
        remainder = num % 10;
        reverse = reverse * 10 + remainder;
        num /= 10;
    }
    if (temp == reverse) return true
    return false;
}

