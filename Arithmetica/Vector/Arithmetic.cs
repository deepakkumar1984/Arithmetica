using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Performs the dot product between 2 vector.
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The second vector.</param>
        /// <returns></returns>
        public static Vector Dot(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        /// <summary>The addmm function is an optimized version of the equation beta*mat + alpha*(mat1 @ mat2)</summary>
        /// <param name="beta">The beta value.</param>
        /// <param name="src">The source vector.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="m1">The first 2D vector.</param>
        /// <param name="m2">The second 2D vector.</param>
        /// <returns></returns>
        public static Vector Addmm(float beta, Vector src, float alpha, Vector m1, Vector m2)
            => Vector.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        /// <summary>
        /// Performs elementwise add operation between two vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The second vector.</param>
        /// <returns></returns>
        public static Vector Add(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between vector and scalar
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Add(Vector lhs, float rhs) => Vector.Out(ArrayOps.Add(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise add operation between scalar and vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Add(float lhs, Vector rhs) => Vector.Out(ArrayOps.Add(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise subtract operation between two vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The second vector.</param>
        /// <returns></returns>
        public static Vector Sub(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between scalar and vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Sub(Vector lhs, float rhs) => Vector.Out(ArrayOps.Sub(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between two vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The second vector.</param>
        /// <returns></returns>
        public static Vector Sub(float lhs, Vector rhs) => Vector.Out(ArrayOps.Sub(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between vector and scalar
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Mul(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between vector and scalar
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Mul(Vector lhs, float rhs) => Vector.Out(ArrayOps.Mul(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Mul(float lhs, Vector rhs) => Vector.Out(ArrayOps.Mul(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise divide operation between two vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The second vector.</param>
        /// <returns></returns>
        public static Vector Div(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise divide operation between vector and scalar
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Div(Vector lhs, float rhs) => Vector.Out(ArrayOps.Div(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise divide operation between scalar and vector
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Div(float lhs, Vector rhs) => Vector.Out(ArrayOps.Div(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise divide modulus for the first vector against a scalar value
        /// </summary>
        /// <param name="lhs">The first vector.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Vector Mod(Vector lhs, float rhs) => Vector.Out(ArrayOps.Mod(lhs.variable, rhs));

        /// <summary>
        /// Negates the specified vector.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Neg(Vector src) => Vector.Out(ArrayOps.Neg(src.variable));

        /// <summary>
        /// Finds the elementwise absolute value of the vector
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Abs(Vector src) => Vector.Out(ArrayOps.Abs(src.variable));

        /// <summary>
        /// Returns an element-wise indication of the sign of a number. The sign function returns -1 if x< 0, 0 if x==0, 1 if x> 0. nan is returned for nan inputs.
        /// For complex inputs, the sign function returns sign(x.real) + 0j if x.real != 0 else sign(x.imag) + 0j.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Sign(Vector src) => Vector.Out(ArrayOps.Sign(src.variable));

        /// <summary>
        /// Finds the linear interpolation is a method of curve fitting using linear polynomials to construct new data points within the range of a discrete set of known data points.
        /// </summary>
        /// <param name="a">The first vector</param>
        /// <param name="b">The second vector.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        public static Vector Lerp(Vector a, Vector b, float weight) => Vector.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
