using NumSharp;
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
        public static NDArray Exp(Vector<T> src) => Global.OP.Exp(src.variable);

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source Vector.</param>
        /// <returns></returns>
        public static NDArray Log(Vector<T> src) => Global.OP.Log(src.variable);

    }
}
