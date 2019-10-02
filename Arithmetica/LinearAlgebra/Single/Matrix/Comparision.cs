using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Single
{
    public partial class Matrix
    {
        /// <summary>
        /// Performs lhs > rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix GreaterThan(Matrix lhs, Matrix rhs) => Matrix.Out(lhs.variable > rhs.variable);

        /// <summary>
        /// Performs lhs > scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Matrix GreaterThan(Matrix lhs, float rhs) => Matrix.Out(lhs.variable > rhs);

        /// <summary>
        /// Performs lhs >= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix GreaterEqual(Matrix lhs, Matrix rhs) => Matrix.Out(lhs.variable >= rhs.variable);

        /// <summary>
        /// Performs lhs >= float elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Matrix GreaterEqual(Matrix lhs, float rhs) => Matrix.Out(lhs.variable >= rhs);

        /// <summary>
        /// <![CDATA[Performs lhs &lt; rhs elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix LessThan(Matrix lhs, Matrix rhs) => Matrix.Out(lhs.variable < rhs.variable);

        /// <summary>
        /// <![CDATA[Performs lhs &lt; scalar elemenwise.]]>
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Matrix LessThan(Matrix lhs, float rhs) => Matrix.Out(lhs.variable < rhs);

        /// <summary>
        /// Performs lhs &lt;= rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix LessEqual(Matrix lhs, Matrix rhs) => Matrix.Out(lhs.variable <= rhs.variable);

        /// <summary>
        /// Performs lhs &lt;= scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Matrix LessEqual(Matrix lhs, float rhs) => Matrix.Out(lhs.variable <= rhs);

        /// <summary>
        /// Performs lhs == rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix EqualTo(Matrix lhs, Matrix rhs) => Matrix.Out(np.array_equal(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs == scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Matrix EqualTo(Matrix lhs, float rhs) => Matrix.Out(lhs.variable <= rhs);

        /// <summary>
        /// Performs lhs != rhs elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix NotEqualTo(Matrix lhs, Matrix rhs) => Matrix.Out(Global.OP.NotEqual(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs lhs != scalar elemenwise.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS scalar float.</param>
        /// <returns></returns>
        public static Matrix NotEqualTo(Matrix lhs, float rhs) => Matrix.Out(Global.OP.NotEqual(lhs.variable, rhs));

        /// <summary>
        /// Find the maximum between two matrix elemenwise
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix Maximum(Matrix lhs, Matrix rhs) => Matrix.Out(np.maximum(lhs.variable, rhs.variable));

        /// <summary>
        /// Find the maximum between matrix and scalar value
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns></returns>
        public static Matrix Maximum(Matrix lhs, float rhs) => Matrix.Out(np.maximum(lhs.variable, rhs));

    }
}
