using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Single
{
    public partial class Matrix
    {
        /// <summary>
        /// Performs the dot product between 2 matrix.
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Matrix Dot(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Dot(lhs.variable, rhs.variable));

        /// <summary>The addmm function is an optimized version of the equation beta*mat + alpha*(mat1 @ mat2)</summary>
        /// <param name="beta">The beta value.</param>
        /// <param name="src">The source matrix.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="m1">The first 2D matrix.</param>
        /// <param name="m2">The second 2D matrix.</param>
        /// <returns></returns>
        public static Matrix Addmm(float beta, Matrix src, float alpha, Matrix m1, Matrix m2)
            => Matrix.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        /// <summary>
        /// Performs elementwise add operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Matrix Add(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between matrix and scalar
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Add(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Add(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise add operation between scalar and matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Add(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Add(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise subtract operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Matrix Sub(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between scalar and matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Sub(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Sub(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Matrix Sub(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Sub(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between matrix and scalar
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Mul(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between matrix and scalar
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Mul(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Mul(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Mul(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Mul(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise divide operation between two matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The second matrix.</param>
        /// <returns></returns>
        public static Matrix Div(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise divide operation between matrix and scalar
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Div(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Div(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise divide operation between scalar and matrix
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Div(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Div(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise divide modulus for the first matrix against a scalar value
        /// </summary>
        /// <param name="lhs">The first matrix.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Matrix Mod(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Mod(lhs.variable, rhs));

        /// <summary>
        /// Negates the specified matrix.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Neg(Matrix src) => Matrix.Out(ArrayOps.Neg(src.variable));

        /// <summary>
        /// Finds the elementwise absolute value of the matrix
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Abs(Matrix src) => Matrix.Out(ArrayOps.Abs(src.variable));

        /// <summary>
        /// Returns an element-wise indication of the sign of a number. The sign function returns -1 if x< 0, 0 if x==0, 1 if x> 0. nan is returned for nan inputs.
        /// For complex inputs, the sign function returns sign(x.real) + 0j if x.real != 0 else sign(x.imag) + 0j.
        /// </summary>
        /// <param name="src">The source matrix.</param>
        /// <returns></returns>
        public static Matrix Sign(Matrix src) => Matrix.Out(ArrayOps.Sign(src.variable));

        /// <summary>
        /// Finds the linear interpolation is a method of curve fitting using linear polynomials to construct new data points within the range of a discrete set of known data points.
        /// </summary>
        /// <param name="a">The first matrix</param>
        /// <param name="b">The second matrix.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        public static Matrix Lerp(Matrix a, Matrix b, float weight) => Matrix.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
