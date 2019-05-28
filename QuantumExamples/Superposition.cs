using System;
using Arithmetica.Quantum;

namespace QuantumExamples
{
    public class Superposition : IExample
    {
        private Random rand = new Random();
        public void Run()
        {
            //PlusState();
            //MinusState();
            //UnequalSuperposition();
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
            //Create a register with 2 Qubits
            QuantumRegister register = new QuantumRegister(2);

            //Create a blank circuit with the regiter initialised
            QuantumCircuit circuit = new QuantumCircuit(register);

            //Initialize the tranported counter
            int transported = 0;
            
            //Let try to teleport 25 quantum information
            for (int i = 0; i < 25; i++)
            {
                var send = GetRandom();

                //Initial the first Qubit with the particle to be teleported
                circuit.INIT(0, send);

                //Hadamard gate to apply superposition to the first quantum bit which means the first qubit will have both 0 and 1
                circuit.H(0);

                //Controlled not gate to entangle the two qubit
                circuit.CNOT(0, 1);

                //Measure the first will collapse the quantum state and bring it to reality whic will be either one or zero
                circuit.Measure(0);

                //Store the first state
                var res1 = register[0].QState;

                //Now measue the second particle and store the value
                circuit.Measure(1);
                var res2 = register[1].QState;

                Console.WriteLine("Send: {0}, Received: {1}", res1, res2);

                //If you compare the result the two result will be same which states that the information is teleported.
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