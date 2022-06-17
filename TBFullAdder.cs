using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class TBFullAdder : BaseComponent
    {
        private HALFAdder firstHALF = new HALFAdder();
        private FULLAdder firstFULL = new FULLAdder();
        private FULLAdder secondFull = new FULLAdder();

        /// <summary>
        /// Default constructor to reinitialize the inputs as there are 3 instead of 2. Establish
        /// connections between internal components
        /// </summary>
        public TBFullAdder()
        {
            inputs = new List<Connection>() { new Connection(), new Connection(), new Connection() };
            firstHALF.ConnectOutput(1, firstFULL, 2);
            firstFULL.ConnectOutput(1, secondFull, 2);
        }

        /// <summary>
        /// Get the state of one of the input pins depending on the bit number and pin
        /// </summary>
        /// <param name="pin">the pin of the 1 bit adder for the first or second number</param>
        /// <param name="bit"> the number of the bit you want to set</param>
        /// <returns>the state of the input pin</returns>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public bool GetInput(int pin, int bit)
        {
            switch (bit)
            {
                case 0:
                    switch (pin)
                    {
                        case 0:
                            return firstHALF.GetInput(bit);
                        case 1:
                            return firstHALF.GetInput(bit);
                        case 2:
                            return firstHALF.GetInput(bit);
                        default:
                            throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
                    }

                case 1:
                    switch (pin)
                    {
                        case 0:
                            return firstFULL.GetInput(bit);
                        case 1:
                            return firstFULL.GetInput(bit);
                        case 2:
                            return firstFULL.GetInput(bit);
                        default:
                            throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
                    }

                case 2:
                    switch (pin)
                    {
                        case 0:
                            return secondFull.GetInput(bit);
                        case 1:
                            return secondFull.GetInput(bit);
                        case 2:
                            return secondFull.GetInput(bit);
                        default:
                            throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
                    }

                default:
                    throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
            }
        }


        public override bool GetOutput(int pin) { throw new NotImplementedException(); }

        /// <summary>
        /// Get the output of a 1bit adder depending on the pin and the number of the bit
        /// </summary>
        /// <param name="pin">the output pin for the sum of bit1[pin] and bit2[pin]</param>
        /// <param name="bit">the number of the bit</param>
        /// <returns>the state of the output pin</returns>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public bool GetOutput(int pin, int bit)
        {
            switch (bit)
            {
                case 0:
                    switch (pin)
                    {
                        case 0:
                            return firstHALF.GetOutput(pin);
                        case 1:
                            return firstHALF.GetOutput(pin);
                        default:
                            throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
                    }

                case 1:
                    switch (pin)
                    {
                        case 0:
                            return firstFULL.GetOutput(pin);
                        case 1:
                            return firstFULL.GetOutput(pin);
                        default:
                            throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
                    }
                case 2:
                    switch (pin)
                    {
                        case 0:
                            return secondFull.GetOutput(pin);
                        case 1:
                            return secondFull.GetOutput(pin);
                        default:
                            throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
                    }

                default:
                    throw new InvalidPinException(pin + " is not a valid output pin for TBFullAdder");
            }
        }
        
        /// <summary>
        /// A method to set the input on one of the pins depending on the number of the bit
        /// </summary>
        /// <param name="pin">the pin to set</param>
        /// <param name="bit">the number of the bit </param>
        /// <param name="value">the value to set </param>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public void SetInput(int pin, int bit, bool value)
        {
            switch (bit)
            {
                
                case 0:
                    switch (pin)
                    {
                        case 0:
                            firstHALF.SetInput(pin, value);
                            break;
                        case 1:
                            firstHALF.SetInput(pin, value);
                            break;
                        case 2:
                            firstHALF.SetInput(pin, value);
                            break;
                        default:
                            throw new InvalidPinException(pin + " is not a valid input pin for TBFullAdder");
                    }

                    break;
                case 1:
                    switch(pin)
                    {
                        case 0:
                            firstFULL.SetInput(pin, value);
                            break;
                        case 1:
                            firstFULL.SetInput(pin, value);
                            break;
                        default:
                            throw new InvalidPinException(pin + " is not a valid input pin for TBFullAdder");
            }
            break;
                case 2:
                    switch(pin)
                    {
                        case 0:
                            secondFull.SetInput(pin, value);
                            break;
                        case 1:
                            secondFull.SetInput(pin, value);
                            break;
                        default:
                            throw new InvalidPinException(pin + " is not a valid input pin for TBFullAdder");
                    }
                    break;
                default:
                    throw new InvalidPinException(pin + " is not a valid input pin for TBFullAdder");
            }

        }

        public override void ConnectOutput(int inputPin, ILogicComponent other, int outputPin)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connect an output of this component to an input of another component.
        /// Allows multiple connections from the same output to other output pins
        /// </summary>
        /// <param name="outputPin">the output pin of this component</param>
        /// <param name="bit">the number of the bit we want to connect</param>
        /// <param name="other">the other component to connect to</param>
        /// <param name="inputPin">the input pin of the other componnet to connect to</param>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public void ConnectOutput(int outputPin, int bit, ILogicComponent other, int inputPin)
        {

            switch (bit)
            {
                case 0:
                    switch (outputPin)
                    {
                        case 0:
                            firstHALF.ConnectOutput(outputPin, other, inputPin);
                            break;
                        case 1:
                            firstHALF.ConnectOutput(outputPin, other, inputPin);
                            break;
                        default:
                            throw new InvalidPinException(outputPin + " is not a valid input pin for TBFullAdder");
                    }
                    break;
                case 1:
                    switch (outputPin)
                    {
                        case 0:
                            firstFULL.ConnectOutput(outputPin, other, inputPin);
                            break;
                        case 1:
                            firstFULL.ConnectOutput(outputPin, other, inputPin);
                            break;
                        default:
                            throw new InvalidPinException(outputPin + " is not a valid input pin for TBFullAdder");
                    }
                    break;
                case 2:
                    switch (outputPin)
                    {
                        case 0:
                            secondFull.ConnectOutput(outputPin, other, inputPin);
                            break;
                        case 1:
                            secondFull.ConnectOutput(outputPin, other, inputPin);
                            break;
                        default:
                            throw new InvalidPinException(outputPin + " is not a valid input pin for TBFullAdder");
                    }
                    break;
                default:
                    throw new InvalidPinException(outputPin + " is not a valid input pin for TBFullAdder");
            }
        }
    }
}
