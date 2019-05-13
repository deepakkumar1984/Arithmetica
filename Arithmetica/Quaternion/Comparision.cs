using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion GreaterThan(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Quaternion GreaterThan(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion GreaterEqual(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Quaternion GreaterEqual(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        /// <summary>
        /// <![CDATA[Performs lhs < rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion LessThan(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        /// <summary>
        /// <![CDATA[Performs lhs < scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Quaternion LessThan(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.LessThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs <= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion LessEqual(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs <= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Quaternion LessEqual(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion EqualTo(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Quaternion EqualTo(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion NotEqualTo(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Quaternion NotEqualTo(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        /// <summary>
        /// Find the maximum between two quaternion elemenwise
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion Maximum(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        /// <summary>
        /// Find the maximum between quaternion and scalar value
        /// </summary>
        /// <param name="lhs">The LHS quaternion.</param>
        /// <param name="rhs">The RHS quaternion.</param>
        /// <returns></returns>
        public static Quaternion Maximum(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
