using System;

namespace IceCreamDesktop.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}