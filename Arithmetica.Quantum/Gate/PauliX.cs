using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    /// <summary>
    /// The Pauli-X gate acts on a single qubit. 
    /// It is the quantum equivalent of the NOT gate for classical computers (with respect to the standard basis {0>, |1> , which distinguishes the Z-direction; in the sense that a measurement of the eigenvalue +1 corresponds to classical 1/true and -1 to 0/false). 
    /// <para>
    /// Wikipedia: https://en.wikipedia.org/wiki/Quantum_logic_gate#Pauli-X_gate
    /// </para>
    /// </summary>
    /// <seealso cref="Arithmetica.Quantum.Gate.QuantumGate" />
    public class PauliX : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PauliX"/> class.
        /// </summary>
        public PauliX() : base("NOT")
        {
            Matrix = new Complex[,] {
                    { 0, 1 },
                    { 1, 0 },
                };
        }
    }
}
