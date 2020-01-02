using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
