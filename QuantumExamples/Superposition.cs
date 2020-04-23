using System;
using Arithmetica;

namespace QuantumExamples
{
    public class Superposition
    {
        public static void Run()
        {
            Console.WriteLine("Running superposition example");
            PlusState();
            MinusState();
            UnequalSuperposition();
            Console.WriteLine("Running superposition example---- Done\n");
        }

        private static void PlusState()
        {
            QuantumRegister register  = new QuantumRegister(1);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.H(0);
            Console.WriteLine("PlusState Result: " + register[0].IsPlus);
        }

        private static void MinusState()
        {
            QuantumRegister register  = new QuantumRegister(1);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.X(0);
            circuit.H(0);
            Console.WriteLine("MinusState Result: " + register[0].IsMinus);
        }

        private static void UnequalSuperposition()
        {
            QuantumRegister register  = new QuantumRegister(1);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.Rx(0, 1.78);
            Console.WriteLine("Superposition State: " + (register[0].QState == QubitState.Superposition));
        }

    }
}