using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the vector
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static Vector Pow(Vector src, float value) => Vector.Out(ArrayOps.Pow(src.variable, value));

        /// <summary>
        /// Performs elementwise power to vector power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Tpow(float value, Vector src) => Vector.Out(ArrayOps.Tpow(value, src.variable));

        /// <summary>
        /// Perform square root operation on the vector elemenwise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Sqrt(Vector src) => Vector.Out(ArrayOps.Sqrt(src.variable));

        /// <summary>
        /// Perform square operation on the vector elemenwise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Square(Vector src) => Vector.Out(ArrayOps.Square(src.variable));

    }
}
