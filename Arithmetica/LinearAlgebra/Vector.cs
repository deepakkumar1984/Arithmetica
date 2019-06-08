using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SuperchargedArray;

namespace Arithmetica.LinearAlgebra
{
    public partial class Vector<T> : IFormattable
    {
        public long Size => variable.Shape[0];

        internal SuperArray variable = null;

        public Vector(int size)
        {
            variable = new SuperArray(size, 1);
        }

        internal Vector(int size, int dim_length, DType dtype)
        {
            variable = new SuperArray(new long[] { size, dim_length }, dtype);
        }

        public Vector(SuperArray arithArray)
        {
            variable = arithArray;
        }

        public void CopyTo(Vector<T> vector)
        {
            Helper.Copy(vector.variable, variable);
        }

        public static Vector<T> LoadArray(params T[] data)
        {
            Vector<T> vector = new Vector<T>(data.Length, 1, DTypeBuilder.FromCLRType(typeof(T)));
            vector.variable.LoadFrom(data);
            return vector;
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

        public static Vector<T> Out(SuperArray arithArray)
        {
            return new Vector<T>(arithArray);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Vector: " + Size;
        }

        public static SuperArray operator +(Vector<T> lhs, Vector<T> rhs) { return lhs.variable + rhs.variable; }

        public static SuperArray operator +(Vector<T> lhs, float rhs) { return lhs.variable + rhs; }

        public static SuperArray operator +(float lhs, Vector<T> rhs) { return lhs + rhs.variable; }

        public static SuperArray operator -(Vector<T> lhs, Vector<T> rhs) { return lhs.variable - rhs.variable; }

        public static SuperArray operator -(Vector<T> lhs, float rhs) { return lhs.variable - rhs; }

        public static SuperArray operator -(float lhs, Vector<T> rhs) { return lhs - rhs.variable; }

        public static SuperArray operator *(Vector<T> lhs, Vector<T> rhs) { return lhs.variable * rhs.variable; }

        public static SuperArray operator *(Vector<T> lhs, float rhs) { return lhs.variable * rhs; }

        public static SuperArray operator *(float lhs, Vector<T> rhs) { return lhs * rhs.variable; }

        public static SuperArray operator /(Vector<T> lhs, Vector<T> rhs) { return lhs.variable / rhs.variable; }

        public static SuperArray operator /(Vector<T> lhs, float rhs) { return lhs / rhs; }

        public static SuperArray operator /(float lhs, Vector<T> rhs) { return lhs / rhs; }

        public static SuperArray operator >(Vector<T> lhs, Vector<T> rhs) { return lhs > rhs; }

        public static SuperArray operator >(Vector<T> lhs, float rhs) { return lhs > rhs; }

        public static SuperArray operator <(Vector<T> lhs, Vector<T> rhs) { return lhs < rhs; }

        public static SuperArray operator <(Vector<T> lhs, float rhs) { return lhs < rhs; }

        public static SuperArray operator >=(Vector<T> lhs, Vector<T> rhs) { return lhs >= rhs; }

        public static SuperArray operator >=(Vector<T> lhs, float rhs) { return lhs >= rhs; }

        public static SuperArray operator <=(Vector<T> lhs, Vector<T> rhs) { return lhs <= rhs; }

        public static SuperArray operator <=(Vector<T> lhs, float rhs) { return lhs <= rhs; }

        public static implicit operator Vector<T>(SuperArray variable)
        {
            return new Vector<T>(variable);
        }
    }
}
