using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// Gate to initialize the qubit to certain state
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class Initalize : QuantumGate
    {
        private Qubit InitState = Qubit.Zero;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hadamard"/> class.
        /// </summary>
        /// <param name="registerLength">Length of the register.</param>
        public Initalize(Qubit initial) : base("INIT")
        {
            InitState = initial;
        }

        /// <summary>
        /// Appliy the gate to the one or more qubit
        /// </summary>
        /// <param name="qubits">The qubits.</param>
        public override void Apply(params Qubit[] qubits)
        {
            Parallel.For(0, qubits.Length, (i) =>
            {
                qubits[i].BitRegister = InitState.BitRegister;
            });
        }
    }
}
