using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NumSharp;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T> : IFormattable
    {
        public long Size => variable.Shape[0];

        internal NDArray variable = null;

        public Vector(int size)
        {
            variable = new NDArray(size, 1);
        }

        internal Vector(int size, int dim_length, DType dtype)
        {
            variable = new NDArray(new long[] { size, dim_length }, dtype);
        }

        public Vector(NDArray arithArray)
        {
            variable = arithArray;
        }

        public void CopyTo(Vector<T> vector)
        {
            Helper.Copy(vector.variable, variable);
        }

        public static NDArray LoadArray(params T[] data)
        {
            NDArray arithArray = new NDArray(data.Length, 1);
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

        public static Vector<T> Out(NDArray arithArray)
        {
            return new Vector<T>(arithArray);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Vector: " + Size;
        }

        public static NDArray operator +(Vector<T> lhs, Vector<T> rhs) { return lhs.variable + rhs.variable; }

        public static NDArray operator +(Vector<T> lhs, float rhs) { return lhs.variable + rhs; }

        public static NDArray operator +(float lhs, Vector<T> rhs) { return lhs + rhs.variable; }

        public static NDArray operator -(Vector<T> lhs, Vector<T> rhs) { return lhs.variable - rhs.variable; }

        public static NDArray operator -(Vector<T> lhs, float rhs) { return lhs.variable - rhs; }

        public static NDArray operator -(float lhs, Vector<T> rhs) { return lhs - rhs.variable; }

        public static NDArray operator *(Vector<T> lhs, Vector<T> rhs) { return lhs.variable * rhs.variable; }

        public static NDArray operator *(Vector<T> lhs, float rhs) { return lhs.variable * rhs; }

        public static NDArray operator *(float lhs, Vector<T> rhs) { return lhs * rhs.variable; }

        public static NDArray operator /(Vector<T> lhs, Vector<T> rhs) { return lhs.variable / rhs.variable; }

        public static NDArray operator /(Vector<T> lhs, float rhs) { return lhs / rhs; }

        public static NDArray operator /(float lhs, Vector<T> rhs) { return lhs / rhs; }

        public static NDArray operator >(Vector<T> lhs, Vector<T> rhs) { return lhs > rhs; }

        public static NDArray operator >(Vector<T> lhs, float rhs) { return lhs > rhs; }

        public static NDArray operator <(Vector<T> lhs, Vector<T> rhs) { return lhs < rhs; }

        public static NDArray operator <(Vector<T> lhs, float rhs) { return lhs < rhs; }

        public static NDArray operator >=(Vector<T> lhs, Vector<T> rhs) { return lhs >= rhs; }

        public static NDArray operator >=(Vector<T> lhs, float rhs) { return lhs >= rhs; }

        public static NDArray operator <=(Vector<T> lhs, Vector<T> rhs) { return lhs <= rhs; }

        public static NDArray operator <=(Vector<T> lhs, float rhs) { return lhs <= rhs; }

        public static implicit operator Vector<T>(NDArray variable)
        {
            return new Vector<T>(variable);
        }
    }
}
