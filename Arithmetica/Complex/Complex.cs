using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica
{
    /// <summary>
    /// Represents a Complex with X and Y components and can hold multiple Complex
    /// </summary>
    public partial class Complex
    {
        internal ArithArray variable;

        /// <summary>
        /// Gets the number of the Complex in this instance.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public long Size
        {
            get
            {
                return variable.Shape[0];
            }
        }

        /// <summary>
        /// Gets the X value for the Complex. Usually gets the first Complex value.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        /// <exception cref="Exception">Not initialized</exception>
        public float Real
        {
            get
            {
                if (Size > 0)
                {
                    return this[0].Item1;
                }

                throw new Exception("Not initialized");
            }
        }

        /// <summary>
        /// Gets the Y value for the Complex. Usually gets the first Complex value.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        /// <exception cref="Exception">Not initialized</exception>
        public float Imag
        {
            get
            {
                if (Size > 0)
                {
                    return this[0].Item2;
                }

                throw new Exception("Not initialized");
            }
        }

        /// <summary>
        /// Gets the magnitude.
        /// </summary>
        /// <value>
        /// The magnitude.
        /// </value>
        public float Magnitude
        {
            get
            {
                return GetMagnitude()[0];
            }
        }

        /// <summary>
        /// Gets the phase.
        /// </summary>
        /// <value>
        /// The phase.
        /// </value>
        public float Phase
        {
            get
            {
                return GetPhase()[0];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="size">Defines number of complex variable in the list.</param>
        public Complex(long size = 1)
        {
            variable = new ArithArray(size, 2);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex" /> class.
        /// </summary>
        /// <param name="real">The real value.</param>
        /// <param name="imag">The imaginary value.</param>
        public Complex(float real, float imag) : this(1)
        {
            variable.LoadFrom(new float[] { real, imag });
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="size">Defines number of complex variable in the list.</param>
        /// <param name="dataType">The data type.</param>
        public Complex(int size, DType dataType)
        {
            variable = new ArithArray(new long[] { size, 2 }, dataType);
        }

        /// <summary>
        /// Create a Unit Complex which is Complex of size 1
        /// </summary>
        /// <param name="X">The x value.</param>
        /// <param name="Y">The y value.</param>
        /// <returns></returns>
        public static Complex Unit(float real, float imag)
        {
            return FromArray(real, imag);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="v">The v.</param>
        private Complex(ArithArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Creates a Complex of specified size and all filled with 1
        /// </summary>
        /// <param name="size">Defines number of complex variable in the list.</param>
        /// <returns></returns>
        public static Complex Ones(long size)
        {
            var x = new Complex(size);
            x.Fill(1);
            return x;
        }

        /// <summary>
        /// Creates a Complex of specified size and all filled with 0
        /// </summary>
        /// <param name="size">Defines number of complex variable in the list.</param>
        /// <returns></returns>
        public static Complex Zeros(long size)
        {
            var x = new Complex(size);
            x.Fill(0);
            return x;
        }

        /// <summary>
        /// Create a Complex from the array.
        /// </summary>
        /// <param name="data">The data array to be loaded.</param>
        /// <returns></returns>
        public static Complex FromArray(params float[] data)
        {
            var x = new Complex(data.Length / 2);
            x.variable.LoadFrom(data);
            return x;
        }

        /// <summary>
        /// Ins the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static ArithArray In(Complex x)
        {
            return x.variable;
        }

        /// <summary>
        /// Outs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static Complex Out(ArithArray x)
        {
            return new Complex(x);
        }

        /// <summary>
        /// Gets the generalised arith array which is a multi dimensional array
        /// </summary>
        /// <value>
        /// The arith array.
        /// </value>
        public ArithArray ArithArray
        {
            get
            {
                return variable;
            }
        }

        /// <summary>
        /// Gets the data in the .NET Array format.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public Array Data
        {
            get
            {
                return variable.ToArray();
            }
        }

        /// <summary>
        /// Gets or sets the complex value at the specified index.
        /// </summary>
        /// <value>
        /// Get the (X, Y) value at the index
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public (float, float) this[long index]
        {
            get
            {
                return (variable.GetElementAsFloat(index, 0), variable.GetElementAsFloat(index, 1));
            }
            set
            {
                variable.SetElementAsFloat(value.Item1, index, 0);
                variable.SetElementAsFloat(value.Item2, index, 1);
            }
        }

        /// <summary>
        /// Gets the Complex value at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Complex Get(long index)
        {
            return FromArray(variable.GetElementAsFloat(index, 0), variable.GetElementAsFloat(index, 1));
        }

        /// <summary>
        /// Fills all the values in the Complex with specified value
        /// </summary>
        /// <param name="value">The value.</param>
        public void Fill(float value)
        {
            variable.Fill(value);
        }

        /// <summary>
        /// Prints this Complex.
        /// </summary>
        public void Print()
        {
            variable.Print();
        }

        /// <summary>
        /// Gets the magnitude of the complex variables.
        /// </summary>
        /// <returns></returns>
        public float[] GetMagnitude()
        {
            var comp_abs = Complex.Abs(this);
            float[] result = new float[Size];
            Parallel.For(0, Size, (i) => {
                var (real, imag) = this[i];
                if (real > imag)
                {
                    double r = imag / real;
                    result[i] = real * (float)Math.Sqrt(1.0 + r * r);
                }
                else if (imag == 0.0)
                {
                    result[i] = real;
                }
                else
                {
                    double r = real / imag;
                    result[i] = imag * (float)Math.Sqrt(1.0 + r * r);
                }
            });

            return result;
        }

        public float[] GetPhase()
        {
            float[] result = new float[Size];
            Parallel.For(0, Size, (i) =>
            {
                var (real, imag) = this[i];
                result[i] = (float)Math.Atan2(imag, real);
            });

            return result;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator +(Complex lhs, Complex rhs) { return Out(In(lhs) + In(rhs)); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator +(Complex lhs, float rhs) { return Out(In(lhs) + rhs); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator +(float lhs, Complex rhs) { return Out(lhs + In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator -(Complex lhs, Complex rhs) { return Out(In(lhs) - In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator -(Complex lhs, float rhs) { return Out(In(lhs) - rhs); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator -(float lhs, Complex rhs) { return Out(lhs - In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator *(Complex lhs, Complex rhs) { return Out(In(lhs) * In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator *(Complex lhs, float rhs) { return Out(In(lhs) * rhs); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator *(float lhs, Complex rhs) { return Out(lhs * In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator /(Complex lhs, Complex rhs) { return Out(In(lhs) / In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator /(Complex lhs, float rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator /(float lhs, Complex rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator >(Complex lhs, Complex rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator >(Complex lhs, float rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <(Complex lhs, Complex rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <(Complex lhs, float rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator >=(Complex lhs, Complex rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator >=(Complex lhs, float rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <=(Complex lhs, Complex rhs) { return lhs <= rhs; }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <=(Complex lhs, float rhs) { return lhs <= rhs; }
    }
}
