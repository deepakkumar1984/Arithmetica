using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        public static Vector GreaterThan(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Vector GreaterThan(Vector lhs, float rhs) => Vector.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Vector GreaterEqual(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Vector GreaterEqual(Vector lhs, float rhs) => Vector.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Vector LessThan(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Vector LessThan(Vector lhs, float rhs) => Vector.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Vector LessEqual(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Vector LessEqual(Vector lhs, float rhs) => Vector.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector EqualTo(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Vector EqualTo(Vector lhs, float rhs) => Vector.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector NotEqualTo(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Vector NotEqualTo(Vector lhs, float rhs) => Vector.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Vector Maximum(Vector lhs, Vector rhs) => Vector.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Vector Maximum(Vector lhs, float rhs) => Vector.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
