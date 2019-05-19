using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Image
    {
        /// <summary>
        /// Reduced Sum of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Image Sum(Image src) => Image.Out(ArrayOps.Sum(src.variable));

        /// <summary>
        /// Reduced Sum of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Image Sum(Image src, int dimension) => Image.Out(ArrayOps.Sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Image Prod(Image src) => Image.Out(ArrayOps.Prod(src.variable));

        public static Image Prod(Image src, int dimension) => Image.Out(ArrayOps.Prod(src.variable, dimension));

        public static Image Mean(Image src) => Image.Out(ArrayOps.Mean(src.variable));

        public static Image Mean(Image src, int dimension) => Image.Out(ArrayOps.Mean(src.variable, dimension));

        public static Image Max(Image src) => Image.Out(ArrayOps.Max(src.variable));

        public static Image Max(Image src, int dimension) => Image.Out(ArrayOps.Max(src.variable, dimension));

        public static Image Min(Image src) => Image.Out(ArrayOps.Min(src.variable));

        public static Image Min(Image src, int dimension) => Image.Out(ArrayOps.Min(src.variable, dimension));

        public static Image Norm(Image src, float value) => Image.Out(ArrayOps.Norm(src.variable, value));

        public static Image Norm(Image src, float value, int dimension) => Image.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Image Var(Image src) => Image.Out(ArrayOps.Var(src.variable));

        public static Image Var(Image src, bool normByN, int dimension) => Image.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Image Argmin(Image src, int dimension) => Image.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Image Argmax(Image src, int dimension) => Image.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
