using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        /// <summary>
        /// Performs the dot product between 2 array.
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The second array.</param>
        /// <returns></returns>
        public static ArithArray Dot(ArithArray lhs, ArithArray rhs) => ArrayOps.Dot(lhs, rhs);

        /// <summary>The addmm function is an optimized version of the equation beta*mat + alpha*(mat1 @ mat2)</summary>
        /// <param name="beta">The beta value.</param>
        /// <param name="src">The source array.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="m1">The first 2D array.</param>
        /// <param name="m2">The second 2D array.</param>
        /// <returns></returns>
        public static ArithArray Addmm(float beta, ArithArray src, float alpha, ArithArray m1, ArithArray m2)
            => ArrayOps.Addmm(beta, src, alpha, m1, m2);

        /// <summary>
        /// Performs elementwise add operation between two array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The second array.</param>
        /// <returns></returns>
        public static ArithArray Add(ArithArray lhs, ArithArray rhs) => ArrayOps.Add(lhs, rhs);

        /// <summary>
        /// Performs elementwise add operation between array and scalar
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Add(ArithArray lhs, float rhs) => ArrayOps.Add(lhs, rhs);

        /// <summary>
        /// Performs elementwise add operation between scalar and array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Add(float lhs, ArithArray rhs) => ArrayOps.Add(rhs, lhs);

        /// <summary>
        /// Performs elementwise subtract operation between two array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The second array.</param>
        /// <returns></returns>
        public static ArithArray Sub(ArithArray lhs, ArithArray rhs) => ArrayOps.Sub(lhs, rhs);

        /// <summary>
        /// Performs elementwise subtract operation between array and scalar
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Sub(ArithArray lhs, float rhs) => ArrayOps.Sub(lhs, rhs);

        /// <summary>
        /// Performs elementwise subtract operation between scalar and array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Sub(float lhs, ArithArray rhs) => ArrayOps.Sub(lhs, rhs);

        /// <summary>
        /// Performs elementwise multiplication operation between two array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The second array.</param>
        /// <returns></returns>
        public static ArithArray Mul(ArithArray lhs, ArithArray rhs) => ArrayOps.Mul(lhs, rhs);

        /// <summary>
        /// Performs elementwise multiplication operation between array and scalar
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Mul(ArithArray lhs, float rhs) => ArrayOps.Mul(lhs, rhs);

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Mul(float lhs, ArithArray rhs) => ArrayOps.Mul(rhs, lhs);

        /// <summary>
        /// Performs elementwise divide operation between two array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The second array.</param>
        /// <returns></returns>
        public static ArithArray Div(ArithArray lhs, ArithArray rhs) => ArrayOps.Div(lhs, rhs);

        /// <summary>
        /// Performs elementwise divide operation between array and scalar
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Div(ArithArray lhs, float rhs) => ArrayOps.Div(lhs, rhs);

        /// <summary>
        /// Performs elementwise divide operation between scalar and array
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Div(float lhs, ArithArray rhs) => ArrayOps.Div(lhs, rhs);

        /// <summary>
        /// Performs elementwise divide modulus for the first array against a scalar value
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static ArithArray Mod(ArithArray lhs, float rhs) => ArrayOps.Mod(lhs, rhs);

        /// <summary>
        /// Negates the specified array.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Neg(ArithArray src) => ArrayOps.Neg(src);

        /// <summary>
        /// Finds the elementwise absolute value of the array
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Abs(ArithArray src) => ArrayOps.Abs(src);

        /// <summary>
        /// Returns an element-wise indication of the sign of a number. The sign function returns -1 if x< 0, 0 if x==0, 1 if x> 0. nan is returned for nan inputs.
       /// For complex inputs, the sign function returns sign(x.real) + 0j if x.real != 0 else sign(x.imag) + 0j.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Sign(ArithArray src) => ArrayOps.Sign(src);

        /// <summary>
        /// Finds the linear interpolation is a method of curve fitting using linear polynomials to construct new data points within the range of a discrete set of known data points.
        /// </summary>
        /// <param name="a">The first array</param>
        /// <param name="b">The second array.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        public static ArithArray Lerp(ArithArray a, ArithArray b, float weight) => ArrayOps.Lerp(a, b, weight);
    }
}
