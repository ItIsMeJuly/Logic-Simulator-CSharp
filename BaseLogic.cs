using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    abstract class BaseComponent : ILogicComponent
    {
        protected List<bool> values;                  // store the input values
        protected List<Connection> inputs;            // keep track of inputs
        protected List<BaseComponent> outputs;        // store the connections made from this gate
        protected List<int> outputPins;               // store the pins to with the output is connected

        public BaseComponent()
        {
            values = new List<bool>() { false, false };     // basic component has two inputs
            inputs = new List<Connection>() { new Connection(), new Connection() };  // basic component has two inputs
            outputs = new List<BaseComponent>();            // empty list of outputs
            outputPins = new List<int>();               // empty list of pins
        }

        /// <summary>
        /// get property for inputs
        /// </summary>
        public List<Connection> INPUTS
        {
            get { return inputs; }
        }

        /// <summary>
        /// Virtual method to get the output of the base element
        /// </summary>
        /// <param name="pin"> output pin  </param>
        /// <returns> the state of output pin </returns>
        /// <exception cref="InvalidPinException"> throw if pin is invalid</exception>
        public virtual bool GetInput(int pin)
        {
            if (pin != 0 && pin != 1)
            {
                throw new InvalidPinException(pin + " is not a valid input pin");
            }
            else if (pin == 0)
            {
                return values[0];
            }
            else
            {
                return values[1];
            }
        }


        /// <summary>
        /// Virtual method to set input value of base component and update all connections
        /// </summary>
        /// <param name="pin"> input pin </param>
        /// <param name="value"> true of false </param>
        /// <exception cref="InvalidPinException"> throw if pin is invalid </exception>
        public virtual void SetInput(int pin, bool value)
        {
            if (pin != 0 && pin != 1)
            {
                throw new InvalidPinException(pin + " is not a valid input pin");
            }
            else if (pin == 0)
            {
                this.values[0] = value;
                if (outputs.Count > 0)
                {
                    // update all connections recurively
                    for (int i = 0; i < outputs.Count; i++)
                    {
                        outputs[i].SetInput(outputPins[i], GetOutput(0));
                    }
                }
            }
            else
            {
                this.values[1] = value;
                if (outputs.Count > 0)
                {
                    // update all connections recursively
                    for (int i = 0; i < outputs.Count; i++)
                    {
                        outputs[i].SetInput(outputPins[0], GetOutput(0));
                    }
                }
            }
        }

        /// <summary>
        /// Get output state of element. Must be overriden for the component
        /// </summary>
        /// <param name="pin"> output pin </param>
        /// <returns> output pin state </returns>
        public abstract bool GetOutput(int pin);

        /// <summary>
        /// Abstract in order not to force implementation for the components
        /// Method to connect output of this component to input of another
        /// </summary>
        /// <param name="inputPin"> input pin of other component </param>
        /// <param name="other"> the other component </param>
        /// <param name="outputPin"> output pin of this component to connect </param>
        public abstract void ConnectOutput(int inputPin, ILogicComponent other, int outputPin);


    }
}
