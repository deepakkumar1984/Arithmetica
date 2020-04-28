using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The square root of NOT gate acts on a single qubit.
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class SquareRootNot : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareRootNot"/> class.
        /// </summary>
        public SquareRootNot() : base("SQRT_NOT")
        {
            Matrix = new ComplexMatrix(new Complex[,] {
                    { 1 + Complex.ImaginaryOne, 1 - Complex.ImaginaryOne },
                    { 1 - Complex.ImaginaryOne, 1 + Complex.ImaginaryOne },
                }) / 2;
        }
    }
}
