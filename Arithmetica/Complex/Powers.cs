using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica
{
    public partial class Complex
    {
        public static Complex Pow(Complex src, Complex power)
        {
            Complex result = new Complex(src.Size);
            var rho = Abs(src);
            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                var (preal, pimag) = power[i];
                if (preal == 0)
                {
                    result[i] = (1, 0);
                }
                else if (real == 0)
                {
                    result[i] = (0, 0);
                }
                else
                {
                    float theta = (float)Math.Atan2(imag, real);
                    float newRho = preal * theta + pimag * (float)Math.Log(rho[i]);
                    float t = (float)Math.Pow(rho[i], preal) * (float)Math.Pow(Math.E, -pimag * theta);
                    result[i] = ((t * (float)Math.Cos(newRho), t * Math.Sign(newRho)));
                }
            });

            return result;
        }

        /// <summary>
        /// Performs elementwise power to the scalar operation elemenwise for the complex
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <param name="value">The scalar value.</param>
        /// <returns></returns>
        public static Complex Pow(Complex src, float power)
        {
            Complex powerValues = new Complex(src.Size);
            powerValues.Fill(power);
            return Pow(src, powerValues);
        }

        /// <summary>
        /// Perform square root operation on the complex elemenwise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Sqrt(Complex src)
        {
            Complex result = new Complex(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var c = src.Get(i);
                result[i] = ((float)Math.Sqrt(c.Magnitude), c.Phase / 2);
            });

            return result;
        }

        /// <summary>
        /// Perform square operation on the complex elemenwise.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Square(Complex src)
        {
            return Pow(src, 2);
        }

    }
}
