using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Exp(Vector src) => Vector.Out(ArrayOps.Exp(src.variable));

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Log(Vector src) => Vector.Out(ArrayOps.Log(src.variable));

        /// <summary>
        /// Return the natural logarithm of one plus the input vector, element-wise.        Calculates log(1 + x).
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Log1p(Vector src) => Vector.Out(ArrayOps.Log1p(src.variable));

    }
}
