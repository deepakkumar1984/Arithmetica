using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Imaging
{
    public partial class Image
    {
        /// <summary>
        /// Performs the dot product between 2 Image.
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Dot(Image lhs, Image rhs) => Image.Out(np.sum(np.multiply(lhs.variable, rhs.variable.transpose()), 1));

        /// <summary>
        /// Performs elementwise add operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Add(Image lhs, Image rhs) => Image.Out(np.add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Add(Image lhs, float rhs) => Image.Out(np.add(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise add operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Add(float lhs, Image rhs) => Image.Out(np.add(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise subtract operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Sub(Image lhs, Image rhs) => Image.Out(np.subtract(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Sub(Image lhs, float rhs) => Image.Out(np.subtract(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Sub(float lhs, Image rhs) => Image.Out(np.subtract(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mul(Image lhs, Image rhs) => Image.Out(np.multiply(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mul(Image lhs, float rhs) => Image.Out(np.multiply(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mul(float lhs, Image rhs) => Image.Out(np.multiply(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise divide operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Div(Image lhs, Image rhs) => Image.Out(np.divide(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise divide operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Div(Image lhs, float rhs) => Image.Out(np.divide(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise divide operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Div(float lhs, Image rhs) => Image.Out(np.divide(lhs, rhs.variable));
    }
}
