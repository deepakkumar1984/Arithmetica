using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        internal ArithArray variable;

        public long Length
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public Vector2(long length)
        {
            variable = new ArithArray(length, 2);
        }

        public Vector2(int length, DType dataType)
        {
            variable = new ArithArray(new long[] { length, 2 }, dataType);
        }

        public static Vector2 Unit(float X, float Y)
        {
            Vector2 x = new Vector2(1);
            x.LoadArray(X, Y);
            return x;
        }

        private Vector2(ArithArray v)
        {
            variable = v;
        }

        public static Vector2 Ones(long length)
        {
            var x = new Vector2(length);
            x.Fill(1);
            return x;
        }

        public static Vector2 Zeros(long length)
        {
            var x = new Vector2(length);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.LoadFrom(data);
        }

        internal static ArithArray In(Vector2 x)
        {
            return x.variable;
        }

        internal static Vector2 Out(ArithArray x)
        {
            return new Vector2(x);
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

        public void Fill(float value)
        {
            variable.Fill(value);
        }

        public void Print()
        {
            variable.Print();
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs) { return Out(In(lhs) + In(rhs)); }

        public static Vector2 operator +(Vector2 lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Vector2 operator +(float lhs, Vector2 rhs) { return Out(lhs + In(rhs)); }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs) { return Out(In(lhs) - In(rhs)); }

        public static Vector2 operator -(Vector2 lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Vector2 operator -(float lhs, Vector2 rhs) { return Out(lhs - In(rhs)); }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs) { return Out(In(lhs) * In(rhs)); }

        public static Vector2 operator *(Vector2 lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Vector2 operator *(float lhs, Vector2 rhs) { return Out(lhs * In(rhs)); }

        public static Vector2 operator /(Vector2 lhs, Vector2 rhs) { return Out(In(lhs) / In(rhs)); }

        public static Vector2 operator /(Vector2 lhs, float rhs) { return lhs / rhs; }

        public static Vector2 operator /(float lhs, Vector2 rhs) { return lhs / rhs; }

        public static Vector2 operator >(Vector2 lhs, Vector2 rhs) { return lhs > rhs; }

        public static Vector2 operator >(Vector2 lhs, float rhs) { return lhs > rhs; }

        public static Vector2 operator <(Vector2 lhs, Vector2 rhs) { return lhs < rhs; }

        public static Vector2 operator <(Vector2 lhs, float rhs) { return lhs < rhs; }

        public static Vector2 operator >=(Vector2 lhs, Vector2 rhs) { return lhs >= rhs; }

        public static Vector2 operator >=(Vector2 lhs, float rhs) { return lhs >= rhs; }

        public static Vector2 operator <=(Vector2 lhs, Vector2 rhs) { return lhs <= rhs; }

        public static Vector2 operator <=(Vector2 lhs, float rhs) { return lhs <= rhs; }
    }
}
