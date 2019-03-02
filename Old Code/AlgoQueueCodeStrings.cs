// Reverse words in a sentence
// I am a student
// student a am I

public static void revSentenceWordByWord(String input){

     /* Split word by word */
     string[] word =  input.split(" ");
     StringBuilder result = new StringBuilder();
     /* Iterate from end to beginning */
     for(int i = word.length - 1; i >= 0 ; i--)
        result.append(word[i]);
        result.append(" ");

     System.out.println(result.toString());

 }

 public static char[] revSentenceWordByWord(char[] input){

     int beginIndex = 0;
     int endIndex = input.length - 1;
     if (endIndex > 1){

        /* Reverse the whole sentence */
        input = reverseString(input, 0, endIndex);

        /* Reverse each word in the reversed sentence */
        for (endIndex = 0; endIndex  < = input.length; endIndex++){
            if (endIndex == input.length || input[endIndex] == ' '){
                input = reverseString(input, beginIndex, endIndex - 1);
                beginIndex = endIndex + 1;
            }
        }
     }
     return input;
 }

 public static char[] reverseString(char[] input, int beginIndex, int endIndex){

     char temp;
     while(beginIndex  <  endIndex){

         temp = input[beginIndex];
         input[beginIndex++] = input[endIndex];
         input[endIndex--] = temp;
     }
     return input;
 }

// First non-repeating character in a string 
 /*Take an empty integer array of 256256 elements to hold the frequency of character of the string.
Iterate through the string and construct the frequency array. Increment the current value of the frequency array by 11 at the location of the corresponding ASCII value of the character.
Iterate through the string and check the frequency array. Return the first element whose frequency is 11.*/
 public static char FirstNonRepeatingChar(String string) {

     /* When the string is null */
     if(string == null)
          throw new NullPointerException(string);
       
     /* Create an empty integer array to store the frequency */
     int[] charFrequency = new int[256];
     
     /* Construct the frequency array */
     for(int i = 0; i  <  string.length; i++)
          charFrequency[string.charAt(i)]++;
        
     /* Iterate through string and check the frequency */
     for(int i = 0; i  <  string.length; i++){
          if(charFrequency[string.charAt(i)] == 1)
              /* Print the first non repeating character */
              return string.charAt(i));
              break;
          }
     }
        
 }

 // Find two elements from an array whose sum equals a given element 

 public static boolean search2Numbers (int[] array, int x){

   /* Sort the array */ 
   Arrays.sort (array); 

   /* Index of first element */ 
   int i = 0;
   /* Index of last element */ 
   int j = array.length - 1;

   while (i  <  j) {

      /* Check if the sum of the elements at index i and j equals x */ 
          if (array[i] + array[j] == x)
             return true; 

      /* If the sum is greater than x, decrease the sum */ 
          elseif (array[i] + array[j] > x)
             j--; 

      /* If the sum is less than x, increase the sum */ 
          else 
             i++; 

   }

   /* If there is no such pair */ 
   return false; 
}

// Find duplicates in a String

public static boolean doesStringHasAllUniqueChars(String string) {

     /* Initialize boolean array */
     boolean[] charStatus = new boolean[256];

     /* Iterate through the string */
     for(int i = 0; i  <  string.length; i++){
        /* ASCII value of the current character */
        int value = string.charAt(i);
      /* Check the corresponding location of ASCII value in the boolean array */
        if(charStatus[value])
            return false;
        charStatus[value] == true;
     }
     return true;
 }

 // Check whether one string is a rotation of another 
 //Check the length of the two strings. If they are not same, return false.
//Otherwise, concatenate string1string1 with itself and check whether string2string2 is a substring of it.
public static boolean checkStringRotation(String string1, String string2){

     /* Check the length of the two strings */
     if(string1.length = string2.length)

         /* Concatenate string1 with itself */
         String concatenatedString1 = string1 + string1;
         /* Check whether string2 is a substring of concatenatedString1 */
         return (concatenatedString1.indexOf(string2) != -1);
     }
     /* If two strings have different length - return false */
     return false;
 }

 // Check whether string is palindrome or not 


 public boolean checkStringIsPalindrome(String input){
     for (int i = 0;i  <  input.length / 2) + 1; ++i){
        if (input.charAt(i) != input.charAt(input.length - i - 1))
        return false;
     }
     return true;
 }

 // Check whether strings are anagrams

 public static boolean checkTwoStringsAnagram(String string1, String string2){

     /* Either string is null */
     if (string1 == null || string2 == null)
         return false;

     /* Length of two strings are not same - return false */
     if(string1.length() != string2.length())
         return false;

     /* Create an integer array to store the frequency of characters */
     int[] charFrequency = new int[256];

     /* Iterate through the strings */
     for (int i = 0; i  <  string1.length(); i++){
        /* increment frequency count in the first string */
        charFrequency[string1.charAt(i)]++;
        /* decrement frequency count in the second string */
        charFrequency[string2.charAt(i)]--;
     }

     /* Check the frequency array */
     for (int i = 0; i  <  256; i++){
        if (charFrequency[i] != 0)
            /* Character set not same - Not an anagram */
            return false;
     }
     /* Strings are anagram */
     return true;
 }

// Reverse a string in place
 public string reverseString(String input){

     /* Input string is null */
     if (input == null)
         return null;

     /* string to character array */
     char[] string2CharArray = input.ToCharArray();
     /* First pointer */
     int firstIndex = 0;
     /* Second pointer */
     int lastIndex = input.length - 1;

     while (firstIndex  <  lastIndex){

         /* Exchange the values at the two pointer */
         char temp = string2CharArray[firstIndex];
         string2CharArray[firstIndex] = string2CharArray[lastIndex];
         string2CharArray[lastIndex] = temp;

         /* Move the first pointer forward */
         firstIndex ++;
         /* Move the second pointer backward */
         lastIndex --;
     }
     return String.valueOf(string2CharArray);
 }