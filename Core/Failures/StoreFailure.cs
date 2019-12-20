namespace IceCreamDesktop.Core.Failures
{
    public class StoreFailure
    {
        public string Message { get; }

        public StoreFailure(string message)
        {
            Message = message;
        }
    }
}
