using NumSharp;
using NumSharp;
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
        public static NDArray GreaterThan(Vector<T> lhs, Vector<T> rhs) => lhs.variable > rhs.variable;

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static NDArray GreaterThan(Vector<T> lhs, float rhs) => lhs.variable > rhs;

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray GreaterEqual(Vector<T> lhs, Vector<T> rhs) => lhs.variable >= rhs.variable;

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static NDArray GreaterEqual(Vector<T> lhs, float rhs) => lhs.variable >= rhs;

        /// <summary>
        /// <![CDATA[Performs lhs &lt; rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray LessThan(Vector<T> lhs, Vector<T> rhs) => lhs.variable < rhs.variable;

        /// <summary>
        /// <![CDATA[Performs lhs &lt; scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static NDArray LessThan(Vector<T> lhs, float rhs) => lhs.variable < rhs;

        /// <summary>
        /// Performs lhs &lt;= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray LessEqual(Vector<T> lhs, Vector<T> rhs) => lhs.variable <= rhs.variable;

        /// <summary>
        /// Performs lhs &lt;= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static NDArray LessEqual(Vector<T> lhs, float rhs) => lhs.variable <= rhs;

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray EqualTo(Vector<T> lhs, Vector<T> rhs) => np.array_equal(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static NDArray EqualTo(Vector<T> lhs, float rhs) => lhs.variable <= rhs;

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray NotEqualTo(Vector<T> lhs, Vector<T> rhs) => Global.OP.NotEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static NDArray NotEqualTo(Vector<T> lhs, float rhs) => Global.OP.NotEqual(lhs.variable, rhs);

        /// <summary>
        /// Find the maximum between two Vector<T> elemenwise
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray Maximum(Vector<T> lhs, Vector<T> rhs) => np(lhs.variable, rhs.variable);

        /// <summary>
        /// Find the maximum between Vector<T> and scalar value
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static NDArray Maximum(Vector<T> lhs, float rhs) => np.maximum(lhs.variable, rhs);

    }
}
