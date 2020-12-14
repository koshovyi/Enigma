using System;
using Xunit;

namespace Enigma.Tests
{
	public class PlugboardTests
	{

		[Theory]
		[InlineData(true, 'A', 'Z')]
		[InlineData(true, 'B', 'F')]
		public void PlugboardGet(bool exp, char input, char output)
		{
			//Arrange
			Plugboard p = new Plugboard();
			p.Add(input, output);

			//Act
			char result1 = p.Get(output);
			char result2 = p.Get(input);

			//Assert
			Assert.Equal(exp, p.Exist(input));
			Assert.Equal(exp, p.Exist(output));
			Assert.Equal(result1, input);
			Assert.Equal(result2, output);
		}

		/* Exceptions */

		[Fact]
		public void Plugboard_Exception_EnigmaPlugboardAddCharException()
		{
			//Arrange
			Plugboard p = new Plugboard();

			//Act && Assert
			Assert.Throws<Exceptions.EnigmaPlugboardAddCharException>(() => p.Add('1', 'A'));
			Assert.Throws<Exceptions.EnigmaPlugboardAddCharException>(() => p.Add('A', '1'));
		}

	}
}
