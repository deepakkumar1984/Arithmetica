using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T>
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the Vector<T>
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Pow(Vector<T> src, float value) => ArrayOps.Pow(src.variable, value);

        /// <summary>
        /// Performs elementwise power to Vector<T> power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Tpow(float value, Vector<T> src) => ArrayOps.Tpow(value, src.variable);

        /// <summary>
        /// Perform square root operation on the Vector<T> elemenwise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Sqrt(Vector<T> src) => ArrayOps.Sqrt(src.variable);

        /// <summary>
        /// Perform square operation on the Vector<T> elemenwise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Square(Vector<T> src) => ArrayOps.Square(src.variable);

    }
}
