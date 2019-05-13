using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        /// <summary>
        /// Reduced Sum of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Sum(ArithArray src) => ArrayOps.Sum(src);

        /// <summary>
        /// Reduced Sum of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Sum(ArithArray src, int dimension) => ArrayOps.Sum(src, dimension);

        /// <summary>
        /// Reduced Prod of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Prod(ArithArray src) => ArrayOps.Prod(src);

        /// <summary>
        /// Reduced Prod of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Prod(ArithArray src, int dimension) => ArrayOps.Prod(src, dimension);

        /// <summary>
        /// Reduced Mean of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Mean(ArithArray src) => ArrayOps.Mean(src);

        /// <summary>
        /// Reduced Mean of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Mean(ArithArray src, int dimension) => ArrayOps.Mean(src, dimension);

        /// <summary>
        /// Reduced Max of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Max(ArithArray src) => ArrayOps.Max(src);

        /// <summary>
        /// Reduced Max of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Max(ArithArray src, int dimension) => ArrayOps.Max(src, dimension);

        /// <summary>
        /// Reduced Min of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Min(ArithArray src) => ArrayOps.Min(src);

        /// <summary>
        /// Reduced Min of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Min(ArithArray src, int dimension) => ArrayOps.Min(src, dimension);

        /// <summary>
        /// Reduced Norm of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Norm(ArithArray src, float value) => ArrayOps.Norm(src, value);

        /// <summary>
        /// Reduced Norm w.r.t to a scalar value of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Norm(ArithArray src, float value, int dimension) => ArrayOps.Norm(src, dimension, value);

        /// <summary>
        /// Reduced Variance of the array elements on all dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Var(ArithArray src) => ArrayOps.Var(src);

        /// <summary>
        /// Reduced Variance of the array elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Var(ArithArray src, bool normByN, int dimension) => ArrayOps.Var(src, dimension, normByN);


        /// <summary>
        /// Returns the indices of the minimum values along a dimension.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Argmin(ArithArray src, int dimension) => ArrayOps.Argmin(src, dimension);

        /// <summary>
        /// Returns the indices of the maximum values along a dimension.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static ArithArray Argmax(ArithArray src, int dimension) => ArrayOps.Argmax(src, dimension);
    }
}
