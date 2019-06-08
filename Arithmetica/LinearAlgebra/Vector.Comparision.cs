using SuperchargedArray;
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
        public static SuperArray GreaterThan(Vector<T> lhs, Vector<T> rhs) => Global.OP.GreaterThan(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static SuperArray GreaterThan(Vector<T> lhs, float rhs) => Global.OP.GreaterThan(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray GreaterEqual(Vector<T> lhs, Vector<T> rhs) => Global.OP.GreaterOrEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static SuperArray GreaterEqual(Vector<T> lhs, float rhs) => Global.OP.GreaterOrEqual(lhs.variable, rhs);

        /// <summary>
        /// <![CDATA[Performs lhs &lt; rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray LessThan(Vector<T> lhs, Vector<T> rhs) => Global.OP.LessThan(lhs.variable, rhs.variable);

        /// <summary>
        /// <![CDATA[Performs lhs &lt; scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static SuperArray LessThan(Vector<T> lhs, float rhs) => Global.OP.LessThan(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs &lt;= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray LessEqual(Vector<T> lhs, Vector<T> rhs) => Global.OP.LessOrEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs &lt;= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static SuperArray LessEqual(Vector<T> lhs, float rhs) => Global.OP.LessOrEqual(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray EqualTo(Vector<T> lhs, Vector<T> rhs) => Global.OP.EqualTo(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static SuperArray EqualTo(Vector<T> lhs, float rhs) => Global.OP.LessOrEqual(lhs.variable, rhs);

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray NotEqualTo(Vector<T> lhs, Vector<T> rhs) => Global.OP.NotEqual(lhs.variable, rhs.variable);

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static SuperArray NotEqualTo(Vector<T> lhs, float rhs) => Global.OP.NotEqual(lhs.variable, rhs);

        /// <summary>
        /// Find the maximum between two Vector<T> elemenwise
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray Maximum(Vector<T> lhs, Vector<T> rhs) => Global.OP.Maximum(lhs.variable, rhs.variable);

        /// <summary>
        /// Find the maximum between Vector<T> and scalar value
        /// </summary>
        /// <param name="lhs">The LHS Vector<T>.</param>
        /// <param name="rhs">The RHS Vector<T>.</param>
        /// <returns></returns>
        public static SuperArray Maximum(Vector<T> lhs, float rhs) => Global.OP.Maximum(lhs.variable, rhs);

    }
}
