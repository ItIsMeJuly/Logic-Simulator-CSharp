using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class NOTGate : BaseComponent, ILogicComponent
    {
        /// <summary>
        /// Default constructor to reinitialize the input and values as the NOT Gate has just one input and output
        /// </summary>
        public NOTGate() : base()
        {
            values = new List<bool>() {false};
            inputs = new List<Connection>() { new Connection(), new Connection() };
            outputs = new List<BaseComponent>();
            outputPins = new List<int>();
        }


        /// <summary>
        /// Get the state of the input pin. Override this method because not is 
        /// different from the other gates in terms of inputs
        /// </summary>
        /// <param name="pin">the input pin</param>
        /// <returns>the state of the input pin</returns>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override bool GetInput(int pin)
        {
            if (pin != 0)
            {
                throw new InvalidPinException(pin + " is not a valid input pin for NOT");
            }
            return values[0];
        }

        /// <summary>
        /// Get the state of the output pin. Override this method because not is 
        /// different from the other gates in terms of inputs
        /// </summary>
        /// <param name="pin">output pin</param>
        /// <returns>the state of the output pin</returns>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0)
            {
                throw new InvalidPinException(pin + " is not a valid output pin for NOT");
            }
            return !values[0];
        }

        /// <summary>
        /// Set the state of the input pin. Override the method because it has only one input pin
        /// </summary>
        /// <param name="pin">input pin of this component</param>
        /// <param name="value">value to be set on the pin</param>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override void SetInput(int pin, bool value)
        {
            if (pin != 0)
            {
                throw new InvalidPinException(pin + " is not a valid output pin for NOT");
            }
            this.values[0] = value;
            if (outputs.Count > 0)
            {
                // update all connections recursively after a set input
                for (int i = 0; i < outputs.Count; i++)
                {
                    outputs[i].SetInput(outputPins[i], GetOutput(0));
                }
            }

        }

        /// <summary>
        /// Connect an output of this component to an input of another component.
        /// Allows multiple connections from the same output to other output pins
        /// </summary>
        /// <param name="outputPin">the output pin of this component</param>
        /// <param name="other"> the other component</param>
        /// <param name="inputPin"> the input pin of the other component</param>
        /// <exception cref="InvalidPinException">throw if pin is invalid</exception>
        public override void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            if (outputPin != 0 && outputPin != 1 && inputPin != 0 && inputPin != 1)
            {
                throw new InvalidPinException();
            }
            BaseComponent component;
            try
            {
                // connect to the other pin
                component = (BaseComponent)other;
                component.INPUTS[inputPin].connect();

            }
            catch (Exception)
            {
                throw;
            }
            // set the input of the other component and save the connection to the list of output connections
            other.SetInput(inputPin, GetOutput(outputPin));
            outputs.Add(component);
            outputPins.Add(inputPin);
        }
    }
}
