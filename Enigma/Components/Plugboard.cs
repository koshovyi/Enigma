using System.Collections.Generic;

namespace Enigma
{

	public class Plugboard
	{

		private readonly List<char> _l1;
		private readonly List<char> _l2;

		public bool Enabled
		{ 
			get => this._l1.Count > 0;
		}

		public Plugboard()
		{
			this._l1 = new List<char>();
			this._l2 = new List<char>();
		}

		public void Add(char input, char output)
		{
			if(!char.IsLetter(input))
				throw new Exceptions.EnigmaPlugboardAddCharException("Input char is not valid letter.", input);
			if (!char.IsLetter(output))
				throw new Exceptions.EnigmaPlugboardAddCharException("Output char is not valid letter.", output);
			if (this.Exist(input))
				throw new Exceptions.EnigmaPlugboardAddCharException($"Input char with the same value has already been added: {input}", input);
			if (this.Exist(output))
				throw new Exceptions.EnigmaPlugboardAddCharException($"Output char with the same value has already been added: {input}", output);

			this._l1.Add(char.ToUpper(input));
			this._l2.Add(char.ToUpper(output));
		}

		public bool Exist(char @char) => this._l1.Contains(@char) || this._l2.Contains(@char);

		public char Get(char @char)
		{
			@char = char.ToUpper(@char);
			if (this._l1.Contains(@char))
				return _l2[_l1.IndexOf(@char)];
			if (this._l2.Contains(@char))
				return _l1[_l2.IndexOf(@char)];

			throw new Exceptions.EnigmaPlugboardException("Char not found.");
		}

		public void Clear()
		{
			this._l1.Clear();
			this._l2.Clear();
		}

	}

}
