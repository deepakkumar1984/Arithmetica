using Arithmetica.LinearAlgebra.Single;
using Arithmetica.Quantum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class QuantumBellTest
    {
        public static void Run()
        {
            //Set initial qubit
            Qubit qubit = null;

            int count = 1000;
            int numOnes = 0;
            for (int i = 0; i < count; i++)
            {
                qubit = Qubit.Zero;
                qubit.Collapse();
                if (qubit.OneAmplitude != null)
                {
                    numOnes++;
                }
            }

            Console.WriteLine("Zeros Count: " + (count - numOnes));
            Console.WriteLine("Ones Count: " + numOnes);
        }
    }
}
