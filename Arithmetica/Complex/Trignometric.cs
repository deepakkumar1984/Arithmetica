using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs Trigonometric sine, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Sin(Complex src)
        {
            Complex result = new Complex(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                result[i] = ((float)Math.Sin(real) * (float)Math.Cosh(imag), (float)Math.Cos(real) * (float)Math.Sinh(imag));
            });

            return result;
        }

        /// <summary>
        /// Performs Trigonometric cosine, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Cos(Complex src)
        {
            Complex result = new Complex(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                result[i] = ((float)Math.Cos(real) * (float)Math.Cosh(imag), -(float)Math.Sin(real) * (float)Math.Sinh(imag));
            });

            return result;
        }

        /// <summary>
        /// Performs Trigonometric tangent, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Tan(Complex src)
        {
            return Sin(src) / Cos(src);
        }

        /// <summary>
        /// Performs inverse sine, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Asin(Complex src)
        {
            var imagOnes = ImaginaryOnes(src.Size);
            var ones = Ones(src.Size);

            return -imagOnes * Log(imagOnes * src + Sqrt(ones - Square(src)));
        }

        /// <summary>
        /// Performs inverse cosine, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Acos(Complex src)
        {
            var imagOnes = ImaginaryOnes(src.Size);
            var ones = Ones(src.Size);

            return -imagOnes * Log(src + imagOnes * src + Sqrt(ones - Square(src)));
        }

        /// <summary>
        /// Performs inverse tangent, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Atan(Complex src)
        {
            Complex twoes = new Complex(src.Size);
            twoes.Fill(2);
            var imagOnes = ImaginaryOnes(src.Size);
            var ones = Ones(src.Size);

            return (imagOnes / twoes) * (Log(ones - imagOnes * src) - Log(ones + imagOnes * src));
        }


        /// <summary>
        /// Performs hyperbolic sine, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Sinh(Complex src)
        {
            Complex result = new Complex(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                result[i] = ((float)Math.Sinh(real) * (float)Math.Cos(imag), (float)Math.Cosh(real) * (float)Math.Sin(imag));
            });

            return result;
        }

        /// <summary>
        /// Performs hyperbolic cosine, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Cosh(Complex src)
        {
            Complex result = new Complex(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                result[i] = ((float)Math.Cosh(real) * (float)Math.Cos(imag), (float)Math.Sinh(real) * (float)Math.Sin(imag));
            });

            return result;
        }

        /// <summary>
        /// Performs hyperbolic tangent, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Tanh(Complex src)
        {
            return Sinh(src) / Cosh(src);
        }

        /// <summary>
        /// Performs arc tangent, element-wise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex ATan(Complex src)
        {
            Complex twoes = new Complex(src.Size);
            twoes.Fill(2);
            var imagOnes = ImaginaryOnes(src.Size);
            var ones = Ones(src.Size);

            return (imagOnes / twoes) * (Log(ones - imagOnes * src) - Log(ones + imagOnes * src));
        }
    }
}
