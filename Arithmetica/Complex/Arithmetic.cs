using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica
{
    public partial class Complex
    {
        /// <summary>
        /// Performs the dot product between 2 complex.
        /// </summary>
        /// <param name="lhs">The first complex.</param>
        /// <param name="rhs">The second complex.</param>
        /// <returns></returns>
        public static Complex Dot(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Dot(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise add operation between two complex
        /// </summary>
        /// <param name="lhs">The first complex.</param>
        /// <param name="rhs">The second complex.</param>
        /// <returns></returns>
        public static Complex Add(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        /// <summary>
        /// Performs elementwise subtract operation between two complex
        /// </summary>
        /// <param name="lhs">The first complex.</param>
        /// <param name="rhs">The second complex.</param>
        /// <returns></returns>
        public static Complex Sub(Complex lhs, Complex rhs) => Complex.Out(ArrayOps.Sub(lhs.variable, rhs.variable));


        /// <summary>
        /// Performs elementwise multiplication operation between complex and scalar
        /// </summary>
        /// <param name="lhs">The first complex.</param>
        /// <param name="rhs">The scalar value.</param>
        /// <returns></returns>
        public static Complex Mul(Complex lhs, Complex rhs)
        {
            Complex result = new Complex(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                var (real1, imag1) = lhs[i];
                var (real2, imag2) = rhs[i];
                var real = (real1 * real2) - (imag1 * imag2);
                var imag = (imag1 * real2) - (real1 * imag2);
                result[0] = (real, imag);
            });

            return result;
        }

        /// <summary>
        /// Performs elementwise divide operation between two complex
        /// </summary>
        /// <param name="lhs">The first complex.</param>
        /// <param name="rhs">The second complex.</param>
        /// <returns></returns>
        public static Complex Div(Complex lhs, Complex rhs)
        {
            Complex result = new Complex(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                var (real1, imag1) = lhs[i];
                var (real2, imag2) = rhs[i];
                if (Math.Abs(imag2) < Math.Abs(real2))
                {
                    float doc = imag2 / real2;
                    result[i] = ((real1 + imag1 * doc) / (real2 + imag2 * doc), (imag1 - real1 * doc) / (real2 + imag2 * doc));
                }
                else
                {
                    float cod = real2 / imag2;
                    result[i] = ((imag1 + real1 * cod) / (imag2 + real2 * cod), (-real1 + imag1 * cod) / (imag2 + real2 * cod));
                }
            });

            return result;
        }

        /// <summary>
        /// Negates the specified complex.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Neg(Complex src) => Complex.Out(ArrayOps.Neg(src.variable));

        /// <summary>
        /// Finds the elementwise absolute value of the complex
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Vector Abs(Complex src)
        {
            Vector result = new Vector(src.Size);

            Parallel.For(0, src.Size, (i) => {
                var (real, imag) = src[i];
                if (float.IsInfinity(real) || float.IsInfinity(imag))
                {
                    result[i] = float.PositiveInfinity;
                }

                float c = Math.Abs(real);
                float d = Math.Abs(imag);

                if (c > d)
                {
                    double r = d / c;
                    result[i] = c * (float)Math.Sqrt(1.0 + r * r);
                }
                else if (d == 0.0)
                {
                    result[i] = c;  // c is either 0.0 or NaN
                }
                else
                {
                    double r = c / d;
                    result[i] = d * (float)Math.Sqrt(1.0 + r * r);
                }
            });

            return result;
        }

        public static Complex Conjugate(Complex value)
        {
            Complex result = new Complex(value.Size);

            Parallel.For(0, value.Size, (i) => {
                var (real, imag) = value[i];
                result[i] = (real, (-imag));
            });

            return result;
        }

        public static Complex Reciprocal(Complex value)
        {
            Complex result = new Complex(value.Size);

            Parallel.For(0, value.Size, (i) => {
                var (real, imag) = value[i];
                if ((real == 0) && (imag == 0))
                {
                    result[i] = (0, 0);
                }
                else
                {
                    result[i] = (1, 0);
                }
            });

            return result / value;
        }

        /// <summary>
        /// Returns an element-wise indication of the sign of a number. The sign function returns -1 if x< 0, 0 if x==0, 1 if x> 0. nan is returned for nan inputs.
        /// For complex inputs, the sign function returns sign(x.real) + 0j if x.real != 0 else sign(x.imag) + 0j.
        /// </summary>
        /// <param name="src">The source complex.</param>
        /// <returns></returns>
        public static Complex Sign(Complex src) => Complex.Out(ArrayOps.Sign(src.variable));

        /// <summary>
        /// Finds the linear interpolation is a method of curve fitting using linear polynomials to construct new data points within the range of a discrete set of known data points.
        /// </summary>
        /// <param name="a">The first complex</param>
        /// <param name="b">The second complex.</param>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        public static Complex Lerp(Complex a, Complex b, float weight) => Complex.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
