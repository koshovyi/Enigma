using System;

namespace Enigma
{

	public class Rotor
	{

		#region Fields & Properties

		private readonly char[] _chars;

		private int _head;

		public char Notch { get; set; }

		public char Turnover { get; set; }

		public Rotor Prev { get; set; }

		public Rotor Next { get; set; }

		public Type Type { get; set; }

		public bool IsFirst { get; set; }

		public char Current
		{
			get => Common.ALPHABET[this._head];
			set => this.SetHead(value);
		}

		#endregion

		public Rotor(Type type, string chars)
		{
			this._chars = chars.ToCharArray();
			this.Type = type;
		}

		public static int GetAlphabetCharIndex(char @char) => Array.IndexOf(Common.ALPHABET, char.ToUpper(@char));

		public char GetFromAlphabet(char @char)
		{
			int index = GetAlphabetCharIndex(@char);
			return this._chars[index];
		}

		public char GetFromRotor(char @char)
		{
			int index = Array.IndexOf(this._chars, char.ToUpper(@char));
			return Common.ALPHABET[index];
		}

		public void SetHead(char @char) => this._head = GetAlphabetCharIndex(@char);

		public char Enter(char @char)
		{
			if (this.Current == this.Turnover && this.Type == Type.Rotor)
				this.Prev.Rotate();
			if(this.IsFirst)
				this.Rotate();

			int from = Array.IndexOf(Common.ALPHABET, char.ToUpper(this.Current));
			int to = this.Next == null ? 0 : Array.IndexOf(Common.ALPHABET, char.ToUpper(this.Next.Current));
			int index = Array.IndexOf(Common.ALPHABET, char.ToUpper(@char));

			int distance = Common.Mod(from, to);
			char get = Common.CharPlusN(index, distance);

			char map = GetFromAlphabet(get);
			return map;
		}

		public char Reverse(char @char)
		{
			int f = Array.IndexOf(Common.ALPHABET, char.ToUpper(this.Current));
			int t = this.Prev == null ? 0 : Array.IndexOf(Common.ALPHABET, char.ToUpper(this.Prev.Current));
			int nn = Array.IndexOf(Common.ALPHABET, char.ToUpper(@char));

			int d = Common.Mod(f, t);
			char get = Common.CharPlusN(nn, d);

			char map = GetFromRotor(get);
			return map;
		}

		public void Rotate()
		{
			if (this._head + 1 >= this._chars.Length)
				this._head = 0;
			else
				this._head++;
		}

	}

}
