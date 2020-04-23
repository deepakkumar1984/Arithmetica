using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Rx gate is one of the Rotation operators. The Rx gate is a single-qubit rotation through angle θ (radians) around the x-axis.
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class RotationX : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotationX"/> class.
        /// </summary>
        /// <param name="theta">The theta angle radians.</param>
        public RotationX(double theta) : base("Rx")
        {
            Matrix = new Complex[,] {
                { Math.Cos(theta/2), -Math.Sin(theta/2) },
                { -Math.Sin(theta/2), Math.Cos(theta/2)},
            };
        }
    }
}
