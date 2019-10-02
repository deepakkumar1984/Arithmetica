using NumSharp;
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
        public static Image Sum(Image src, int dimension) => Image.Out(np.sum(src.variable, dimension));

        /// <summary>
        /// Reduced Prod of the matrix elements on all dimension.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static float Prod(Image src) => np.prod(src.variable);

        public static Image Prod(Image src, int dimension) => Image.Out(np.prod(src.variable, dimension));

        public static float Mean(Image src) => np.mean(src.variable);

        public static Image Mean(Image src, int dimension) => Image.Out(np.mean(src.variable, dimension));

        public static float Max(Image src) => np.max(src.variable);

        public static Image Max(Image src, int dimension) => Image.Out(np.max(src.variable, dimension));

        public static Image Min(Image src, int dimension) => Image.Out(np.min(src.variable, dimension));

    }
}
