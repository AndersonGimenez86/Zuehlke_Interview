using System;

namespace Interview
{
	public class InvalidRomanNumericalException : Exception
	{
		private const string BaseMessage = "Invalid Roman Numerical were inputed: ";
		public InvalidRomanNumericalException(char invalidNumeral) : base(BaseMessage + invalidNumeral)
		{
		}

		public InvalidRomanNumericalException(string message) : base(message)
		{
		}
	}
}
