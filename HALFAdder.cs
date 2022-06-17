using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class HALFAdder : BaseComponent
    {
        private ANDGate and = new ANDGate();
        private XORGate xor = new XORGate();

        public HALFAdder()
        {
            // re-initialize the inputs because it has 3 instead of 2 as the base class
            inputs = new List<Connection>() { new Connection(), new Connection(), new Connection() };
        }

        /// <summary>
        /// Method to get the input of a pin
        /// </summary>
        /// <param name="pin"> one of the input pins of the component </param>
        /// <returns> the state of the pin</returns>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid</exception>
        public override bool GetInput(int pin)
        {
            if (pin != 0 && pin != 1)
            {
                throw new InvalidPinException(pin + " is not a valid input pin for HALFAdder");
            }
            else if (pin == 0)
            {
                return and.GetInput(pin);
            }
            else
            {
                return and.GetInput(pin);
            }
        }

        /// <summary>
        /// Method to get the state of an output pin
        /// </summary>
        /// <param name="pin"> one of the output pins for this component</param>
        /// <returns> the state of the output pin</returns>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0 && pin != 1)
            {
                throw new InvalidPinException(pin + " is not a valid output pin for HALFAdder");
            }
            else if (pin == 0)
            {
                return xor.GetOutput(0);
            }
            else
            {
                return and.GetOutput(0);
            }
        }


        /// <summary>
        /// A method to set the state of one of the input pins on this component
        /// </summary>
        /// <param name="pin"> one of the input pins</param>
        /// <param name="value"> the value to be set </param>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid</exception>
        public override void SetInput(int pin, bool value)
        {
            if (pin != 0 && pin != 1)
            {
                throw new InvalidPinException(pin + " is not a valid input pin for HALFAdder");
            }
                this.and.SetInput(pin, value);
                this.xor.SetInput(pin, value);
            
        }


        /// <summary>
        /// A method to connect to other components
        /// </summary>
        /// <param name="outputPin">one of the output pins on this component</param>
        /// <param name="other"> the other component to connect to</param>
        /// <param name="inputPin"> one of the other component's input pin</param>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid</exception>
        public override void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            if (outputPin.Equals(0))
            {
                xor.ConnectOutput(0, other, inputPin);
            }
            else
            {
                and.ConnectOutput(0, other, inputPin);
            }
        }

    }
}
