namespace Enigma
{

	public static class HistoricData
	{

		/// <summary>
		/// Keyboard
		/// </summary>
		public static Rotor Keyboard
		{
			get => new Rotor(RotorType.Keyboard, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
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
				get => new Rotor(RotorType.Rotor_I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
				{
					Notch = 'Y',
					Turnover = 'Q',
				};
			}

			public static Rotor II
			{
				get => new Rotor(RotorType.Rotor_II, "AJDKSIRUXBLHWTMCQGZNPYFVOE")
				{
					Notch = 'M',
					Turnover = 'E',
				};
			}

			public static Rotor III
			{
				get => new Rotor(RotorType.Rotor_III, "BDFHJLCPRTXVZNYEIWGAKMUSQO")
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
				get => new Rotor(RotorType.Reflector, "EJMZALYXVBWFCRQUONTSPIKHGD");
			}


			public static Rotor ReflectorB
			{
				get => new Rotor(RotorType.Reflector, "YRUHQSLDPXNGOKMIEBFZCWVJAT");
			}

			public static Rotor ReflectorC
			{
				get => new Rotor(RotorType.Reflector, "FVPJIAOYEDRZXWGCTKUQSBNMHL");
			}

		}

	}

}
