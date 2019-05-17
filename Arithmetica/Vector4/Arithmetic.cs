using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector Dot(Vector4 lhs, Vector4 rhs) => Vector.Out(ArrayOps.Sum(ArrayOps.Mul(lhs.variable, rhs.variable), 1));

        public static Vector4 Add(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Vector4 Add(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Vector4 Add(float lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Vector4 Sub(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Vector4 Sub(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Vector4 Sub(float lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Vector4 Mul(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Vector4 Mul(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Vector4 Mul(float lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Vector4 Div(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Vector4 Div(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Vector4 Div(float lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Vector4 Mod(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Vector4 Neg(Vector4 src) => Vector4.Out(ArrayOps.Neg(src.variable));

        public static Vector4 Abs(Vector4 src) => Vector4.Out(ArrayOps.Abs(src.variable));

        public static Vector4 Sign(Vector4 src) => Vector4.Out(ArrayOps.Sign(src.variable));

        public static Vector4 Lerp(Vector4 a, Vector4 b, float weight) => Vector4.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
