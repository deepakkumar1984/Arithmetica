using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane Dot(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Dot(lhs.variable, rhs.variable.Transpose()));

        public static Plane Addmm(float beta, Plane src, float alpha, Plane m1, Plane m2)
            => Plane.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        public static Plane Add(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Plane Add(Plane lhs, float rhs) => Plane.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Plane Add(float lhs, Plane rhs) => Plane.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Plane Sub(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Plane Sub(Plane lhs, float rhs) => Plane.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Plane Sub(float lhs, Plane rhs) => Plane.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Plane Mul(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Plane Mul(Plane lhs, float rhs) => Plane.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Plane Mul(float lhs, Plane rhs) => Plane.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Plane Div(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Plane Div(Plane lhs, float rhs) => Plane.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Plane Div(float lhs, Plane rhs) => Plane.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Plane Mod(Plane lhs, float rhs) => Plane.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Plane Neg(Plane src) => Plane.Out(ArrayOps.Neg(src.variable));

        public static Plane Abs(Plane src) => Plane.Out(ArrayOps.Abs(src.variable));

        public static Plane Sign(Plane src) => Plane.Out(ArrayOps.Sign(src.variable));

        public static Plane Lerp(Plane a, Plane b, float weight) => Plane.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
