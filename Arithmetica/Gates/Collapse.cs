﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica.QuantumGates
{
    public class Collapse : QuantumGate
    {
        public Collapse() : base("M")
        {
            
        }

        public override void Apply(params Qubit[] qubits)
        {
            Parallel.For(0, qubits.Length, (i) =>
            {
                qubits[i].Collapse();
            });
        }
    }
}
