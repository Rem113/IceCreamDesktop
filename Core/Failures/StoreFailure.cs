namespace IceCreamDesktop.Core.Failures
{
    public class StoreFailure : Failure
    {
        public string Message { get; }

        public StoreFailure(string message)
        {
            Message = message;
        }
    }
}
