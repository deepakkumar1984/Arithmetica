using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    /// <summary>
    /// The SWAP gate is two-qubit operation. Expressed in basis states, the SWAP gate swaps the state of the two qubits involved in the operation
    /// </summary>
    /// <seealso cref="Arithmetica.Quantum.Gate.QuantumGate" />
    public class Swap : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Swap"/> class.
        /// </summary>
        public Swap() : base("SWAP")
        {
            Matrix = new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 1 },
                };
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
