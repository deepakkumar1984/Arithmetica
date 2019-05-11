using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        public static Vector Dot(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        public static Vector Addmm(float beta, Vector src, float alpha, Vector m1, Vector m2)
            => Vector.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        public static Vector Add(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Vector Add(Vector lhs, float rhs) => Vector.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Vector Add(float lhs, Vector rhs) => Vector.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Vector Sub(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Vector Sub(Vector lhs, float rhs) => Vector.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Vector Sub(float lhs, Vector rhs) => Vector.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Vector Mul(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Vector Mul(Vector lhs, float rhs) => Vector.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Vector Mul(float lhs, Vector rhs) => Vector.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Vector Div(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Vector Div(Vector lhs, float rhs) => Vector.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Vector Div(float lhs, Vector rhs) => Vector.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Vector Mod(Vector lhs, float rhs) => Vector.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Vector Neg(Vector src) => Vector.Out(ArrayOps.Neg(src.variable));

        public static Vector Abs(Vector src) => Vector.Out(ArrayOps.Abs(src.variable));

        public static Vector Sign(Vector src) => Vector.Out(ArrayOps.Sign(src.variable));

        public static Vector Lerp(Vector a, Vector b, float weight) => Vector.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
