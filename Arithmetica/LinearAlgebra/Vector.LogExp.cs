using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T>
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source Vector.</param>
        /// <returns></returns>
        public static ArithArray Exp(Vector<T> src) => ArrayOps.Exp(src.variable);

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source Vector.</param>
        /// <returns></returns>
        public static ArithArray Log(Vector<T> src) => ArrayOps.Log(src.variable);

        /// <summary>
        /// Return the natural logarithm of one plus the input Vector, element-wise.        Calculates log(1 + x).
        /// </summary>
        /// <param name="src">The source Vector.</param>
        /// <returns></returns>
        public static ArithArray Log1p(Vector<T> src) => ArrayOps.Log1p(src.variable);

    }
}
