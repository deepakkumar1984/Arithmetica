using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Geometry
{
    public partial class Plane
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS plane.</param>
        /// <returns></returns>
        public static Plane GreaterThan(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane GreaterThan(Plane lhs, float rhs) => Plane.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS plane.</param>
        /// <returns></returns>
        public static Plane GreaterEqual(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane GreaterEqual(Plane lhs, float rhs) => Plane.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        /// <summary>
        /// <![CDATA[Performs lhs &lt; rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS plane.</param>
        /// <returns></returns>
        public static Plane LessThan(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        /// <summary>
        /// <![CDATA[Performs lhs &lt; scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane LessThan(Plane lhs, float rhs) => Plane.Out(ArrayOps.LessThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs &lt;= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane LessEqual(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs &lt;= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane LessEqual(Plane lhs, float rhs) => Plane.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane EqualTo(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane EqualTo(Plane lhs, float rhs) => Plane.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS plane.</param>
        /// <returns></returns>
        public static Plane NotEqualTo(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Plane NotEqualTo(Plane lhs, float rhs) => Plane.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        /// <summary>
        /// Find the maximum between two plane elemenwise
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS plane.</param>
        /// <returns></returns>
        public static Plane Maximum(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        /// <summary>
        /// Find the maximum between plane and scalar value
        /// </summary>
        /// <param name="lhs">The LHS plane.</param>
        /// <param name="rhs">The RHS plane.</param>
        /// <returns></returns>
        public static Plane Maximum(Plane lhs, float rhs) => Plane.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
