using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Imaging
{
    public partial class Image
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image GreaterThan(Image lhs, Image rhs) => Image.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Image GreaterThan(Image lhs, float rhs) => Image.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image GreaterEqual(Image lhs, Image rhs) => Image.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Image GreaterEqual(Image lhs, float rhs) => Image.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        /// <summary>
        /// <![CDATA[Performs lhs < rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image LessThan(Image lhs, Image rhs) => Image.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        /// <summary>
        /// <![CDATA[Performs lhs < scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Image LessThan(Image lhs, float rhs) => Image.Out(ArrayOps.LessThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs <= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image LessEqual(Image lhs, Image rhs) => Image.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs <= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Image LessEqual(Image lhs, float rhs) => Image.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image EqualTo(Image lhs, Image rhs) => Image.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Image EqualTo(Image lhs, float rhs) => Image.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image NotEqualTo(Image lhs, Image rhs) => Image.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Image NotEqualTo(Image lhs, float rhs) => Image.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        /// <summary>
        /// Find the maximum between two Image elemenwise
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image Maximum(Image lhs, Image rhs) => Image.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        /// <summary>
        /// Find the maximum between Image and scalar value
        /// </summary>
        /// <param name="lhs">The LHS Image.</param>
        /// <param name="rhs">The RHS Image.</param>
        /// <returns></returns>
        public static Image Maximum(Image lhs, float rhs) => Image.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
