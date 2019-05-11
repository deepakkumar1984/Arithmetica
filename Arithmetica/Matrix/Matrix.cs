using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public class Matrix
    {
        internal ArithArray variable;

        public long Rows
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public long Cols
        {
            get
            {
                return variable.Shape[1];
            }
        }

        public Matrix(ArithArray v)
        {
            variable = v;
        }

        public Matrix(long rows, long cols)
        {
            variable = new ArithArray(rows, cols);
        }

        public Matrix(long rows, long cols, DType dataType)
        {
            variable = new ArithArray(new long[] { rows, cols }, dataType);
        }

        internal static ArithArray In(Matrix x)
        {
            return x.variable;
        }

        internal static Matrix Out(ArithArray x)
        {
            return new Matrix(x);
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

        public void Fill(float value)
        {
            variable.Fill(value);
        }

        public void Print()
        {
            variable.Print();
        }

        public Matrix Transpose()
        {
            return Out(variable.Transpose());
        }

        public Matrix T
        {
            get
            {
                return Transpose();
            }
        }

        public static Matrix operator +(Matrix lhs, Matrix rhs) { return Out(In(lhs) + In(rhs)); }

        public static Matrix operator +(Matrix lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Matrix operator +(float lhs, Matrix rhs) { return Out(lhs + In(rhs)); }

        public static Matrix operator -(Matrix lhs, Matrix rhs) { return Out(In(lhs) - In(rhs)); }

        public static Matrix operator -(Matrix lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Matrix operator -(float lhs, Matrix rhs) { return Out(lhs - In(rhs)); }

        public static Matrix operator *(Matrix lhs, Matrix rhs) { return Out(In(lhs) * In(rhs)); }

        public static Matrix operator *(Matrix lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Matrix operator *(float lhs, Matrix rhs) { return Out(lhs * In(rhs)); }

        public static Matrix operator /(Matrix lhs, Matrix rhs) { return Out(In(lhs) / In(rhs)); }

        public static Matrix operator /(Matrix lhs, float rhs) { return lhs / rhs; }

        public static Matrix operator /(float lhs, Matrix rhs) { return lhs / rhs; }

        public static Matrix operator >(Matrix lhs, Matrix rhs) { return lhs > rhs; }

        public static Matrix operator >(Matrix lhs, float rhs) { return lhs > rhs; }

        public static Matrix operator <(Matrix lhs, Matrix rhs) { return lhs < rhs; }

        public static Matrix operator <(Matrix lhs, float rhs) { return lhs < rhs; }

        public static Matrix operator >=(Matrix lhs, Matrix rhs) { return lhs >= rhs; }

        public static Matrix operator >=(Matrix lhs, float rhs) { return lhs >= rhs; }

        public static Matrix operator <=(Matrix lhs, Matrix rhs) { return lhs <= rhs; }

        public static Matrix operator <=(Matrix lhs, float rhs) { return lhs <= rhs; }
    }
}
