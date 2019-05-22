#region Using directives

using Arithmetica.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Arithmetica.Analysis
{
	/// <summary>
	/// Defines an interface for classes that performs integration of a single-precision floating-point function over an interval.
	/// </summary>
	public interface IFloatIntegrator
	{
		/// <summary>
		/// Integrates a given function within the given integral.
		/// </summary>
		/// <param name="f">The function to integrate.</param>
		/// <param name="a">The lower limit.</param>
		/// <param name="b">The higher limit.</param>
		/// <returns>
		/// The integral of <paramref name="function"/> over the interval from <paramref name="a"/> to <paramref name="b"/>
		/// </returns>
		float Integrate(ArithMath.UnaryFunction<float> f, float a, float b);
	}

	/// <summary>
	/// Defines an interface for classes that performs integration of a double-precision floating-point function over an interval.
	/// </summary>
	public interface IDoubleIntegrator
	{
		/// <summary>
		/// Integrates a given function within the given integral.
		/// </summary>
		/// <param name="f">The function to integrate.</param>
		/// <param name="a">The lower limit.</param>
		/// <param name="b">The higher limit.</param>
		/// <returns>
		/// The integral of <paramref name="function"/> over the interval from <paramref name="a"/> to <paramref name="b"/>
		/// </returns>
		double Integrate(ArithMath.UnaryFunction<double> f, double a, double b);
	}

	/// <summary>
	/// Defines an interface for classes that perform differentiation of a single-precision floating-point function at a point.
	/// </summary>
	public interface IFloatDifferentiator
	{
		/// <summary>
		/// Differentiates the given function at a given point.
		/// </summary>
		/// <param name="f">The function to differentiate.</param>
		/// <param name="x">The point to differentiate at.</param>
		/// <returns>The derivative of function at <paramref name="x"/>.</returns>
		double Differentiate(ArithMath.UnaryFunction<float> f, float x);
	}

	/// <summary>
	/// Defines an interface for classes that perform differentiation of a double-precision floating-point function at a point.
	/// </summary>
	public interface IDoubleDifferentiator
	{
		/// <summary>
		/// Differentiates the given function at a given point.
		/// </summary>
		/// <param name="f">The function to differentiate.</param>
		/// <param name="x">The point to differentiate at.</param>
		/// <returns>The derivative of function at <paramref name="x"/>.</returns>
		double Differentiate(ArithMath.UnaryFunction<double> f, double x);
	}

}
