using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Arithmetica
{
    public static class ComplexExtension
    {
		public static bool IsReal(this Complex complex)
		{
			if (complex.Real != 0 && complex.Imaginary == 0)
				return true;

			return false;
		}

		public static bool IsImaginary(this Complex complex)
		{
			if (complex.Real == 0 && complex.Imaginary != 0)
				return true;

			return false;
		}

		public static Complex Normalize(this Complex complex)
		{
			var modulus = Complex.Abs(complex);
			if (modulus == 0)
			{
				return Complex.Zero;
			}

			var _real = (complex.Real / modulus);
			var _image = (complex.Magnitude / modulus);
			return new Complex(_real, _image);
		}

		public static Complex Asinh(this Complex complex)
		{
			Complex result = Complex.Sqrt(Complex.Pow(complex, 2) + 1);
			result = Complex.Log(complex + result);
			return result;
		}

		public static Complex Acosh(this Complex complex)
		{
			Complex result = Complex.Sqrt(complex - 1) * Complex.Sqrt(complex + 1);
			result = complex + result;
			result = Complex.Log(result);
			return result;
		}

		public static Complex Atanh(this Complex complex)
		{
			return 0.5f * (Complex.Log(1 + complex) - Complex.Log(1 - complex));
		}

		public static Complex Acoth(this Complex complex)
		{
			return 0.5f * (Complex.Log(complex + 1) - Complex.Log(complex - 1));
		}

		public static Complex Asech(this Complex complex)
		{
			Complex inverse = 1 / complex;
			Complex temp = inverse + Complex.Sqrt(inverse - 1) * Complex.Sqrt(inverse + 1);
			return Complex.Log(temp);
		}

		public static Complex Acsch(this Complex complex)
		{
			Complex inverse = 1 / complex;
			Complex temp = inverse + Complex.Pow(inverse - 1, 2) * Complex.Pow(inverse + 1, 2);
			return Complex.Log(temp);
		}

		public static Complex Square(this Complex complex)
		{
			return Complex.Pow(complex, 2);
		}

		public static Complex Cot(this Complex complex)
		{
			Complex result = Complex.Zero;

			var sinr = System.Math.Sin(complex.Real);
			var sinhi = System.Math.Sinh(complex.Imaginary);
			var denom = sinr * sinr + sinhi * sinhi;

			var Real = (sinr * (float)System.Math.Cos(complex.Real)) / denom;
			var Imaginary = (-sinhi * (float)System.Math.Cosh(complex.Imaginary)) / denom;

			return new Complex(Real, Imaginary);
		}
		/// <summary>
		/// Calculates the secant of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The secant of <paramref name="complex"/>.</returns>
		public static Complex Sec(this Complex complex)
		{
			Complex result = Complex.Zero;

			var cosr = ArithMath.Cos(complex.Real);
			var sinhi = ArithMath.Sinh(complex.Imaginary);
			var denom = cosr * cosr + sinhi * sinhi;
			var Real = (cosr * (float)ArithMath.Cosh(complex.Imaginary)) / denom;
			var Imaginary = ((float)ArithMath.Sin(complex.Real) * sinhi) / denom;

			return new Complex(Real, Imaginary);
		}
		/// <summary>
		/// Calculates the cosecant of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The cosecant of <paramref name="complex"/>.</returns>
		public static Complex Csc(this Complex complex)
		{
			Complex result = Complex.Zero;

			var sinr = ArithMath.Sin(complex.Real);
			var sinhi = ArithMath.Sinh(complex.Imaginary);
			var denom = sinr * sinr + sinhi * sinhi;
			var Real = (sinr * ArithMath.Cosh(complex.Imaginary)) / denom;
			var Imaginary = (-ArithMath.Cos(complex.Real) * sinhi) / denom;

			return new Complex(Real, Imaginary);
		}

		public static Complex Acot(this Complex complex)
		{
			Complex tmp = new Complex(-complex.Imaginary, complex.Real);
			return (new Complex(0, 0.5)) * (Complex.Log(1 + tmp) - Complex.Log(1.0f - tmp)) + ArithMath.HalfPI;
		}

		/// <summary>
		/// Compute the Arc sec of the complex number.
		/// </summary>
		/// <param name="complex">The complex.</param>
		/// <returns></returns>
		public static Complex Asec(this Complex complex)
		{
			Complex inverse = 1 / complex;
			return (-Complex.ImaginaryOne) * Complex.Log(inverse + Complex.ImaginaryOne * Complex.Sqrt(1 - Complex.Pow(inverse, 2)));
		}

		/// <summary>
		/// Compute the Arc cosec of the complex number.
		/// </summary>
		/// <param name="complex">The complex.</param>
		/// <returns></returns>
		public static Complex Acsc(this Complex complex)
		{
			Complex inverse = 1 / complex;
			return (-Complex.ImaginaryOne) * Complex.Log(Complex.ImaginaryOne * inverse + Complex.Sqrt(1 - Complex.Pow(inverse, 2)));
		}

		public static Complex Coth(this Complex complex)
		{
			//return ComplexF.Divide(Cosh(complex), Sinh(complex));
			var sini = -System.Math.Sin(complex.Imaginary);
			var sinhr = System.Math.Sinh(complex.Real);
			var denom = (sini * sini) + (sinhr * sinhr);

			return new Complex(
				(sinhr * System.Math.Cosh(complex.Real)) / denom,
				(sini * System.Math.Cos(complex.Imaginary)) / denom
				);
		}
		/// <summary>
		/// Calculates the hyperbolic secant of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic secant of the specified complex number.</returns>
		public static Complex Sech(this Complex complex)
		{
			Complex exp = Complex.Exp(complex);
			return (2 * exp) / (Complex.Pow(exp, 2) + 1);
		}
		/// <summary>
		/// Calculates the hyperbolic cosecant of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic cosecant of the specified complex number.</returns>
		public static Complex Csch(this Complex complex)
		{
			Complex exp = Complex.Exp(complex);
			return (2 * exp) / (Complex.Pow(exp, 2) - 1);
		}

		public static double ModulusSquared(this Complex complex)
		{
			return Math.Pow(Complex.Abs(complex), 2);
		}
	}
}
