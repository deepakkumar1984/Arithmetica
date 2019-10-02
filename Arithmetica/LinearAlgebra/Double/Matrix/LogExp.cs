using NumSharp;
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
        public static Matrix Exp(Matrix src) => Matrix.Out(Global.OP.Exp(src.variable));

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Log(Matrix src) => Matrix.Out(Global.OP.Log(src.variable));


    }
}
