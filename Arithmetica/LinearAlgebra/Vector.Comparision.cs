using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T>
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray GreaterThan(Vector<T> lhs, Vector<T> rhs) => ArrayOps.GreaterThan(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray GreaterThan(Vector<T> lhs, float rhs) => ArrayOps.GreaterThan(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray GreaterEqual(Vector<T> lhs, Vector<T> rhs) => ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray GreaterEqual(Vector<T> lhs, float rhs) => ArrayOps.GreaterOrEqual(lhs.variable, rhs);

        /// <summary>
        /// <![CDATA[Performs lhs &lt; rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray LessThan(Vector<T> lhs, Vector<T> rhs) => ArrayOps.LessThan(lhs.variable, rhs.variable);

        /// <summary>
        /// <![CDATA[Performs lhs &lt; scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray LessThan(Vector<T> lhs, float rhs) => ArrayOps.LessThan(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs &lt;= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray LessEqual(Vector<T> lhs, Vector<T> rhs) => ArrayOps.LessOrEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs &lt;= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray LessEqual(Vector<T> lhs, float rhs) => ArrayOps.LessOrEqual(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray EqualTo(Vector<T> lhs, Vector<T> rhs) => ArrayOps.EqualTo(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray EqualTo(Vector<T> lhs, float rhs) => ArrayOps.LessOrEqual(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray NotEqualTo(Vector<T> lhs, Vector<T> rhs) => ArrayOps.NotEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray NotEqualTo(Vector<T> lhs, float rhs) => ArrayOps.NotEqual(lhs.variable, rhs);

        /// <summary>
        /// Find the maximum between two Vector<T> elemenwise
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Maximum(Vector<T> lhs, Vector<T> rhs) => ArrayOps.Maximum(lhs.variable, rhs.variable);

        /// <summary>
        /// Find the maximum between Vector<T> and scalar value
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Maximum(Vector<T> lhs, float rhs) => ArrayOps.Maximum(lhs.variable, rhs);

    }
}
