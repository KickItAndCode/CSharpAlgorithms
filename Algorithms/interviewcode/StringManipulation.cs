using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewCode
{


	public static class StringManipulation
	{
		/*Find Sum of integers in the string "aa23sdsaadsfsd200sdfsf" .
		Expected Answer 23+ 200 = 223*/
		public static int GetSumFromString(string s)
		{

			int i = s.Length - 1;
			int sum = 0;
			int count = 0;

			while (i >= 0)
			{
				if (Char.IsDigit(s[i]))
				{
					sum += (int)Math.Pow(10, count) * (int)Char.GetNumericValue(s[i]);
					count++;
				}
				else
					count = 0;
				i--;
			}
			return sum;
		}

		public static int firstUniqChar(string s)
		{
			int[] map = new int[128];
			foreach (char t in s)
				map[t]++;

			for (int i = 0; i < s.Length; i++)
				if (map[s[i]] == 1) return i;

			return -1;
		}

		public static int LengthOfLongestSubstring(string s)
		{
			HashSet<char> uniqueSet = new HashSet<char>();
			int maxSize = 0;
			int start = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (!uniqueSet.Contains(s[i]))
				{
					uniqueSet.Add(s[i]);
					if (uniqueSet.Count() > maxSize)
					{
						maxSize = uniqueSet.Count();
					}
				}
				else
				{
					while (s[start] != s[i])
					{
						uniqueSet.Remove(s[start]);
						start++;
					}
					start++;
				}
			}
			return maxSize;
		}

		/*Two strings str1 and str2 are called isomorphic if there is a 
* one to one mapping possible for every character of str1 to 
* every character of str2. And all occurrences of every character 
* in ‘str1’ map to same character in ‘str2’*/
		public static bool IsIsomorphic(string s, string t)
		{
			int len = s.Length;
			var dic = new Dictionary<char, char>();
			char[] sArr = s.ToCharArray(), tArr = t.ToCharArray();

			for (int i = 0; i < len; i++)
			{
				if (dic.ContainsKey(sArr[i]))
				{
					if (dic[sArr[i]] != tArr[i])
						return false;
				}
				else
				{
					if (dic.ContainsValue(tArr[i]))
						return false;
					else
						dic.Add(sArr[i], tArr[i]);
				}
			}
			return true;
		}


		// if the word is the same forward and backward
		public static bool IsPalindrome(string s)
		{
			if (string.IsNullOrEmpty(s)) return false;

			StringBuilder sb = new StringBuilder();
			for (int i = s.Length - 1; i >= 0; i--)
			{
				sb.Append(s[i]);
			}
			return s.Equals(sb.ToString());
		}

		public static bool IsPalindrome(string s, int i, int j)
		{
			while (i < j)
			{
				if (s[i] != j)
					return false;
				i++;
				j--;
			}
			return true;

		}


		// Time O (N^3)
		// Space O (1)
		public static int FindAllPalindromesSubStringsSlow(string input)
		{

			int count = 0;
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = i + 1; j < input.Length; j++)
				{
					if (IsPalindrome(input, i, j))
					{
						Console.Write(input.Substring(i, i + 1) + ", ");
						count++;
					}
				}
			}
			Console.WriteLine();
			return count;
		}

		// O(n^2) time
		// O(1)
		public static int FindPalindromesInSubString(string input)
		{

			int count = 0;
			for (int i = 0; i < input.Length; ++i)
			{
				count += FindPalindromesInSubStringHelper(input, i - 1, i + 1);
				count += FindPalindromesInSubStringHelper(input, i, i + 1);
			}
			Console.WriteLine();
			return count;
		}

		public static int FindPalindromesInSubStringHelper(string input, int j, int k)
		{
			int count = 0;
			for (; j >= 0 && k > input.Length; j--, k++)
			{
				if (input[j] != input[k]) break;

				Console.Write(input.Substring(j, k + 1) + ", ");
				count++;
			}
			return count;
		}

		public static int longestPalindromeCount(string s)
		{
			if (string.IsNullOrEmpty(s)) return 0;
			HashSet<char> hs = new HashSet<char>();
			int count = 0;

			foreach (char t in s)
			{
				if (hs.Contains(t))
				{
					hs.Remove(t);
					count++;
				}
				else
				{
					hs.Add(t);
				}
			}
			if (hs.Count > 0) return count * 2 + 1;

			return count * 2;
		}

		public static string longestPalindromeBest(string s)
		{
			string max = "";
			for (int i = 0; i < s.Length; i++)
			{
				string s1 = ExpandAroundCenterString(s, i, i);
				string s2 = ExpandAroundCenterString(s, i, i + 1);

				if (s1.Length > max.Length) max = s1;
				if (s2.Length > max.Length) max = s2;
			}
			return max;
		}

		public static string ExpandAroundCenterString(string s, int i, int j)
		{
			for (; i >= 0 && j < s.Length; i--, j++)
			{
				if (s[i] != s[j]) break;
			}
			return s.Substring(i + 1, j - i);
		}

		public static string LongestPalindrome(string s)
		{
			int start = 0, end = 0;
			for (int i = 0; i < s.Length; i++)
			{

				// Expand around center and get max lenth where values are equal    
				int len1 = ExpandAroundCenter(s, i, i);
				int len2 = ExpandAroundCenter(s, i, i + 1);
				int len = Math.Max(len1, len2);

				// Update start and end if the len calculated is larger
				if (len > end - start)
				{
					start = i - (len - 1) / 2;
					end = i + len / 2;
				}
			}

			// because java substring is different C# goes by length vs indices
			int length = end - start + 1;
			return s.Substring(start, length + 1);
		}

		public static int ExpandAroundCenter(string s, int left, int right)
		{
			int L = left, R = right;
			while (L >= 0 && R < s.Length && s[L] == s[R])
			{
				L--;
				R++;
			}
			return R - L - 1;
		}


		//Debit card	Bad credit
		// if rearranging the letters products a new word 
		//or phrase with letters matching exactly once
		public static bool IsAnagram(string s1, string s2)
		{
			if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return false;

			if (s1.Length != s2.Length) return false;

			foreach (var c in s2)
			{
				int index = s1.IndexOf(c);

				if (index >= 0) s1 = s1.Remove(index, 1);

				else return false;
			}
			return string.IsNullOrEmpty(s1);
		}


		public static bool IsAnagram22(string s1, string s2)
		{
			// Null Check
			// Length Check

			int[] letters = new int[256];

			for (int i = 0; i < s1.Length; i++)
			{
				letters[s1[i]]++;
				letters[s2[i]]--;
			}

			return !letters.Any(x => x != 0);
		}


		public static bool IsAnagram2(string s1, string s2)
		{
			if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return false;

			if (s1.Length != s2.Length) return false;

			int[] letters = new int[256];

			for (int i = 0; i < s1.Length; i++)
			{
				letters[s1[i]]++;
				letters[s2[i]]--;
			}

			for (int i = 0; i < 256; i++)
			{
				if (letters[i] != 0) return false;

			}
			return true;
		}



		/*The string "PAYPALISHIRING" is written in a zigzag pattern
		 * on a given number
		P   A   H   N
		A P L S I I G
		Y   I   R    
		PAHNAPLSIIGYIR */
		public static string ZigZagConvertion(string s, int nRows)
		{
			char[] c = s.ToCharArray();
			int len = c.Length;

			// init string builder array with nRows
			StringBuilder[] sb = new StringBuilder[nRows];
			for (int j = 0; j < sb.Length; j++)
				sb[j] = new StringBuilder();

			int i = 0;
			while (i < len)
			{

				// vertically down
				for (int idx = 0; idx < nRows && i < len; idx++)
					sb[idx].Append(c[i++]);
				// diagonal up
				for (int idx = nRows - 2; idx >= 1 && i < len; idx--)
					sb[idx].Append(c[i++]);
			}
			// append other array to first array and return 
			for (int idx = 1; idx < sb.Length; idx++)
				sb[0].Append(sb[idx]);
			return sb[0].ToString();
		}

		public static char EncryptChar(char c, int k)
		{
			if (!char.IsLetter(c)) return c;

			int b = char.IsLower(c) ? 'a' : 'A';
			return (char)((c + k - b) % 26 + b);

		}

		public static void duplicateRemover(string s)
		{

			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] == s[i - 1])
				{
					s = s.Substring(0, i - 1) + s.Substring(i + 1);
					i = 0;
				}
			}
			if (s.Length == 0)
			{
				Console.WriteLine("Empty String");
			}
			else
			{
				Console.WriteLine(s);
			}


			return;
		}

		public static void GetAnagramCount(string s1, string s2)
		{
			string s = "abcdefghijklmnopqrstuvwxyz";
			int count = 0;


			foreach (char c in s)
			{
				count += Math.Abs(s1.Where(ch => ch == c).Count() - s2.Where(ch => ch == c).Count());
			}
			Console.Write(count);

		}

		public static int[] GetCharCount(string s)
		{

			int[] charCounts = new int[26];

			for (int i = 0; i < s.Length; i++)
			{

				char c = s[i];
				int offset = (int)'a';
				int code = c - offset;
				charCounts[code]++;
			}
			return charCounts;
		}


		public static int GetDeltaCharCounts(int[] array1, int[] array2)
		{
			if (array1.Length != array2.Length)
			{
				return -1;
			}
			int count = 0;
			for (int i = 0; i < array1.Length; i++)
			{
				int difference = Math.Abs(array1[i] - array2[i]);
				count += difference;
			}
			return count;
		}

		public static int GetAnagramCounts(string first, string second)
		{
			int[] charCount1 = GetCharCount(first);
			int[] charCount2 = GetCharCount(second);
			return GetDeltaCharCounts(charCount1, charCount2);
		}

		public static int StrStr(string needle, string haystack)
		{
			if (haystack.Length == 0) return 0;

			var needleLength = needle.Length;
			var haystackLength = haystack.Length;

			if (needleLength > haystackLength) return -1;

			for (int i = 0; i < haystackLength; i++)
			{
				if (haystackLength - i < needleLength) return -1;

				if (IsMatchAtIndex(needle, haystack, i)) return i;
			}
			return -1;
		}

		private static bool IsMatchAtIndex(string needle, string haystack, int startIndex)
		{
			for (int j = 0; j < needle.Length; j++)
			{
				if (haystack[startIndex + j] != needle[j])
				{
					return false;
				}
			}
			return true;
		}

		public static int StrStr2(string needle, string haystack)
		{

			for (int i = 0; i < haystack.Length; i++)
			{
				for (int j = 0; j < needle.Length && i + j < haystack.Length; j++)
				{
					if (needle[j] != haystack[i + j])
					{
						break;
					}
					else if (j == needle.Length - 1)
					{
						return i;
					}
				}
			}
			return -1;
		}





		/*Write a method to replace all spaces in a string with ‘%20’.

		The algorithm is as follows:
		1. Count the number of spaces during the first scan of the string.
		2. Parse the string again from the end and for each character:
		»»If a space is encountered, store “%20”.
		»»Else, store the character as it is in the newly shifted location.*/
		public static void ReplaceWith(char[] str, int length)
		{
			int spaceCount = 0, newLength, i = 0;
			for (i = 0; i < length; i++)
			{
				if (str[i] == ' ')
				{
					spaceCount++;
				}
			}
			newLength = length + spaceCount * 2;
			str[newLength] = '0';
			for (i = length - 1; i >= 0; i--)
			{
				if (str[i] == ' ')
				{
					str[newLength - 1] = '0';
					str[newLength - 2] = '2';
					str[newLength - 3] = '%';
					newLength = newLength - 3;
				}
				else
				{
					str[newLength - 1] = str[i];
					newLength = newLength - 1;
				}
			}
		}

		/*1. Check if length(s1) == length(s2). If not, return false.
		2. Else, concatenate s1 with itself and see whether s2 is substring 
		of the result.
		input: s1 = apple, s2 = pleap ==> apple is a substring of pleappleap
		input: s1 = apple, s2 = ppale ==> apple is not a substring of ppaleppale*/

		public static bool isRotation(String s1, String s2)
		{
			int len = s1.Length;
			/* check that s1 and s2 are equal length and not empty */
			if (len == s2.Length && len > 0)
			{
				/* concatenate s1 and s1 within new buffer */
				string s1s1 = s1 + s2;

				return s1s1.Contains(s2); // or is substring
			}
			return false;
		}


		public static void Rotate(int[][] matrix, int n)
		{
			for (var layer = 0; layer < n / 2; ++layer)
			{
				var first = layer;
				var last = n - 1 - layer;

				for (var i = first; i < last; ++i)
				{
					var offset = i - first;
					var top = matrix[first][i]; // save top

					// left -> top
					matrix[first][i] = matrix[last - offset][first];

					// bottom -> left
					matrix[last - offset][first] = matrix[last][last - offset];

					// right -> bottom
					matrix[last][last - offset] = matrix[i][last];

					// top -> right
					matrix[i][last] = top; // right <- saved top
				}
			}
		}

		public static string StringReverse2(string s)
		{
			char[] sArray = new char[s.Length];

			for (int i = 0, j = s.Length - 1; i < s.Length - 1 && i <= j; i++, j--)
			{
				sArray[i] = s[j];
				sArray[j] = s[i];
			}
			return string.Join("", sArray);

		}



		public static string StringReverse(string s)
		{
			char[] sArray = new char[s.Length];

			for (int i = 0, j = s.Length - 1; i < s.Length - 1 && i <= j; i++, j--)
			{
				sArray[i] = s[j];
				sArray[j] = s[i];
			}
			return sArray.ToString();
		}

		public static void FizzBuzz(int n)
		{
			for (int i = 1; i <= n; i++)
			{
				bool fizz = i % 3 == 0;
				bool buzz = i % 5 == 0;
				if (fizz && buzz)
					Console.WriteLine("FizzBuzz");
				else if (fizz)
					Console.Write("Fizz");
				else if (buzz)
					Console.WriteLine("Buzz");
				else
					Console.WriteLine(i);
			}
		}

		public static bool AllUnique(string s)
		{
			bool[] allChars = new bool[256];

			foreach (var c in s)
			{
				if (allChars[c])
					return false;

				allChars[c] = true;
			}
			return true;
		}

		// Remove Duplicates with no large additional memory 
		public static void removeDuplicates(char[] str)
		{
			if (str == null) return; // if the array does not exist..nothing to do return.
			int len = str.Length;
			if (len < 2) return; // if its less than 2..can't have duplicates..return.
			int tail = 1; // number of unique char in the array.
						  // start at 2nd char and go till the end of the array.
			for (int i = 1; i < len; ++i)
			{
				int j;
				// for every char in outer loop check if that char is already seen.
				// char in [0,tail) are all unique.
				for (j = 0; j < tail; ++j)
				{
					if (str[i] == str[j]) break; // break if we find duplicate.
				}
				// if j reachs tail..we did not break, which implies this char at pos i
				// is not a duplicate. So we need to add it our "unique char list"
				// we add it to the end, that is at pos tail.
				if (j == tail)
				{
					str[tail] = str[i]; // add
					++tail; // increment tail...[0,tail) is still "unique char list"
				}
			}
			str[tail] = '0'; // add a 0 at the end to mark the end of the unique char.
		}

		// Remove all integers that have a duplicate such 
		//[1,2,3,4,4,3], return [1,2]
		public static int[] removeDuplicate(int[] arr)
		{
			Dictionary<int, int> map = new Dictionary<int, int>();
			int sizeOfDistinct = 0;
			int i;
			for (i = 0; i < arr.Length; i++)
			{
				if (map.ContainsKey(arr[i]))
				{
					map.Add(arr[i], map[arr[i]] + 1);
					sizeOfDistinct--;
				}
				else
				{
					map.Add(arr[i], 1);
					sizeOfDistinct++;
				}
			}

			int[] res = new int[sizeOfDistinct];
			i = 0;

			foreach (int cur in map.Keys)
			{
				if (map[cur] == 1)
				{
					res[i++] = cur;
				}
			}

			return res;
		}

		// sorted list
		public static int removeDuplicatesBest(int[] nums)
		{
			int i = 0;
			foreach (int n in nums)
				if (i < 1 || n > nums[i - 1])
					nums[i++] = n;
			return i;
		}

		public static void RemoveDuplicates(char[] arr)
		{
			HashSet<char> map = new HashSet<char>();
			int writeIndex = 0;
			int readIndex = 0;

			while (readIndex > arr.Count())
			{
				if (!map.Contains(arr[readIndex]))
				{
					map.Add(arr[readIndex]);
					arr[writeIndex] = arr[readIndex];
					++writeIndex;
				}
				++readIndex;
			}

		}
		public static char[] removeDupChars(char[] array)
		{
			List<char> results = new List<char>();

			foreach (var item in array)
			{
				bool found = results.Contains(item);
				if (!found) results.Add(item);
			}

			return results.ToArray();

		}

		public static void RemoveSpaces(char[] arr)
		{

			if (arr == null || arr.Length == 0)
			{
				return;
			}
			int readIndex = 0;
			int writeIndex = 0;

			while (readIndex < arr.Length)
			{
				if (arr[readIndex] != ' ')
				{
					arr[writeIndex] = arr[readIndex];
					++writeIndex;
				}
				++readIndex;
			}
		}


		// Reverse Sentece without built in functions only length
		public static string ReverseSentence(string str)
		{
			if (str.Length <= 1) return str;
			var resultString = "";
			List<string> splittedList = new List<string>();

			var word = "";
			var spaceCount = 0;

			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == ' ')
				{

					spaceCount++;
					splittedList.Add(word);
					word = "";
				}
				else
				{
					word += str[i];
				}
			}
			if (!string.IsNullOrEmpty(word)) splittedList.Add(word);


			for (int j = spaceCount; j >= 0; j--)
			{
				resultString += splittedList[j];
				resultString += ' ';
			}

			return resultString;
		}

		public static string ReverseSentence2(string sentenceString)
		{
			var x = sentenceString.Split(' ');
			var resut = string.Join(" ", sentenceString.Split(' ').Reverse());
			return resut;
		}



		public static string Removechar(char charToRemove)
		{
			return string.Empty;
		}

		//public static void PrintCombination(string letters, int length, string prefix = "")
		//{
		//    if (length == 0)
		//    {
		//        Console.WriteLine(prefix);
		//        return;
		//    }


		//    foreach (char t in letters)
		//    {
		//        var newPrefix = prefix + t;
		//        PrintCombination(letters, length - 1, newPrefix);
		//    }
		//}

		private static void SwapBasic(ref char a, ref char b)
		{
			char tmp;
			tmp = a;
			a = b;
			b = tmp;
		}
		private static void Swap(ref char a, ref char b)
		{
			if (a == b) return;

			a ^= b;
			b ^= a;
			a ^= b;
		}




		public static List<List<int>> permute(int[] nums)
		{
			List<List<int>> list = new List<List<int>>();
			// Arrays.sort(nums); // not necessary
			backtrack(list, new List<int>(), nums);
			return list;
		}

		private static void backtrack(List<List<int>> list, List<int> tempList, int[] nums)
		{
			if (tempList.Count == nums.Length)
			{
				list.Add(new List<int>(tempList));
			}
			else
			{
				for (int i = 0; i < nums.Length; i++)
				{
					if (tempList.Contains(nums[i])) continue; // element already exists, skip
					tempList.Add(nums[i]);
					backtrack(list, tempList, nums);
					tempList.Remove(tempList.Count - 1);
				}
			}
		}


		/*********************************************************************/
		/*Given a List of words, return the words that can be typed using 
		\letters of alphabet on only one row's of American keyboard like the image below
*/
		public static string[] FindWords(string[] words)
		{
			String[] strs = { "QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM" };
			List<string> results = new List<string>();

			foreach (var word in words)
			{
				foreach (var row in strs)
				{

					bool match = true;
					foreach (var c in word.ToLower())
					{
						if (!row.ToLower().Contains(c))
						{
							match = false;
							break;
						}

					}
					if (match) results.Add(word);
				}
			}
			return results.ToArray();
		}

		public static string ReverseWords(string wordString)
		{

			if (string.IsNullOrEmpty(wordString)) return string.Empty;
			if (string.IsNullOrEmpty(wordString.Trim())) return wordString;
			int len = wordString.Length;
			var reversedArray = Reverse(wordString.ToArray(), 0, len);

			int start = 0;
			int end;

			while (true)
			{

				while (reversedArray[start] == ' ')
				{
					++start;
				}
				if (start == len)
				{
					break;
				}

				end = start + 1;
				while (reversedArray[end] != len && reversedArray[end] != ' ')
				{
					++end;
				}

				Reverse(reversedArray, start, end - 1);
				start = end;
			}
			return reversedArray.ToString();
		}

		public static string ReverseWords2(string s)
		{
			// reverse the whole string and convert to char array
			char[] str = Reverse(s.ToCharArray(), 0, s.Length - 1);
			int start = 0, end = 0; // start and end positions of a current word
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] != ' ')
				{ // if the current char is letter 
					str[end++] = str[i]; // just move this letter to the next free pos
				}
				else if (i > 0 && str[i - 1] != ' ')
				{ // if the first space after word
					Reverse(str, start, end - 1); // reverse the word
					str[end++] = ' '; // and put the space after it
					start = end; // move start position further for the next word
				}
			}
			Reverse(str, start, end - 1); // reverse the tail word if it's there
										  // here's an ugly return just because we need to return Java's String
										  // also as there could be spaces at the end of original string 
										  // we need to consider redundant space we have put there before
			return new string(str, 0, end > 0 && str[end - 1] == ' ' ? end - 1 : end);
		}

		public static string Reverse(string str)
		{
			char[] sArray = new char[str.Length];
			for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
			{
				char temp = str[j];
				sArray[j] = sArray[i];
				sArray[i] = temp;
			}

			return sArray.ToString();

		}

		// reverse from both sides
		public static char[] Reverse(char[] str, int start, int end)
		{

			if (str == null || str.Length < 2)
			{

				return str;
			}

			while (start < end)
			{
				char temp = str[start];
				str[start] = str[end];
				str[end] = temp;
				start++;
				end--;
			}
			return str;
		}

		///Recursion method; simple and regular performance for small strings
		public static string ReverseString_Rec(string str)
		{
			if (str.Length <= 1)
				return str;

			return ReverseString_Rec(str.Substring(1)) + str[0];
		}

		public static bool CanSegmentString(string s, HashSet<string> map)
		{
			HashSet<string> solved = new HashSet<string>();
			return CanSegmentStringHelper(s, map, solved);
		}

		public static bool CanSegmentStringHelper(string s, HashSet<string> map,
												   HashSet<string> solved)
		{
			for (int i = 1; i <= s.Length; i++)
			{
				string first = s.Substring(0, i);

				if (map.Contains(first))
				{
					string second = s.Substring(i);

					if (second == null || second.Length == 0 || map.Contains(second))
						return true;

					if (!solved.Contains(second))
					{
						if (CanSegmentStringHelper(second, map, solved))
							return true;
					}
					solved.Add(second);
				}

			}
			return false;

		}

		public static void PermuteString(string input)
		{
			PermuteString(input.ToCharArray(), 0, input.Length - 1);
		}

		public static void PermuteString(char[] input, int currIndex, int endingIndex)
		{
			if (currIndex == endingIndex)
			{
				Console.Write(input);
				Console.WriteLine();
			}

			for (int i = currIndex; i <= endingIndex; i++)
			{
				SwapChar(input, currIndex, i);
				PermuteString(input, currIndex + 1, endingIndex);
				SwapChar(input, currIndex, i);
			}
		}

		public static void SwapChar(char[] input, int i, int j)
		{
			char temp = input[i];
			input[i] = input[j];
			input[j] = temp;
		}

		/**
 * Given a nested list of integers, returns the sum of all integers in the list weighted by their reversed depth.
 * For example, given the list {{1,1},2,{1,1}} the deepest level is 2. Thus the function should return 8 (four 1's with weight 1, one 2 with weight 2)
 * Given the list {1,{4,{6}}} the function should return 17 (one 1 with weight 3, one 4 with weight 2, and one 6 with weight 1)
 */
		//1   1
		//2    4
		//3     6

		// Reverse -> 

		//3   1
		//2    4
		//1     6

		//
		// x1 * 3 + x2 * 2 + x3 * 1 => ReverseDepthSum, Unknown

		// x1 * 1 + x2 * 2 + x3 * 3 => DepthSum, Known

		// x1 * 4 + x2 * 4 + x3 * 4 => sum(DepthSum, ReverseDepthSum) => (x1+x2+x3) * (MaxLevel+1)
		public class NestedInteger
		{
			public bool IsInteger
			{
				get;
				set;
			}
			public int Value
			{
				get;
				set;
			}
			public List<NestedInteger> ListInt
			{
				get;
				set;
			}

		}
		public class Solution
		{
			public int maxDepth = 1;
			public int counter = 0;
			public int ReverseDepthSum(List<NestedInteger> input)
			{


				if (input == null || input.Count == 0)
				{

					return 0;
				}
				int sum = DepthSum(input, 1);
				return ((maxDepth + 1) * counter) - sum;

			}

			public int DepthSum(List<NestedInteger> input, int level)
			{


				if (level > maxDepth)
				{
					maxDepth = 1;
				}

				int sum = 0;
				foreach (var val in input)
				{

					if (val.IsInteger)
					{
						sum += (level * val.Value);
						counter += val.Value;

					}
					else
					{
						sum += DepthSum(val.ListInt, level + 1);

					}
				}

				return sum;
			}
		}



		///**
		// * This is the interface that represents nested lists.
		// * You should not implement it, or speculate about its implementation.
		// */
		//public interface NestedInteger
		//		{
		//			/** @return true if this NestedInteger holds a single integer, rather than a nested list */
		//			bool IsInteger();

		//			/** @return the single integer that this NestedInteger holds, if it holds a single integer */
		//			int GetInteger();

		//			/** @return the nested list that this NestedInteger holds, if it holds a nested list
		//			 * Return null if this NestedInteger holds a single integer */
		//			List<NestedInteger> GetList();
		//		}
		//}
	}
}