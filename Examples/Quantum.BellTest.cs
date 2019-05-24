using Arithmetica.LinearAlgebra.Single;
using Arithmetica.Quantum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class QuantumBellTest : Transform
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
                H(ref qubit);
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
            Qubit q0 = null;
            Qubit q1 = null;
            
            int count = 1000;
            int numOnes = 0;
            for (int i = 0; i < count; i++)
            {
                q0 = Qubit.Zero;
                q1 = Qubit.One;
                H(ref q0);

                var state = State(q0);
                q1 = CNOT(q0, q1);

                if (state == QuantumState.One)
                {
                    numOnes++;
                }
            }

            Console.WriteLine("Zeros Count: " + (count - numOnes));
            Console.WriteLine("Ones Count: " + numOnes);
        }
    }
}
