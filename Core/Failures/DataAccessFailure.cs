namespace IceCreamDesktop.Core.Failures
{
	public class DataAccessFailure : Failure
	{
		public DataAccessFailure(string message = "Data Access Failure") : base(message)
		{
		}
	}
}