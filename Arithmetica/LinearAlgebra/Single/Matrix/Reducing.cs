using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Single
{
    public partial class Matrix
    {
        /// <summary>
        /// Reduced Sum of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Sum(Matrix src) => np.sum(src.variable);

        /// <summary>
        /// Reduced Sum of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Sum(Matrix src, int dimension) => Matrix.Out(np.sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Prod(Matrix src) => np.prod(src.variable);

        /// <summary>
        /// Reduced Prod of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Prod(Matrix src, int dimension) => Matrix.Out(np.prod(src.variable, dimension));

        /// <summary>
        /// Reduced Mean of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Mean(Matrix src) => np.mean(src.variable);

        /// <summary>
        /// Reduced Mean of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Mean(Matrix src, int dimension) => Matrix.Out(np.mean(src.variable, dimension));

        /// <summary>
        /// Reduced Max of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Max(Matrix src) => np.max(src.variable);

        /// <summary>
        /// Reduced Max of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Max(Matrix src, int dimension) => Matrix.Out(np.max(src.variable, dimension));

        /// <summary>
        /// Reduced Min of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Min(Matrix src) => np.min(src.variable);

        ///// <summary>
        ///// Reduced Min of the matrix elements on a specific dimension.
        ///// </summary>
        ///// <param name="src">The source matrix.</param>
        ///// <param name="dimension">The dimension.</param>
        ///// <returns></returns>
        //public static Matrix Min(Matrix src, int dimension) => Matrix.Out(np.min(src.variable, dimension));

        ///// <summary>
        ///// Reduced Norm of the matrix elements on all dimension.
        ///// </summary>
        ///// <param name="src">The source matrix.</param>
        ///// <returns></returns>
        //public static float Norm(Matrix src, float value) => Global.OP.Norm(src.variable, value).DataFloat[0];

        ///// <summary>
        ///// Reduced Norm w.r.t to a scalar value of the matrix elements on a specific dimension.
        ///// </summary>
        ///// <param name="src">The source matrix.</param>
        ///// <param name="dimension">The dimension.</param>
        ///// <returns></returns>
        //public static Matrix Norm(Matrix src, float value, int dimension) => Matrix.Out(Global.OP.Norm(src.variable, dimension, value));

        ///// <summary>
        ///// Reduced Variance of the matrix elements on all dimension.
        ///// </summary>
        ///// <param name="src">The source matrix.</param>
        ///// <returns></returns>
        //public static float Var(Matrix src) => Global.OP.Var(src.variable).DataFloat[0];

        ///// <summary>
        ///// Reduced Variance of the matrix elements on a specific dimension.
        ///// </summary>
        ///// <param name="src">The source matrix.</param>
        ///// <param name="dimension">The dimension.</param>
        ///// <returns></returns>
        //public static Matrix Var(Matrix src, bool normByN, int dimension) => Matrix.Out(Global.OP.Var(src.variable, dimension, normByN));

        /// <summary>
        /// Returns the indices of the minimum values along a dimension.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Argmin(Matrix src, int dimension) => Matrix.Out(Global.OP.Argmin(src.variable, dimension));

        /// <summary>
        /// Returns the indices of the maximum values along a dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Argmax(Matrix src, int dimension) => Matrix.Out(Global.OP.Argmax(src.variable, dimension));
    }
}
