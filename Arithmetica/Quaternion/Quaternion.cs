using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        internal ArithArray variable;

        public long Length
        {
            get
            {
                return variable.Shape[0];
            }
        }

        public Quaternion(long length)
        {
            variable = new ArithArray(length, 4);
        }

        public Quaternion(int length, DType dataType)
        {
            variable = new ArithArray(new long[] { length, 4 }, dataType);
        }

        public static Quaternion Unit(float X, float Y, float Z, float W)
        {
            Quaternion x = new Quaternion(1);
            x.LoadArray(X, Y, Z, W);
            return x;
        }

        private Quaternion(ArithArray v)
        {
            variable = v;
        }

        public static Quaternion Ones(long length)
        {
            var x = new Quaternion(length);
            x.Fill(1);
            return x;
        }

        public static Quaternion Zeros(long length)
        {
            var x = new Quaternion(length);
            x.Fill(0);
            return x;
        }

        public void LoadArray(params float[] data)
        {
            variable.LoadFrom(data);
        }

        internal static ArithArray In(Quaternion x)
        {
            return x.variable;
        }

        internal static Quaternion Out(ArithArray x)
        {
            return new Quaternion(x);
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

        public static Quaternion operator +(Quaternion lhs, Quaternion rhs) { return Out(In(lhs) + In(rhs)); }

        public static Quaternion operator +(Quaternion lhs, float rhs) { return Out(In(lhs) + rhs); }

        public static Quaternion operator +(float lhs, Quaternion rhs) { return Out(lhs + In(rhs)); }

        public static Quaternion operator -(Quaternion lhs, Quaternion rhs) { return Out(In(lhs) - In(rhs)); }

        public static Quaternion operator -(Quaternion lhs, float rhs) { return Out(In(lhs) - rhs); }

        public static Quaternion operator -(float lhs, Quaternion rhs) { return Out(lhs - In(rhs)); }

        public static Quaternion operator *(Quaternion lhs, Quaternion rhs) { return Out(In(lhs) * In(rhs)); }

        public static Quaternion operator *(Quaternion lhs, float rhs) { return Out(In(lhs) * rhs); }

        public static Quaternion operator *(float lhs, Quaternion rhs) { return Out(lhs * In(rhs)); }

        public static Quaternion operator /(Quaternion lhs, Quaternion rhs) { return Out(In(lhs) / In(rhs)); }

        public static Quaternion operator /(Quaternion lhs, float rhs) { return lhs / rhs; }

        public static Quaternion operator /(float lhs, Quaternion rhs) { return lhs / rhs; }

        public static Quaternion operator >(Quaternion lhs, Quaternion rhs) { return lhs > rhs; }

        public static Quaternion operator >(Quaternion lhs, float rhs) { return lhs > rhs; }

        public static Quaternion operator <(Quaternion lhs, Quaternion rhs) { return lhs < rhs; }

        public static Quaternion operator <(Quaternion lhs, float rhs) { return lhs < rhs; }

        public static Quaternion operator >=(Quaternion lhs, Quaternion rhs) { return lhs >= rhs; }

        public static Quaternion operator >=(Quaternion lhs, float rhs) { return lhs >= rhs; }

        public static Quaternion operator <=(Quaternion lhs, Quaternion rhs) { return lhs <= rhs; }

        public static Quaternion operator <=(Quaternion lhs, float rhs) { return lhs <= rhs; }
    }
}
