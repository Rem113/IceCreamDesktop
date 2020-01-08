﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Exceptions
{
    public class NotAllowedException : Exception
    {
        public NotAllowedException() : base()
        {
        }

        public NotAllowedException(string message) : base(message)
        {
        }
    }
}
