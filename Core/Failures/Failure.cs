namespace IceCreamDesktop.Core.Failures
{
	public abstract class Failure
	{
		public string Message { get; set; }

		public Failure(string message)
		{
			if (string.IsNullOrEmpty(message))
				Message = "An error has occured";
			else Message = message;
		}
	}
}