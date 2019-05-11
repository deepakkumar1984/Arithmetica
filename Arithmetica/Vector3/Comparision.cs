using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 GreaterThan(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Vector3 GreaterThan(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Vector3 GreaterEqual(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Vector3 GreaterEqual(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Vector3 LessThan(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Vector3 LessThan(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Vector3 LessEqual(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Vector3 LessEqual(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector3 EqualTo(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Vector3 EqualTo(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Vector3 NotEqualTo(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Vector3 NotEqualTo(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Vector3 Maximum(Vector3 lhs, Vector3 rhs) => Vector3.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Vector3 Maximum(Vector3 lhs, float rhs) => Vector3.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
