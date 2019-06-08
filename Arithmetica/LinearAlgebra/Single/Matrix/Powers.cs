using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Single
{
    public partial class Matrix
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the matrix
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Pow(Matrix src, float value) => Matrix.Out(Global.OP.Pow(src.variable, value));

        /// <summary>
        /// Performs elementwise power to matrix power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Tpow(float value, Matrix src) => Matrix.Out(Global.OP.TPow(value, src.variable));

        /// <summary>
        /// Perform square root operation on the matrix elemenwise.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Sqrt(Matrix src) => Matrix.Out(Global.OP.Sqrt(src.variable));

        /// <summary>
        /// Perform square operation on the matrix elemenwise.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Square(Matrix src) => Matrix.Out(Global.OP.Square(src.variable));

    }
}
