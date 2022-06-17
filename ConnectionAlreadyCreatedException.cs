using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class ConnectionAlreadyCreatedException : Exception
    {
        /// <summary>
        /// default message exception for already existant connection
        /// </summary>
        public ConnectionAlreadyCreatedException() : base("Connection exists") { }

        /// <summary>
        /// exception with custom message for already existant connection
        /// </summary>
        /// <param name="msg"> custom message</param>
        public ConnectionAlreadyCreatedException(String msg) : base(msg) { }

        /// <summary>
        /// exception with custom message and inner exception for already existant connection
        /// </summary>
        /// <param name="msg"> custom message </param>
        /// <param name="inner"> inner exception </param>
        public ConnectionAlreadyCreatedException(String msg, Exception inner) : base(msg, inner) { }
    }
}
