using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector2 GreaterThan(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Vector2 GreaterThan(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Vector2 GreaterEqual(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Vector2 GreaterEqual(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Vector2 LessThan(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Vector2 LessThan(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Vector2 LessEqual(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Vector2 LessEqual(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector2 EqualTo(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Vector2 EqualTo(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector2 NotEqualTo(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Vector2 NotEqualTo(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Vector2 Maximum(Vector2 lhs, Vector2 rhs) => Vector2.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Vector2 Maximum(Vector2 lhs, float rhs) => Vector2.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
