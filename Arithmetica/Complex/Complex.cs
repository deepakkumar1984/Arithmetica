using System;
using System.Collections.Generic;
using System.Linq;
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

        public float MagnitudeSquared
        {
            get
            {
                var mag = GetMagnitude()[0];
                return mag * mag;
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

        public static Complex One
        {
            get
            {
                return new Complex(1, 0);
            }
        }

        public static Complex ImaginaryOne
        {
            get
            {
                return new Complex(0, 1);
            }
        }

        public static Complex Zero
        {
            get
            {
                return new Complex(0, 0);
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
        /// Creates a Complex of specified size and all filled with 1 for the real component
        /// </summary>
        /// <param name="size">Defines number of complex variable in the list.</param>
        /// <returns></returns>
        public static Complex Ones(long size)
        {
            var x = new Complex(size);
            Parallel.For(0, size, (i) =>
            {
                x[i] = (1, 0);
            });

            return x;
        }

        /// <summary>
        /// Creates a Complex of specified size and all filled with 1 for the imaginary component
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Complex ImaginaryOnes(long size)
        {
            var x = new Complex(size);
            Parallel.For(0, size, (i) =>
            {
                x[i] = (0, 1);
            });

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
            Parallel.For(0, size, (i) =>
            {
                x[i] = (0, 0);
            });

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

        public void Set(long index, Complex complex)
        {
            this[index] = (complex.Real, complex.Imag);
        }


        /// <summary>
        /// Normalizes this instance.
        /// </summary>
        public void Normalize()
        {
            var magnitudes = GetMagnitude();
            var max = magnitudes.Max();
            Parallel.For(0, Size, (i) => {
                var (real, imag) = this[i];
                this[i] = (real / max, imag / max);
            });
        }

        /// <summary>
        /// Fills all the values in the Complex with specified value
        /// </summary>
        /// <param name="value">The value.</param>
        public void Fill(float value)
        {
            Parallel.For(0, Size, (i) =>
            {
                this[i] = (value, 0);
            });
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

        /// <summary>
        /// Get the phase of the complex numbers
        /// </summary>
        /// <returns></returns>
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
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator -(Complex lhs, Complex rhs) { return Out(In(lhs) - In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator *(Complex lhs, Complex rhs) { return Mul(lhs, rhs); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator *(Complex lhs, float scalar)
        {
            Complex rhs = new Complex(lhs.Size);
            rhs.Fill(scalar);
            return Mul(lhs, rhs);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator /(Complex lhs, Complex rhs) { return Div(lhs, rhs); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator /(Complex lhs, float scalar)
        {
            Complex rhs = new Complex(lhs.Size);
            rhs.Fill(scalar);
            return Div(lhs, rhs);
        }

        /// <summary>
        /// Negates the complex numbers
        /// </summary>
        /// <param name="src">The source complex</param>
        /// <returns></returns>
        public static Complex operator -(Complex src) { return Neg(src); }

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
        /// Implements the operator <.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <(Complex lhs, Complex rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator <.
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
        /// Implements the operator <=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <=(Complex lhs, Complex rhs) { return lhs <= rhs; }

        /// <summary>
        /// Implements the operator <=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Complex operator <=(Complex lhs, float rhs) { return lhs <= rhs; }

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
