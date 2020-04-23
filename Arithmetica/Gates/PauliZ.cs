using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Pauli-Z gate acts on a single qubit. 
    /// It equates to a rotation around the Z-axis of the Bloch sphere by pi radians. 
    /// Thus, it is a special case of a phase shift gate (which are described in a next subsection) with phi = pi.
    /// It leaves the basis state |0>  unchanged and maps {1>  to -|1>. Due to this nature, it is sometimes called phase-flip.
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class PauliZ : QuantumGate
    {
        public PauliZ() : base("Z")
        {
            Matrix = new Complex[,] {
                    { 1, 0 },
                    { 0, -1 },
                };
        }
    }
}
