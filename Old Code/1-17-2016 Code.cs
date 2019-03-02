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

    // Display All Anagrams from a list of strings
    public static void DiplayAnagrams (List<string> words){

    List<strings> results  = new List<string>();
        for(int i = 0; i< words.count() -1; i++){

            for(int j = i+ 1; j  < words.count(); j++){
                
                if (words[i].Length != words[j].Length){
                char [] a = words [i].toCharArray();
                char [] b = words [j].toCharArray();
                    if (Array.Sort(a).toString().equals(Array.Sort(b).toString())){
                        results.Add(words[i]);
                        results.Add(words[j]);
                    }
                }
            }
        }
        Console.Write(results);
    }

    public static ReverseStringIterative(string str)
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
