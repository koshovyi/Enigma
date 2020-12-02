using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Tests")]

namespace Enigma
{

	/// <summary>
	/// Enigma Machine emulator
	/// </summary>
	public class Enigma
	{

		public Rotors Rotors { get; set; }

		public Enigma()
		{
			this.Rotors = new Rotors();
		}

		public string Encrypt(string data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			StringBuilder sb = new StringBuilder();
			foreach (char d in data.ToCharArray())
				if (char.IsLetter(d))
					sb.Append(this.Rotors.Enter(d));
				else
					sb.Append(d);
			return sb.ToString();
		}

	}

}
