using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    /// <summary>
    /// Inverse of the Phase Shift gate
    /// </summary>
    /// <seealso cref="Arithmetica.Quantum.Gate.PhaseShift" />
    public class PhaseShiftInverse : PhaseShift
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhaseShiftInverse"/> class.
        /// </summary>
        /// <param name="phase">The phase.</param>
        public PhaseShiftInverse(double phase) : base(phase)
        {
            Matrix = ComplexMatrix.Inverse(Matrix);
            Name = "Ri";
        }
    }
}
