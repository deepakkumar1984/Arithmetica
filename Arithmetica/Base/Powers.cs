using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the array
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Pow(ArithArray src, float value) => ArrayOps.Pow(src, value);

        /// <summary>
        /// Performs elementwise power to array power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Tpow(float value, ArithArray src) => ArrayOps.Tpow(value, src);

        /// <summary>
        /// Perform square root operation on the array elemenwise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Sqrt(ArithArray src) => ArrayOps.Sqrt(src);

        /// <summary>
        /// Perform square operation on the array elemenwise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Square(ArithArray src) => ArrayOps.Square(src);

    }
}
