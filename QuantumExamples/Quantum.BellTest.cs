using Arithmetica;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumExamples
{
    public class QuantumBellTest
    {
        public static void Run()
        {
            Console.WriteLine("Running Bell Test");

            //Set initial qubit
            QuantumRegister reg = new QuantumRegister(2);
            QuantumCircuit circuit = new QuantumCircuit(reg);
            circuit.ExecuteWithJob = true;
            circuit.H(0);
            circuit.X(1);
            //circuit.Y(1);
            circuit.H(1);
            circuit.Measure();
            var result = circuit.Execute(1000);
            Console.WriteLine(result.ToJson());
            Console.WriteLine("Running Bell Test ---- Done\n");
        }
    }
}
