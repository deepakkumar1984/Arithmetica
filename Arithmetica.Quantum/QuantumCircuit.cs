using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    public class QuantumCircuit
    {
        public Qubit[] Bits = null;

        public QuantumCircuit(params Qubit[] qubits)
        {
            Bits = qubits;
        }
    }
}
