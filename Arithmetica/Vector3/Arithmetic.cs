using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 Dot(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        public static Vector3 Addmm(float beta, Vector3 src, float alpha, Vector3 m1, Vector3 m2)
            => Vector3.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        public static Vector3 Add(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Vector3 Add(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Vector3 Add(float lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Vector3 Sub(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Vector3 Sub(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Vector3 Sub(float lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Vector3 Mul(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Vector3 Mul(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Vector3 Mul(float lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Vector3 Div(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Vector3 Div(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Vector3 Div(float lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Vector3 Mod(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Vector3 Neg(Vector3 src) => Vector3.Out(ArrayOps.Neg(src.variable));

        public static Vector3 Abs(Vector3 src) => Vector3.Out(ArrayOps.Abs(src.variable));

        public static Vector3 Sign(Vector3 src) => Vector3.Out(ArrayOps.Sign(src.variable));

        public static Vector3 Lerp(Vector3 a, Vector3 b, float weight) => Vector3.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
