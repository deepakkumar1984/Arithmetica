using Arithmetica.LinearAlgebra.Single;
using Arithmetica.Quantum;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumExamples
{
    public class QuantumBellTest
    {
        public static void Run()
        {
            //Set initial qubit
            QuantumRegister reg = new QuantumRegister(5);
            QuantumCircuit circuit = new QuantumCircuit(reg);
            //circuit.Debug = true;
            circuit.H(0);
            circuit.H(1);
            //circuit.Y(1);
            circuit.Collapse();
            var result = circuit.Execute(1000);
            
            Console.WriteLine(result.ToJson());
        }
    }
}
