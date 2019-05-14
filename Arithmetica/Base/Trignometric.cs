using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class ArithArray
    {
        /// <summary>
        /// Performs Trigonometric sine, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Sin(ArithArray src) => ArrayOps.Sin(src);

        /// <summary>
        /// Performs Trigonometric cosine, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Cos(ArithArray src) => ArrayOps.Cos(src);

        /// <summary>
        /// Performs Trigonometric tangent, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Tan(ArithArray src) => ArrayOps.Tan(src);

        /// <summary>
        /// Performs inverse sine, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Asin(ArithArray src) => ArrayOps.Asin(src);

        /// <summary>
        /// Performs inverse cosine, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Acos(ArithArray src) => ArrayOps.Acos(src);

        /// <summary>
        /// Performs inverse tangent, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Atan(ArithArray src) => ArrayOps.Atan(src);

        /// <summary>
        /// Element-wise arc tangent of x1/x2 choosing the quadrant correctly.
        /// <para>The quadrant(i.e., branch) is chosen so that arctan2(x1, x2) is the signed angle in radians between the ray ending at the origin and passing through the point(1,0), and the ray ending at the origin and passing through the point(x2, x1). (Note the role reversal: the “y-coordinate” is the first function parameter, the “x-coordinate” is the second.) By IEEE convention, this function is defined for x2 = +/-0 and for either or both of x1 and x2 = +/-inf(see Notes for specific values).</para>
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Atan2(ArithArray srcY, ArithArray srcX) => ArrayOps.Atan2(srcY, srcX);

        /// <summary>
        /// Performs hyperbolic sine, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Sinh(ArithArray src) => ArrayOps.Sinh(src);

        /// <summary>
        /// Performs hyperbolic cosine, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Cosh(ArithArray src) => ArrayOps.Cosh(src);

        /// <summary>
        /// Performs hyperbolic tangent, element-wise.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <returns></returns>
        public static ArithArray Tanh(ArithArray src) => ArrayOps.Tanh(src);


    }
}
