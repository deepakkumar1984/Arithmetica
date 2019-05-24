using Arithmetica.LinearAlgebra.Single;
using Arithmetica.Quantum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class QuantumBellTest : Operators
    {
        public static void Run()
        {
            //Set initial qubit
            Qubit qubit = null;

            int count = 1000;
            int numOnes = 0;
            for (int i = 0; i < count; i++)
            {
                qubit = Qubit.One;
                var state = State(qubit);
                H(qubit);
                state = State(qubit);
                qubit = M(qubit);
                state = State(qubit);

                if (state == QuantumState.One)
                {
                    numOnes++;
                }
            }

            Console.WriteLine("Zeros Count: " + (count - numOnes));
            Console.WriteLine("Ones Count: " + numOnes);
        }

        public static void Run1()
        {
            //Set initial qubit
                                   
            QuantumRegister register = new QuantumRegister(2);
            var epr = QuantumRegister.WState;
            var r = epr.ToString();
            
        }
    }
}
