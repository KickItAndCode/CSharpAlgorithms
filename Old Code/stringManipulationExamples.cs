public void DoFizzBuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        bool fizz = i % 3 == 0;
        bool buzz = i % 5 == 0;
        if (fizz && buzz)
            Console.WriteLine ("FizzBuzz");
        else if (fizz)
            Console.WriteLine ("Fizz");
        else if (buzz)
            Console.WriteLine ("Buzz");
        else
            Console.WriteLine (i);
    }
}


// is a palindrome (strings whos reverse is equal to the original)
	public static bool isPalindrome (string s){
		string st = new StringBuilder(s).Reverse().ToString;
		if (st.equals(s)) return true;
		return false;
	}

	public static bool isPalindrome (string s){
		if (s.ISNULLOREMPTY()) return false;
		StringBuilder sb = new StringBuilder(s.length);
		for(int i = s.length -1; i>= 0; i--){
			sb.append(s[i]);
		}
		if (s.equals(sb.ToString())) return true
		return false;
	}

public static  string stringReverseString3b(string str){
    char newStr = [str.length];
    for (int i = 0, j = str.length -1; i< str.length -1, i<= j;  i++, j--;){
        newStr[i] = str [i];
        newStr[j] = str [j];
    }
    return newStr.ToString();

}
//determine if a string has all unique characters
public static bool allUnique (string str){
	// array for each character
	bool[] allChars = new bool[256];

	// loop through string
	for(int i = 0; i < str.length(); i++){
		// val at index i
		char val = str.charAt(i);
		// if theres already a character there then return 
		if (allChars[val]) 
			return false;

		allChars[val] = true;
	}
	return true;

	// to reduced space you can use a bit vector
	// O(n) n is the length of the string 
	// space is O(n)	
	// if you couldn't use additional data structures you could check 
	// every other char of the string for duplicate occurences O(n^2) but no space
}

///String Reversal without Copy to Char Array it's i <= j as we need to getthe middle /// 
public static stringReverseString3b(string str)
{
   char[] chars = new char[str.Length];
   for (int i = 0, j =str.Length - 1; i <= j; i++, j--)
   {
    chars[i] = str[j];
    chars[j] = str[i];
   }
   return new string(chars);
}

///Recursion method; simple and regular performance for small strings
public static string ReverseString_Rec(string str)
{
   if (str.Length <= 1)
    return str;
   else
   return ReverseString_Rec(str.Substring(1)) + str[0];
}


// Remove Duplicates with no large additional memory 
public static void removeDuplicates(char[] str) {
  if (str == null) return; // if the array does not exist..nothing to do return.
  int len = str.length; 
  if (len < 2) return; // if its less than 2..can't have duplicates..return.
  int tail = 1; // number of unique char in the array.
  // start at 2nd char and go till the end of the array.
  for (int i = 1; i < len; ++i) { 
    int j;
    // for every char in outer loop check if that char is already seen.
    // char in [0,tail) are all unique.
    for (j = 0; j < tail; ++j) {
      if (str[i] == str[j]) break; // break if we find duplicate.
    }
    // if j reachs tail..we did not break, which implies this char at pos i
    // is not a duplicate. So we need to add it our "unique char list"
    // we add it to the end, that is at pos tail.
    if (j == tail) {
      str[tail] = str[i]; // add
      ++tail; // increment tail...[0,tail) is still "unique char list"
    }
  }
  str[tail] = 0; // add a 0 at the end to mark the end of the unique char.
}

public int[] removeDuplicates(int [] array){
  List<int> results = new List<int>();

  foreach(var item in array){
    bool found = false;

    foreach(resultItem in results){
      if (resultItem == item) found = true;      
    }
    if (!found) results.add(item);
  }
   
  return  results.toArray();

  }



public bool IsAnagram(string s, string t){
	return sort(s) == sort(t);
}

// You also may add some additional checks for null 
// and empty values and move solution to StringBuilder to 
// improve performance but intent of code is clear.
public static bool IsAnagram(string s1, string s2)
{
    if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
        return false;
    if (s1.Length != s2.Length)
        return false;

    foreach (char c in s2)
    {
        int z = s1.IndexOf(c);
        if (z >= 0)
            s1 = s1.Remove(z, 1);
        else
            return false;
    }

    return string.IsNullOrEmpty(s1);
}

final static int LETTERS_LEN = 256;	
	
public static boolean isAnagram(String s1, String s2) {
	if (s1 == null || s2 == null)
		return false;
	int len = s1.length();
	if (len != s2.length() || len < 2)
		return false;

	int[] letters = new int[LETTERS_LEN];

	for (int i = 0; i < len; i++) {
		letters[s1.charAt(i)]++;
		letters[s2.charAt(i)]--;
	}

	for (int i = 0; i < LETTERS_LEN; i++) {
		if (letters[i] != 0) {
			return false;
		}
	}
	return true;
}
/*This solution is based upon the following. When you are scanning first string you 
are "raising" rate for every letter in hash. In the same (!) loop you are downgrades
 it for every letter founded in the second string. So, if all letters in the both
  words will be appeared exactly the same times, their value in hash position must
   be zero. 
*/





// Substring returns index of the match
public int StrStr(string value, string searchArgument)
{
    if (value == null) { throw new ArgumentNullException("value"); }
    if (searchArgument == null) { throw new ArgumentNullException("searchArgument"); }
    if (searchArgument.Length == 0) { return 0; }

    int searchLength = searchArgument.Length;
    int length = value.Length;

    if (searchLength > length) { return -1; }

    for (int i = 0; i < length; i++)
    {
        if (length - i < searchLength) { return -1; }

        if (IsMatchAtIndex(value, searchArgument, i)) { return i; }
    }
    return -1;
}

private bool IsMatchAtIndex(string value, string searchArgument, int startIndex)
{
    for (int j = 0; j < searchArgument.Length; j++)
    {
        if (value[startIndex + j] != searchArgument[j])
        {
            return false;
        }
    }
    return true;
}  

public int Search(String haystack, String needle){
    for(int i = 0; i < haystack.length(); i++ ) {
        for(int j = 0; j < needle.length() && i+j < haystack.length(); j++ ) {
            if(needle.charAt(j) != haystack.charAt(i+j)) {
                break;
            } else if (j == needle.length()-1) {
                return i;
            }
        }
    }
    return -1;
}



//Write an algorithm to print all possible combinations 
// of characters in a string.
private void printCombinations(String string) {
	for (int i = 0; i 0) {
		substr = string.substring(0, i);
	}
	substr += string.substring(i + 1);
	combine(substr,string.charAt(i));
}
}

private void combine(String instr, char first) {
	String rotate = instr;
	for (int i = 0; i < instr.length(); i++) {
		System.out.println(first + rotate);
		if (i < (instr.length() - 1)) {
			rotate = instr.substring(i+1);
		}
		rotate += instr.substring(0, i+1);
	}
}

/*Write a method to replace all spaces in a string with ‘%20’.

The algorithm is as follows:
1. Count the number of spaces during the first scan of the string.
2. Parse the string again from the end and for each character:
»»If a space is encountered, store “%20”.
»»Else, store the character as it is in the newly shifted location.*/
public static void ReplaceWith%20(char[] str, int length) {
	int spaceCount = 0, newLength, i = 0;
	for (i = 0; i < length; i++) {
		if (str[i] == ‘ ‘) {
			spaceCount++;
		}
	}
	newLength = length + spaceCount * 2;
	str[newLength] = ‘\0’;
	for (i = length - 1; i >= 0; i--) {
		if (str[i] == ‘ ‘) {
			str[newLength - 1] = ‘0’;
			str[newLength - 2] = ‘2’;
			str[newLength - 3] = ‘%’;
			newLength = newLength - 3;
		} else {
			str[newLength - 1] = str[i];
			newLength = newLength - 1;
		}
	}
}

/*1. Check if length(s1) == length(s2). If not, return false.
2. Else, concatenate s1 with itself and see whether s2 is substring of the result.
input: s1 = apple, s2 = pleap ==> apple is a substring of pleappleap
input: s1 = apple, s2 = ppale ==> apple is not a substring of ppaleppale*/

public static boolean isRotation(String s1, String s2) {
    int len = s1.length();
 /* check that s1 and s2 are equal length and not empty */
    if (len == s2.length() && len > 0) {
 /* concatenate s1 and s1 within new buffer */
    string s1s1 = s1 + s2;
    return isSubstring(s1s1, s2);
    }
    return false;
 }




public void combine(String instr, StringBuffer outstr, int index)
{
    for (int i = index; i < instr.length(); i++)
    {
        outstr.append(instr.charAt(i));
        System.out.println(outstr);
        combine(instr, outstr, i + 1);
        outstr.deleteCharAt(outstr.length() - 1);
    }
} 


// Get First Non Repeated Character
  public static char getFirstNonRepeatedChar(String str) {
        Map<Character,Integer> counts = new LinkedHashMap<>(str.length());
        
        for (char c : str.toCharArray()) {
            counts.put(c, counts.containsKey(c) ? counts.get(c) + 1 : 1);
        }
        
        for (Entry<Character,Integer> entry : counts.entrySet()) {
            if (entry.getValue() == 1) {
                return entry.getKey();
            }
        }
        throw new RuntimeException("didn't find any non repeated Character");
    }

    // Get All Permutations
 private void Swap(ref char a, ref char b)
    {
        if (a == b) return;

        a ^= b;
        b ^= a;
        a ^= b;
    }

public static void GetPer(char[] list)
{
    int x = list.Length - 1;
    GetPer(list, 0, x);
}

private static void GetPer(char[] list, int recursionDepth, int maxDepth)
{
    if (recursionDepth == maxDepth)
    {
        Console.Write(list);
    }
    else
        for (int i = recursionDepth; i <= maxDepth; i++)
        {
               Swap(ref list[recursionDepth], ref list[i]);
               GetPer(list, recursionDepth + 1, maxDepth);
               Swap(ref list[recursionDepth], ref list[i]);
        }
}

// Write a method which will remove any given character from a String? 
	public static string RemoveChar (string st, char c ){
		if (st == null || st == "") return st;
		return st.Replace(c.ToString(),"");
	}

	public static string removechar (string st, char c){
		char [] array = st.ToCharArray();
		for(int i= 0; i< st.length; i++){

			if (array[i] == c.ToString()){
				array[i] = "";
			}
		}
		return array.ToString();
		}


// Print all permutations of string 
  // base case is empty string 
  public static void permutations (string str){
  	permutations("",str)
  }
  
  // try each of the letters in turn as the first letter and then 
  //find all the permutations of the remaining letters using a recursive call
  private static void permutations (string prefix, string str){
  	int n = str.length();
  	if (n == 0) console.Write(prefix);
  	else {
  		for (int i=0 ; i< n; i++){
  			permutations(prefix+ str.charAt(i), str.substring(0,i) +str.substring(i+1, n));
  		}
  	}
  }
  
// 1. remove first char 
// 2. find permutations of the rest of chars
// 3. Attach the first char to each of those permutations.
//     3.1  for each permutation, move firstChar in all indexes to produce even more permutations.
// 4. Return list of possible permutations.

public string[] FindPermutations(string word)
    {
        if (word.Length == 2)
        {
            char[] _c = word.ToCharArray();
            string s = new string(new char[] { _c[1], _c[0] });
            return new string[]
            {
                word,
                s
            };
        }

        List<string> result = new List<string>();

        string[] _subsetPermutations = FindPermutations(word.Substring(1));
        char _firstChar = word[0];
        foreach (string s in _subsetPermutations)
        {
            string _temp = _firstChar.ToString() + s;
            result.Add(_temp);
            char[] _chars = _temp.ToCharArray();
            for (int i = 0; i < _temp.Length - 1; i++)
            {
                char t = _chars[i];
                _chars[i] = _chars[i + 1];
                _chars[i + 1] = t;
                string s2 = new string(_chars);
                result.Add(s2);
            }
        }
        return result.ToArray();
    }

 
  public static void printPermutations (string input, string soFar, Set<String> hashset){
  		if (input.equals("")){
  			hashset.add(soFar);
  		}

  		for(int i = 0; i < input.length(); i++){
  			char c = input.CharAt(i);
  			// haven't reached the end
  			if (input.indexOf (c, i+1) != -1)
  				continue;

  			permutations(input.substring(0, i) + input.substring(i+1), soFar + c, hashset);
  		}
  }

  public List<string> perms (string str){
  		List<string> perms = new ArrayList<string>();
  		if (str == null) return null;
  		if (str.length() == 0){
  			perms.add("");
  		}

  		char first = str. charAt(0);
  		string remainder = str.substring(1);
  		// all for n-1
  		ArrayList<string> words = perms(remainder);
  		for (string word in words){
  			for (int j= 0; j<=word.length(); j++){
  				string s = word.Insert(j, first);
  				perms.add(s);
    			}
  		} return perms
  }


// Prints all possible combinations with a given max length
void PrintCombinations(string letters, int length, string prefix = "")
{
    if (length == 0)
    {
        Console.WriteLine(prefix);
        return;
    }
    
    for (var i = 0; i < letters.Length; i++)
    {
        var newPrefix = prefix + letters[i];
        PrintCombinations(letters, length - 1, newPrefix);
    }
}

/**Reverse a Sentence without using C# inbuilt functions
 (except String.Length property, m not going to write code for this small functionality )*/
const char EMPTYCHAR = ' ';
const string EMPTYSTRING = " ";

/// <summary>
/// Reverse a string Sentence
/// </summary>
/// <param name="pStr"></param>
/// <returns></returns>
public string ReverseString(string pStr)
{
  if (pStr.Length > 1) //can be checked/restricted via validation
  {
    string strReversed = String.Empty;
    string[] strSplitted = new String[pStr.Length];
    int i;

    strSplitted = Split(pStr); // Complexity till here O(n)

    for (i = strSplitted.Length - 1; i >= 0; i--)
    // this for loop add O(length of string) in O(n) which is similar to O(n)
    {
        strReversed += strSplitted[i];
    }

    return strReversed;
  }
  return pStr;
}

/// <summary>
/// Split the string into words & empty spaces
/// </summary>
/// <param name="str"></param>
/// <returns></returns>
public string[] Split(string str)
{
    string strTemp = string.Empty;
    string[] strArryWithValues = new String[str.Length];
    int j = 0;
    int countSpace = 0;

    //Complexity of for conditions result to O(n)
    foreach (char ch in str)
    {
        if (!ch.Equals(EMPTYCHAR))
        {
            strTemp += ch; //append characters to strTemp

            if (countSpace > 0)
            {
                strArryWithValues[j] = ReturnSpace(countSpace); // Insert String with Spaces
                j++;
                countSpace = 0;
            }
        }
        else
        {
            countSpace++;

            if (countSpace == 1)
            {
                strArryWithValues[j] = strTemp; // Insert String with Words
                strTemp = String.Empty;
                j++;
            }
        }
    }

    strArryWithValues[j] = strTemp;
    return (strArryWithValues);
}

/// <summary>
/// Return a string with number of spaces(passed as argument)
/// </summary>
/// <param name="count"></param>
/// <returns></returns>
public string ReturnSpace(int count)
{
    string strSpaces = String.Empty;

    while (count > 0)
    {
        strSpaces += EMPTYSTRING;
        count--;
    }

    return strSpaces;

}


// Sudoku validator
!a.Any(i => i != 0 && a.Where(j => j != 0 && i == j).Count >  1)

public static bool IsValid(int[] values)
{
    // bit field (set to zero => no values processed yet)
    int flag = 0;
    foreach (int value in values)
    {
        // value == 0 => reserved for still not filled cells, not to be processed
        if (value != 0)
        {
            // prepares the bit mask left-shifting 1 of value positions
            int bit = 1 << value; 
            // checks if the bit is already set, and if so the Sudoku is invalid
            if ((flag & bit) != 0)
                return false;
            // otherwise sets the bit ("value seen")
            flag |= bit;
        }
    }
    // if we didn't exit before, there are no problems with the given values
    return true;
}

/************Reverse Sentence Ends***************/