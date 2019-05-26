using Arithmetica.LinearAlgebra.Single;
using Arithmetica.Quantum;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumExamples
{
    public class QuantumBellTest : Operators
    {
        public static void Run()
        {
            //Set initial qubit
            QuantumRegister reg = new QuantumRegister(3);
            QuantumCircuit circuit = new QuantumCircuit(reg);
            circuit.Debug = true;
            circuit.H(0);
            circuit.H(1);
            var states = reg.PossibleStates;
        }
    }
}
