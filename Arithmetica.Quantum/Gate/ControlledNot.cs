using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    /// <summary>
    /// The controlled NOT gate (also C-NOT or CNOT) is a quantum gate that is an essential component in the construction of a quantum computer. 
    /// It can be used to entangle and disentangle EPR states. 
    /// Any quantum circuit can be simulated to an arbitrary degree of accuracy using a combination of CNOT gates and single qubit rotations.
    /// <para>
    /// Wikipedia: https://en.wikipedia.org/wiki/Controlled_NOT_gate
    /// </para>
    /// </summary>
    /// <seealso cref="Arithmetica.Quantum.Gate.QuantumGate" />
    public class ControlledNot : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlledNot"/> class.
        /// </summary>
        public ControlledNot() : base("CNOT")
        {
            PauliX notGate = new PauliX();
            Matrix = ControlledGateMatrix(notGate.Matrix);
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
