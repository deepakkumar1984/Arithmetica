using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Hadamard gate is a single-qubit operation creating an equal superposition of the two basis states.
    /// The Hadamard transformation, more often called Hadamard gate in this context (cf. quantum gate), is a one-qubit rotation, mapping the qubit-basis states {\displaystyle |0\rangle } |0\rangle  and {\displaystyle |1\rangle } |1\rangle  to two superposition states with equal weight of the computational basis states |0>  and |1> .
    /// <para>
    /// Wikipedia: https://en.wikipedia.org/wiki/Hadamard_transform
    /// </para>
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class Hadamard : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hadamard"/> class.
        /// </summary>
        /// <param name="registerLength">Length of the register.</param>
        public Hadamard(int registerLength = 1) : base("H")
        {
            Matrix = HadamardGateOfLength(registerLength);
        }

        /// <summary>
        /// Hadamards the length of the gate of.
        /// </summary>
        /// <param name="registerLength">Length of the register.</param>
        /// <returns></returns>
        private ComplexMatrix HadamardGateOfLength(int registerLength)
        {
            var matrix = new ComplexMatrix(new Complex[,] {
                    { 1, 1 },
                    { 1, -1 },
                }) / Math.Sqrt(2);

            if (registerLength == 1)
            {
                return matrix;
            }
            else
            {
                return HadamardGateOfLength(registerLength - 1);
            }
        }
    }
}
