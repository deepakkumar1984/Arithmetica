using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Exp(Complex src) => Complex.Out(ArrayOps.Exp(src.variable));

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Log(Complex src) => Complex.Out(ArrayOps.Log(src.variable));

        /// <summary>
        /// Return the natural logarithm of one plus the input matrix, element-wise.        Calculates log(1 + x).
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Log1p(Complex src) => Complex.Out(ArrayOps.Log1p(src.variable));

    }
}
