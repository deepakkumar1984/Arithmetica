using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Double
{
    public partial class Matrix
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Exp(Matrix src) => Matrix.Out(ArrayOps.Exp(src.variable));

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Log(Matrix src) => Matrix.Out(ArrayOps.Log(src.variable));

        /// <summary>
        /// Return the natural logarithm of one plus the input matrix, element-wise.        Calculates log(1 + x).
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Log1p(Matrix src) => Matrix.Out(ArrayOps.Log1p(src.variable));

    }
}
