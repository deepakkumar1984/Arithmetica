using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector Dot(Vector2 lhs, Vector2 rhs) => Vector.Out(ArrayOps.Sum(ArrayOps.Mul(lhs.variable, rhs.variable.Transpose()), 1));

        public static Vector2 Add(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Vector2 Add(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Vector2 Add(float lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Vector2 Sub(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Vector2 Sub(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Vector2 Sub(float lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Vector2 Mul(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Vector2 Mul(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Vector2 Mul(float lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Vector2 Div(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Vector2 Div(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Vector2 Div(float lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Vector2 Mod(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Vector2 Neg(Vector2 src) => Vector2.Out(ArrayOps.Neg(src.variable));

        public static Vector2 Abs(Vector2 src) => Vector2.Out(ArrayOps.Abs(src.variable));

        public static Vector2 Sign(Vector2 src) => Vector2.Out(ArrayOps.Sign(src.variable));

        public static Vector2 Lerp(Vector2 a, Vector2 b, float weight) => Vector2.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
