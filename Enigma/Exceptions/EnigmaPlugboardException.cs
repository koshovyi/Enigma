using System;

namespace Enigma.Exceptions
{
	public class EnigmaPlugboardException : Exception
	{
		public EnigmaPlugboardException() : base("Plugboard general error.")
		{
		}

		public EnigmaPlugboardException(string message) : base(message)
		{
		}
	}

	public class EnigmaPlugboardAddCharException : EnigmaPlugboardException
	{

		public char Char { get; set; }

		public EnigmaPlugboardAddCharException(string message, char @char) : base(message)
		{
			this.Char = @char;
		}

	}

	public class EnigmaPlugboardAddPairException : EnigmaPlugboardException
	{

		public string Pair { get; set; }

		public EnigmaPlugboardAddPairException(string message, string pair) : base(message)
		{
			this.Pair = pair;
		}

	}

}
