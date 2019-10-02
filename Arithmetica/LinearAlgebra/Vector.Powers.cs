using NumSharp;
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
        public static NDArray Pow(Vector<T> src, float value) => np.power(src.variable, value);

        /// <summary>
        /// Perform square root operation on the Vector<T> elemenwise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static NDArray Sqrt(Vector<T> src) => np.sqrt(src.variable);

        /// <summary>
        /// Perform square operation on the Vector<T> elemenwise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static NDArray Square(Vector<T> src) => np.square(src.variable);

    }
}
