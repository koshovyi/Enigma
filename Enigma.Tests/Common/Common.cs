using Xunit;

namespace Enigma.Tests
{
	public class CommonTests
	{

		[Theory]
		[InlineData(0, 'A')]
		[InlineData(17, 'R')]
		[InlineData(25, 'Z')]
		public void GetIndexFromAlphabet(int index, char @char)
		{
			//Arrange

			//Act
			int result = Rotor.GetAlphabetCharIndex(@char);

			//Assert
			Assert.Equal(index, result);
		}

		[Theory]
		[InlineData(4, 'V', 'R')]
		[InlineData(7, 'C', 'V')]
		public void Mod(int mod, char from, char to)
		{
			//Arrange
			int f = Rotor.GetAlphabetCharIndex(from);
			int t = Rotor.GetAlphabetCharIndex(to);

			//Act
			int result = Common.Mod(f, t);

			//Assert
			Assert.Equal(mod, result);
		}

		[Theory]
		[InlineData('Y', 'U', 4)]
		[InlineData('A', 'Z', 1)]
		[InlineData('Z', 'A', 25)]
		public void CharPlusN(char exp, char @char, int n)
		{
			//Arrange
			int index = Rotor.GetAlphabetCharIndex(@char);

			//Act
			char result = Common.CharPlusN(index, n);

			//Assert
			Assert.Equal(exp, result);
		}

	}
}
