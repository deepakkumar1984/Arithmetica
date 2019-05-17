using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs elementwise exponential operation elemenwise
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Exp(Complex src)
        {
            Complex result = new Complex(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                float temp_factor = (float)Math.Exp(real);
                float result_re = temp_factor * (float)Math.Cos(imag);
                float result_im = temp_factor * (float)Math.Sin(imag);
                result[i] = (result_re, result_im);
            });

            return result;
        }

        /// <summary>
        /// Performs elementwise log operation elemenwise
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Log(Complex src)
        {
            Complex result = new Complex(src.Size);
            var abs = Abs(src);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];

                result[i] = ((float)Math.Log(abs[i]), (float)Math.Atan2(imag, real));
            });

            return result;
        }

        /// <summary>
        /// Return the natural logarithm 10th base the input complex, element-wise. 
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Log10(Complex src)
        {
            float LOG_10_INV = 0.43429448190325f;
            var temp = Log(src);
            return Scale(temp, LOG_10_INV);
        }

        /// <summary>
        /// Scale the complex components with factor value
        /// </summary>
        /// <param name="src">The source complex numbers</param>
        /// <param name="factor">The factor value</param>
        /// <returns></returns>
        public static Complex Scale(Complex src, float factor)
        {
            Complex result = new Complex(src.Size);
            var abs = Abs(src);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];

                result[i] = (real * factor, imag * factor);
            });

            return result;
        }
    }
}
