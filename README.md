# Logic-Simulator-CSharp
This project was to build a logic simulator to connect logic gates into bigger components and test the circuit. There are some base components such as:
<ul>
  <li>AND gate
    <li>NOT gate
      <li>XOR gate
        <li>OR gate
          <li>HALFAdder
            <li>FULLAdder
              <li>3BitFULLAdder
                <li>more soon
                  </ul>
Each component can be connected to the input of another component connecting a bigger system. If a change of an input occurs, every component down the chain is updated recursively. An inplementation of exceptions is present for wrong pins or existing connection(there are some flaws in the exceptions). In order to create a new component, the new class should inherit from the base class and override its methods. A main program file is present for testing of the newly added components.
