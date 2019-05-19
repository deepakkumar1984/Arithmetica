using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Image
    {
        /// <summary>
        /// Performs the dot product between 2 Image.
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Dot(Image lhs, Image rhs) => Image.Out(ArrayOps.Sum(ArrayOps.Mul(lhs.variable, rhs.variable.Transpose()), 1));

        /// <summary>
        /// Performs elementwise add operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Add(Image lhs, Image rhs) => Image.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Add(Image lhs, float rhs) => Image.Out(ArrayOps.Add(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise add operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Add(float lhs, Image rhs) => Image.Out(ArrayOps.Add(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise subtract operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Sub(Image lhs, Image rhs) => Image.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Sub(Image lhs, float rhs) => Image.Out(ArrayOps.Sub(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Sub(float lhs, Image rhs) => Image.Out(ArrayOps.Sub(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mul(Image lhs, Image rhs) => Image.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mul(Image lhs, float rhs) => Image.Out(ArrayOps.Mul(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mul(float lhs, Image rhs) => Image.Out(ArrayOps.Mul(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise divide operation between two Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The second Image.</param>
        /// <returns></returns>
        public static Image Div(Image lhs, Image rhs) => Image.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise divide operation between Image and scalar
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Div(Image lhs, float rhs) => Image.Out(ArrayOps.Div(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise divide operation between scalar and Image
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Div(float lhs, Image rhs) => Image.Out(ArrayOps.Div(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise divide modulus for the first Image against a scalar value
        /// </summary>
        /// <param name="lhs">The first Image.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Image Mod(Image lhs, float rhs) => Image.Out(ArrayOps.Mod(lhs.variable, rhs));

        /// <summary>
        /// Negates the specified Image.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Neg(Image src) => Image.Out(ArrayOps.Neg(src.variable));

        /// <summary>
        /// Finds the elementwise absolute value of the Image
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Abs(Image src) => Image.Out(ArrayOps.Abs(src.variable));

        /// <summary>
        /// Returns an element-wise indication of the sign of a number. The sign function returns -1 if x< 0, 0 if x==0, 1 if x> 0. nan is returned for nan inputs.
        /// For complex inputs, the sign function returns sign(x.real) + 0j if x.real != 0 else sign(x.imag) + 0j.
        /// </summary>
        /// <param name="src">The source Image.</param>
        /// <returns></returns>
        public static Image Sign(Image src) => Image.Out(ArrayOps.Sign(src.variable));

        /// <summary>
        /// Finds the linear interpolation is a method of curve fitting using linear polynomials to construct new data points within the range of a discrete set of known data points.
        /// </summary>
        /// <param name="a">The first Image</param>
        /// <param name="b">The second Image.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        public static Image Lerp(Image a, Image b, float weight) => Image.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
