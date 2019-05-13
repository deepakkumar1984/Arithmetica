using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Exp(ArithArray src) => ArrayOps.Exp(src);

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Log(ArithArray src) => ArrayOps.Log(src);

        /// <summary>
        /// Return the natural logarithm of one plus the input array, element-wise.        Calculates log(1 + x).
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Log1p(ArithArray src) => ArrayOps.Log1p(src);

    }
}
