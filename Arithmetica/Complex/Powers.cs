using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the matrix
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static Complex Pow(Complex src, float value) => Complex.Out(ArrayOps.Pow(src.variable, value));

        /// <summary>
        /// Performs elementwise power to matrix power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Tpow(float value, Complex src) => Complex.Out(ArrayOps.Tpow(value, src.variable));

        /// <summary>
        /// Perform square root operation on the matrix elemenwise.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Sqrt(Complex src) => Complex.Out(ArrayOps.Sqrt(src.variable));

        /// <summary>
        /// Perform square operation on the matrix elemenwise.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Square(Complex src) => Complex.Out(ArrayOps.Square(src.variable));

    }
}
