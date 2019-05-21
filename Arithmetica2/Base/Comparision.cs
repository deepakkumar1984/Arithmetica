using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class ArithArray
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray GreaterThan(ArithArray lhs, ArithArray rhs) => ArrayOps.GreaterThan(lhs, rhs);

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray GreaterThan(ArithArray lhs, float rhs) => ArrayOps.GreaterThan(lhs, rhs);

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray GreaterEqual(ArithArray lhs, ArithArray rhs) => ArrayOps.GreaterOrEqual(lhs, rhs);

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray GreaterEqual(ArithArray lhs, float rhs) => ArrayOps.GreaterOrEqual(lhs, rhs);

        /// <summary>
        /// <![CDATA[Performs lhs < rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray LessThan(ArithArray lhs, ArithArray rhs) => ArrayOps.LessThan(lhs, rhs);

        /// <summary>
        /// <![CDATA[Performs lhs < scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray LessThan(ArithArray lhs, float rhs) => ArrayOps.LessThan(lhs, rhs);

        /// <summary>
        /// Performs lhs <= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray LessEqual(ArithArray lhs, ArithArray rhs) => ArrayOps.LessOrEqual(lhs, rhs);

        /// <summary>
        /// Performs lhs <= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray LessEqual(ArithArray lhs, float rhs) => ArrayOps.LessOrEqual(lhs, rhs);

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray EqualTo(ArithArray lhs, ArithArray rhs) => ArrayOps.EqualTo(lhs, rhs);

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray EqualTo(ArithArray lhs, float rhs) => ArrayOps.LessOrEqual(lhs, rhs);

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray NotEqualTo(ArithArray lhs, ArithArray rhs) => ArrayOps.NotEqual(lhs, rhs);

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static ArithArray NotEqualTo(ArithArray lhs, float rhs) => ArrayOps.NotEqual(lhs, rhs);

        /// <summary>
        /// Find the maximum between two array elemenwise
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray Maximum(ArithArray lhs, ArithArray rhs) => ArrayOps.Maximum(lhs, rhs);

        /// <summary>
        /// Find the maximum between array and scalar value
        /// </summary>
        /// <param name="lhs">The LHS array.</param>
        /// <param name="rhs">The RHS array.</param>
        /// <returns></returns>
        public static ArithArray Maximum(ArithArray lhs, float rhs) => ArrayOps.Maximum(lhs, rhs);

    }
}
