using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex GreaterThan(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Complex GreaterThan(Complex lhs, float rhs) => Complex.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex GreaterEqual(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Complex GreaterEqual(Complex lhs, float rhs) => Complex.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        /// <summary>
        /// <![CDATA[Performs lhs < rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex LessThan(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        /// <summary>
        /// <![CDATA[Performs lhs < scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Complex LessThan(Complex lhs, float rhs) => Complex.Out(ArrayOps.LessThan(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs <= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex LessEqual(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs <= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Complex LessEqual(Complex lhs, float rhs) => Complex.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex EqualTo(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Complex EqualTo(Complex lhs, float rhs) => Complex.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex NotEqualTo(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Complex NotEqualTo(Complex lhs, float rhs) => Complex.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        /// <summary>
        /// Find the maximum between two complex elemenwise
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex Maximum(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        /// <summary>
        /// Find the maximum between complex and scalar value
        /// </summary>
        /// <param name="lhs">The LHS complex.</param>
        /// <param name="rhs">The RHS complex.</param>
        /// <returns></returns>
        public static Complex Maximum(Complex lhs, float rhs) => Complex.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
