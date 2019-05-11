using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Matrix
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

        public Matrix(long rows, long cols)
        {
            variable = new ArithArray(rows, cols);
        }

        public Matrix(long rows, long cols, DType dataType)
        {
            variable = new ArithArray(new long[] { rows, cols }, dataType);
        }

        private Matrix(ArithArray v)
        {
            variable = v;
        }

        public static Matrix Matrix3x2(params float[] data)
        {
            var x = new ArithArray(new long[] { 3, 2 });
            if(data.Length == 6)
            {
                x.CopyFrom(data);
            }

            return Out(x);
        }

        public static Matrix Matrix4x4(params float[] data)
        {
            var x = new ArithArray(new long[] { 4, 4 });
            if (data.Length == 8)
            {
                x.CopyFrom(data);
            }

            return Out(x);
        }

        public static Matrix Ones(int rows, int cols)
        {
            var x = new ArithArray(new long[] { rows, cols });
            x.Fill(1);
            return Out(x);
        }

        public static Matrix Zeros(int rows, int cols)
        {
            var x = new ArithArray(new long[] { rows, cols });
            x.Fill(0);
            return Out(x);
        }

        public static Matrix Diagonal(params float[] data)
        {
            var x = new ArithArray(new long[] { data.Length, 1 });
            x.CopyFrom(data);
            x = ArrayOps.Diag(x);
            return Out(x);
        }

        public static Matrix Identity(int diagElementCount)
        {
            var x = new ArithArray(new long[] { diagElementCount });
            x.Fill(1);
            x = ArrayOps.Diag(x);
            return Out(x);
        }

        public void LoadArray(params float[] data)
        {
            variable.CopyFrom(data);
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
