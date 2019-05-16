using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Geometry
{
    public partial class Quaternion
    {
        /// <summary>
        /// Performs the dot product between 2 quaternion.
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The second quaternion.</param>
        /// <returns></returns>
        public static Quaternion Dot(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        /// <summary>The addmm function is an optimized version of the equation beta*mat + alpha*(mat1 @ mat2)</summary>
        /// <param name="beta">The beta value.</param>
        /// <param name="src">The source quaternion.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="m1">The first 2D quaternion.</param>
        /// <param name="m2">The second 2D quaternion.</param>
        /// <returns></returns>
        public static Quaternion Addmm(float beta, Quaternion src, float alpha, Quaternion m1, Quaternion m2)
            => Quaternion.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        /// <summary>
        /// Performs elementwise add operation between two quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The second quaternion.</param>
        /// <returns></returns>
        public static Quaternion Add(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between quaternion and scalar
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Add(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Add(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise add operation between scalar and quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Add(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Add(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise subtract operation between two quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The second quaternion.</param>
        /// <returns></returns>
        public static Quaternion Sub(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between scalar and quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Sub(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Sub(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between two quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The second quaternion.</param>
        /// <returns></returns>
        public static Quaternion Sub(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Sub(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between quaternion and scalar
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Mul(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise multiplication operation between quaternion and scalar
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Mul(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Mul(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise multiplication operation between scalar and quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Mul(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Mul(rhs.variable, lhs));

        /// <summary>
        /// Performs elementwise divide operation between two quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The second quaternion.</param>
        /// <returns></returns>
        public static Quaternion Div(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise divide operation between quaternion and scalar
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Div(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Div(lhs.variable, rhs));

        /// <summary>
        /// Performs elementwise divide operation between scalar and quaternion
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Div(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Div(lhs, rhs.variable));

        /// <summary>
        /// Performs elementwise divide modulus for the first quaternion against a scalar value
        /// </summary>
        /// <param name="lhs">The first quaternion.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Quaternion Mod(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Mod(lhs.variable, rhs));

        /// <summary>
        /// Negates the specified quaternion.
        /// </summary>
        /// <param name="src">The source quaternion.</param>
        /// <returns></returns>
        public static Quaternion Neg(Quaternion src) => Quaternion.Out(ArrayOps.Neg(src.variable));

        //public static Quaternion Abs(Quaternion src) => Quaternion.Out(ArrayOps.Abs(src.variable));

        //public static Quaternion Sign(Quaternion src) => Quaternion.Out(ArrayOps.Sign(src.variable));

        //public static Quaternion Lerp(Quaternion a, Quaternion b, float weight) => Quaternion.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
