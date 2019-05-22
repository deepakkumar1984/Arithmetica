using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Imaging
{
    public partial class Image
    {
        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the Image
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static Image Pow(Image src, float value) => Image.Out(ArrayOps.Pow(src.variable, value));

        /// <summary>
        /// Performs elementwise power to Image power operation elemenwise for a scalar
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Tpow(float value, Image src) => Image.Out(ArrayOps.Tpow(value, src.variable));

        /// <summary>
        /// Perform square root operation on the Image elemenwise.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Sqrt(Image src) => Image.Out(ArrayOps.Sqrt(src.variable));

        /// <summary>
        /// Perform square operation on the Image elemenwise.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Square(Image src) => Image.Out(ArrayOps.Square(src.variable));

    }
}
