namespace IceCreamDesktop.Core.Failures
{
	public class InvalidInputFailure : Failure
	{
		public InvalidInputFailure(string message = "Invalid Input") : base(message)
		{
		}
	}
}