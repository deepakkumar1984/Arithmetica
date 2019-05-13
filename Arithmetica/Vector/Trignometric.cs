using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        /// <summary>
        /// Performs Trigonometric sine, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Sin(Vector src) => Vector.Out(ArrayOps.Sin(src.variable));

        /// <summary>
        /// Performs Trigonometric cosine, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Cos(Vector src) => Vector.Out(ArrayOps.Cos(src.variable));

        /// <summary>
        /// Performs Trigonometric tangent, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Tan(Vector src) => Vector.Out(ArrayOps.Tan(src.variable));

        /// <summary>
        /// Performs inverse sine, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Asin(Vector src) => Vector.Out(ArrayOps.Asin(src.variable));

        /// <summary>
        /// Performs inverse cosine, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Acos(Vector src) => Vector.Out(ArrayOps.Acos(src.variable));

        /// <summary>
        /// Performs inverse tangent, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Atan(Vector src) => Vector.Out(ArrayOps.Atan(src.variable));

        /// <summary>
        /// Element-wise arc tangent of x1/x2 choosing the quadrant correctly.
        /// <para>The quadrant(i.e., branch) is chosen so that arctan2(x1, x2) is the signed angle in radians between the ray ending at the origin and passing through the point(1,0), and the ray ending at the origin and passing through the point(x2, x1). (Note the role reversal: the “y-coordinate” is the first function parameter, the “x-coordinate” is the second.) By IEEE convention, this function is defined for x2 = +/-0 and for either or both of x1 and x2 = +/-inf(see Notes for specific values).</para>
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Atan2(Vector srcY, Vector srcX) => Vector.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        /// <summary>
        /// Performs hyperbolic sine, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Sinh(Vector src) => Vector.Out(ArrayOps.Sinh(src.variable));

        /// <summary>
        /// Performs hyperbolic cosine, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Cosh(Vector src) => Vector.Out(ArrayOps.Cosh(src.variable));

        /// <summary>
        /// Performs hyperbolic tangent, element-wise.
        /// </summary>
        /// <param name="src">The source vector.</param>
        /// <returns></returns>
        public static Vector Tanh(Vector src) => Vector.Out(ArrayOps.Tanh(src.variable));

    }
}
