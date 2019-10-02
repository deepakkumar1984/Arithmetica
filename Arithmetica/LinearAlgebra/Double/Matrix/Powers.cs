using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Double
{
    public partial class Matrix
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the matrix
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Pow(Matrix src, float value) => Matrix.Out(np.power(src.variable, value));

        /// <summary>
        /// Performs elementwise power to matrix power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Tpow(float value, Matrix src) => Matrix.Out(np.power(value, src.variable));

        /// <summary>
        /// Perform square root operation on the matrix elemenwise.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Sqrt(Matrix src) => Matrix.Out(np.sqrt(src.variable));

        /// <summary>
        /// Perform square operation on the matrix elemenwise.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Square(Matrix src) => Matrix.Out(np.square(src.variable));

    }
}
