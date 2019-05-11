using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        internal ArithArray variable;

        public long Length
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public Vector3(long length)
        {
            variable = new ArithArray(length, 3);
        }

        public Vector3(int length, DType dataType)
        {
            variable = new ArithArray(new long[] { length, 3 }, dataType);
        }

        public static Vector3 Unit(float X, float Y, float Z)
        {
            Vector3 x = new Vector3(1);
            x.LoadArray(X, Y, Z);
            return x;
        }

        private Vector3(ArithArray v)
        {
            variable = v;
        }

        public static Vector3 Ones(long length)
        {
            var x = new Vector3(length);
            x.Fill(1);
            return x;
        }

        public static Vector3 Zeros(long length)
        {
            var x = new Vector3(length);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.CopyFrom(data);
        }

        internal static ArithArray In(Vector3 x)
        {
            return x.variable;
        }

        internal static Vector3 Out(ArithArray x)
        {
            return new Vector3(x);
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

        public void Fill(float value)
        {
            variable.Fill(value);
        }

        public void Print()
        {
            variable.Print();
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) + In(rhs)); }

        public static Vector3 operator +(Vector3 lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Vector3 operator +(float lhs, Vector3 rhs) { return Out(lhs + In(rhs)); }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) - In(rhs)); }

        public static Vector3 operator -(Vector3 lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Vector3 operator -(float lhs, Vector3 rhs) { return Out(lhs - In(rhs)); }

        public static Vector3 operator *(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) * In(rhs)); }

        public static Vector3 operator *(Vector3 lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Vector3 operator *(float lhs, Vector3 rhs) { return Out(lhs * In(rhs)); }

        public static Vector3 operator /(Vector3 lhs, Vector3 rhs) { return Out(In(lhs) / In(rhs)); }

        public static Vector3 operator /(Vector3 lhs, float rhs) { return lhs / rhs; }

        public static Vector3 operator /(float lhs, Vector3 rhs) { return lhs / rhs; }

        public static Vector3 operator >(Vector3 lhs, Vector3 rhs) { return lhs > rhs; }

        public static Vector3 operator >(Vector3 lhs, float rhs) { return lhs > rhs; }

        public static Vector3 operator <(Vector3 lhs, Vector3 rhs) { return lhs < rhs; }

        public static Vector3 operator <(Vector3 lhs, float rhs) { return lhs < rhs; }

        public static Vector3 operator >=(Vector3 lhs, Vector3 rhs) { return lhs >= rhs; }

        public static Vector3 operator >=(Vector3 lhs, float rhs) { return lhs >= rhs; }

        public static Vector3 operator <=(Vector3 lhs, Vector3 rhs) { return lhs <= rhs; }

        public static Vector3 operator <=(Vector3 lhs, float rhs) { return lhs <= rhs; }
    }
}
