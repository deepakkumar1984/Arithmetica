using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    /// <summary>
    /// Provides a collection of static convenience methods for creating, manipulating, combining, and converting generic vectors.
    /// </summary>
    public partial class Vector
    {
        internal ArithArray variable;

        /// <summary>
        /// Gets the size of the vector.
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
                if(Size > 0)
                {
                    return this[0];
                }

                throw new Exception("Not initialized");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="size">The size of the vector.</param>
        public Vector(long size)
        {
            variable = new ArithArray(size, 1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector" /> class.
        /// </summary>
        /// <param name="size">The size of the vector.</param>
        /// <param name="dataType">The data tyoe.</param>
        public Vector(int size, DType dataType)
        {
            variable = new ArithArray(new long[] { size, 1 }, dataType);
        }

        /// <summary>
        /// Create a Unit vector which is vector of size 1
        /// </summary>
        /// <param name="X">The X value.</param>
        /// <returns></returns>
        public static Vector Unit(float X)
        {
            return Vector.FromArray(X);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="v">The arith array which is a generalised array.</param>
        private Vector(ArithArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Creates a Vector of specified size and all filled with 1
        /// </summary>
        /// <param name="size">The size of the vector.</param>
        /// <returns></returns>
        public static Vector Ones(long size)
        {
            var x = new Vector(size);
            x.Fill(1);
            return x;
        }

        /// <summary>
        /// Creates a Vector of specified size and all filled with 0
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Vector Zeros(long size)
        {
            var x = new Vector(size);
            x.Fill(0);
            return x;
        }

        /// <summary>
        /// Created a Vector from the array.
        /// </summary>
        /// <param name="data">The data array to be loaded.</param>
        /// <returns></returns>
        public static Vector FromArray(params float[] data)
        {
            var x = new Vector(data.Length);
            x.variable.LoadFrom(data);
            return x;
        }

        /// <summary>
        /// Ins the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static ArithArray In(Vector x)
        {
            return x.variable;
        }

        /// <summary>
        /// Outs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static Vector Out(ArithArray x)
        {
            return new Vector(x);
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
        /// Get the value at the index
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public float this[long index]
        {
            get
            {
                return variable.GetElementAsFloat(index, 0);
            }
            set
            {
                variable.SetElementAsFloat(value, index, 0);
            }
        }

        /// <summary>
        /// Gets the Vector value at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Vector Get(long index)
        {
            return FromArray(variable.GetElementAsFloat(index, 0));
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
        /// Prints this vector.
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
        public static Vector operator +(Vector lhs, Vector rhs) { return Out(In(lhs) + In(rhs)); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator +(Vector lhs, float rhs) { return Out(In(lhs) + rhs); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator +(float lhs, Vector rhs) { return Out(lhs + In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator -(Vector lhs, Vector rhs) { return Out(In(lhs) - In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator -(Vector lhs, float rhs) { return Out(In(lhs) - rhs); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator -(float lhs, Vector rhs) { return Out(lhs - In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator *(Vector lhs, Vector rhs) { return Out(In(lhs) * In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator *(Vector lhs, float rhs) { return Out(In(lhs) * rhs); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator *(float lhs, Vector rhs) { return Out(lhs * In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator /(Vector lhs, Vector rhs) { return Out(In(lhs) / In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator /(Vector lhs, float rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator /(float lhs, Vector rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator >(Vector lhs, Vector rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator >(Vector lhs, float rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator <(Vector lhs, Vector rhs) { return lhs &lt; rhs; }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator <(Vector lhs, float rhs) { return lhs &lt; rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator >=(Vector lhs, Vector rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator >=(Vector lhs, float rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator <=(Vector lhs, Vector rhs) { return lhs &lt;= rhs; }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator <=(Vector lhs, float rhs) { return lhs &lt;= rhs; }
    }
}
