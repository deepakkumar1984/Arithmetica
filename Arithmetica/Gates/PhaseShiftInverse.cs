using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// Inverse of the Phase Shift gate
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.PhaseShift" />
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
