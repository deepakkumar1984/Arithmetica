using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SuperchargedArray;

namespace Arithmetica.LinearAlgebra.Double
{
    /// <summary>
    /// Vector of double values
    /// </summary>
    /// <seealso cref="Arithmetica.LinearAlgebra.Vector{System.Double}" />
    /// <seealso cref="System.IFormattable" />
    public class DoubleVector : LinearAlgebra.Vector<double>, IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public Vector(int size) : base(size, 1, DType.Double)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="arithArray">The arith array.</param>
        internal Vector(SuperArray arithArray): base(arithArray)
        {

        }

        /// <summary>
        /// Gets or sets the <see cref="System.Single"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Single"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public float this[int index]
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
        /// Performs an implicit conversion from <see cref="SuperArray"/> to <see cref="Vector"/>.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Vector(SuperArray variable)
        {
            return new DoubleVector(variable);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Vector (double): " + Size;
        }
    }

    /// <summary>
    /// Create an instance of Vector of Vector2
    /// </summary>
    /// <seealso cref="Arithmetica.LinearAlgebra.Vector{Arithmetica.LinearAlgebra.Double.Vector2}" />
    public class Vector2Vector : LinearAlgebra.Vector<Vector2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Vector"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public Vector2Vector(int size) : base(size, 2, DType.Double)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Vector"/> class.
        /// </summary>
        /// <param name="arithArray">The arith array.</param>
        internal Vector2Vector(SuperArray arithArray) : base(arithArray)
        {

        }

        /// <summary>
        /// Loads the array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public new static Vector2Vector LoadArray(params Double.Vector2[] data)
        {
            Vector2Vector result = new Vector2Vector(data.Length);
            Parallel.For(0, data.Length, (i) => {
                result[i] = data[i];
            });

            return result;
        }

        /// <summary>
        /// Gets or sets the <see cref="Double.Vector2"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Double.Vector2"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Double.Vector2 this[int index]
        {
            get
            {
                return new Double.Vector2(variable.GetElementAsFloat(index, 0), variable.GetElementAsFloat(index, 1));
            }
            set
            {
                variable.SetElementAsFloat((float)value.X, index, 0);
                variable.SetElementAsFloat((float)value.Y, index, 1);
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SuperArray"/> to <see cref="Vector2Vector"/>.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Vector2Vector(SuperArray variable)
        {
            return new Vector2Vector(variable);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Vector (Vector2): " + Size;
        }
    }

    /// <summary>
    /// Create an instance of Vector of Vector3
    /// </summary>
    /// <seealso cref="Arithmetica.LinearAlgebra.Vector{Arithmetica.LinearAlgebra.Double.Vector3}" />
    public class Vector3Vector : LinearAlgebra.Vector<Vector3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3Vector"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public Vector3Vector(int size) : base(size, 3, DType.Double)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3Vector"/> class.
        /// </summary>
        /// <param name="arithArray">The arith array.</param>
        internal Vector3Vector(SuperArray arithArray) : base(arithArray)
        {

        }

        /// <summary>
        /// Loads the array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public new static Vector3Vector LoadArray(params Double.Vector3[] data)
        {
            Vector3Vector result = new Vector3Vector(data.Length);
            Parallel.For(0, data.Length, (i) => {
                result[i] = data[i];
            });

            return result;
        }

        /// <summary>
        /// Gets or sets the <see cref="Double.Vector3"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Double.Vector3"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Double.Vector3 this[int index]
        {
            get
            {
                return new Double.Vector3(variable.GetElementAsFloat(index, 0), variable.GetElementAsFloat(index, 1), variable.GetElementAsFloat(index, 2));
            }
            set
            {
                variable.SetElementAsFloat((float)value.X, index, 0);
                variable.SetElementAsFloat((float)value.Y, index, 1);
                variable.SetElementAsFloat((float)value.Z, index, 2);
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SuperArray"/> to <see cref="Vector3Vector"/>.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Vector3Vector(SuperArray variable)
        {
            return new Vector3Vector(variable);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Vector (Vector3): " + Size;
        }
    }

    /// <summary>
    /// Create an instance of Vector of Vector4
    /// </summary>
    /// <seealso cref="Arithmetica.LinearAlgebra.Vector{Arithmetica.LinearAlgebra.Double.Vector4}" />
    public class Vector4Vector : LinearAlgebra.Vector<Vector4>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4Vector"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public Vector4Vector(int size) : base(size, 4, DType.Double)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4Vector"/> class.
        /// </summary>
        /// <param name="arithArray">The arith array.</param>
        internal Vector4Vector(SuperArray arithArray) : base(arithArray)
        {

        }

        /// <summary>
        /// Loads the array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public new static Vector4Vector LoadArray(params Double.Vector4[] data)
        {
            Vector4Vector result = new Vector4Vector(data.Length);
            Parallel.For(0, data.Length, (i) => {
                result[i] = data[i];
            });

            return result;
        }

        /// <summary>
        /// Gets or sets the <see cref="Double.Vector4"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Double.Vector4"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Double.Vector4 this[int index]
        {
            get
            {
                return new Double.Vector4(variable.GetElementAsFloat(index, 0), 
                            variable.GetElementAsFloat(index, 1),
                            variable.GetElementAsFloat(index, 2),
                            variable.GetElementAsFloat(index, 3));
            }
            set
            {
                variable.SetElementAsFloat((float)value.X, index, 0);
                variable.SetElementAsFloat((float)value.Y, index, 1);
                variable.SetElementAsFloat((float)value.Z, index, 2);
                variable.SetElementAsFloat((float)value.W, index, 3);
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SuperArray"/> to <see cref="Vector4Vector"/>.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Vector4Vector(SuperArray variable)
        {
            return new Vector4Vector(variable);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Vector (Vector4): " + Size;
        }
    }
}
