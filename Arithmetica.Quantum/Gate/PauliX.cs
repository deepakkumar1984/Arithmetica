using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class PauliX : QuantumGate
    {
        public PauliX() : base("NOT")
        {
            Matrix = new Complex[,] {
                    { 0, 1 },
                    { 1, 0 },
                };
        }
    }
}
