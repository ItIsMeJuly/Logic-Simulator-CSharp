using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class ORGate : BaseComponent , ILogicComponent
    {

        /// <summary>
        /// Get the state of the output pin 
        /// </summary>
        /// <param name="pin">the output pin</param>
        /// <returns>the state of the output pin</returns>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0)
            {
                throw new InvalidPinException(pin + " is not a valid output pin for OR");
            }
            else if (GetInput(0) || GetInput(1))
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
        /// <param name="outputPin">output pin of this component</param>
        /// <param name="other"> the other component to connect to</param>
        /// <param name="inputPin"> one of the input pins of the other component</param>
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
                // connect to the input pin
                component = (BaseComponent)other;
                component.INPUTS[inputPin].connect();
            }
            catch (Exception)
            {
                throw;
            }
            // set the input of the other component and save the connection
            other.SetInput(inputPin, GetOutput(outputPin));
            outputs.Add(component);
            outputPins.Add(inputPin);
        }
    }
}
