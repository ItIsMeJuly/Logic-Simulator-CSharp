using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class FULLAdder : BaseComponent
    {
        private XORGate firstXOR =  new XORGate();
        private XORGate secondXOR = new XORGate();
        private ANDGate firstAND = new ANDGate();
        private ANDGate secondAND = new ANDGate();
        private ORGate firstOR = new ORGate();

        /// <summary>
        /// constructor to create a FullAdder
        /// </summary>
        public FULLAdder()
        {
            // reinitialize inputs because it has 3 input pins
            inputs = new List<Connection>() { new Connection(), new Connection(), new Connection() };

            // set connections
            firstXOR.ConnectOutput(0, secondXOR, 0);
            firstXOR.ConnectOutput(0, firstAND, 0);
            firstAND.ConnectOutput(0, firstOR, 0);
            secondAND.ConnectOutput(0, firstOR, 1);
        }

        /// <summary>
        /// Override method because we have 3 input instead of 2. Return input pin state
        /// </summary>
        /// <param name="pin"> input pin </param>
        /// <returns> the state of the input pin </returns>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid </exception>
        public override bool GetInput(int pin)
        {
            switch (pin)
            {
                case 0:
                    return firstXOR.GetInput(0);

                case 1:
                    return firstXOR.GetInput(1);

                case 2:
                    return firstAND.GetInput(0);

                default:
                    throw new InvalidPinException(pin + " is not a valid output pin for FULLAdder");
            }
        }

        /// <summary>
        /// Override GetOutput because it has two outputs instead of 1
        /// </summary>
        /// <param name="pin"></param>
        /// <returns> the state of the output pin</returns>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid </exception>
        public override bool GetOutput(int pin)
        {
            switch (pin) {
                case 0:
                    return secondXOR.GetOutput(0);

                case 1:
                    return firstOR.GetOutput(0);

                default:
                    throw new InvalidPinException(pin + " is not a valid output pin for FULLAdder");
            }
        }

        /// <summary>
        /// Override SetInput because it has more inputs than the base class
        /// </summary>
        /// <param name="pin"> input pin to be set </param>
        /// <param name="value"> value to set </param>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid</exception>
        public override void SetInput(int pin, bool value)
        {
            switch (pin)
            {
                // case 0 an 1 are the same so we type them as follows
                case 0:
                case 1:
                    firstXOR.SetInput(pin, value);
                    secondAND.SetInput(pin, value);
                    break;
                case 2:
                    secondXOR.SetInput(1, value);
                    firstAND.SetInput(1, value);
                    break;
                default:
                    throw new InvalidPinException(pin + " is not a valid input pin for FULLAdder");

            }

        }

        /// <summary>
        /// Override the connection function to connect to other components
        /// </summary>
        /// <param name="outputPin"> output pin of this component to connect</param>
        /// <param name="other"> other component </param>
        /// <param name="inputPin"> input pin of the other component to connect to</param>
        /// <exception cref="InvalidPinException">thrown if input pin is invalid</exception>
        public override void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {

            switch (outputPin)
            {
                case 0:
                    secondXOR.ConnectOutput(0, other, inputPin);
                    break;
                case 1:
                    firstOR.ConnectOutput(0, other, inputPin);
                    break;
                default:
                    throw new InvalidPinException(outputPin + " is not a valid input pin for FULLAdder");
            }
        }

    }
}
