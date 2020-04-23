using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// Also represented as S gate or the Z90 gate, because it represents a 90 degree rotation around the z-axis.
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class PhaseShift : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhaseShift"/> class.
        /// </summary>
        /// <param name="phase">The phase.</param>
        public PhaseShift(double phase) : base("S")
        {
            Matrix = new Complex[,] {
                { 1, 0 },
                { 0, QCUtil.ComplexExp(Complex.ImaginaryOne * phase)},
            };
        }
    }
}
