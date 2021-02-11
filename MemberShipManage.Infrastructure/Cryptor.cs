using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructurer
{
	public class Cryptor
	{
		private char[] HashTab = new char[94]
		{
		'H', '%', 'c', 'R', ')', 'E', 'g', 'h', 'W', 'j',
		'|', 'l', ']', 'n', 'A', 'p', 'C', 'r', 'K', 't',
		'u', 'v', ';', 'x', 'y', '>', '8', 'M', '3', 'P',
		'J', '@', '7', '1', '9', '0', 'o', 'B', 'q', 'D',
		'f', 'F', 'G', 'a', 'I', '5', 's', 'L', '2', 'N',
		'O', '4', 'Q', 'd', 'S', 'T', '?', 'V', 'i', 'X',
		'&', 'Z', '~', '`', '!', '6', '#', '$', 'b', '^',
		'Y', '*', '(', 'e', '_', '-', '+', '=', 'k', '\\',
		'[', 'm', '{', '}', 'w', ':', '"', '\'', ',', '<',
		'.', 'z', 'U', '/'
		};

		public string Encrypt(char[] _sOrigin)
		{
			char[] array = new char[_sOrigin.Length + 21];
			if (_sOrigin.Length != 0)
			{
				array = Confuse(_sOrigin);
				array = Explode(array);
				for (int i = 0; i < 10; i++)
				{
					Shuffle(array);
				}
			}
			string text = "";
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] != 0)
				{
					text += array[j];
				}
			}
			return text;
		}

		private char[] Confuse(char[] sOrigin)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			Random random = new Random();
			num = sOrigin.Length;
			char[] array = new char[num + 21];
			for (int i = 0; i < 20; i++)
			{
				num3 = random.Next() % 94;
				array[num2++] = HashTab[num3];
				if (num4 < num)
				{
					array[num2++] = sOrigin[num4++];
				}
			}
			while (num4 < num)
			{
				array[num2++] = sOrigin[num4++];
			}
			return array;
		}

		private char[] Explode(char[] _sConvert)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			num = _sConvert.Length;
			char[] array = new char[num + 1];
			for (num2 = 0; num2 < num; num2++)
			{
				num3 = LocatePos(_sConvert[num2]);
				array[num2] = HashTab[(num3 + 5) % 94];
			}
			return array;
		}

		private char[] Shuffle(char[] _sConvert)
		{
			int num = 0;
			char[] array = new char[_sConvert.Length + 1];
			num = _sConvert.Length / 2;
			char[] array2 = new char[num + 2];
			char[] array3 = new char[num + 2];
			for (int i = 0; i < num; i++)
			{
				array2[i] = array[i * 2 + 1];
				array3[num - 1 - i] = array[i * 2];
			}
			string text = (_sConvert.Length % 2).ToString();
			if (text != "0")
			{
				array3[num] = array[_sConvert.Length - 1];
				array3[num + 1] = '\0';
			}
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] != 0)
				{
					array[i] = array2[i];
				}
			}
			for (int j = 0; j < array3.Length; j++)
			{
				if (array3[j] != 0)
				{
					array[j + array2.Length - 1] = array3[j];
				}
			}
			return _sConvert;
		}

		public string Decrypt(char[] sEncrypt)
		{
			int num = 0;
			int num2 = 0;
			string text = "";
			if (sEncrypt != null)
			{
				num2 = sEncrypt.Length;
				if (num2 >= 20)
				{
					char[] array = new char[num2 + 1];
					char[] array2 = new char[num2 + 1];
					array = sEncrypt;
					for (num = 0; num < 10; num++)
					{
						array = DeShuffle(sEncrypt);
					}
					array = DeExplode(array);
					array = DeConfuse(array);
					text = new string(array);
					return text.Substring(0, text.Length - 22);
				}
				sEncrypt = null;
			}
			return text.Substring(0, text.Length - 22);
		}

		private char[] DeConfuse(char[] sOrigin)
		{
			int num = sOrigin.Length;
			int num2 = num - 20;
			char[] array = new char[sOrigin.Length];
			for (int i = 0; i < num2; i++)
			{
				if (i < 20)
				{
					array[i] = sOrigin[2 * i + 1];
				}
				else
				{
					array[i] = sOrigin[i + 20];
				}
			}
			return array;
		}

		private char[] DeExplode(char[] sOrigin)
		{
			int num = sOrigin.Length;
			char[] array = new char[num + 1];
			for (int i = 0; i < num; i++)
			{
				int num2 = LocatePos(sOrigin[i]);
				num2 -= 5;
				if (num2 < 0)
				{
					num2 += 94;
				}
				array[i] = HashTab[num2];
			}
			return array;
		}

		private char[] DeShuffle(char[] sOrigin)
		{
			int num = sOrigin.Length / 2;
			char[] array = new char[num + 2];
			char[] array2 = new char[num + 2];
			for (int i = 0; i < num; i++)
			{
				array[i] = sOrigin[i * 2 + 1];
				array2[num - 1 - i] = sOrigin[i * 2];
			}
			for (int i = 0; i < num; i++)
			{
				sOrigin[i * 2] = array2[num - 1 - i];
				sOrigin[i * 2 + 1] = array[i];
			}
			return sOrigin;
		}

		private int LocatePos(char cFind)
		{
			int i;
			for (i = 0; i < 94 && HashTab[i] != cFind; i++)
			{
			}
			return i;
		}
	}

}
