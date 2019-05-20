using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Geometry
{
    /// <summary>
    /// Represents a plane in three-dimensional space.
    /// </summary>
    public partial class Plane
    {
        /// <summary>
        /// The variable
        /// </summary>
        internal ArithArray variable;

        /// <summary>
        /// Gets the size for the planes
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
        /// Gets the X value for the Plane. Usually gets the first Vector value.
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
        /// Gets the Y value for the Plane. Usually gets the first Vector value.
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
        /// Gets the Z value for the Plane. Usually gets the first Vector value.
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
        /// Gets the distance of the plane from the origin.
        /// </summary>
        /// <value>
        /// The d.
        /// </value>
        /// <exception cref="Exception">Not initialized</exception>
        public float D
        {
            get
            {
                if (Size > 0)
                {
                    return this[0].Item4;
                }

                throw new Exception("Not initialized");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Plane"/> class.
        /// </summary>
        /// <param name="size">Defines number of planes in the list.</param>
        public Plane(long size = 1)
        {
            variable = new ArithArray(size, 4);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Plane"/> class.
        /// </summary>
        /// <param name="size">Defines number of planes in the list.</param>
        /// <param name="dataType">The data type.</param>
        public Plane(int size, DType dataType)
        {
            variable = new ArithArray(new long[] { size, 4 }, dataType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Plane"/> class.
        /// </summary>
        /// <param name="X">The x value.</param>
        /// <param name="Y">The y value.</param>
        /// <param name="Z">The z value.</param>
        /// <param name="D">The distance.</param>
        public Plane(float X, float Y, float Z, float D) : this(1)
        {
            variable.LoadFrom(new float[] { X, Y, Z, D });
        }

        /// <summary>
        /// Units the specified x.
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="Z">The z.</param>
        /// <param name="D">The d.</param>
        /// <returns></returns>
        public static Plane Unit(float X, float Y, float Z, float D)
        {
            return new Plane(X, Y, Z, D);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Plane"/> class.
        /// </summary>
        /// <param name="v">The v.</param>
        private Plane(ArithArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Oneses the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Plane Ones(long size)
        {
            var x = new Plane(size);
            x.Fill(1);
            return x;
        }

        /// <summary>
        /// Zeroses the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Plane Zeros(long size)
        {
            var x = new Plane(size);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.LoadFrom(data);
        }

        internal static ArithArray In(Plane x)
        {
            return x.variable;
        }

        internal static Plane Out(ArithArray x)
        {
            return new Plane(x);
        }

        public ArithArray ArithArray
        {
            get
            {
                return variable;
            }
        }

        public Array Data
        {
            get
            {
                return variable.ToArray();
            }
        }

        public (float, float, float, float) this[long index]
        {
            get
            {
                return (variable.GetElementAsFloat(index, 0)
                    , variable.GetElementAsFloat(index, 1)
                    , variable.GetElementAsFloat(index, 2)
                    , variable.GetElementAsFloat(index, 3));
            }
            set
            {
                variable.SetElementAsFloat(value.Item1, index, 0);
                variable.SetElementAsFloat(value.Item2, index, 1);
                variable.SetElementAsFloat(value.Item3, index, 2);
                variable.SetElementAsFloat(value.Item4, index, 3);
            }
        }

        public void Fill(float value)
        {
            variable.Fill(value);
        }

        public void Print()
        {
            variable.Print();
        }

        public static Plane operator +(Plane lhs, Plane rhs) { return Out(In(lhs) + In(rhs)); }

        public static Plane operator +(Plane lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Plane operator +(float lhs, Plane rhs) { return Out(lhs + In(rhs)); }

        public static Plane operator -(Plane lhs, Plane rhs) { return Out(In(lhs) - In(rhs)); }

        public static Plane operator -(Plane lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Plane operator -(float lhs, Plane rhs) { return Out(lhs - In(rhs)); }

        public static Plane operator *(Plane lhs, Plane rhs) { return Out(In(lhs) * In(rhs)); }

        public static Plane operator *(Plane lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Plane operator *(float lhs, Plane rhs) { return Out(lhs * In(rhs)); }

        public static Plane operator /(Plane lhs, Plane rhs) { return Out(In(lhs) / In(rhs)); }

        public static Plane operator /(Plane lhs, float rhs) { return lhs / rhs; }

        public static Plane operator /(float lhs, Plane rhs) { return lhs / rhs; }

        public static Plane operator >(Plane lhs, Plane rhs) { return lhs > rhs; }

        public static Plane operator >(Plane lhs, float rhs) { return lhs > rhs; }

        public static Plane operator <(Plane lhs, Plane rhs) { return lhs &lt; rhs; }

        public static Plane operator <(Plane lhs, float rhs) { return lhs &lt; rhs; }

        public static Plane operator >=(Plane lhs, Plane rhs) { return lhs >= rhs; }

        public static Plane operator >=(Plane lhs, float rhs) { return lhs >= rhs; }

        public static Plane operator <=(Plane lhs, Plane rhs) { return lhs &lt;= rhs; }

        public static Plane operator <=(Plane lhs, float rhs) { return lhs &lt;= rhs; }
    }
}
