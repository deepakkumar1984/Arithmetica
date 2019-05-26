using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class PhaseShiftInverse : PhaseShift
    {
        public PhaseShiftInverse(double phase) : base(phase)
        {
            Matrix = ComplexMatrix.Inverse(Matrix);
            Name = "SI";
        }
    }
}
