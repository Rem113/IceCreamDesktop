using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Failures
{
    public class DataAccessFailure : Failure
    {
        public DataAccessFailure(string message = "DataAccessFailure") : base(message) { }
    }
}
