namespace Enigma
{

	public static class HistoricData
	{

		/// <summary>
		/// Keyboard
		/// </summary>
		public static Rotor Keyboard
		{
			get => new Rotor(Type.Keyboard, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
			{
				Notch = '\0',
				Turnover = '\0',
			};
		}

		/// <summary>
		/// Enigma I
		/// </summary>
		public static class EnigmaI
		{

			public static Rotor I
			{
				get => new Rotor(Type.Rotor, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
				{
					Notch = 'Y',
					Turnover = 'Q',
				};
			}

			public static Rotor II
			{
				get => new Rotor(Type.Rotor, "AJDKSIRUXBLHWTMCQGZNPYFVOE")
				{
					Notch = 'M',
					Turnover = 'E',
				};
			}

			public static Rotor III
			{
				get => new Rotor(Type.Rotor, "BDFHJLCPRTXVZNYEIWGAKMUSQO")
				{
					Notch = 'D',
					Turnover = 'V',
				};
			}

		}

		/// <summary>
		/// Reflectors
		/// </summary>
		public static class Reflectors
		{

			public static Rotor ReflectorA
			{
				get => new Rotor(Type.Reflector, "EJMZALYXVBWFCRQUONTSPIKHGD");
			}


			public static Rotor ReflectorB
			{
				get => new Rotor(Type.Reflector, "YRUHQSLDPXNGOKMIEBFZCWVJAT");
			}

			public static Rotor ReflectorC
			{
				get => new Rotor(Type.Reflector, "FVPJIAOYEDRZXWGCTKUQSBNMHL");
			}

		}

	}

}
