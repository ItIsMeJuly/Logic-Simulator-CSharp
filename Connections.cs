using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Connection
    {
        private bool connected; // flag to save it is connected

        /// <summary>
        /// method to set a connection of current pin
        /// </summary>
        /// <exception cref="ConnectionAlreadyCreatedException"> thrown if we try to connect second input </exception>
        public void connect()
        {
            if (!connected)
            {
                connected = true;
            }
            else
            {
                throw new ConnectionAlreadyCreatedException();
            }
        }
    }
}
