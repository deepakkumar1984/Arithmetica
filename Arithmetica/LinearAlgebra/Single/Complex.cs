#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Arithmetica.Exceptions;

#endregion

namespace Arithmetica.LinearAlgebra.Single
{
	/// <summary>
	/// Represents a complex single-precision floating point number.
	/// </summary>
	[Serializable]
	public class Complex : ICloneable
	{
		#region Private Fields
		private float _real;
		private float _image;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Complex"/> class using given real and imaginary values.
		/// </summary>
		/// <param name="real">Real value.</param>
		/// <param name="imaginary">Imaginary value.</param>
		public Complex(float real, float imaginary)
		{
			_real = real;
			_image = imaginary;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Complex"/> class using values from a given complex instance.
		/// </summary>
		/// <param name="c">A complex number to get values from.</param>
		public Complex(Complex c)
		{
			_real = c.Real;
			_image = c.Imaginary;
		}

        /// <summary>
        /// Constructor to take polar inputs and create a Complex object
        /// </summary>
        /// <param name="magnitude">The magnitude.</param>
        /// <param name="phase">The phase.</param>
        /// <returns></returns>
        public static Complex FromPolarCoordinates(float magnitude, float phase)
        {
            return new Complex((magnitude * (float)Math.Cos(phase)), (magnitude * (float)Math.Sin(phase)));
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the real value of the complex number.
        /// </summary>
        /// <value>The real value of this complex number.</value>
        public float Real
		{
			get { return _real; }
			set { _real = value; }
		}
		/// <summary>
		/// Gets or sets the imaginary value of the complex number.
		/// </summary>
		/// <value>The imaginary value of this complex number.</value>
		public float Imaginary
		{
			get { return _image; }
			set { _image = value; }
		}
		/// <summary>
		/// Gets a value indicating the complex number is real (Its imaginary value is zero).
		/// </summary>
		/// <value>A <see cref="bool"/>.</value>
		public bool IsReal
		{
			get
			{
				return (_image == 0.0);
			}
		}
		/// <summary>
		/// Gets a value indicating the complex number is imaginary (Its real value is zero).
		/// </summary>
		/// <value>A <see cref="bool"/>.</value>
		public bool IsImaginary
		{
			get
			{
				return (_real == 0.0);
			}
		}
		/// <summary>
		/// Gets the the modulus of the complex number.
		/// </summary>
		/// <value>A single-precision floating-point number.</value>
		/// <remarks>See http://mathworld.wolfram.com/ComplexModulus.html for further details.</remarks>
		public float Modulus
		{
			get
			{
                return Abs(this);
            }
		}
		/// <summary>
		/// Gets the squared modulus of the complex number.
		/// </summary>
		/// <value>A single-precision floating-point number.</value>
		/// <remarks>See http://mathworld.wolfram.com/ComplexModulus.html for further details.</remarks>
		public float ModulusSquared
		{
			get
			{
                return (float)Math.Pow(Modulus, 2);
			}
		}
		/// <summary>
		/// Gets or sets the argument of the complex number.
		/// </summary>
		/// <value>A single-precision floating-point number.</value>
		/// <remarks>See http://mathworld.wolfram.com/ComplexArgument.html for further details.</remarks>
		public float Argument
		{
			get
			{
				if ((_image == 0.0) && (_real < 0.0))
				{
					return (float)System.Math.PI;
				}

				if ((_image == 0.0) &&  (_real >= 0.0))
				{
					return 0.0f;
				}

				return (float)System.Math.Atan2(_image, _real);
			}
			set
			{
				float modulus = this.Modulus;
				_real = (float)System.Math.Cos(value) * modulus;
				_image = (float)System.Math.Sin(value) * modulus;
			}
		}
		/// <summary>
		/// Gets or sets the conjugate of the complex number. 
		/// </summary>
		/// <value>A <see cref="Complex"/> instance.</value>
		public Complex Conjugate
		{
			get
			{
				return new Complex(_real, -_image);
			}
		}

        /// <summary>
        /// Gets the phase of the complex number.
        /// </summary>
        /// <value>
        /// The phase.
        /// </value>
        public float Phase
        {
            get
            {
                return (float)Math.Atan2(Imaginary, Real);
            }
        }
        #endregion

        #region Constants
        /// <summary>
        ///  A single-precision complex number that represents zero.
        /// </summary>
        public static readonly Complex Zero = new Complex(0, 0);
		/// <summary>
		///  A single-precision complex number that represents one.
		/// </summary>
		public static readonly Complex One = new Complex(1, 0);
		/// <summary>
		///  A single-precision complex number that represents the squere root of (-1).
		/// </summary>
		public static readonly Complex ImaginaryOne = new Complex(0, 1);
		#endregion

		#region ICloneable Members
		/// <summary>
		/// Creates an exact copy of this <see cref="Complex"/> object.
		/// </summary>
		/// <returns>The <see cref="Complex"/> object this method creates, cast as an object.</returns>
		object ICloneable.Clone()
		{
			return new Complex(this);
		}
		/// <summary>
		/// Creates an exact copy of this <see cref="Complex"/> object.
		/// </summary>
		/// <returns>The <see cref="Complex"/> object this method creates.</returns>
		public Complex Clone()
		{
			return new Complex(this);
		}
		#endregion

		#region Public Static Parse Methods
		/// <summary>
		/// Converts the specified string to its <see cref="Complex"/> equivalent.
		/// </summary>
		/// <param name="value">A string representation of a <see cref="Complex"/>.</param>
		/// <returns>A <see cref="Complex"/> that represents the complex number specified by the <paramref name="s"/> parameter.</returns>
		public static Complex Parse(string value)
		{
			Regex r = new Regex(@"\((?<real>.*),(?<imaginary>.*)\)", RegexOptions.None);
			Match m = r.Match(value);
			if (m.Success)
			{
				return new Complex(
					float.Parse(m.Result("${real}")),
					float.Parse(m.Result("${imaginary}"))
					);
			}
			else
			{
				throw new ParseException("Unsuccessful Match.");
			}
		}
		/// <summary>
		/// Converts the specified string to its <see cref="Complex"/> equivalent.
		/// A return value indicates whether the conversion succeeded or failed.
		/// </summary>
		/// <param name="value">A string representation of a <see cref="Complex"/>.</param>
		/// <param name="result">
		/// When this method returns, if the conversion succeeded,
		/// contains a <see cref="Complex"/> representing the complex number specified by <paramref name="value"/>.
		/// </param>
		/// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
		public static bool TryParse(string value, out Complex result)
		{
			Regex r = new Regex(@"\((?<real>.*),(?<imaginary>.*)\)", RegexOptions.None);
			Match m = r.Match(value);
			if (m.Success)
			{
				result = new Complex(
					float.Parse(m.Result("${real}")),
					float.Parse(m.Result("${imaginary}"))
					);

				return true;
			}

			result = Complex.Zero;
			return false;
		}
		#endregion

		#region Public Static Complex Arithmetics
		/// <summary>
		/// Adds two complex numbers.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the sum.</returns>
		/// <remarks>See http://mathworld.wolfram.com/ComplexAddition.html for further details.</remarks>
		public static Complex Add(Complex left, Complex right)
		{
			return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
		}
		/// <summary>
		/// Adds a complex number and a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the sum.</returns>
		public static Complex Add(Complex complex, float scalar)
		{
			return new Complex(complex.Real + scalar, complex.Imaginary);
		}
		/// <summary>
		/// Adds two complex numbers and put the result in the third complex number.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		/// <remarks>See http://mathworld.wolfram.com/ComplexAddition.html for further details.</remarks>
		public static void Add(Complex left, Complex right, ref Complex result)
		{
			result.Real = left.Real + right.Real;
			result.Imaginary = left.Imaginary + right.Imaginary;
		}
		/// <summary>
		/// Adds a complex number and a scalar and put the result into another complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		public static void Add(Complex complex, float scalar, ref Complex result)
		{
			result.Real = complex.Real + scalar;
			result.Imaginary = complex.Imaginary;
		}

		/// <summary>
		/// Subtracts a complex from a complex.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the difference.</returns>
		/// <remarks>See http://mathworld.wolfram.com/ComplexSubtraction.html for further details.</remarks>
		public static Complex Subtract(Complex left, Complex right)
		{
			return new Complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
		}
		/// <summary>
		/// Subtracts a scalar from a complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the difference.</returns>
		public static Complex Subtract(Complex complex, float scalar)
		{
			return new Complex(complex.Real - scalar, complex.Imaginary);
		}
		/// <summary>
		/// Subtracts a complex from a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the difference.</returns>
		public static Complex Subtract(float scalar, Complex complex)
		{
			return new Complex(scalar - complex.Real, complex.Imaginary);
		}
		/// <summary>
		/// Subtracts a complex from a complex and put the result in the third complex number.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		/// <remarks>See http://mathworld.wolfram.com/ComplexSubtraction.html for further details.</remarks>
		public static void Subtract(Complex left, Complex right, ref Complex result)
		{
			result.Real = left.Real - right.Real;
			result.Imaginary = left.Imaginary - right.Imaginary;
		}
		/// <summary>
		/// Subtracts a scalar from a complex and put the result into another complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		public static void Subtract(Complex complex, float scalar, ref Complex result)
		{
			result.Real = complex.Real - scalar;
			result.Imaginary = complex.Imaginary;
		}
		/// <summary>
		/// Subtracts a complex from a scalar and put the result into another complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		public static void Subtract(float scalar, Complex complex, ref Complex result)
		{
			result.Real = scalar - complex.Real;
			result.Imaginary = complex.Imaginary;
		}

		/// <summary>
		/// Multiplies two complex numbers.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		/// <remarks>See http://mathworld.wolfram.com/ComplexMultiplication.html for further details.</remarks>
		public static Complex Multiply(Complex left, Complex right)
		{
			// (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
			float x = left.Real, y = left.Imaginary;
			float u = right.Real, v = right.Imaginary;

			return new Complex(x * u - y * v, x * v + y * u);
		}
		/// <summary>
		/// Multiplies a complex by a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex Multiply(Complex complex, float scalar)
		{
			return new Complex(complex.Real * scalar, complex.Imaginary * scalar);
		}
		/// <summary>
		/// Multiplies two complex numbers and put the result in a third complex number.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		/// <remarks>See http://mathworld.wolfram.com/ComplexMultiplication.html for further details.</remarks>
		public static void Multiply(Complex left, Complex right, ref Complex result)
		{
			// (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
			float x = left.Real, y = left.Imaginary;
			float u = right.Real, v = right.Imaginary;

			result.Real = x * u - y * v;
			result.Imaginary = x * v + y * u;
		}
		/// <summary>
		/// Multiplies a complex by a scalar and put the result into another complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		public static void Multiply(Complex complex, float scalar, ref Complex result)
		{
			result.Real = complex.Real * scalar;
			result.Imaginary = complex.Imaginary * scalar;
		}
		
		/// <summary>
		/// Divides a complex by a complex.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		/// <remarks>See http://mathworld.wolfram.com/ComplexFivision.html for further details.</remarks>
		public static Complex Divide(Complex left, Complex right)
		{
			float x = left.Real, y = left.Imaginary;
			float u = right.Real, v = right.Imaginary;
			float modulusSquared = u * u + v * v;

			if (modulusSquared == 0)
			{
				throw new DivideByZeroException();
			}

			float invModulusSquared = 1 / modulusSquared;

			return new Complex(
				(x * u + y * v) * invModulusSquared,
				(y * u - x * v) * invModulusSquared);
		}
		/// <summary>
		/// Divides a complex by a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex Divide(Complex complex, float scalar)
		{
			if (scalar == 0)
			{
				throw new DivideByZeroException();
			}

			return new Complex(
				complex.Real / scalar,
				complex.Imaginary / scalar);
		}
		/// <summary>
		/// Divides a scalar by a complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex Divide(float scalar, Complex complex)
		{
			if ((complex.Real == 0) || (complex.Imaginary == 0))
			{
				throw new DivideByZeroException();
			}

			return new Complex(
				scalar / complex.Real,
				scalar / complex.Imaginary);
		}
		/// <summary>
		/// Divides a complex by a complex and put the result in a third complex number.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		/// <remarks>See http://mathworld.wolfram.com/ComplexFivision.html for further details.</remarks>
		public static void Divide(Complex left, Complex right, ref Complex result)
		{
			float x = left.Real, y = left.Imaginary;
			float u = right.Real, v = right.Imaginary;
			float modulusSquared = u * u + v * v;

			if (modulusSquared == 0)
			{
				throw new DivideByZeroException();
			}

			float invModulusSquared = 1 / modulusSquared;

			result.Real = (x * u + y * v) * invModulusSquared;
			result.Imaginary = (y * u - x * v) * invModulusSquared;
		}
		/// <summary>
		/// Divides a complex by a scalar and put the result into another complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		public static void Divide(Complex complex, float scalar, ref Complex result)
		{
			if (scalar == 0)
			{
				throw new DivideByZeroException();
			}

			result.Real = complex.Real / scalar;
			result.Imaginary = complex.Imaginary / scalar;
		}
		/// <summary>
		/// Divides a scalar by a complex and put the result into another complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A single-precision floating-point value.</param>
		/// <param name="result">A <see cref="Complex"/> instance to hold the result.</param>
		public static void Divide(float scalar, Complex complex, ref Complex result)
		{
			if ((complex.Real == 0) || (complex.Imaginary == 0))
			{
				throw new DivideByZeroException();
			}

			result.Real = scalar / complex.Real;
			result.Imaginary = scalar / complex.Imaginary;
		}

		/// <summary>
		/// Negates a complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the negated values.</returns>
		public static Complex Negate(Complex complex)
		{
			return new Complex(-complex.Real, -complex.Imaginary);
		}

		/// <summary>
		/// Tests whether two complex numbers are approximately equal using default tolerance value.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
		public static bool ApproxEqual(Complex left, Complex right)
		{
			return ApproxEqual(left, right, ArithMath.EpsilonF);
		}
		/// <summary>
		/// Tests whether two complex numbers are approximately equal given a tolerance value.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <param name="tolerance">The tolerance value used to test approximate equality.</param>
		/// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
		public static bool ApproxEqual(Complex left, Complex right, float tolerance)
		{
			return
				(
				(System.Math.Abs(left.Real - right.Real) <= tolerance) &&
				(System.Math.Abs(left.Imaginary - right.Imaginary) <= tolerance)
				);
		}
        #endregion

        #region Public Static Complex Special Functions
        /// <summary>
        /// Find the absolute value for the complex variable
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static float Abs(Complex complex)
        {
            float result = 0;
            if (double.IsInfinity(complex.Real) || double.IsInfinity(complex.Imaginary))
            {
                result = float.PositiveInfinity;
            }

            float c = Math.Abs(complex.Real);
            float d = Math.Abs(complex.Imaginary);

            if (c > d)
            {
                double r = d / c;
                result = c * (float)Math.Sqrt(1.0 + r * r);
            }
            else if (d == 0.0)
            {
                result = c;  // c is either 0.0 or NaN
            }
            else
            {
                float r = c / d;
                result = d * (float)Math.Sqrt(1.0 + r * r);
            }

            return result;
        }

        /// <summary>
        /// Calculates the square root of a complex number.
        /// </summary>
        /// <param name="complex">A <see cref="Complex"/> instance.</param>
        /// <returns>The square root of the complex number given in <paramref name="complex"/>.</returns>
        /// <remarks>See http://mathworld.wolfram.com/SquareRoot.html for further details.</remarks>
        public static Complex Sqrt(Complex complex)
		{
			Complex result = Complex.Zero;

			if ((complex.Real == 0.0f) && (complex.Imaginary == 0.0f))
			{
				return result;
			}
			else if (complex.IsReal)
			{
				result.Real = (complex.Real > 0) ? (float)System.Math.Sqrt(complex.Real) : (float)System.Math.Sqrt(-complex.Real);
				result.Imaginary = 0.0f;
			}
			else
			{
				float modulus = complex.Modulus;

				result.Real = (float)System.Math.Sqrt(0.5f * (modulus + complex.Real));
				result.Imaginary = (float)System.Math.Sqrt(0.5f * (modulus - complex.Real));
				if (complex.Imaginary < 0.0f)
					result.Imaginary = -result.Imaginary;
			}

			return result;
		}
		/// <summary>
		/// Calculates the logarithm of a specified complex number.
		/// Calculates the natural (base e) logarithm of a specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The natural (base e) logarithm of the complex number given in <paramref name="complex"/>.</returns>
		public static Complex Log(Complex complex)
		{
			Complex result = Complex.Zero;

			if ((complex.Real > 0.0) && (complex.Imaginary == 0.0))
			{
				result.Real = (float)System.Math.Log(complex.Real);
				result.Imaginary = 0.0f;
			}
			else if (complex.Real == 0.0f)
			{
				if (complex.Imaginary > 0.0f)
				{
					result.Real = (float)System.Math.Log(complex.Imaginary);
					result.Imaginary = (float)ArithMath.HalfPI;
				}
				else
				{
					result.Real = (float)System.Math.Log(-(complex.Imaginary));
					result.Imaginary = -(float)ArithMath.HalfPI;
				}
			}
			else
			{
				result.Real = (float)System.Math.Log(complex.Modulus);
				result.Imaginary = (float)System.Math.Atan2(complex.Imaginary, complex.Real);
			}

			return result;
		}
		/// <summary>
		/// Calculates the exponential of a specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The exponential of the complex number given in <paramref name="complex"/>.</returns>
		public static Complex Exp(Complex complex)
		{
			Complex result = Complex.Zero;
			float r = (float)System.Math.Exp(complex.Real);
			result.Real = r * (float)System.Math.Cos(complex.Imaginary);
			result.Imaginary = r * (float)System.Math.Sin(complex.Imaginary);

			return result;
		}
		/// <summary>
		/// Calculates a specified complex number raised by a specified power.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> representing the number to raise.</param>
		/// <param name="power">A <see cref="Complex"/> representing the power.</param>
		/// <returns>The complex <paramref name="complex"/> raised by <paramref name="power"/>.</returns>
		public static Complex Pow(Complex complex, Complex power)
		{
			return Exp(power * Log(complex));
		}
		/// <summary>
		/// Calculates the square of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The square of the given complex number.</returns>
		public static Complex Square(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex(complex.Real * complex.Real, 0.0f);
			}

			float real = complex.Real;
			float imag = complex.Imaginary;
			return new Complex(real * real - imag * imag, 2.0f * real * imag);
		}
		#endregion

		#region Public Static Trigonometric Functions
		/// <summary>
		/// Calculates the sine of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The sine of <paramref name="complex"/>.</returns>
		public static Complex Sin(Complex complex)
		{
			Complex result = Complex.Zero;

			if (complex.IsReal)
			{
				result.Real = (float)System.Math.Sin(complex.Real);
				result.Imaginary = 0.0f;
			}
			else
			{
				result.Real = (float)(System.Math.Sin(complex.Real) * System.Math.Cosh(complex.Imaginary));
				result.Imaginary = (float)(System.Math.Cos(complex.Real) * System.Math.Sinh(complex.Imaginary));
			}

			return result;
		}
		/// <summary>
		/// Calculates the cosine of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The cosine of <paramref name="complex"/>.</returns>
		public static Complex Cos(Complex complex)
		{
			Complex result = Complex.Zero;

			if (complex.IsReal)
			{
				result.Real = (float)System.Math.Cos(complex.Real);
				result.Imaginary = 0.0f;
			}
			else
			{
				result.Real = (float)(System.Math.Cos(complex.Real) * System.Math.Cosh(complex.Imaginary));
				result.Imaginary = (float)(-System.Math.Sin(complex.Real) * System.Math.Sinh(complex.Imaginary));
			}

			return result;
		}
		/// <summary>
		/// Calculates the tangent of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The tangent of <paramref name="complex"/>.</returns>
		public static Complex Tan(Complex complex)
		{
			Complex result = Complex.Zero;

			if (complex.IsReal)
			{
				result.Real = (float)System.Math.Tan(complex.Real);
				result.Imaginary = 0.0f;
			}
			else
			{
				float cosr = (float)System.Math.Cos(complex.Real);
				float sinhi = (float)System.Math.Sinh(complex.Imaginary);
				float denom = cosr * cosr + sinhi * sinhi;

				result.Real = (float)System.Math.Sin(complex.Real) * cosr / denom;
				result.Imaginary = sinhi * (float)System.Math.Cosh(complex.Imaginary) / denom;
			}

			return result;
		}
		/// <summary>
		/// Calculates the cotangent of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The cotangent of <paramref name="complex"/>.</returns>
		public static Complex Cot(Complex complex)
		{
			Complex result = Complex.Zero;

			if (complex.IsReal)
			{
				result.Real = (float)ArithMath.Cot(complex.Real);
			}
			else
			{
				float sinr = (float)System.Math.Sin(complex.Real);
				float sinhi = (float)System.Math.Sinh(complex.Imaginary);
				float denom = sinr * sinr + sinhi * sinhi;

				result.Real = (sinr * (float)System.Math.Cos(complex.Real)) / denom;
				result.Imaginary = (-sinhi * (float)System.Math.Cosh(complex.Imaginary)) / denom;
			}

			return result;
		}
		/// <summary>
		/// Calculates the secant of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The secant of <paramref name="complex"/>.</returns>
		public static Complex Sec(Complex complex)
		{
			Complex result = Complex.Zero;

			if (complex.IsReal)
			{
				result.Real = ArithMath.Sec(complex.Real);
			}
			else
			{
				float cosr = (float)ArithMath.Cos(complex.Real);
				float sinhi = (float)ArithMath.Sinh(complex.Imaginary);
				float denom = cosr * cosr + sinhi * sinhi;
				result.Real = (cosr * (float)ArithMath.Cosh(complex.Imaginary)) / denom;
				result.Imaginary = ((float)ArithMath.Sin(complex.Real) * sinhi) / denom;
			}

			return result;
		}
		/// <summary>
		/// Calculates the cosecant of the specified complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>The cosecant of <paramref name="complex"/>.</returns>
		public static Complex Csc(Complex complex)
		{
			Complex result = Complex.Zero;

			if (complex.IsReal)
			{
				result.Real = (float)ArithMath.Csc(complex.Real);
			}
			else
			{
				float sinr = (float)ArithMath.Sin(complex.Real);
				float sinhi = (float)ArithMath.Sinh(complex.Imaginary);
				float denom = sinr * sinr + sinhi * sinhi;
				result.Real = (sinr * (float)ArithMath.Cosh(complex.Imaginary)) / denom;
				result.Imaginary = (-(float)ArithMath.Cos(complex.Real) * sinhi) / denom;
			}

			return result;
		}
        #endregion

        #region Public Static Trigonometric Arcus Functions
        /// <summary>
        /// Compute the Arc sin of the complex number.
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static Complex Asin(Complex complex)
		{
			Complex result = 1 - Complex.Square(complex);
			result = Complex.Sqrt(result);
			result = result + (Complex.ImaginaryOne * complex);
			result = Complex.Log(result);
			result = -Complex.ImaginaryOne * result;

			return result;
		}

        /// <summary>
        /// Compute the Arc cos of the complex number.
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static Complex Acos(Complex complex)
		{
			Complex result = 1 - Complex.Square(complex);
			result = Complex.Sqrt(result);
			result = Complex.ImaginaryOne * result;
			result = complex + result;
			result = Complex.Log(result);
			result = -Complex.ImaginaryOne * result;
			return result;
		}

        /// <summary>
        /// Compute the Arc tan of the complex number.
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static Complex Atan(Complex complex)
		{
			Complex tmp = new Complex(-complex.Imaginary, complex.Real);
			return (new Complex(0.0f, 0.5f)) * (Complex.Log(1.0f - tmp) - Complex.Log(1.0f + tmp));
		}

        /// <summary>
        /// Compute the Arc cot of the complex number.
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static Complex Acot(Complex complex)
		{
			Complex tmp = new Complex(-complex.Imaginary, complex.Real);
			return (new Complex(0.0f, 0.5f)) * (Complex.Log(1.0f + tmp) - Complex.Log(1.0f - tmp)) + (float)ArithMath.HalfPI;
		}

        /// <summary>
        /// Compute the Arc sec of the complex number.
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static Complex Asec(Complex complex)
		{
			Complex inverse = 1 / complex;
			return (-Complex.ImaginaryOne) * Complex.Log(inverse + Complex.ImaginaryOne * Complex.Sqrt(1 - Complex.Square(inverse)));
		}

        /// <summary>
        /// Compute the Arc cosec of the complex number.
        /// </summary>
        /// <param name="complex">The complex.</param>
        /// <returns></returns>
        public static Complex Acsc(Complex complex)
		{
			Complex inverse = 1 / complex;
			return (-Complex.ImaginaryOne) * Complex.Log(Complex.ImaginaryOne * inverse + Complex.Sqrt(1 - Complex.Square(inverse)));
		}
		#endregion

		#region Public Static Trigonometric Hyperbolic Functions
		/// <summary>
		/// Calculates the hyperbolic sine of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic sine of the specified complex number.</returns>
		public static Complex Sinh(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex((float)System.Math.Sinh(complex.Real), 0.0f);
			}

			return new Complex(
				(float)(System.Math.Sinh(complex.Real) * System.Math.Cos(complex.Imaginary)),
				(float)(System.Math.Cosh(complex.Real) * System.Math.Sin(complex.Imaginary))
				);
		}
		/// <summary>
		/// Calculates the hyperbolic cosine of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic cosine of the specified complex number.</returns>
		public static Complex Cosh(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex((float)System.Math.Cosh(complex.Real), 0.0f);
			}

			return new Complex(
				(float)(System.Math.Cosh(complex.Real) * System.Math.Cos(complex.Imaginary)),
				(float)(System.Math.Sinh(complex.Real) * System.Math.Sin(complex.Imaginary))
				);
		}
		/// <summary>
		/// Calculates the hyperbolic tangent of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic tangent of the specified complex number.</returns>
		public static Complex Tanh(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex((float)System.Math.Tanh(complex.Real), 0.0f);
			}

			float cosi = (float)System.Math.Cos(complex.Imaginary);
			float sinhr = (float)System.Math.Sinh(complex.Real);
			float denom = (cosi * cosi) + (sinhr * sinhr);

			return new Complex(
				(sinhr * (float)System.Math.Cosh(complex.Real)) / denom,
				(cosi * (float)System.Math.Sin(complex.Imaginary)) / denom
				);
		}
		/// <summary>
		/// Calculates the hyperbolic cotangent of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic cotangent of the specified complex number.</returns>
		public static Complex Coth(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex((float)ArithMath.Coth(complex.Real), 0.0f);
			}

			//return ComplexF.Divide(Cosh(complex), Sinh(complex));
			float sini = -(float)System.Math.Sin(complex.Imaginary);
			float sinhr = (float)System.Math.Sinh(complex.Real);
			float denom = (sini * sini) + (sinhr * sinhr);

			return new Complex(
				(sinhr * (float)System.Math.Cosh(complex.Real)) / denom,
				(sini * (float)System.Math.Cos(complex.Imaginary)) / denom
				);
		}
		/// <summary>
		/// Calculates the hyperbolic secant of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic secant of the specified complex number.</returns>
		public static Complex Sech(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex((float)ArithMath.Sech(complex.Real), 0.0f);
			}

			Complex exp = Complex.Exp(complex);
			return (2 * exp) / (Complex.Square(exp) + 1);
		}
		/// <summary>
		/// Calculates the hyperbolic cosecant of the specified complex number. 
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>Returns the hyperbolic cosecant of the specified complex number.</returns>
		public static Complex Csch(Complex complex)
		{
			if (complex.IsReal)
			{
				return new Complex((float)ArithMath.Csch((double)complex.Real), 0.0f);
			}

			Complex exp = Complex.Exp(complex);
			return (2 * exp) / (Complex.Square(exp) - 1);
		}
		#endregion

		#region Public Static Trigonometric Hyperbolic Area Functions
		public static Complex Asinh(Complex complex)
		{
			Complex result = Complex.Sqrt(Complex.Square(complex) + 1);
			result = Complex.Log(complex + result);
			return result;
		}
		public static Complex Acosh(Complex complex)
		{
			Complex result = Complex.Sqrt(complex - 1) * Complex.Sqrt(complex + 1);
			result = complex + result;
			result = Complex.Log(result);
			return result;
		}
		public static Complex Atanh(Complex complex)
		{
			return 0.5f * (Complex.Log(1 + complex) - Complex.Log(1 - complex));
		}
		public static Complex Acoth(Complex complex)
		{
			return 0.5f * (Complex.Log(complex + 1) - Complex.Log(complex - 1));
		}
		public static Complex Asech(Complex complex)
		{
			Complex inverse = 1 / complex;
			Complex temp = inverse + Complex.Sqrt(inverse - 1) * Complex.Sqrt(inverse + 1);
			return Complex.Log(temp);
		}
		public static Complex Acsch(Complex complex)
		{
			Complex inverse = 1 / complex;
			Complex temp = inverse + Complex.Square(inverse - 1) * Complex.Square(inverse + 1);
			return Complex.Log(temp);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Scale the complex number to modulus 1.
		/// </summary>
		public void Normalize()
		{
			float modulus = this.Modulus;
			if (modulus == 0)
			{
                return;
			}
			_real = (float)(_real / modulus);
			_image = (float)(_image / modulus);
		}
		#endregion

		#region System.Object Overrides
		/// <summary>
		/// Returns the hashcode for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return _real.GetHashCode() ^ _image.GetHashCode();
		}
		/// <summary>
		/// Returns a value indicating whether this instance is equal to
		/// the specified object.
		/// </summary>
		/// <param name="obj">An object to compare to this instance.</param>
		/// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="Complex"/> and has the same values as this instance; otherwise, <see langword="false"/>.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Complex)
			{
				Complex c = (Complex)obj;
				return (this.Real == c.Real) && (this.Imaginary == c.Imaginary);
			}
			return false;
		}
		/// <summary>
		/// Returns a string representation of this object.
		/// </summary>
		/// <returns>A string representation of this object.</returns>
		public override string ToString()
		{
			return string.Format("({0}, {1})", _real, _image);
		}
		#endregion

		#region Comparison Operators
		/// <summary>
		/// Tests whether two specified complex numbers are equal.
		/// </summary>
		/// <param name="left">The left-hand complex number.</param>
		/// <param name="right">The right-hand complex number.</param>
		/// <returns><see langword="true"/> if the two complex numbers are equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(Complex left, Complex right)
		{
			return ValueType.Equals(left, right);
		}
		/// <summary>
		/// Tests whether two specified complex numbers are not equal.
		/// </summary>
		/// <param name="left">The left-hand complex number.</param>
		/// <param name="right">The right-hand complex number.</param>
		/// <returns><see langword="true"/> if the two complex numbers are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(Complex left, Complex right)
		{
			return !ValueType.Equals(left, right);
		}
		#endregion

		#region Unary Operators
		/// <summary>
		/// Negates the complex number.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the negated values.</returns>
		public static Complex operator -(Complex complex)
		{
			return Complex.Negate(complex);
		}
		#endregion

		#region Binary Operators
		/// <summary>
		/// Adds two complex numbers.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the sum.</returns>
		public static Complex operator +(Complex left, Complex right)
		{
			return Complex.Add(left, right);
		}
		/// <summary>
		/// Adds a complex number and a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the sum.</returns>
		public static Complex operator +(Complex complex, float scalar)
		{
			return Complex.Add(complex, scalar);
		}
		/// <summary>
		/// Adds a complex number and a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the sum.</returns>
		public static Complex operator +(float scalar, Complex complex)
		{
			return Complex.Add(complex, scalar);
		}
		/// <summary>
		/// Subtracts a complex from a complex.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the difference.</returns>
		public static Complex operator -(Complex left, Complex right)
		{
			return Complex.Subtract(left, right);
		}
		/// <summary>
		/// Subtracts a scalar from a complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the difference.</returns>
		public static Complex operator -(Complex complex, float scalar)
		{
			return Complex.Subtract(complex, scalar);
		}
		/// <summary>
		/// Subtracts a complex from a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the difference.</returns>
		public static Complex operator -(float scalar, Complex complex)
		{
			return Complex.Subtract(scalar, complex);
		}

		/// <summary>
		/// Multiplies two complex numbers.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex operator *(Complex left, Complex right)
		{
			return Complex.Multiply(left, right);
		}
		/// <summary>
		/// Multiplies a complex by a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex operator *(float scalar, Complex complex)
		{
			return Complex.Multiply(complex, scalar);
		}
		/// <summary>
		/// Multiplies a complex by a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex operator *(Complex complex, float scalar)
		{
			return Complex.Multiply(complex, scalar);
		}
		/// <summary>
		/// Divides a complex by a complex.
		/// </summary>
		/// <param name="left">A <see cref="Complex"/> instance.</param>
		/// <param name="right">A <see cref="Complex"/> instance.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex operator /(Complex left, Complex right)
		{
			return Complex.Divide(left, right);
		}
		/// <summary>
		/// Divides a complex by a scalar.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex operator /(Complex complex, float scalar)
		{
			return Complex.Divide(complex, scalar);
		}
		/// <summary>
		/// Divides a scalar by a complex.
		/// </summary>
		/// <param name="complex">A <see cref="Complex"/> instance.</param>
		/// <param name="scalar">A scalar.</param>
		/// <returns>A new <see cref="Complex"/> instance containing the result.</returns>
		public static Complex operator /(float scalar, Complex complex)
		{
			return Complex.Divide(scalar, complex);
		}
        #endregion


        public static implicit operator Complex(int value)
        {
            return new Complex(value, 0);
        }

        public static implicit operator Complex(float value)
        {
            return new Complex(value, 0);
        }

        public static implicit operator Complex(double value)
        {
            return new Complex((float)value, 0);
        }
    }
}
