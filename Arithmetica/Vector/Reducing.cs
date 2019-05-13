using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Reduced Sum of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Vector Sum(Vector src) => Vector.Out(ArrayOps.Sum(src.variable));

        /// <summary>
        /// Reduced Sum of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Vector Sum(Vector src, int dimension) => Vector.Out(ArrayOps.Sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Vector Prod(Vector src) => Vector.Out(ArrayOps.Prod(src.variable));

        public static Vector Prod(Vector src, int dimension) => Vector.Out(ArrayOps.Prod(src.variable, dimension));

        public static Vector Mean(Vector src) => Vector.Out(ArrayOps.Mean(src.variable));

        public static Vector Mean(Vector src, int dimension) => Vector.Out(ArrayOps.Mean(src.variable, dimension));

        public static Vector Max(Vector src) => Vector.Out(ArrayOps.Max(src.variable));

        public static Vector Max(Vector src, int dimension) => Vector.Out(ArrayOps.Max(src.variable, dimension));

        public static Vector Min(Vector src) => Vector.Out(ArrayOps.Min(src.variable));

        public static Vector Min(Vector src, int dimension) => Vector.Out(ArrayOps.Min(src.variable, dimension));

        public static Vector Norm(Vector src, float value) => Vector.Out(ArrayOps.Norm(src.variable, value));

        public static Vector Norm(Vector src, float value, int dimension) => Vector.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Vector Var(Vector src) => Vector.Out(ArrayOps.Var(src.variable));

        public static Vector Var(Vector src, bool normByN, int dimension) => Vector.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Vector Argmin(Vector src, int dimension) => Vector.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Vector Argmax(Vector src, int dimension) => Vector.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
