using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class ANDGate : BaseComponent, ILogicComponent
    {
        
        /// <summary>
        /// Override the method to extract the result of the AND gate
        /// </summary>
        /// <param name="pin"> the output pin  </param>
        /// <returns> the AND gate result </returns>
        /// <exception cref="InvalidPinException"> throw if pin is invalid </exception>
        public override bool GetOutput(int pin)
        {
            // if output pin is invalid
            if (pin != 0)
            {
                throw new InvalidPinException(pin + " is not a valid output pin for AND");
            }
            else if(GetInput(0) && GetInput(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Override the connect function for this type
        /// </summary>
        /// <param name="outputPin"> output pin of this component </param>
        /// <param name="other"> the other logical component </param>
        /// <param name="inputPin"> the input pin of the other component </param>
        /// <exception cref="InvalidPinException"> throw if pin is invalid </exception>
        public override void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            BaseComponent component;
            if (outputPin != 0 && outputPin != 1 && inputPin != 0 && inputPin != 1)
            {
                throw new InvalidPinException();
            }
            try
            {
                component = (BaseComponent)other;
                component.INPUTS[inputPin].connect();  // connect to input
            }
            catch (Exception)
            {
                throw;
            }

            // save the connection in the list of outputs
            other.SetInput(inputPin, GetOutput(outputPin));
            outputs.Add(component);
            outputPins.Add(inputPin);
        }
    }
}
