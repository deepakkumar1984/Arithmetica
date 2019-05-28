using System;
using Arithmetica.Quantum;

namespace QuantumExamples
{
    public class Superposition : IExample
    {
        private Random rand = new Random();
        public void Run()
        {
            PlusState();
            MinusState();
            UnequalSuperposition();
            Teleportation();
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

        private void Teleportation()
        {
            QuantumRegister register = new QuantumRegister(2);
            QuantumCircuit circuit = new QuantumCircuit(register);

            //circuit.ExecuteWithJob = true;
            int transported = 0;
            
            for (int i = 0; i < 25; i++)
            {
                circuit.INIT(0, GetRandom());
                circuit.H(0);
                circuit.CNOT(0, 1);
                circuit.Measure(0);
                var res1 = register[0].QState;
                circuit.Measure(1);
                var res2 = register[1].QState;

                Console.WriteLine("Send: {0}, Received: {1}", res1, res2);
                if (res1 == res2)
                    transported++;

                register.Reset();
            }

            //var result = circuit.Execute(1000);
            Console.WriteLine("Teleported count: " + transported);
        }

        private Qubit GetRandom()
        {
            if (rand.NextDouble() > 0.5)
                return Qubit.One;

            return Qubit.Zero;
        }
    }
}