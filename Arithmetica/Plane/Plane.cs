using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        internal ArithArray variable;

        public long Length
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public Plane(long length)
        {
            variable = new ArithArray(length, 4);
        }

        public Plane(int length, DType dataType)
        {
            variable = new ArithArray(new long[] { length, 4 }, dataType);
        }

        public static Plane Unit(float W, float X, float Y, float Z)
        {
            Plane x = new Plane(1);
            x.LoadArray(X, Y, Z, W);
            return x;
        }

        private Plane(ArithArray v)
        {
            variable = v;
        }

        public static Plane Ones(long length)
        {
            var x = new Plane(length);
            x.Fill(1);
            return x;
        }

        public static Plane Zeros(long length)
        {
            var x = new Plane(length);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.CopyFrom(data);
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

        public static Plane operator <(Plane lhs, Plane rhs) { return lhs < rhs; }

        public static Plane operator <(Plane lhs, float rhs) { return lhs < rhs; }

        public static Plane operator >=(Plane lhs, Plane rhs) { return lhs >= rhs; }

        public static Plane operator >=(Plane lhs, float rhs) { return lhs >= rhs; }

        public static Plane operator <=(Plane lhs, Plane rhs) { return lhs <= rhs; }

        public static Plane operator <=(Plane lhs, float rhs) { return lhs <= rhs; }
    }
}
