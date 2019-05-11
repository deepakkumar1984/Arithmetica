using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion Dot(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        public static Quaternion Addmm(float beta, Quaternion src, float alpha, Quaternion m1, Quaternion m2)
            => Quaternion.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        public static Quaternion Add(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Quaternion Add(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Quaternion Add(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Quaternion Sub(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Quaternion Sub(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Quaternion Sub(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Quaternion Mul(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Quaternion Mul(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Quaternion Mul(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Quaternion Div(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Quaternion Div(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Quaternion Div(float lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Quaternion Mod(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Quaternion Neg(Quaternion src) => Quaternion.Out(ArrayOps.Neg(src.variable));

        public static Quaternion Abs(Quaternion src) => Quaternion.Out(ArrayOps.Abs(src.variable));

        public static Quaternion Sign(Quaternion src) => Quaternion.Out(ArrayOps.Sign(src.variable));

        public static Quaternion Lerp(Quaternion a, Quaternion b, float weight) => Quaternion.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
