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
        public static float Sum(Matrix src) => ArrayOps.SumF(src.variable);

        /// <summary>
        /// Reduced Sum of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Sum(Matrix src, int dimension) => Matrix.Out(ArrayOps.Sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Prod(Matrix src) => ArrayOps.ProdF(src.variable);

        /// <summary>
        /// Reduced Prod of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Prod(Matrix src, int dimension) => Matrix.Out(ArrayOps.Prod(src.variable, dimension));

        /// <summary>
        /// Reduced Mean of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Mean(Matrix src) => ArrayOps.MeanF(src.variable);

        /// <summary>
        /// Reduced Mean of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Mean(Matrix src, int dimension) => Matrix.Out(ArrayOps.Mean(src.variable, dimension));

        /// <summary>
        /// Reduced Max of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Max(Matrix src) => ArrayOps.MaxF(src.variable);

        /// <summary>
        /// Reduced Max of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Max(Matrix src, int dimension) => Matrix.Out(ArrayOps.Max(src.variable, dimension));

        /// <summary>
        /// Reduced Min of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Min(Matrix src) => ArrayOps.MinF(src.variable);

        /// <summary>
        /// Reduced Min of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Min(Matrix src, int dimension) => Matrix.Out(ArrayOps.Min(src.variable, dimension));

        /// <summary>
        /// Reduced Norm of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Norm(Matrix src, float value) => ArrayOps.Norm(src.variable, value).DataFloat[0];

        /// <summary>
        /// Reduced Norm w.r.t to a scalar value of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Norm(Matrix src, float value, int dimension) => Matrix.Out(ArrayOps.Norm(src.variable, dimension, value));

        /// <summary>
        /// Reduced Variance of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Var(Matrix src) => ArrayOps.Var(src.variable).DataFloat[0];

        /// <summary>
        /// Reduced Variance of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Var(Matrix src, bool normByN, int dimension) => Matrix.Out(ArrayOps.Var(src.variable, dimension, normByN));

        /// <summary>
        /// Returns the indices of the minimum values along a dimension.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Argmin(Matrix src, int dimension) => Matrix.Out(ArrayOps.Argmin(src.variable, dimension));

        /// <summary>
        /// Returns the indices of the maximum values along a dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Matrix Argmax(Matrix src, int dimension) => Matrix.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
