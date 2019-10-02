using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra.Double
{
    /// <summary>
    /// Matrix is an arrangement of numbers into rows and columns
    /// </summary>
    public partial class Matrix
    {
        internal NDArray variable;

        /// <summary>
        /// Gets the rows of the matrix
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public long Rows
        {
            get
            {
                return variable.shape[0];
            }
        }

        /// <summary>
        /// Gets the columns of the matrix
        /// </summary>
        /// <value>
        /// The cols.
        /// </value>
        public long Cols
        {
            get
            {
                return variable.shape[1];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public Matrix(int rows, int cols)
        {
            variable = new NDArray(new long[] { rows, cols }, DType.Double);
            variable = new NDArray(NPTypeCode.Double, new Shape(rows, cols));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="v">The arith array.</param>
        private Matrix(NDArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Creates an instance of 3x2 matrix
        /// </summary>
        /// <param name="data">The array data.</param>
        /// <returns></returns>
        public static Matrix Matrix3x2(params double[] data)
        {
            var x = new NDArray(new long[] { 3, 2 });
            if(data.Length == 6)
            {
                x.LoadFrom(data);
            }

            return Out(x);
        }

        /// <summary>
        /// Creates an instance of 4x4 matrix
        /// </summary>
        /// <param name="data">The array data.</param>
        /// <returns></returns>
        public static Matrix Matrix4x4(params double[] data)
        {
            var x = new NDArray(new long[] { 4, 4 });
            if (data.Length == 8)
            {
                x = np.array(data);
            }

            return Out(x);
        }

        /// <summary>
        /// Creates a matrix with all ones
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <returns></returns>
        public static Matrix Ones(int rows, int cols)
        {
            var x = np.ones(new Shape(rows, cols));
            return Out(x);
        }

        /// <summary>
        /// Creates a matrix with all zeros
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <returns></returns>
        public static Matrix Zeros(int rows, int cols)
        {
            var x = np.zeros(new Shape(rows, cols));
            return Out(x);
        }

        /// <summary>
        /// Create a diagonal matrix from the given array
        /// </summary>
        /// <param name="data">The array data.</param>
        /// <returns></returns>
        public static Matrix Diagonal(params double[] data)
        {
            var x = new NDArray(new long[] { data.Length, 1 });
            x.LoadFrom(data);
            x = Global.OP.Diag(x);
            return Out(x);
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <param name="diagElementCount">The diag element count.</param>
        /// <returns></returns>
        public static Matrix Identity(int diagElementCount)
        {
            var x = new NDArray(new long[] { diagElementCount });
            x.Fill(1);
            x = Global.OP.Diag(x);
            return Out(x);
        }

        /// <summary>
        /// Loads the array data into the matrix.
        /// </summary>
        /// <param name="data">The data.</param>
        public void LoadArray(params double[] data)
        {
            variable.LoadFrom(data);
        }

        internal static NDArray In(Matrix x)
        {
            return x.variable;
        }

        internal static Matrix Out(NDArray x)
        {
            return new Matrix(x);
        }

        /// <summary>
        /// Gets the arith array.
        /// </summary>
        /// <value>
        /// The arith array.
        /// </value>
        public NDArray NDArray
        {
            get
            {
                return variable;
            }
        }

        /// <summary>
        /// Gets the data.
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
        /// Fills the the matrix with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Fill(double value)
        {
            variable.Fill((float)value);
        }

        /// <summary>
        /// Prints this matrix.
        /// </summary>
        public void Print()
        {
            variable.Print();
        }

        /// <summary>
        /// Transposes this matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            return Out(variable.transpose());
        }

        /// <summary>
        /// Gets the transposed matrix
        /// </summary>
        /// <value>
        /// The t.
        /// </value>
        public Matrix T
        {
            get
            {
                return Transpose();
            }
        }

        public static Matrix operator +(Matrix lhs, Matrix rhs) { return Out(In(lhs) + In(rhs)); }

        public static Matrix operator +(Matrix lhs, double rhs) { return Out(In(lhs) + (float)rhs); }

        public static Matrix operator +(double lhs, Matrix rhs) { return Out((float)lhs + In(rhs)); }

        public static Matrix operator -(Matrix lhs, Matrix rhs) { return Out(In(lhs) - In(rhs)); }

        public static Matrix operator -(Matrix lhs, double rhs) { return Out(In(lhs) - (float)rhs); }

        public static Matrix operator -(double lhs, Matrix rhs) { return Out((float)lhs - In(rhs)); }

        public static Matrix operator *(Matrix lhs, Matrix rhs) { return Out(In(lhs) * In(rhs)); }

        public static Matrix operator *(Matrix lhs, double rhs) { return Out(In(lhs) * (float)rhs); }

        public static Matrix operator *(double lhs, Matrix rhs) { return Out((float)lhs * In(rhs)); }

        public static Matrix operator /(Matrix lhs, Matrix rhs) { return Out(In(lhs) / In(rhs)); }

        public static Matrix operator /(Matrix lhs, double rhs) { return lhs / rhs; }

        public static Matrix operator /(double lhs, Matrix rhs) { return lhs / rhs; }

        public static Matrix operator >(Matrix lhs, Matrix rhs) { return lhs > rhs; }

        public static Matrix operator >(Matrix lhs, double rhs) { return lhs > rhs; }

        public static Matrix operator <(Matrix lhs, Matrix rhs) { return lhs < rhs; }

        public static Matrix operator <(Matrix lhs, double rhs) { return lhs < rhs; }

        public static Matrix operator >=(Matrix lhs, Matrix rhs) { return lhs >= rhs; }

        public static Matrix operator >=(Matrix lhs, double rhs) { return lhs >= rhs; }

        public static Matrix operator <=(Matrix lhs, Matrix rhs) { return lhs <= rhs; }

        public static Matrix operator <=(Matrix lhs, double rhs) { return lhs <= rhs; }
    }
}
