using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        internal ArithArray variable;

        public long Length
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public Vector(long length)
        {
            variable = new ArithArray(length, 1);
        }

        public Vector(int length, DType dataType)
        {
            variable = new ArithArray(new long[] { length, 1 }, dataType);
        }

        public static Vector Unit(float X)
        {
            Vector x = new Vector(1);
            x.LoadArray(X);
            return x;
        }

        private Vector(ArithArray v)
        {
            variable = v;
        }

        public static Vector Ones(long length)
        {
            var x = new Vector(length);
            x.Fill(1);
            return x;
        }

        public static Vector Zeros(long length)
        {
            var x = new Vector(length);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.LoadFrom(data);
        }

        internal static ArithArray In(Vector x)
        {
            return x.variable;
        }

        internal static Vector Out(ArithArray x)
        {
            return new Vector(x);
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

        public void Fill(float value)
        {
            variable.Fill(value);
        }

        public void Print()
        {
            variable.Print();
        }

        public static Vector operator +(Vector lhs, Vector rhs) { return Out(In(lhs) + In(rhs)); }

        public static Vector operator +(Vector lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Vector operator +(float lhs, Vector rhs) { return Out(lhs + In(rhs)); }

        public static Vector operator -(Vector lhs, Vector rhs) { return Out(In(lhs) - In(rhs)); }

        public static Vector operator -(Vector lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Vector operator -(float lhs, Vector rhs) { return Out(lhs - In(rhs)); }

        public static Vector operator *(Vector lhs, Vector rhs) { return Out(In(lhs) * In(rhs)); }

        public static Vector operator *(Vector lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Vector operator *(float lhs, Vector rhs) { return Out(lhs * In(rhs)); }

        public static Vector operator /(Vector lhs, Vector rhs) { return Out(In(lhs) / In(rhs)); }

        public static Vector operator /(Vector lhs, float rhs) { return lhs / rhs; }

        public static Vector operator /(float lhs, Vector rhs) { return lhs / rhs; }

        public static Vector operator >(Vector lhs, Vector rhs) { return lhs > rhs; }

        public static Vector operator >(Vector lhs, float rhs) { return lhs > rhs; }

        public static Vector operator <(Vector lhs, Vector rhs) { return lhs < rhs; }

        public static Vector operator <(Vector lhs, float rhs) { return lhs < rhs; }

        public static Vector operator >=(Vector lhs, Vector rhs) { return lhs >= rhs; }

        public static Vector operator >=(Vector lhs, float rhs) { return lhs >= rhs; }

        public static Vector operator <=(Vector lhs, Vector rhs) { return lhs <= rhs; }

        public static Vector operator <=(Vector lhs, float rhs) { return lhs <= rhs; }
    }
}
