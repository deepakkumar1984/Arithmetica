using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Return the floor of the input, element-wise. The floor of the scalar x is the largest integer i, such that i <= x.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Floor(Vector src) => Vector.Out(ArrayOps.Floor(src.variable));

        /// <summary>
        /// Return the round of the input, element-wise to nearest integer
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Round(Vector src) => Vector.Out(ArrayOps.Round(src.variable));

        /// <summary>
        /// Return the truncated value of the input, element-wise. The truncated value of the scalar x is the nearest integer i which is closer to zero than x is. In short, the fractional part of the signed number x is discarded.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Trunc(Vector src) => Vector.Out(ArrayOps.Trunc(src.variable));

        /// <summary>
        /// Return the ceiling of the input, element-wise. The ceil of the scalar x is the smallest integer i, such that i >= x.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Ceil(Vector src) => Vector.Out(ArrayOps.Ceil(src.variable));

        /// <summary>
        /// Clip (limit) the values in an vector. Given an interval, values outside the interval are clipped to the interval edges.For example, if an interval of[0, 1] is specified, values smaller than 0 become 0, and values larger than 1 become 1.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <param name="min">The minimum clip value.</param>
        /// <param name="max">The maximum clip value.</param>
        /// <returns></returns>
        public static Vector Clip(Vector src, float min, float max) => Vector.Out(ArrayOps.Clip(src.variable, min, max));

        /// <summary>
        /// Return the fractional and integral parts of an vector, element-wise. The fractional and integral parts are negative if the given number is negative.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Frac(Vector src) => Vector.Out(ArrayOps.Frac(src.variable));

        /// <summary>
        /// Compute the standard deviation along the specified axis. 
        /// Returns the standard deviation, a measure of the spread of a distribution, of the vector elements.The standard deviation is computed for the flattened vector by default, otherwise over the specified axis.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Std(Vector src) => Vector.Out(ArrayOps.Std(src.variable));

        /// <summary>
        /// Compute the standard deviation along the specified axis. 
        /// Returns the standard deviation, a measure of the spread of a distribution, of the vector elements.The standard deviation is computed for the flattened vector by default, otherwise over the specified axis.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Std(Vector src, bool normbyN, int dimension) => Vector.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
