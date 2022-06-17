using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class XORGate : BaseComponent, ILogicComponent
    {

        
        /// <summary>
        /// Returns the state of the output pin
        /// </summary>
        /// <param name="pin">the output pin of this component</param>
        /// <returns>the state of the output pin</returns>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0)
            {
                throw new InvalidPinException(pin + " is not a valid output pin");
            }

            if ((GetInput(0) == true && GetInput(1) == false) || (GetInput(0) == false && GetInput(1) == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Connect an output of this component to an input of another component.
        /// Allows multiple connections from the same output to other output pins
        /// </summary>
        /// <param name="outputPin">the output pin of this component</param>
        /// <param name="other">the other componnet to connect to</param>
        /// <param name="inputPin">the input pin of the other component to connect to</param>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            BaseComponent component;
            if (outputPin != 0 && outputPin != 1 && inputPin != 0 && inputPin != 1)
            {
                throw new InvalidPinException();
            }
            try
            {
                // connect to the pin of the other componnet
                component = (BaseComponent)other;
                component.INPUTS[inputPin].connect();
            }
            catch (Exception)
            {
                throw;
            }
            // set the input pin of the other component with the value of the output pin
            // and save the connection from this output pin
            other.SetInput(inputPin, GetOutput(outputPin));
            outputs.Add(component);
            outputPins.Add(inputPin);
        }
    }
}
