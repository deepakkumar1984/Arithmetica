using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Reduced Sum of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Sum(Complex src) => Complex.Out(ArrayOps.Sum(src.variable));

        /// <summary>
        /// Reduced Sum of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Sum(Complex src, int dimension) => Complex.Out(ArrayOps.Sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Prod(Complex src) => Complex.Out(ArrayOps.Prod(src.variable));

        /// <summary>
        /// Reduced Prod of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Prod(Complex src, int dimension) => Complex.Out(ArrayOps.Prod(src.variable, dimension));

        /// <summary>
        /// Reduced Mean of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Mean(Complex src) => Complex.Out(ArrayOps.Mean(src.variable));

        /// <summary>
        /// Reduced Mean of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Mean(Complex src, int dimension) => Complex.Out(ArrayOps.Mean(src.variable, dimension));

        /// <summary>
        /// Reduced Max of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Max(Complex src) => Complex.Out(ArrayOps.Max(src.variable));

        /// <summary>
        /// Reduced Max of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Max(Complex src, int dimension) => Complex.Out(ArrayOps.Max(src.variable, dimension));

        /// <summary>
        /// Reduced Min of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Min(Complex src) => Complex.Out(ArrayOps.Min(src.variable));

        /// <summary>
        /// Reduced Min of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Min(Complex src, int dimension) => Complex.Out(ArrayOps.Min(src.variable, dimension));

        /// <summary>
        /// Reduced Norm of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Norm(Complex src, float value) => Complex.Out(ArrayOps.Norm(src.variable, value));

        /// <summary>
        /// Reduced Norm w.r.t to a scalar value of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Norm(Complex src, float value, int dimension) => Complex.Out(ArrayOps.Norm(src.variable, dimension, value));

        /// <summary>
        /// Reduced Variance of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Var(Complex src) => Complex.Out(ArrayOps.Var(src.variable));

        /// <summary>
        /// Reduced Variance of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Var(Complex src, bool normByN, int dimension) => Complex.Out(ArrayOps.Var(src.variable, dimension, normByN));

        /// <summary>
        /// Returns the indices of the minimum values along a dimension.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Argmin(Complex src, int dimension) => Complex.Out(ArrayOps.Argmin(src.variable, dimension));

        /// <summary>
        /// Returns the indices of the maximum values along a dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Complex Argmax(Complex src, int dimension) => Complex.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
