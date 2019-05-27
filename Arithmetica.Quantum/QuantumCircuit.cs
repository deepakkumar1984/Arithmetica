using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arithmetica.Quantum.Gate;
using System.Threading.Tasks;
using System.Threading;

namespace Arithmetica.Quantum
{
    /// <summary>
    /// A quantum circuit is a model for quantum computation in which a computation is a sequence of quantum gates, 
    /// which are reversible transformations on a quantum mechanical analog of an n-bit register. 
    /// This analogous structure is referred to as an n-qubit register.
    /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="QuantumCircuit"/> is debug.
        /// </summary>
        /// <value>
        ///   <c>true</c> if debug; otherwise, <c>false</c>.
        /// </value>
        public bool Debug { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumCircuit"/> class.
        /// </summary>
        /// <param name="register">The register.</param>
        public QuantumCircuit(params QuantumRegister[] registers)
        {
            QCUtil.Random = new Random();
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

        /// <summary>
        /// Apply the Hadamard gate
        /// </summary>
        /// <param name="index">The index.</param>
        public void H(int index)
        {
            if(Debug)
            {
                new Hadamard().Apply(Register[index]);
                return;
            }

            Program.Add(new Hadamard(), index);
        }

        /// <summary>
        /// Apply the PauliX gate (NOT gate)
        /// </summary>
        /// <param name="index">The index.</param>
        public void X(int index)
        {
            if (Debug)
            {
                new PauliX().Apply(Register[index]);
                return;
            }

            Program.Add(new PauliX(), index);
        }

        /// <summary>
        /// Apply the Controlled Not gate
        /// </summary>
        /// <param name="firstBit">The first bit.</param>
        /// <param name="secondBit">The second bit.</param>
        public void CNOT(int firstBit, int secondBit)
        {
            if (Debug)
            {
                new ControlledNot().Apply(Register[firstBit], Register[secondBit]);
                return;
            }

            Program.Add(new ControlledNot(), firstBit, secondBit);
        }

        /// <summary>
        /// Apply the collapse gate to measure the quantum register
        /// </summary>
        /// <param name="index">The index.</param>
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

        /// <summary>
        /// Executes the circuit and run for specified number of shots to capture all the possibilities.
        /// </summary>
        /// <param name="shots">The shots.</param>
        /// <exception cref="QuantumException">Cannot execute job in debug mode</exception>
        public CircuitResult Execute(int shots = 1024)
        {
            CircuitResult result = new CircuitResult();

            if (Debug)
            {
                result.Success = false;
                result.Message = "Cannot execute in debug mode";
                return result;
            }

            for (int i = 0; i < shots; i++)
            {
                var reg = new QuantumRegister(Register.BitRegister);
                foreach (var code in Program.Codes)
                {
                    code.Gate.Apply(reg[code.BitIndex]);
                }

                foreach (var item in reg.Possiblities)
                {
                    result[item] += 1;
                }
            }

            result.Result = result.Result.OrderBy(x => (x.ClassicalValue)).ToList();
            foreach (var item in result.Result)
            {
                item.Percentage = (float)item.Count * 100 / (float)shots;
            }

            result.Success = true;

            return result;
        }
    }

    /// <summary>
    /// Circuit program which consist of instructions for the quantum circuit
    /// </summary>
    public class CircuitProgram
    {
        /// <summary>
        /// Gets or sets the codes / instructions.
        /// </summary>
        /// <value>
        /// The codes.
        /// </value>
        public List<ProgramCode> Codes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitProgram"/> class.
        /// </summary>
        public CircuitProgram()
        {
            Codes = new List<ProgramCode>();
        }

        /// <summary>
        /// Adds the specified gate.
        /// </summary>
        /// <param name="gate">The gate.</param>
        /// <param name="bitIndex">Index of the bit.</param>
        public void Add(QuantumGate gate, params int[] bitIndex)
        {
            Codes.Add(new ProgramCode(gate, bitIndex));
        }
    }

    /// <summary>
    /// Individual instruction for the circuit program
    /// </summary>
    public class ProgramCode
    {
        /// <summary>
        /// Gets or sets the index of the qubit which will run the code.
        /// </summary>
        /// <value>
        /// The index of the bit.
        /// </value>
        public int[] BitIndex { get; set; }

        /// <summary>
        /// Gets or sets the gate which will be applied.
        /// </summary>
        /// <value>
        /// The gate.
        /// </value>
        public QuantumGate Gate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramCode"/> class.
        /// </summary>
        /// <param name="gate">The gate.</param>
        /// <param name="bitIndex">Index of the bit.</param>
        public ProgramCode(QuantumGate gate, params int[] bitIndex)
        {
            Gate = gate;
            BitIndex = bitIndex;
        }
    }
}
