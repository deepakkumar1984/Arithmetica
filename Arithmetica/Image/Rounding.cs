using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Imaging
{
    public partial class Image
    {
        /// <summary>
        /// Return the floor of the input, element-wise. The floor of the scalar x is the largest integer i.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Floor(Image src) => Image.Out(ArrayOps.Floor(src.variable));

        /// <summary>
        /// Return the round of the input, element-wise to nearest integer
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Round(Image src) => Image.Out(ArrayOps.Round(src.variable));

        /// <summary>
        /// Return the truncated value of the input, element-wise. The truncated value of the scalar x is the nearest integer i which is closer to zero than x is. In short, the fractional part of the signed number x is discarded.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Trunc(Image src) => Image.Out(ArrayOps.Trunc(src.variable));

        /// <summary>
        /// Return the ceiling of the input, element-wise. The ceil of the scalar x is the smallest integer i, such that i >= x.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Ceil(Image src) => Image.Out(ArrayOps.Ceil(src.variable));

        /// <summary>
        /// Clip (limit) the values in an Image. Given an interval, values outside the interval are clipped to the interval edges.For example, if an interval of[0, 1] is specified, values smaller than 0 become 0, and values larger than 1 become 1.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <param name="min">The minimum clip value.</param>
        /// <param name="max">The maximum clip value.</param>
        /// <returns></returns>
        public static Image Clip(Image src, float min, float max) => Image.Out(ArrayOps.Clip(src.variable, min, max));

        /// <summary>
        /// Return the fractional and integral parts of an Image, element-wise. The fractional and integral parts are negative if the given number is negative.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Frac(Image src) => Image.Out(ArrayOps.Frac(src.variable));

        /// <summary>
        /// Compute the standard deviation along the specified axis. 
        /// Returns the standard deviation, a measure of the spread of a distribution, of the Image elements.The standard deviation is computed for the flattened Image by default, otherwise over the specified axis.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Std(Image src) => Image.Out(ArrayOps.Std(src.variable));

        /// <summary>
        /// Compute the standard deviation along the specified axis. 
        /// Returns the standard deviation, a measure of the spread of a distribution, of the Image elements.The standard deviation is computed for the flattened Image by default, otherwise over the specified axis.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Std(Image src, bool normbyN, int dimension) => Image.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
