using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// Controlled Pauli Z gate
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class ControlledZ : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlledZ"/> class.
        /// </summary>
        public ControlledZ() : base("CZ")
        {
            PauliZ gate = new PauliZ();
            Matrix = ControlledGateMatrix(gate.Matrix);
        }

        /// <summary>
        /// Appliy the gate to the one or more qubit
        /// </summary>
        /// <param name="qubits">The qubits.</param>
        public override void Apply(params Qubit[] qubits)
        {
            var reg = new QuantumRegister(qubits);
            var result = QuantumRegister.GetQubits(ComplexMatrix.Multiply(Matrix, reg.BitRegister));
            for (int i = 0; i < qubits.Length; i++)
                qubits[i].BitRegister = result[i].BitRegister;
        }
    }
}
