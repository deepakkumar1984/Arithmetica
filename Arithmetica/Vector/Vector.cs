using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public class Vector
    {
        internal ArithArray variable;

        public long Size
        {
            get
            {
                return variable.ElementCount();
            }
        }

        public Vector(ArithArray v)
        {
            variable = v;
        }

        public Vector(long size, bool arrangeByRow = false)
        {
            if(arrangeByRow)
                variable = new ArithArray(size, 1);
            else
                variable = new ArithArray(1, size);
        }

        public Vector(long size, DType dataType, bool arrangeByRow = false)
        {
            if (arrangeByRow)
                variable = new ArithArray(new long[] { size, 1 }, dataType);
            else
                variable = new ArithArray(new long[] { 1, size }, dataType);
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
