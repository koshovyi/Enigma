using System.Text;
using Xunit;

namespace Enigma.Tests
{

	public class RotorsTests
	{

		/// <summary>
		/// Keyboard -> Rotor I -> Rotor II -> Rotor III
		/// </summary>
		[Theory]
		[InlineData('C', 'U', 'Q', 'A')]
		public void Rotors_From_Right_To_Left_I_II_III(char left, char mid, char right, char enter)
		{
			//Arrange
			Rotor rotRight = HistoricData.EnigmaI.I;
			Rotor rotMid = HistoricData.EnigmaI.II;
			Rotor rotLeft = HistoricData.EnigmaI.III;

			rotRight.SetHead(right);
			rotRight.IsFirst = true;
			rotMid.SetHead(mid);
			rotLeft.SetHead(left);

			rotRight.Prev = rotMid;
			rotMid.Next = rotRight;
			rotMid.Prev = rotLeft;
			rotLeft.Next = rotMid;

			//Act
			char fr1 = rotRight.Enter(enter);
			char fr2 = rotMid.Enter(fr1);
			char fr3 = rotLeft.Enter(fr2);

			//Assert
			Assert.Equal('U', fr1);
			Assert.Equal('O', fr2);
			Assert.Equal('M', fr3);
		}

		/// <summary>
		/// Reflector -> Rotor III -> Rotor II -> Rotor I -> 
		/// </summary>
		[Theory]
		[InlineData('C', 'V', 'R', 'N')]
		public void Rotors_From_Left_To_Right_III_II_I(char left, char mid, char right, char enter)
		{
			//Arrange
			Rotor rotRight = HistoricData.EnigmaI.I;
			Rotor rotMid = HistoricData.EnigmaI.II;
			Rotor rotLeft = HistoricData.EnigmaI.III;
			rotRight.SetHead(right);
			rotMid.SetHead(mid);
			rotLeft.SetHead(left);

			rotRight.Prev = rotMid;
			rotMid.Next = rotRight;
			rotMid.Prev = rotLeft;
			rotLeft.Next = rotMid;

			//Act
			char fr3 = rotLeft.Reverse(enter);
			char fr2 = rotMid.Reverse(fr3);
			char fr1 = rotRight.Reverse(fr2);

			//Assert
			Assert.Equal('H', fr3);
			Assert.Equal('A', fr2);
			Assert.Equal('N', fr1);
		}

		/// <summary>
		/// Keyboard -> Rotor I -> Rotor II -> Rotor III -> Reflector -> Rotor III -> Rotor II -> Rotor I -> 
		/// </summary>
		[Theory]
		[InlineData('C', 'U', 'Q', 'A')]
		public void Rotors_FullWay_Letter_By_Letter(char left, char mid, char right, char enter)
		{
			//Arrange
			Rotor rotRight = HistoricData.EnigmaI.I;
			Rotor rotMid = HistoricData.EnigmaI.II;
			Rotor rotLeft = HistoricData.EnigmaI.III;
			Rotor rotReflector = HistoricData.Reflectors.ReflectorB;

			rotRight.IsFirst = true;
			rotRight.SetHead(right);
			rotMid.SetHead(mid);
			rotLeft.SetHead(left);

			rotReflector.Prev = rotLeft;
			rotRight.Prev = rotMid;
			rotMid.Next = rotRight;
			rotMid.Prev = rotLeft;
			rotLeft.Next = rotMid;

			//To reflector
			char fr1 = rotRight.Enter(enter);
			char fr2 = rotMid.Enter(fr1);
			char fr3 = rotLeft.Enter(fr2);

			//Reflector
			char fr_ref = rotReflector.Reverse(fr3);

			//From reflector
			char fr4 = rotLeft.Reverse(fr_ref);
			char fr5 = rotMid.Reverse(fr4);
			char fr6 = rotRight.Reverse(fr5);

			//Assert
			Assert.Equal('U', fr1);
			Assert.Equal('O', fr2);
			Assert.Equal('M', fr3);
			Assert.Equal('N', fr_ref);
			Assert.Equal('H', fr4);
			Assert.Equal('A', fr5);
			Assert.Equal('N', fr6);
		}

		/// <summary>
		/// Keyboard -> Rotor I -> Rotor II -> Rotor III -> Reflector -> Rotor III -> Rotor II -> Rotor I -> 
		/// </summary>
		[Theory]
		[InlineData('W', 'C', 'U', 'Q', 'A')]
		[InlineData('X', 'S', 'F', 'J', 'A')]
		[InlineData('B', 'S', 'F', 'J', 'T')]
		[InlineData('L', 'G', 'K', 'E', 'O')]
		public void Rotors_FullWay(char exp, char left, char mid, char right, char enter)
		{
			//Arrange
			Rotor rotRight = HistoricData.EnigmaI.I;
			Rotor rotMid = HistoricData.EnigmaI.II;
			Rotor rotLeft = HistoricData.EnigmaI.III;
			Rotor rotReflector = HistoricData.Reflectors.ReflectorB;
			Rotor rotKeyboard = HistoricData.Keyboard;

			rotRight.SetHead(right);
			rotRight.IsFirst = true;
			rotMid.SetHead(mid);
			rotLeft.SetHead(left);

			rotReflector.Prev = rotLeft;
			rotKeyboard.Prev = rotRight;

			rotRight.Prev = rotMid;
			rotMid.Next = rotRight;
			rotMid.Prev = rotLeft;
			rotLeft.Next = rotMid;

			//To reflector
			char fr1 = rotRight.Enter(enter);
			char fr2 = rotMid.Enter(fr1);
			char fr3 = rotLeft.Enter(fr2);

			//Reflector	
			char fr_ref = rotReflector.Reverse(fr3);

			//From reflector
			char fr4 = rotLeft.Reverse(fr_ref);
			char fr5 = rotMid.Reverse(fr4);
			char fr6 = rotRight.Reverse(fr5);

			//Result
			char result = rotKeyboard.Reverse(fr6);

			//Assert
			Assert.Equal(exp, result);
		}

		/// <summary>
		/// Keyboard -> Rotor I -> Rotor II -> Rotor III -> Reflector -> Rotor III -> Rotor II -> Rotor I -> 
		/// </summary>
		[Theory]
		[InlineData("HBSVXM UFNPPOIY", 'C', 'U', 'Q', "dmytro koshovyi")]
		[InlineData("OYR YTHZH PPQKF VUI ALVMF LFWB BSN PYAT IWY", 'H', 'C', 'R', "The quick brown fox jumps over the lazy dog")]
		[InlineData("BOOTKLARXBEIJSCHNOORJETWAZWOSIBENXNOVXSECHSNULCBMXPROVIANTBISZWONULXDEZXBENOETIGEGLAESERYNOCHVIERKLARXSTEHEMARQUBRUNOBRUNOZWOFUNFXLAGEWIEJSCHAEFERJXNNNWWWFUNFYEINSFUNFMBSTEIGENDYGUTESICHTVVVJRASCH", 'A', 'Q', 'L', "utnbvfqxwpxycadckauxcvbmrnepfqlxtaucxjjzvngrmvpohwoyswyxcavphknxjmmthqcfwkxywornqrpmxjdnomwpyquledtgcgkpsipjeywqjcpzartfsdsbcsgouqphlqszadpurbbjmtuhlkzfgfzikcczmrgqshzosapwuawjflcvhzeddrxkjmsxdfdy")]
		public void Rotors_FullWay_Text(string exp, char left, char mid, char right, string enter)
		{
			//Arrange
			Rotor rotRight = HistoricData.EnigmaI.I;
			Rotor rotMid = HistoricData.EnigmaI.II;
			Rotor rotLeft = HistoricData.EnigmaI.III;
			Rotor rotReflector = HistoricData.Reflectors.ReflectorB;
			Rotor rotKeyboard = HistoricData.Keyboard;

			rotRight.SetHead(right);
			rotRight.IsFirst = true;
			rotMid.SetHead(mid);
			rotLeft.SetHead(left);

			rotReflector.Prev = rotLeft;
			rotKeyboard.Prev = rotRight;

			rotRight.Prev = rotMid;
			rotMid.Next = rotRight;
			rotMid.Prev = rotLeft;
			rotLeft.Next = rotMid;

			StringBuilder sb = new StringBuilder();
			foreach (char c in enter.ToCharArray())
			{
				if (char.IsLetter(c))
				{
					//To reflector
					char fr1 = rotRight.Enter(c);
					char fr2 = rotMid.Enter(fr1);
					char fr3 = rotLeft.Enter(fr2);

					//Reflector	
					char fr_ref = rotReflector.Reverse(fr3);

					//From reflector
					char fr4 = rotLeft.Reverse(fr_ref);
					char fr5 = rotMid.Reverse(fr4);
					char fr6 = rotRight.Reverse(fr5);

					//Result
					char result = rotKeyboard.Reverse(fr6);
					sb.Append(result);
				}
				else
					sb.Append(c);
			}

			//Assert
			Assert.Equal(exp, sb.ToString());
		}


	}

}
