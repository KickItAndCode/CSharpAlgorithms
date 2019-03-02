public class reverseString
{
//      fe
//  o l l e h
//      i


    // Reverse string by doing a swap from the front and back at the same time using two pointers
    public string reverseString1(string s)
    {
        if (s == null || s.Length == 1 || s.Length == 0)
            return s;

        char[] word = s.ToCharArray();
        for (int f = 0, e = s.Length - 1; f <= e; f++, e--)
        {
            char temp = word[f];
            word[f] = word[e];
            word[e] = temp;

        }
        return new string(word);

    }
}