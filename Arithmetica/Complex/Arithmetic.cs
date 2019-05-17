using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs the dot product between 2 matrix.
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Complex Dot(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Dot(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Complex Add(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Complex Sub(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Sub(lhs.variable, rhs.variable));


        /// <summary>
        /// Performs elementwise multiplication operation between matrix and scalar
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Complex Mul(Complex lhs, Complex rhs)
        {

        }

        /// <summary>
        /// Performs elementwise divide operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Complex Div(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        /// <summary>
        /// Negates the specified matrix.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Neg(Complex src) => Complex.Out(ArrayOps.Neg(src.variable));

        /// <summary>
        /// Finds the elementwise absolute value of the matrix
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Abs(Complex src) => Complex.Out(ArrayOps.Abs(src.variable));

        /// <summary>
        /// Returns an element-wise indication of the sign of a number. The sign function returns -1 if x< 0, 0 if x==0, 1 if x> 0. nan is returned for nan inputs.
        /// For complex inputs, the sign function returns sign(x.real) + 0j if x.real != 0 else sign(x.imag) + 0j.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Complex Sign(Complex src) => Complex.Out(ArrayOps.Sign(src.variable));

        /// <summary>
        /// Finds the linear interpolation is a method of curve fitting using linear polynomials to construct new data points within the range of a discrete set of known data points.
        /// </summary>
        /// <param name="a">The first matrix</param>
        /// <param name="b">The second matrix.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        public static Complex Lerp(Complex a, Complex b, float weight) => Complex.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
