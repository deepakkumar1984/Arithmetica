using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    /// <summary>
    /// Represents a Vector with X, Y and Z components and can hold multiple Vector3
    /// </summary>
    public partial class Vector3
    {
        /// <summary>
        /// The variable
        /// </summary>
        internal ArithArray variable;

        /// <summary>
        /// Gets the number of the Vector3 in this instance.
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
        /// Gets the X value for the Vector. Usually gets the first Vector value.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        /// <exception cref="Exception">Not initialized</exception>
        public float X
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
        /// Gets the Y value for the Vector. Usually gets the first Vector value.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        /// <exception cref="Exception">Not initialized</exception>
        public float Y
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
        /// Gets the Z value for the Vector. Usually gets the first Vector value.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        /// <exception cref="Exception">Not initialized</exception>
        public float Z
        {
            get
            {
                if (Size > 0)
                {
                    return this[0].Item3;
                }

                throw new Exception("Not initialized");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="size">Defines number of Vector3 in the list.</param>
        public Vector3(long size = 1)
        {
            variable = new ArithArray(size, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="X">The x value.</param>
        /// <param name="Y">The y value.</param>
        /// <param name="Z">The z value.</param>
        public Vector3(float X, float Y, float Z) : this(1)
        {
            variable.LoadFrom(new float[] { X, Y, Z });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="size">Defines number of Vector3 in the list.</param>
        /// <param name="dataType">The data type.</param>
        public Vector3(int size, DType dataType)
        {
            variable = new ArithArray(new long[] { size, 3 }, dataType);
        }

        /// <summary>
        /// Create a Unit Vector3 which is vector of size 1
        /// </summary>
        /// <param name="X">The x value.</param>
        /// <param name="Y">The y value.</param>
        /// <param name="Z">The z value.</param>
        /// <returns></returns>
        public static Vector3 Unit(float X, float Y, float Z)
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="v">The v.</param>
        private Vector3(ArithArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Creates a Vector3 of specified size and all filled with 1
        /// </summary>
        /// <param name="size">Defines number of Vector3 in the list.</param>
        /// <returns></returns>
        public static Vector3 Ones(long size)
        {
            var x = new Vector3(size);
            x.Fill(1);
            return x;
        }

        /// <summary>
        /// Creates a Vector3 of specified size and all filled with 0
        /// </summary>
        /// <param name="size">Defines number of vectors in the list.</param>
        /// <returns></returns>
        public static Vector3 Zeros(long size)
        {
            var x = new Vector3(size);
            x.Fill(0);
            return x;
        }

        /// <summary>
        /// Create a Vector3 from the array.
        /// </summary>
        /// <param name="data">The data array to be loaded.</param>
        /// <returns></returns>
        public static Vector3 FromArray(params float[] data)
        {
            var x = new Vector3(data.Length / 3);
            x.variable.LoadFrom(data);
            return x;
        }

        /// <summary>
        /// Ins the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static ArithArray In(Vector3 x)
        {
            return x.variable;
        }

        /// <summary>
        /// Outs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static Vector3 Out(ArithArray x)
        {
            return new Vector3(x);
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
        /// Gets or sets the vector value at the specified index.
        /// </summary>
        /// <value>
        /// Get the (X, Y, Z) value at the index
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public (float, float, float) this[long index]
        {
            get
            {
                return (variable.GetElementAsFloat(index, 0), variable.GetElementAsFloat(index, 1), variable.GetElementAsFloat(index, 2));
            }
            set
            {
                variable.SetElementAsFloat(value.Item1, index, 0);
                variable.SetElementAsFloat(value.Item2, index, 1);
                variable.SetElementAsFloat(value.Item3, index, 2);
            }
        }

        /// <summary>
        /// Gets the Vector3 value at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Vector3 Get(long index)
        {
            return FromArray(variable.GetElementAsFloat(index, 0), variable.GetElementAsFloat(index, 1), variable.GetElementAsFloat(index, 2));
        }

        /// <summary>
        /// Fills all the values in the vector with specified value
        /// </summary>
        /// <param name="value">The value.</param>
        public void Fill(float value)
        {
            variable.Fill(value);
        }

        /// <summary>
        /// Prints this instance.
        /// </summary>
        public void Print()
        {
            variable.Print();
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) + In(rhs)); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator +(Vector3 lhs, float rhs) { return Out(In(lhs) + rhs); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator +(float lhs, Vector3 rhs) { return Out(lhs + In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) - In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator -(Vector3 lhs, float rhs) { return Out(In(lhs) - rhs); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator -(float lhs, Vector3 rhs) { return Out(lhs - In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator *(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) * In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator *(Vector3 lhs, float rhs) { return Out(In(lhs) * rhs); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator *(float lhs, Vector3 rhs) { return Out(lhs * In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator /(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) / In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator /(Vector3 lhs, float rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator /(float lhs, Vector3 rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator >(Vector3 lhs, Vector3 rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator >(Vector3 lhs, float rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator <.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator <(Vector3 lhs, Vector3 rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator <.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator <(Vector3 lhs, float rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator >=(Vector3 lhs, Vector3 rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator >=(Vector3 lhs, float rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator <=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator <=(Vector3 lhs, Vector3 rhs) { return lhs <= rhs; }

        /// <summary>
        /// Implements the operator <=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector3 operator <=(Vector3 lhs, float rhs) { return lhs <= rhs; }
    }
}
