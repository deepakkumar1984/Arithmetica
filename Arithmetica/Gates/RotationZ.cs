using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Rz gate is one of the Rotation operators. The Ry gate is a single-qubit rotation through angle θ (radians) around the z-axis.
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class RotationZ : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotationZ"/> class.
        /// </summary>
        /// <param name="theta">The theta angle radians.</param>
        public RotationZ(double theta) : base("Rz")
        {
            Matrix = new Complex[,] {
                { QCUtil.ComplexExp(-Complex.ImaginaryOne * theta / 2), 0 },
                { 0, QCUtil.ComplexExp(Complex.ImaginaryOne * theta / 2)},
            };
        }
    }
}
