#region Using directives

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

#endregion

namespace Arithmetica
{
	/// <summary>
	/// Provides standard mathematical functions for the library types.
	/// </summary>
	public static class ArithMath
	{
		#region Delegates
		public delegate T VoidFunction<T>();
		public delegate T UnaryFunction<T>(T param);
		public delegate T BinaryFunction<T>(T param1, T param2);
		public delegate T TenaryFunction<T>(T param1, T param2, T param3);
		#endregion

		#region Constants
		/// <summary>
		/// The value of PI.
		/// </summary>
		public const double PI = System.Math.PI;
		/// <summary>
		/// The value of (2 * PI).
		/// </summary>
		public const double TwoPI = 2 * System.Math.PI;
		/// <summary>
		/// The value of (PI*PI).
		/// </summary>
		public const double SquaredPI = System.Math.PI * System.Math.PI;
		/// <summary>
		/// The value of PI/2.
		/// </summary>
		public const double HalfPI = System.Math.PI / 2.0;

		/// <summary>
		/// Epsilon, a fairly small value for a single precision floating point
		/// </summary>
		public const float EpsilonF = 4.76837158203125E-7f;
		/// <summary>
		/// Epsilon, a fairly small value for a double precision floating point
		/// </summary>
		public const double EpsilonD = 8.8817841970012523233891E-16;
		#endregion

		#region Function Definitions

		#region Trigonometric Functions
		public static readonly UnaryFunction<double> DoubleSinFunction = new UnaryFunction<double>(ArithMath.Sin);
		public static readonly UnaryFunction<double> DoubleCosFunction = new UnaryFunction<double>(ArithMath.Cos);
		public static readonly UnaryFunction<double> DoubleTanFunction = new UnaryFunction<double>(ArithMath.Tan);
		public static readonly UnaryFunction<double> DoubleCotFunction = new UnaryFunction<double>(ArithMath.Cot);
		public static readonly UnaryFunction<double> DoubleSecFunction = new UnaryFunction<double>(ArithMath.Sec);
		public static readonly UnaryFunction<double> DoubleCscFunction = new UnaryFunction<double>(ArithMath.Csc);

		public static readonly UnaryFunction<Complex> ComplexSinFunction = new UnaryFunction<Complex>(ArithMath.Sin);
		public static readonly UnaryFunction<Complex> ComplexCosFunction = new UnaryFunction<Complex>(ArithMath.Cos);
		public static readonly UnaryFunction<Complex> ComplexTanFunction = new UnaryFunction<Complex>(ArithMath.Tan);
		public static readonly UnaryFunction<Complex> ComplexCotFunction = new UnaryFunction<Complex>(ArithMath.Cot);
		public static readonly UnaryFunction<Complex> ComplexSecFunction = new UnaryFunction<Complex>(ArithMath.Sec);
		public static readonly UnaryFunction<Complex> ComplexCscFunction = new UnaryFunction<Complex>(ArithMath.Csc);
		#endregion

		#region Trigonometric Arcus Functions
		public static readonly UnaryFunction<double> DoubleAsinFunction = new UnaryFunction<double>(ArithMath.Asin);
		public static readonly UnaryFunction<double> DoubleAcosFunction = new UnaryFunction<double>(ArithMath.Acos);
		public static readonly UnaryFunction<double> DoubleAtanFunction = new UnaryFunction<double>(ArithMath.Atan);
		public static readonly UnaryFunction<double> DoubleAcotFunction = new UnaryFunction<double>(ArithMath.Acot);
		public static readonly UnaryFunction<double> DoubleAsecFunction = new UnaryFunction<double>(ArithMath.Asec);
		public static readonly UnaryFunction<double> DoubleAcscFunction = new UnaryFunction<double>(ArithMath.Acsc);

		public static readonly UnaryFunction<Complex> ComplexAsinFunction = new UnaryFunction<Complex>(ArithMath.Asin);
		public static readonly UnaryFunction<Complex> ComplexAcosFunction = new UnaryFunction<Complex>(ArithMath.Acos);
		public static readonly UnaryFunction<Complex> ComplexAtanFunction = new UnaryFunction<Complex>(ArithMath.Atan);
		public static readonly UnaryFunction<Complex> ComplexAcotFunction = new UnaryFunction<Complex>(ArithMath.Acot);
		public static readonly UnaryFunction<Complex> ComplexAsecFunction = new UnaryFunction<Complex>(ArithMath.Asec);
		public static readonly UnaryFunction<Complex> ComplexAcscFunction = new UnaryFunction<Complex>(ArithMath.Acsc);
		#endregion

		#region Hyperbolic Functions
		public static readonly UnaryFunction<double> DoubleSinhFunction = new UnaryFunction<double>(ArithMath.Sinh);
		public static readonly UnaryFunction<double> DoubleCoshFunction = new UnaryFunction<double>(ArithMath.Cosh);
		public static readonly UnaryFunction<double> DoubleTanhFunction = new UnaryFunction<double>(ArithMath.Tanh);
		public static readonly UnaryFunction<double> DoubleCothFunction = new UnaryFunction<double>(ArithMath.Coth);
		public static readonly UnaryFunction<double> DoubleSechFunction = new UnaryFunction<double>(ArithMath.Sech);
		public static readonly UnaryFunction<double> DoubleCschFunction = new UnaryFunction<double>(ArithMath.Csch);

		public static readonly UnaryFunction<Complex> ComplexSinhFunction = new UnaryFunction<Complex>(ArithMath.Sinh);
		public static readonly UnaryFunction<Complex> ComplexCoshFunction = new UnaryFunction<Complex>(ArithMath.Cosh);
		public static readonly UnaryFunction<Complex> ComplexTanhFunction = new UnaryFunction<Complex>(ArithMath.Tanh);
		public static readonly UnaryFunction<Complex> ComplexCothFunction = new UnaryFunction<Complex>(ArithMath.Coth);
		public static readonly UnaryFunction<Complex> ComplexSechFunction = new UnaryFunction<Complex>(ArithMath.Sech);
		public static readonly UnaryFunction<Complex> ComplexCschFunction = new UnaryFunction<Complex>(ArithMath.Csch);
		#endregion

		#region Hyperbolic Area Functions
		public static readonly UnaryFunction<double> DoubleAsinhFunction = new UnaryFunction<double>(ArithMath.Asinh);
		public static readonly UnaryFunction<double> DoubleAcoshFunction = new UnaryFunction<double>(ArithMath.Acosh);
		public static readonly UnaryFunction<double> DoubleAtanhFunction = new UnaryFunction<double>(ArithMath.Atanh);
		public static readonly UnaryFunction<double> DoubleAcothFunction = new UnaryFunction<double>(ArithMath.Acoth);
		public static readonly UnaryFunction<double> DoubleAsechFunction = new UnaryFunction<double>(ArithMath.Asech);
		public static readonly UnaryFunction<double> DoubleAcschFunction = new UnaryFunction<double>(ArithMath.Acsch);

		public static readonly UnaryFunction<Complex> ComplexAsinhFunction = new UnaryFunction<Complex>(ArithMath.Asinh);
		public static readonly UnaryFunction<Complex> ComplexAcoshFunction = new UnaryFunction<Complex>(ArithMath.Acosh);
		public static readonly UnaryFunction<Complex> ComplexAtanhFunction = new UnaryFunction<Complex>(ArithMath.Atanh);
		public static readonly UnaryFunction<Complex> ComplexAcothFunction = new UnaryFunction<Complex>(ArithMath.Acoth);
		public static readonly UnaryFunction<Complex> ComplexAsechFunction = new UnaryFunction<Complex>(ArithMath.Asech);
		public static readonly UnaryFunction<Complex> ComplexAcschFunction = new UnaryFunction<Complex>(ArithMath.Acsch);
		#endregion

		#region Abs Functions
		/// <summary>
		/// Absolute value function for single-precision floating point numbers.
		/// </summary>
		public static readonly UnaryFunction<float> FloatAbsFunction = new UnaryFunction<float>(System.Math.Abs);
		/// <summary>
		/// Absolute value function for double-precision floating point numbers.
		/// </summary>
		public static readonly UnaryFunction<double> DoubleAbsFunction = new UnaryFunction<double>(System.Math.Abs);
		/// <summary>
		/// Absolute value function for integers.
		/// </summary>
		public static readonly UnaryFunction<int> IntAbsFunction = new UnaryFunction<int>(System.Math.Abs);
		#endregion

		public static readonly UnaryFunction<double> DoubleSqrtFunction = new UnaryFunction<double>(System.Math.Sqrt);
		#endregion

		#region Abs
		/// <summary>
		/// Calculates the absolute value of an integer.
		/// </summary>
		/// <param name="x">An integer.</param>
		/// <returns>The absolute value of <paramref name="x"/>.</returns>
		public static int Abs(int x)
		{
			return System.Math.Abs(x);
		}
		/// <summary>
		/// Calculates the absolute value of a single-precision floating point number.
		/// </summary>
		/// <param name="x">A single-precision floating point number.</param>
		/// <returns>The absolute value of <paramref name="x"/>.</returns>
		public static float Abs(float x)
		{
			return System.Math.Abs(x);
		}
		/// <summary>
		/// Calculates the absolute value of a double-precision floating point number.
		/// </summary>
		/// <param name="x">A double-precision floating point number.</param>
		/// <returns>The absolute value of <paramref name="x"/>.</returns>
		public static double Abs(double x)
		{
			return System.Math.Abs(x);
		}
		/// <summary>
		/// Creates a new array of integers whose element values are the
		/// result of applying the absolute function on the elements of the
		/// given integers array.
		/// </summary>
		/// <param name="array">An array of integers.</param>
		/// <returns>A new array of integers whose values are the result of applying the absolute function to each element in <paramref name="array"/></returns>
		public static int[] Abs(int[] array)
		{
			int[] result = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				result[i] = Abs(array[i]);
			}
			return result;
		}		
		/// <summary>
		/// Creates a new <see cref="float[]"/> whose element values are the
		/// result of applying the absolute function on the elements of the
		/// given floats array.
		/// </summary>
		/// <param name="array">An array of single-precision floating point values.</param>
		/// <returns>A new <see cref="FloatArrayList"/> whose values are the result of applying the absolute function to each element in <paramref name="array"/></returns>
		public static float[] Abs(float[] array)
		{
			float[] result = new float[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				result[i] = Abs(array[i]);
			}
			return result;
		}
		/// <summary>
		/// Creates a new <see cref="double[]"/> whose element values are the
		/// result of applying the absolute function on the elements of the
		/// given doubles array.
		/// </summary>
		/// <param name="array">An array of double-precision floating point values.</param>
		/// <returns>A new <see cref="double[]"/> whose values are the result of applying the absolute function to each element in <paramref name="array"/></returns>
		public static double[] Abs(double[] array)
		{
			double[] result = new double[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				result[i] = Abs(array[i]);
			}

			return result;
		}
		#endregion

		#region Trigonometric Functions
		public static double Sin(double value)
		{
			return System.Math.Sin(value);
		}
		public static float Sin(float value)
		{
			return (float)System.Math.Sin(value);
		}
		public static Complex Sin(Complex value)
		{
			return Complex.Sin(value);
		}

		public static double Cos(double value)
		{
			return System.Math.Cos(value);
		}
		public static float Cos(float value)
		{
			return (float)System.Math.Cos(value);
		}
		public static Complex Cos(Complex value)
		{
			return Complex.Cos(value);
		}

		public static double Tan(double value)
		{
			return System.Math.Tan(value);
		}
		public static float Tan(float value)
		{
			return (float)System.Math.Tan(value);
		}
		public static Complex Tan(Complex value)
		{
			return Complex.Tan(value);
		}

		public static double Cot(double value)
		{
			return 1 / System.Math.Tan(value);
		}
		public static float Cot(float value)
		{
			return (float)(1 / System.Math.Tan(value));
		}
		public static Complex Cot(Complex value)
		{
			return value.Cot();
		}

		public static double Sec(double value)
		{
			return 1 / System.Math.Cos(value);
		}
		public static float Sec(float value)
		{
			return (float)(1 / System.Math.Cos(value));
		}
		public static Complex Sec(Complex value)
		{
			return value.Sec();
		}

		public static double Csc(double value)
		{
			return 1 / System.Math.Sin(value);
		}
		public static float Csc(float value)
		{
			return (float)(1 / System.Math.Sin(value));
		}
		public static Complex Csc(Complex value)
		{
			return value.Csc();
		}
		#endregion

		#region Trigonometric Arcus Functions
		public static float Asin(float value)
		{
			return (float)System.Math.Asin(value);
		}
		public static double Asin(double value)
		{
			return System.Math.Asin(value);
		}
		public static Complex Asin(Complex value)
		{
			return Complex.Asin(value);
		}

		public static float Acos(float value)
		{
			return (float)System.Math.Acos(value);
		}
		public static double Acos(double value)
		{
			return System.Math.Acos(value);
		}
		public static Complex Acos(Complex value)
		{
			return Complex.Acos(value);
		}

		public static float Atan(float value)
		{
			return (float)System.Math.Atan(value);
		}
		public static double Atan(double value)
		{
			return System.Math.Atan(value);
		}
		public static Complex Atan(Complex value)
		{
			return Complex.Atan(value);
		}

		public static float Acot(float value)
		{
			return (float)System.Math.Atan(1 / value);
		}
		public static double Acot(double value)
		{
			return System.Math.Atan(1 / value);
		}
		public static Complex Acot(Complex value)
		{
			return value.Acot();
		}

		public static float Asec(float value)
		{
			return (float)System.Math.Acos(1 / value);
		}
		public static double Asec(double value)
		{
			return System.Math.Acos(1 / value);
		}
		public static Complex Asec(Complex value)
		{
			return value.Asec();
		}

		public static float Acsc(float value)
		{
			return (float)System.Math.Asin(1 / value);
		}
		public static double Acsc(double value)
		{
			return System.Math.Asin(1 / value);
		}
		public static Complex Acsc(Complex value)
		{
			return value.Acsc();
		}
		#endregion

		#region Hyperbolic Functions
		public static float Sinh(float value)
		{
			return (float)System.Math.Sinh(value);
		}
		public static double Sinh(double value) 
		{
			return System.Math.Sinh(value);
		}
		public static Complex Sinh(Complex value)
		{
			return Complex.Sinh(value);
		}

		public static float Cosh(float value)
		{
			return (float)System.Math.Cosh(value);
		}
		public static double Cosh(double value) 
		{
			return System.Math.Cosh(value);
		}
		public static Complex Cosh(Complex value)
		{
			return Complex.Cosh(value);
		}

		public static float Tanh(float value)
		{
			return (float)System.Math.Tanh(value);
		}
		public static double Tanh(double value) 
		{
			return System.Math.Tanh(value);
		}
		public static Complex Tanh(Complex value)
		{
			return Complex.Tanh(value);
		}

		public static float Coth(float value)
		{
			return 1 / (float)System.Math.Tanh(value);
		}
		public static double Coth(double value) 
		{
			return 1/System.Math.Tanh(value);
		}
		public static Complex Coth(Complex value)
		{
			return value.Coth();
		}

		public static float Sech(float value)
		{
			return 1 / (float)Cosh(value);
		}
		public static double Sech(double value) 
		{
			return 1/Cosh(value);
		}
		public static Complex Sech(Complex value)
		{
			return value.Sech();
		}

		public static float Csch(float value)
		{
			return 1 / (float)Sinh(value);
		}
		public static double Csch(double value) 
		{
			return 1/Sinh(value);
		}
		public static Complex Csch(Complex value)
		{
			return value.Csch();
		}
		#endregion

		#region Hyperbolic Area Functions
		public static float Asinh(float value)
		{
			return (float)System.Math.Log(value + System.Math.Sqrt(value * value + 1), System.Math.E);
		}

		public static double Asinh(double value)
		{
			return System.Math.Log(value + System.Math.Sqrt(value * value + 1), System.Math.E);
		}

		public static Complex Asinh(Complex value)
		{
			return value.Asinh();
		}

		public static float Acosh(float value)
		{
			return (float)System.Math.Log(value + System.Math.Sqrt(value - 1) * System.Math.Sqrt(value + 1), System.Math.E);
		}

		public static double Acosh(double value)
		{
			return System.Math.Log(value + System.Math.Sqrt(value - 1) * System.Math.Sqrt(value + 1), System.Math.E);
		}

		public static Complex Acosh(Complex value)
		{
			return value.Acosh();
		}

		public static float Atanh(float value)
		{
			return (float)(0.5 * System.Math.Log((1 + value) / (1 - value), System.Math.E));
		}

		public static double Atanh(double value)
		{
			return 0.5 * System.Math.Log((1 + value) / (1 - value), System.Math.E);
		}

		public static Complex Atanh(Complex value)
		{
			return value.Atanh();
		}

		public static float Acoth(float value)
		{
			return 0.5f * (float)System.Math.Log((value + 1) / (value - 1), System.Math.E);
		}

		public static double Acoth(double value)
		{
			return 0.5 * System.Math.Log((value + 1) / (value - 1), System.Math.E);
		}

		public static Complex Acoth(Complex value)
		{
			return value.Acoth();
		}

		public static float Asech(float value)
		{
			return Acosh(1 / value);
		}

		public static double Asech(double value)
		{
			return Acosh(1 / value);
		}

		public static Complex Asech(Complex value)
		{
			return value.Asech();
		}

		public static float Acsch(float value)
		{
			return Asinh(1 / value);
		}

		public static double Acsch(double value)
		{
			return Asinh(1 / value);
		}

		public static Complex Acsch(Complex value)
		{
			return value.Acsch();
		}
		#endregion

		#region Misc Functions
		public static float Cbrt(float value)
		{
			return (float)System.Math.Cbrt(value);
		}
		public static double Cbrt(double value)
		{
			return System.Math.Cbrt(value);
		}

		public static float Ceiling(float value)
		{
			return (float)System.Math.Ceiling(value);
		}
		public static double Ceiling(double value)
		{
			return System.Math.Ceiling(value);
		}

		public static float Clamp(float value, float min, float max)
		{
			return System.Math.Clamp(value, min, max);
		}
		public static double Clamp(double value, double min, double max)
		{
			return System.Math.Clamp(value, min, max);
		}

		public static float Exp(float value)
		{
			return (float)System.Math.Exp(value);
		}
		public static double Exp(double value)
		{
			return System.Math.Exp(value);
		}
		public static Complex Exp(Complex value)
		{
			return Complex.Exp(value);
		}

		public static float Floor(float value)
		{
			return (float)System.Math.Floor(value);
		}
		public static double Floor(double value)
		{
			return System.Math.Floor(value);
		}

		public static float Log(float value)
		{
			return (float)System.Math.Log(value);
		}
		public static double Log(double value)
		{
			return System.Math.Log(value);
		}
		public static Complex Log(Complex value)
		{
			return Complex.Log(value);
		}

		public static float Log10(float value)
		{
			return (float)System.Math.Log10(value);
		}
		public static double Log10(double value)
		{
			return System.Math.Log10(value);
		}

		public static float Max(int val1, int val2)
		{
			return System.Math.Max(val1, val2);
		}
		public static float Max(float val1, float val2)
		{
			return (float)System.Math.Max(val1, val2);
		}
		public static double Max(double val1, double val2)
		{
			return System.Math.Max(val1, val2);
		}

		public static float Min(int val1, int val2)
		{
			return System.Math.Min(val1, val2);
		}
		public static float Min(float val1, float val2)
		{
			return System.Math.Min(val1, val2);
		}
		public static double Min(double val1, double val2)
		{
			return System.Math.Min(val1, val2);
		}

		public static float Round(float value)
		{
			return (float)System.Math.Round(value);
		}
		public static double Round(double value)
		{
			return System.Math.Round(value);
		}

		public static float Sqrt(float value)
		{
			return (float)System.Math.Sqrt(value);
		}
		public static double Sqrt(double value)
		{
			return System.Math.Sqrt(value);
		}
		public static Complex Sqrt(Complex value)
		{
			return Complex.Sqrt(value);
		}

		public static float Pow(float value, float power)
		{
			return (float)System.Math.Pow(value, power);
		}
		public static double Pow(double value, double power)
		{
			return System.Math.Pow(value, power);
		}
		public static Complex Sqrt(Complex value, Complex power)
		{
			return Complex.Pow(value, power);
		}

		public static float Truncate(float value)
		{
			return (float)System.Math.Truncate(value);
		}
		public static double Truncate(double value)
		{
			return System.Math.Truncate(value);
		}
		#endregion

		#region ApproxEquals
		/// <summary>
		/// Tests whether two single-precision floating point numbers are approximately equal using default tolerance value.
		/// </summary>
		/// <param name="a">A single-precision floating point number.</param>
		/// <param name="b">A single-precision floating point number.</param>
		/// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
		public static bool ApproxEquals(float a, float b)
		{
			return (System.Math.Abs(a - b) <= EpsilonF);
		}
		/// <summary>
		/// Tests whether two single-precision floating point numbers are approximately equal given a tolerance value.
		/// </summary>
		/// <param name="a">A single-precision floating point number.</param>
		/// <param name="b">A single-precision floating point number.</param>
		/// <param name="tolerance">The tolerance value used to test approximate equality.</param>
		/// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
		public static bool ApproxEquals(float a, float b, float tolerance)
		{
			return (System.Math.Abs(a - b) <= tolerance);
		}
		/// <summary>
		/// Tests whether two double-precision floating point numbers are approximately equal using default tolerance value.
		/// </summary>
		/// <param name="a">A double-precision floating point number.</param>
		/// <param name="b">A double-precision floating point number.</param>
		/// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
		public static bool ApproxEquals(double a, double b)
		{
			return (System.Math.Abs(a - b) <= EpsilonD);
		}
		/// <summary>
		/// Tests whether two double-precision floating point numbers are approximately equal given a tolerance value.
		/// </summary>
		/// <param name="a">A double-precision floating point number.</param>
		/// <param name="b">A double-precision floating point number.</param>
		/// <param name="tolerance">The tolerance value used to test approximate equality.</param>
		/// <returns><see langword="true"/> if the two vectors are approximately equal; otherwise, <see langword="false"/>.</returns>
		public static bool ApproxEquals(double a, double b, double tolerance)
		{
			return (System.Math.Abs(a - b) <= tolerance);
		}
		#endregion

		public static void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp = lhs;
			lhs = rhs;
			rhs = temp;
		}
	}
}
