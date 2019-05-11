using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane GreaterThan(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Plane GreaterThan(Plane lhs, float rhs) => Plane.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Plane GreaterEqual(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Plane GreaterEqual(Plane lhs, float rhs) => Plane.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Plane LessThan(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Plane LessThan(Plane lhs, float rhs) => Plane.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Plane LessEqual(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Plane LessEqual(Plane lhs, float rhs) => Plane.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Plane EqualTo(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Plane EqualTo(Plane lhs, float rhs) => Plane.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Plane NotEqualTo(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Plane NotEqualTo(Plane lhs, float rhs) => Plane.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Plane Maximum(Plane lhs, Plane rhs) => Plane.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Plane Maximum(Plane lhs, float rhs) => Plane.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
