using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector4 GreaterThan(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Vector4 GreaterThan(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Vector4 GreaterEqual(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Vector4 GreaterEqual(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Vector4 LessThan(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Vector4 LessThan(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Vector4 LessEqual(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Vector4 LessEqual(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector4 EqualTo(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Vector4 EqualTo(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector4 NotEqualTo(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Vector4 NotEqualTo(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Vector4 Maximum(Vector4 lhs, Vector4 rhs) => Vector4.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Vector4 Maximum(Vector4 lhs, float rhs) => Vector4.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
