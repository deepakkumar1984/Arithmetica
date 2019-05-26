using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arithmetica.Quantum.Gate;

namespace Arithmetica.Quantum
{
    public class QuantumCircuit
    {
        /// <summary>
        /// Gets or sets the program.
        /// </summary>
        /// <value>
        /// The program.
        /// </value>
        public CircuitProgram Program { get; private set; }

        /// <summary>
        /// Gets or sets the register.
        /// </summary>
        /// <value>
        /// The register.
        /// </value>
        public QuantumRegister Register { get; private set; }

        public bool Debug { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumCircuit"/> class.
        /// </summary>
        /// <param name="register">The register.</param>
        public QuantumCircuit(params QuantumRegister[] registers)
        {
            Program = new CircuitProgram();
            List<Qubit> qubits = new List<Qubit>();
            foreach (var item in registers)
            {
                qubits.AddRange(item.Qubits);
            }

            Register = new QuantumRegister(qubits.ToArray());
            Debug = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumCircuit"/> class.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="program">The program.</param>
        public QuantumCircuit(QuantumRegister[] registers, CircuitProgram program)
            : this(registers)
        {
            Program = program;
        }

        public void H(int index)
        {
            if(Debug)
            {
                new HardmadGate().Apply(Register[index]);
                return;
            }

            Program.Add(new HardmadGate(), index);
        }

        public void X(int index)
        {
            if (Debug)
            {
                new PauliX().Apply(Register[index]);
                return;
            }

            Program.Add(new PauliX(), index);
        }

        public void CNOT(int firstBit, int secondBit)
        {
            if (Debug)
            {
                new ControlledNot().Apply(Register[firstBit], Register[secondBit]);
                return;
            }

            Program.Add(new ControlledNot(), firstBit, secondBit);
        }

        public void Collapse(int? index = null)
        {
            List<int> bitIndex = new List<int>();
            if (index.HasValue)
                bitIndex.Add(index.Value);
            else
            {
                for (int i = 0; i < Register.Qubits.Length; i++)
                    bitIndex.Add(i);
            }

            if (Debug)
            {
                new Collapse().Apply(Register[bitIndex.ToArray()]);
                return;
            }

            Program.Add(new Collapse(), bitIndex.ToArray());
        }

        public void Execute(int shots = 1024)
        {
            if (Debug)
                throw new QuantumException("Cannot execute job in debug mode");

            foreach (var code in Program.Codes)
            {
                code.Gate.Apply(Register[code.BitIndex]);
            }
        }
    }

    public class CircuitProgram
    {
        public List<ProgramCode> Codes { get; set; }

        public CircuitProgram()
        {
            Codes = new List<ProgramCode>();
        }

        public void Add(QuantumGate gate, params int[] bitIndex)
        {
            Codes.Add(new ProgramCode(gate, bitIndex));
        }
    }

    public class ProgramCode
    {
        public int[] BitIndex { get; set; }

        public QuantumGate Gate { get; set; }

        public ProgramCode(QuantumGate gate, params int[] bitIndex)
        {
            Gate = gate;
            BitIndex = bitIndex;
        }
    }
}
