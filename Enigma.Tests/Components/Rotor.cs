using Xunit;

namespace Enigma.Tests
{
	public class RotorTests
	{

		[Theory]
		[InlineData('U', 'R')]
		[InlineData('Z', 'J')]
		public void Rotor_RotorI_GetFromAlphabet(char exp, char @char)
		{
			//Arrange
			Rotor r = HistoricData.EnigmaI.I;

			//Act
			char result = r.GetFromAlphabet(@char);

			//Assert
			Assert.Equal(exp, result);
		}

		[Theory]
		[InlineData('A', 'Z')]
		[InlineData('B', 'A')]
		[InlineData('D', 'C')]
		[InlineData('F', 'E')]
		public void Rotor_RotorI_Rotate(char exp, char head)
		{
			//Arrange
			Rotor r = HistoricData.EnigmaI.I;
			r.SetHead(head);

			//Act
			r.Rotate();

			//Assert
			Assert.Equal(exp, r.Current);
		}

		[Theory]
		[InlineData('U', 'Q', 'R')]
		[InlineData('N', 'X', 'K')]
		public void Rotor_RotorI_Enter(char exp, char head, char @char)
		{
			//Arrange
			Rotor r = HistoricData.EnigmaI.I;
			r.IsFirst = true;
			r.SetHead(head);

			//Act
			char result = r.Enter(@char);

			//Assert
			Assert.Equal(exp, result);
		}

		[Theory]
		[InlineData('L', 'G', 'F')]
		//[InlineData('M', 'X', 'X')]
		public void Rotor_ReflectorB_Enter(char exp, char @char, char head)
		{
			//Arrange
			Rotor r = HistoricData.Reflectors.ReflectorB;
			Rotor left = HistoricData.EnigmaI.I;
			left.SetHead(head);

			//Act
			char result = r.Enter(@char);

			//Assert
			Assert.Equal(exp, result);
		}

	}
}
