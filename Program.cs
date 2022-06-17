using System;

namespace Assignment3
{
    class Program
    {

        /// <summary>
        /// Function to convert number to binary
        /// </summary>
        /// <param name="number"> number to be converted </param>
        /// <returns> return an array with the bits in order </returns>
        static int[] convertToBinary(int number)
        {
            if(number < 0 || number > 7)
            {
                throw new Exception("Number out of range");
            }

            int[] arr = new int[3] {0,0,0 };
            int counter = 0;
            while(number != 0)
            {
                arr[counter] = number % 2;
                number /= 2;
                ++counter;
            }
            return arr;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("----------NOT-----------");
                NOTGate not = new NOTGate();
                Console.WriteLine("A Q");
                not.SetInput(0, false);
                Console.Write("F ");
                if (not.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                not.SetInput(0, true);
                Console.Write("T ");
                if (not.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");


                //----------------------------------------

                Console.WriteLine("---------AND--------------");
                ANDGate and = new ANDGate();
                Console.WriteLine("A B Q");
                and.SetInput(0, false);
                and.SetInput(1, false);
                Console.Write("F F ");
                if (and.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                and.SetInput(0, false);
                and.SetInput(1, true);
                Console.Write("F T ");
                if (and.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");

                and.SetInput(0, true);
                and.SetInput(1, false);
                Console.Write("T F ");
                if (and.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                and.SetInput(0, true);
                and.SetInput(1, true);
                Console.Write("T T ");
                if (and.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");


                ////--------------------------------------
                ///
                Console.WriteLine("-----------OR-------------");
                ORGate or = new ORGate();
                Console.WriteLine("A B Q");
                or.SetInput(0, false);
                or.SetInput(1, false);
                Console.Write("F F ");
                if (or.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                or.SetInput(0, false);
                or.SetInput(1, true);
                Console.Write("F T ");
                if (or.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");

                or.SetInput(0, true);
                or.SetInput(1, false);
                Console.Write("T F ");
                if (or.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                or.SetInput(0, true);
                or.SetInput(1, true);
                Console.Write("T T ");
                if (or.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");

                //---------------------------------

                Console.WriteLine("----------------XOR-------------");
                XORGate xor = new XORGate();
                Console.WriteLine("A B Q");
                xor.SetInput(0, false);
                xor.SetInput(1, false);
                Console.Write("F F ");
                if (xor.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                xor.SetInput(0, false);
                xor.SetInput(1, true);
                Console.Write("F T ");
                if (xor.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");

                xor.SetInput(0, true);
                xor.SetInput(1, false);
                Console.Write("T F ");
                if (xor.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                xor.SetInput(0, true);
                xor.SetInput(1, true);
                Console.Write("T T ");
                if (xor.GetOutput(0))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");

                //-------------------------

                Console.WriteLine("----------------HalfAdder-------------");
                HALFAdder halfAdder = new HALFAdder();
                Console.WriteLine("A B S C");
                halfAdder.SetInput(0, false);
                halfAdder.SetInput(1, false);
                Console.Write("F F ");
                if (halfAdder.GetOutput(0))
                    Console.Write("T ");
                else
                    Console.Write("F ");
                if (halfAdder.GetOutput(1))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                halfAdder.SetInput(0, false);
                halfAdder.SetInput(1, true);
                Console.Write("F T ");
                if (halfAdder.GetOutput(0))
                    Console.Write("T ");
                else
                    Console.Write("F ");
                if (halfAdder.GetOutput(1))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");

                halfAdder.SetInput(0, true);
                halfAdder.SetInput(1, false);
                Console.Write("T F ");
                if (halfAdder.GetOutput(0))
                    Console.Write("T ");
                else
                    Console.Write("F ");
                if (halfAdder.GetOutput(1))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");
                halfAdder.SetInput(0, true);
                halfAdder.SetInput(1, true);
                Console.Write("T T ");
                if (halfAdder.GetOutput(0))
                    Console.Write("T ");
                else
                    Console.Write("F ");
                if (halfAdder.GetOutput(1))
                    Console.WriteLine("T");
                else
                    Console.WriteLine("F");


                ///---------------------------

                Console.WriteLine("------------FullAdder----------");

                FULLAdder full = new FULLAdder();
                Console.WriteLine("A B Ci S Co");
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int t = 0; t < 2; t++)
                        {
                            full.SetInput(0, Convert.ToBoolean(i));
                            full.SetInput(1, Convert.ToBoolean(j));
                            full.SetInput(2, Convert.ToBoolean(t));
                            Console.WriteLine($"{i} {j} {t}  {Convert.ToInt16(full.GetOutput(0))} {Convert.ToInt16(full.GetOutput(1))}");
                        }
                    }
                }

                Console.WriteLine("----------TBFullAdder----------\n");
                Console.WriteLine("Test 3 bit adder 3 times\n");
                TBFullAdder tbFull = new TBFullAdder();

                // make 3 add operations to verify
                for (int tests = 1; tests <= 3; tests++)
                {
                    Console.WriteLine($"Test number {tests}\n");

                    // read first number from user
                    Console.WriteLine("Enter number 1 (0 - 7)");
                    int number1 = Convert.ToInt16(Console.ReadLine());

                    // convert the first number
                    int[] firstNumToBin = convertToBinary(number1);

                    // read second number from user
                    Console.WriteLine("Enter number 2 (0 - 7)");
                    int number2 = Convert.ToInt16(Console.ReadLine());

                    // convert the second number
                    int[] secondNumToBin = convertToBinary(number2);

                    // set all the bits in the 3BitFullAdder
                    for (int i = 0; i < 3; i++)
                    {
                        tbFull.SetInput(0, i, Convert.ToBoolean(firstNumToBin[i]));
                        tbFull.SetInput(1, i, Convert.ToBoolean(secondNumToBin[i]));
                    }

                    // print the answer
                    Console.WriteLine($"SUM: {number1 + number2} \nCout C B A  (bin format)");
                    Console.WriteLine($"   {Convert.ToInt16(tbFull.GetOutput(1, 2))} {Convert.ToInt16(tbFull.GetOutput(0, 2))} " +
                        $"{Convert.ToInt16(tbFull.GetOutput(0, 1))} {Convert.ToInt16(tbFull.GetOutput(0, 0))}\n");
                }
            }
            catch (Exception e)
            {
                // if exception is caught, print its content
                Console.WriteLine(e.Message);
            }
        }
    }
}
