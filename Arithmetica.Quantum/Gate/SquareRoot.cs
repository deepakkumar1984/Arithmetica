using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class SquareRoot : QuantumGate
    {
        public SquareRoot() : base("SQRT")
        {
            Matrix = new ComplexMatrix(new Complex[,] {
                    { 1 + Complex.ImaginaryOne, 1 - Complex.ImaginaryOne },
                    { 1 - Complex.ImaginaryOne, 1 + Complex.ImaginaryOne },
                }) / 2;
        }
    }
}
