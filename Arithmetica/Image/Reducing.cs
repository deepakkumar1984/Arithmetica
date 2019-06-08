using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Imaging
{
    public partial class Image
    {
        /// <summary>
        /// Reduced Sum of the matrix elements on a specific dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public static Image Sum(Image src, int dimension) => Image.Out(Global.OP.Sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Prod(Image src) => Global.OP.Prod(src.variable);

        public static Image Prod(Image src, int dimension) => Image.Out(Global.OP.Prod(src.variable, dimension));

        public static float Mean(Image src) => Global.OP.Mean(src.variable);

        public static Image Mean(Image src, int dimension) => Image.Out(Global.OP.Mean(src.variable, dimension));

        public static float Max(Image src) => Global.OP.Max(src.variable);

        public static Image Max(Image src, int dimension) => Image.Out(Global.OP.Max(src.variable, dimension));

        public static Image Min(Image src, int dimension) => Image.Out(Global.OP.Min(src.variable, dimension));

    }
}
