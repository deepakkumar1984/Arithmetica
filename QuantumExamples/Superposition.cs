using System;
using Arithmetica.Quantum;

namespace QuantumExamples
{
    public class Superposition : IExample
    {
        public void Run()
        {
            PlusState();
            MinusState();
            UnequalSuperposition();
            BellState();
        }

        private void PlusState()
        {
            QuantumRegister register  = new QuantumRegister(1);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.H(0);
            Console.WriteLine("PlusState Result: " + register[0].IsPlus);
        }

        private void MinusState()
        {
            QuantumRegister register  = new QuantumRegister(1);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.X(0);
            circuit.H(0);
            Console.WriteLine("MinusState Result: " + register[0].IsMinus);
        }

        private void UnequalSuperposition()
        {
            QuantumRegister register  = new QuantumRegister(1);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.Rx(0, 1.78);
            Console.WriteLine("Superposition State: " + (register[0].QState == QubitState.Superposition));
        }

        private void BellState()
        {
            QuantumRegister register  = new QuantumRegister(2);
            QuantumCircuit circuit = new QuantumCircuit(register);

            circuit.H(0);
            circuit.CNOT(0, 1);
            
            Console.WriteLine("MinusState Result: " + register[0].IsMinus);
        }
    }
}