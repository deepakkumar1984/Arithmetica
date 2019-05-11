using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion GreaterThan(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Quaternion GreaterThan(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Quaternion GreaterEqual(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Quaternion GreaterEqual(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Quaternion LessThan(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Quaternion LessThan(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Quaternion LessEqual(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Quaternion LessEqual(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Quaternion EqualTo(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Quaternion EqualTo(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Quaternion NotEqualTo(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Quaternion NotEqualTo(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Quaternion Maximum(Quaternion lhs, Quaternion rhs) => Quaternion.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Quaternion Maximum(Quaternion lhs, float rhs) => Quaternion.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
