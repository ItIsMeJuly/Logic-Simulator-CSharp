using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class InvalidPinException : Exception
    {
        /// <summary>
        /// Default exception with default message
        /// </summary>
        public InvalidPinException() : base("Invalid Pin") { }

        /// <summary>
        /// Exception for invalid pin with custom message
        /// </summary>
        /// <param name="msg">the message of the exception</param>
        public InvalidPinException(String msg) : base(msg) { }

        /// <summary>
        /// Exception for invalid pin with custom message and inner exception
        /// </summary>
        /// <param name="msg">the message of the exception</param>
        /// <param name="inner">the inner exception</param>
        public InvalidPinException(String msg, Exception inner) : base(msg, inner) { }
    }
}
