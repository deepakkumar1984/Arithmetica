using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Imaging
{
    public partial class Image
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Exp(Image src) => Image.Out(ArrayOps.Exp(src.variable));

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Log(Image src) => Image.Out(ArrayOps.Log(src.variable));

        /// <summary>
        /// Return the natural logarithm of one plus the input Image, element-wise.        Calculates log(1 + x).
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Log1p(Image src) => Image.Out(ArrayOps.Log1p(src.variable));

    }
}
