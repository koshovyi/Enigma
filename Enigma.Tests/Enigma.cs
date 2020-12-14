using System;
using Xunit;

namespace Enigma.Tests
{

	public class EnigmaTests
	{

		[Theory]
		[InlineData("W", 'C', 'U', 'Q', "A")]
		[InlineData("X", 'S', 'F', 'J', "A")]
		[InlineData("B", 'S', 'F', 'J', "T")]
		[InlineData("L", 'G', 'K', 'E', "O")]
		[InlineData("HBSVXM UFNPPOIY", 'C', 'U', 'Q', "dmytro koshovyi")]
		[InlineData("OYR YTHZH PPQKF VUI ALVMF LFWB BSN PYAT IWY", 'H', 'C', 'R', "The quick brown fox jumps over the lazy dog")]
		[InlineData("BOOTKLARXBEIJSCHNOORJETWAZWOSIBENXNOVXSECHSNULCBMXPROVIANTBISZWONULXDEZXBENOETIGEGLAESERYNOCHVIERKLARXSTEHEMARQUBRUNOBRUNOZWOFUNFXLAGEWIEJSCHAEFERJXNNNWWWFUNFYEINSFUNFMBSTEIGENDYGUTESICHTVVVJRASCH", 'A', 'Q', 'L', "utnbvfqxwpxycadckauxcvbmrnepfqlxtaucxjjzvngrmvpohwoyswyxcavphknxjmmthqcfwkxywornqrpmxjdnomwpyquledtgcgkpsipjeywqjcpzartfsdsbcsgouqphlqszadpurbbjmtuhlkzfgfzikcczmrgqshzosapwuawjflcvhzeddrxkjmsxdfdy")]
		public void Enigma_I_II_III(string exp, char left, char mid, char right, string enter)
		{
			//Arrange
			Enigma e = new Enigma();
			e.Rotors.Add(RotorType.Rotor_I, right);
			e.Rotors.Add(RotorType.Rotor_II, mid);
			e.Rotors.Add(RotorType.Rotor_III, left);
			e.Rotors.SetReflector(ReflectorType.UWK_B);

			//Act
			string result = e.Encrypt(enter);

			//Assert
			Assert.Equal(exp, result);
		}

		[Theory]
		[InlineData("W", 'C', 'Q', 'L', "A")]
		[InlineData("X", 'E', 'T', 'M', "G")]
		public void Enigma_III_II_I(string exp, char left, char mid, char right, string enter)
		{
			//Arrange
			Enigma e = new Enigma();
			e.Rotors.Add(RotorType.Rotor_III, right);
			e.Rotors.Add(RotorType.Rotor_II, mid);
			e.Rotors.Add(RotorType.Rotor_I, left);
			e.Rotors.SetReflector(ReflectorType.UWK_C);

			//Act
			string result = e.Encrypt(enter);

			//Assert
			Assert.Equal(exp, result);
		}

		[Theory]
		[InlineData("O", 'I', 'V', 'D', 'F', 'Y', "F")]
		[InlineData("B", 'B', 'H', 'U', 'P', 'T', "P")]
		[InlineData("MEHPXWIBWQXE", 'B', 'Q', 'L', 'A', 'K', "KOSHOVYIDIMA")]
		public void Enigma_I_II_III_Plugboard1(string exp, char left, char mid, char right, char pb1, char pb2, string enter)
		{
			//Arrange
			Enigma e = new Enigma();
			e.Rotors.Add(RotorType.Rotor_III, right);
			e.Rotors.Add(RotorType.Rotor_II, mid);
			e.Rotors.Add(RotorType.Rotor_I, left);
			e.Rotors.SetReflector(ReflectorType.UWK_B);
			e.Plugboard.Add(pb1, pb2);

			//Act	
			string result = e.Encrypt(enter);

			//Assert
			Assert.Equal(exp, result);
		}


		[Theory]
		[InlineData("RRJEVLDAWHEAVHUFBHUUCLFLISGYWEXFVYD", 'G', 'K', 'S', "THEQUICKBROWNFOXJUMPSOVERTHELAZYDOG")]
		public void Enigma_I_II_III_Plugboard2(string exp, char left, char mid, char right, string enter)
		{
			//Arrange
			Enigma e = new Enigma();
			e.Rotors.Add(RotorType.Rotor_III, right);
			e.Rotors.Add(RotorType.Rotor_II, mid);
			e.Rotors.Add(RotorType.Rotor_I, left);
			e.Rotors.SetReflector(ReflectorType.UWK_B);
			e.Plugboard.Add('D', 'N');
			e.Plugboard.Add('U', 'I');
			e.Plugboard.Add('Z', 'W');
			e.Plugboard.Add('J', 'O');

			//Act	
			string result = e.Encrypt(enter);

			//Assert
			Assert.Equal(exp, result);
		}

		/* Exceptions */

		[Fact]
		public void Enigma_ArgumentNullException()
		{
			//Arrange
			Enigma e = new Enigma();

			//Act && Arrange
			Assert.Throws<ArgumentNullException>(() => e.Encrypt(null));
		}

	}

}
