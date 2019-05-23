using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T>
    {
        /// <summary>
        /// Performs Trigonometric sine, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Sin(Vector<T> src) => ArrayOps.Sin(src.variable);

        /// <summary>
        /// Performs Trigonometric cosine, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Cos(Vector<T> src) => ArrayOps.Cos(src.variable);

        /// <summary>
        /// Performs Trigonometric tangent, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Tan(Vector<T> src) => ArrayOps.Tan(src.variable);

        /// <summary>
        /// Performs inverse sine, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Asin(Vector<T> src) => ArrayOps.Asin(src.variable);

        /// <summary>
        /// Performs inverse cosine, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Acos(Vector<T> src) => ArrayOps.Acos(src.variable);

        /// <summary>
        /// Performs inverse tangent, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Atan(Vector<T> src) => ArrayOps.Atan(src.variable);

        /// <summary>
        /// Element-wise arc tangent of x1/x2 choosing the quadrant correctly.
        /// <para>The quadrant(i.e., branch) is chosen so that arctan2(x1, x2) is the signed angle in radians between the ray ending at the origin and passing through the point(1,0), and the ray ending at the origin and passing through the point(x2, x1). (Note the role reversal: the “y-coordinate” is the first function parameter, the “x-coordinate” is the second.) By IEEE convention, this function is defined for x2 = +/-0 and for either or both of x1 and x2 = +/-inf(see Notes for specific values).</para>
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Atan2(Vector<T> srcY, Vector<T> srcX) => ArrayOps.Atan2(srcY.variable, srcX.variable);

        /// <summary>
        /// Performs hyperbolic sine, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Sinh(Vector<T> src) => ArrayOps.Sinh(src.variable);

        /// <summary>
        /// Performs hyperbolic cosine, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Cosh(Vector<T> src) => ArrayOps.Cosh(src.variable);

        /// <summary>
        /// Performs hyperbolic tangent, element-wise.
        /// </summary>
        /// <param name="src">The source Vector<T>.</param>
        /// <returns></returns>
        public static ArithArray Tanh(Vector<T> src) => ArrayOps.Tanh(src.variable);


    }
}
