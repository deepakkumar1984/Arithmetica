using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Sqrt(SWAP) gate performs half-way of a two-qubit swap. 
    /// It is universal such that any many-qubit gate can be constructed from only Sqrt(SWAP) and single qubit gates. 
    /// The Sqrt(SWAP) gate is not, however maximally entangling; more than one application of it is required to produce a Bell state from product states. 
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class SqrtSwap : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqrtSwap"/> class.
        /// </summary>
        public SqrtSwap() : base("SQRT_SWAP")
        {
            Matrix = new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, (1 + Complex.ImaginaryOne) / 2, (1 - Complex.ImaginaryOne) / 2, 0 },
                    { 0, (1 - Complex.ImaginaryOne) / 2, (1 + Complex.ImaginaryOne) / 2, 0 },
                    { 0, 0, 0, 1 } };
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
