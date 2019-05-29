using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T> : IFormattable
    {
        public long Size => variable.Shape[0];

        internal ArithArray variable = null;

        public Vector(int size)
        {
            variable = new ArithArray(size, 1);
        }

        internal Vector(int size, int dim_length, DType dtype)
        {
            variable = new ArithArray(new long[] { size, dim_length }, dtype);
        }

        public Vector(ArithArray arithArray)
        {
            variable = arithArray;
        }

        public void CopyTo(Vector<T> vector)
        {
            ArrayOps.Copy(vector.variable, variable);
        }

        public static ArithArray LoadArray(params T[] data)
        {
            ArithArray arithArray = new ArithArray(data.Length, 1);
            arithArray.LoadFrom(data);
            return arithArray;
        }

        public void Fill(float value)
        {
            variable.Fill(value);
        }

        public Array Array
        {
            get
            {
                return variable.ToArray();
            }
        }

        public void Print()
        {
            variable.Print();
        }

        public static Vector<T> Out(ArithArray arithArray)
        {
            return new Vector<T>(arithArray);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Vector: " + Size;
        }

        public static ArithArray operator +(Vector<T> lhs, Vector<T> rhs) { return lhs.variable + rhs.variable; }

        public static ArithArray operator +(Vector<T> lhs, float rhs) { return lhs.variable + rhs; }

        public static ArithArray operator +(float lhs, Vector<T> rhs) { return lhs + rhs.variable; }

        public static ArithArray operator -(Vector<T> lhs, Vector<T> rhs) { return lhs.variable - rhs.variable; }

        public static ArithArray operator -(Vector<T> lhs, float rhs) { return lhs.variable - rhs; }

        public static ArithArray operator -(float lhs, Vector<T> rhs) { return lhs - rhs.variable; }

        public static ArithArray operator *(Vector<T> lhs, Vector<T> rhs) { return lhs.variable * rhs.variable; }

        public static ArithArray operator *(Vector<T> lhs, float rhs) { return lhs.variable * rhs; }

        public static ArithArray operator *(float lhs, Vector<T> rhs) { return lhs * rhs.variable; }

        public static ArithArray operator /(Vector<T> lhs, Vector<T> rhs) { return lhs.variable / rhs.variable; }

        public static ArithArray operator /(Vector<T> lhs, float rhs) { return lhs / rhs; }

        public static ArithArray operator /(float lhs, Vector<T> rhs) { return lhs / rhs; }

        public static ArithArray operator >(Vector<T> lhs, Vector<T> rhs) { return lhs > rhs; }

        public static ArithArray operator >(Vector<T> lhs, float rhs) { return lhs > rhs; }

        public static ArithArray operator <(Vector<T> lhs, Vector<T> rhs) { return lhs < rhs; }

        public static ArithArray operator <(Vector<T> lhs, float rhs) { return lhs < rhs; }

        public static ArithArray operator >=(Vector<T> lhs, Vector<T> rhs) { return lhs >= rhs; }

        public static ArithArray operator >=(Vector<T> lhs, float rhs) { return lhs >= rhs; }

        public static ArithArray operator <=(Vector<T> lhs, Vector<T> rhs) { return lhs <= rhs; }

        public static ArithArray operator <=(Vector<T> lhs, float rhs) { return lhs <= rhs; }

        public static implicit operator Vector<T>(ArithArray variable)
        {
            return new Vector<T>(variable);
        }
    }
}
