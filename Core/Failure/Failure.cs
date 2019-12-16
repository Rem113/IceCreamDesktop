using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Failures
{
    public abstract class Failure
    {
        public string Message { get; }

        public Failure(string message)
        {
            Message = message;
        }
    }
}
