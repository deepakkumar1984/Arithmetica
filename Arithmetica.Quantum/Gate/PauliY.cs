using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    public class PauliY : QuantumGate
    {
        public PauliY() : base("Y")
        {
            Matrix = new Complex[,] {
                    { 0, -Complex.ImaginaryOne },
                    { Complex.ImaginaryOne, 0 },
                };
        }
    }
}
