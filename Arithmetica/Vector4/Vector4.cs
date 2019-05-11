using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        internal ArithArray variable;

        public long Length
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public Vector4(long length)
        {
            variable = new ArithArray(length, 4);
        }

        public Vector4(int length, DType dataType)
        {
            variable = new ArithArray(new long[] { length, 4 }, dataType);
        }

        public static Vector4 Unit(float W, float X, float Y, float Z)
        {
            Vector4 x = new Vector4(1);
            x.LoadArray(X, Y, Z, W);
            return x;
        }

        private Vector4(ArithArray v)
        {
            variable = v;
        }

        public static Vector4 Ones(long length)
        {
            var x = new Vector4(length);
            x.Fill(1);
            return x;
        }

        public static Vector4 Zeros(long length)
        {
            var x = new Vector4(length);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.CopyFrom(data);
        }

        internal static ArithArray In(Vector4 x)
        {
            return x.variable;
        }

        internal static Vector4 Out(ArithArray x)
        {
            return new Vector4(x);
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

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs) { return Out(In(lhs) + In(rhs)); }

        public static Vector4 operator +(Vector4 lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Vector4 operator +(float lhs, Vector4 rhs) { return Out(lhs + In(rhs)); }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs) { return Out(In(lhs) - In(rhs)); }

        public static Vector4 operator -(Vector4 lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Vector4 operator -(float lhs, Vector4 rhs) { return Out(lhs - In(rhs)); }

        public static Vector4 operator *(Vector4 lhs, Vector4 rhs) { return Out(In(lhs) * In(rhs)); }

        public static Vector4 operator *(Vector4 lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Vector4 operator *(float lhs, Vector4 rhs) { return Out(lhs * In(rhs)); }

        public static Vector4 operator /(Vector4 lhs, Vector4 rhs) { return Out(In(lhs) / In(rhs)); }

        public static Vector4 operator /(Vector4 lhs, float rhs) { return lhs / rhs; }

        public static Vector4 operator /(float lhs, Vector4 rhs) { return lhs / rhs; }

        public static Vector4 operator >(Vector4 lhs, Vector4 rhs) { return lhs > rhs; }

        public static Vector4 operator >(Vector4 lhs, float rhs) { return lhs > rhs; }

        public static Vector4 operator <(Vector4 lhs, Vector4 rhs) { return lhs < rhs; }

        public static Vector4 operator <(Vector4 lhs, float rhs) { return lhs < rhs; }

        public static Vector4 operator >=(Vector4 lhs, Vector4 rhs) { return lhs >= rhs; }

        public static Vector4 operator >=(Vector4 lhs, float rhs) { return lhs >= rhs; }

        public static Vector4 operator <=(Vector4 lhs, Vector4 rhs) { return lhs <= rhs; }

        public static Vector4 operator <=(Vector4 lhs, float rhs) { return lhs <= rhs; }
    }
}
