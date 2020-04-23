using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Pauli-Y gate acts on a single qubit. 
    /// It equates to a rotation around the Y-axis of the Bloch sphere by pi radians. It maps |0>  to i|1> and |1>  to -i|0>
    /// <para>
    /// Wikipedia: https://en.wikipedia.org/wiki/Quantum_logic_gate#Pauli-X_gate
    /// </para>
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class PauliY : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PauliY"/> class.
        /// </summary>
        public PauliY() : base("Y")
        {
            Matrix = new Complex[,] {
                    { 0, -Complex.ImaginaryOne },
                    { Complex.ImaginaryOne, 0 },
                };
        }
    }
}
