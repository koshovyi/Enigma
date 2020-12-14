using System;

namespace Enigma
{

	public static class Common
	{

		public static char[] ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

		public const int MODULO_MAX_LETTERS = 26;

		public static char CharPlusN(int c, int n) => ALPHABET[(c + n) % MODULO_MAX_LETTERS];

		public static int Mod(int f, int t) => (Math.Abs((f - t) * MODULO_MAX_LETTERS) + (f - t)) % MODULO_MAX_LETTERS;

	}

}
