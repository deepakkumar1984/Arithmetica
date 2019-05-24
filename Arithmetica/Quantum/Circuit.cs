using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    public class Circuit
    {
        public Qubit[] Bits = null;

        public Circuit(params Qubit[] qubits)
        {
            Bits = qubits;
        }
    }
}
