using System;
using System.Text;
using System.Collections.Generic;
namespace InterviewCode
{


	public class RomanNumberToDecimal
	{

		public string converToRoman(int dec)
		{
			StringBuilder sb = new StringBuilder();
			while (dec > 0)
			{
				dec = literal(dec, sb);
			}
			return sb.ToString();
		}

		public int convertToDecimal(char[] roman)
		{
			int dec = 0;
			for (int i = 0; i < roman.Length;)
			{
				if (i < roman.Length - 1 && literal(roman[i]) < literal(roman[i + 1]))
				{
					dec += literal(roman[i + 1]) - literal(roman[i]);
					i += 2;
				}
				else
				{
					dec += literal(roman[i]);
					i++;
				}
			}
			return dec;
		}

		private int literal(int dec, StringBuilder sb)
		{
			if (dec >= 1000)
			{
				sb.Append("M");
				dec -= 1000;
				return dec;
			}
			else if (dec >= 900)
			{
				sb.Append("CM");
				dec -= 900;
				return dec;
			}
			else if (dec >= 500)
			{
				sb.Append("D");
				dec -= 500;
				return dec;
			}
			else if (dec >= 400)
			{
				sb.Append("CD");
				dec -= 400;
				return dec;
			}
			else if (dec >= 100)
			{
				sb.Append("C");
				dec -= 100;
				return dec;
			}
			else if (dec >= 90)
			{
				sb.Append("XC");
				dec -= 90;
				return dec;
			}
			else if (dec >= 50)
			{
				sb.Append("L");
				dec -= 50;
				return dec;
			}
			else if (dec >= 40)
			{
				sb.Append("XL");
				dec -= 40;
				return dec;
			}
			else if (dec >= 10)
			{
				sb.Append("X");
				dec -= 10;
				return dec;
			}
			else if (dec >= 9)
			{
				sb.Append("IX");
				dec -= 9;
				return dec;
			}
			else if (dec >= 5)
			{
				sb.Append("V");
				dec -= 5;
				return dec;
			}
			else if (dec >= 4)
			{
				sb.Append("IV");
				dec -= 4;
				return dec;
			}
			else
			{
				sb.Append("I");
				dec -= 1;
				return dec;
			}
		}

		public int literal(char ch)
		{
			switch (ch)
			{
				case 'I':
					return 1;
				case 'V':
					return 5;
				case 'X':
					return 10;
				case 'L':
					return 50;
				case 'C':
					return 100;
				case 'D':
					return 500;
				case 'M':
					return 1000;
				default:
					throw new Exception();
			}
		}
	}
}