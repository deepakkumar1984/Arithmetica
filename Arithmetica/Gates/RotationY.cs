using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Ry gate is one of the Rotation operators. The Ry gate is a single-qubit rotation through angle θ (radians) around the y-axis.
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class RotationY : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotationY"/> class.
        /// </summary>
        /// <param name="theta">The theta angle radians.</param>
        public RotationY(double theta) : base("Ry")
        {
            Matrix = new Complex[,] {
                { Math.Cos(theta/2), -Math.Sin(theta/2) },
                { Math.Sin(theta/2), Math.Cos(theta/2)},
            };
        }
    }
}
