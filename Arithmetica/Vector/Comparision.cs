using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector GreaterThan(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Vector GreaterThan(Vector lhs, float rhs) => Vector.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector GreaterEqual(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Vector GreaterEqual(Vector lhs, float rhs) => Vector.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        /// <summary>
        /// <![CDATA[Performs lhs &lt; rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector LessThan(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        /// <summary>
        /// <![CDATA[Performs lhs &lt; scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Vector LessThan(Vector lhs, float rhs) => Vector.Out(ArrayOps.LessThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs &lt;= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector LessEqual(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs &lt;= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Vector LessEqual(Vector lhs, float rhs) => Vector.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector EqualTo(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Vector EqualTo(Vector lhs, float rhs) => Vector.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector NotEqualTo(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Vector NotEqualTo(Vector lhs, float rhs) => Vector.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        /// <summary>
        /// Find the maximum between two vector elemenwise
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector Maximum(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        /// <summary>
        /// Find the maximum between vector and scalar value
        /// </summary>
        /// <param name="lhs">The LHS vector.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns></returns>
        public static Vector Maximum(Vector lhs, float rhs) => Vector.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
