using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Geometry
{
    public partial class Plane
    {
        /// <summary>
        /// Performs the dot product between 2 plane.
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The second plane.</param>
        /// <returns></returns>
        public static Plane Dot(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        /// <summary>
        /// Performs the dot product between plan and Vector4.
        /// </summary>
        /// <param name="lhs">The plan.</param>
        /// <param name="rhs">The vector4.</param>
        /// <returns></returns>
        public static Plane Dot(Plane lhs, Vector4 rhs) => Plane.Out(ArrayOps.Dot(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs the dot product between plan and Matrix (4 x n).
        /// </summary>
        /// <param name="lhs">The plane.</param>
        /// <param name="rhs">The matrix (4 x n).</param>
        /// <returns></returns>
        public static Plane Dot(Plane lhs, Complex rhs) => Plane.Out(ArrayOps.Dot(lhs.variable, rhs.variable));

        /// <summary>The addmm function is an optimized version of the equation beta*mat + alpha*(mat1 @ mat2)</summary>
        /// <param name="beta">The beta value.</param>
        /// <param name="src">The source plane.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="m1">The first 2D plane.</param>
        /// <param name="m2">The second 2D plane.</param>
        /// <returns></returns>
        public static Plane Addmm(float beta, Plane src, float alpha, Plane m1, Plane m2)
            => Plane.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        /// <summary>
        /// Performs elementwise add operation between two plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The second plane.</param>
        /// <returns></returns>
        public static Plane Add(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between plane and scalar
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Add(Plane lhs, float rhs) => Plane.Out(ArrayOps.Add(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise add operation between scalar and plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Add(float lhs, Plane rhs) => Plane.Out(ArrayOps.Add(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise subtract operation between two plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The second plane.</param>
        /// <returns></returns>
        public static Plane Sub(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between scalar and plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Sub(Plane lhs, float rhs) => Plane.Out(ArrayOps.Sub(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between two plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The second plane.</param>
        /// <returns></returns>
        public static Plane Sub(float lhs, Plane rhs) => Plane.Out(ArrayOps.Sub(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between plane and scalar
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Mul(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between plane and scalar
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Mul(Plane lhs, float rhs) => Plane.Out(ArrayOps.Mul(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Mul(float lhs, Plane rhs) => Plane.Out(ArrayOps.Mul(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise divide operation between two plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The second plane.</param>
        /// <returns></returns>
        public static Plane Div(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise divide operation between plane and scalar
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Div(Plane lhs, float rhs) => Plane.Out(ArrayOps.Div(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise divide operation between scalar and plane
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Div(float lhs, Plane rhs) => Plane.Out(ArrayOps.Div(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise divide modulus for the first plane against a scalar value
        /// </summary>
        /// <param name="lhs">The first plane.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Plane Mod(Plane lhs, float rhs) => Plane.Out(ArrayOps.Mod(lhs.variable, rhs));

        /// <summary>
        /// Negates the specified plane.
        /// </summary>
        /// <param name="src">The source plane.</param>
        /// <returns></returns>
        public static Plane Neg(Plane src) => Plane.Out(ArrayOps.Neg(src.variable));

        //public static Plane Abs(Plane src) => Plane.Out(ArrayOps.Abs(src.variable));

        //public static Plane Sign(Plane src) => Plane.Out(ArrayOps.Sign(src.variable));

        //public static Plane Lerp(Plane a, Plane b, float weight) => Plane.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
