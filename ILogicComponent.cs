using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public interface ILogicComponent
    {
        /// <summary>
        /// Returns the state of an input pin.
        /// </summary>
        /// <param name="pin"> one of the input pin </param>
        /// <returns>Returns the state of an input pin.</returns>
        bool GetInput(int pin);

        /// <summary>
        /// Returns the state of an output in.
        /// </summary>
        /// <param name="pin">one of the output pins</param>
        /// <returns>Returns the state of an output in.</returns>
        bool GetOutput(int pin);

        /// <summary>
        /// Set the state of an input pin.
        /// </summary>
        /// <param name="pin"> one of the input pins</param>
        /// <param name="value"> value to be set </param>
        void SetInput(int pin, bool value);

        /// <summary>
        /// Connect an output of this component to an input of another component.
        /// Allows multiple connections from the same output to other output pins
        /// </summary>
        /// <param name="outputPin">one of the output pin on this component</param>
        /// <param name="other">the other component</param>
        /// <param name="inputPin">one of the input pin of the other component</param>
        void ConnectOutput(int outputPin, ILogicComponent other, int inputPin);     
    }
}
