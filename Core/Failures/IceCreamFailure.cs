using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Failures
{
    public class IceCreamFailure
    {
        public string Message { get; }

        public IceCreamFailure(string message)
        {
            Message = message;
        }
    }
}
