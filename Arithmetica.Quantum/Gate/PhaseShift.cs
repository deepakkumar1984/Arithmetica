using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class PhaseShift : QuantumGate
    {
        public PhaseShift(double phase) : base("S")
        {
            Matrix = new Complex[,] {
                { 1, 0 },
                { 0, QCUtil.ComplexExp(Complex.ImaginaryOne * phase)},
            };
        }
    }
}
