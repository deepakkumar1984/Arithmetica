using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray GreaterThan(ArithArray lhs, ArithArray rhs) => ArrayOps.GreaterThan(lhs, rhs);

        public static ArithArray GreaterThan(ArithArray lhs, float rhs) => ArrayOps.GreaterThan(lhs, rhs);

        public static ArithArray GreaterEqual(ArithArray lhs, ArithArray rhs) => ArrayOps.GreaterOrEqual(lhs, rhs);

        public static ArithArray GreaterEqual(ArithArray lhs, float rhs) => ArrayOps.GreaterOrEqual(lhs, rhs);

        public static ArithArray LessThan(ArithArray lhs, ArithArray rhs) => ArrayOps.LessThan(lhs, rhs);

        public static ArithArray LessThan(ArithArray lhs, float rhs) => ArrayOps.LessThan(lhs, rhs);

        public static ArithArray LessEqual(ArithArray lhs, ArithArray rhs) => ArrayOps.LessOrEqual(lhs, rhs);

        public static ArithArray LessEqual(ArithArray lhs, float rhs) => ArrayOps.LessOrEqual(lhs, rhs);

        public static ArithArray EqualTo(ArithArray lhs, ArithArray rhs) => ArrayOps.EqualTo(lhs, rhs);

        public static ArithArray EqualTo(ArithArray lhs, float rhs) => ArrayOps.LessOrEqual(lhs, rhs);

        public static ArithArray NotEqualTo(ArithArray lhs, ArithArray rhs) => ArrayOps.NotEqual(lhs, rhs);

        public static ArithArray NotEqualTo(ArithArray lhs, float rhs) => ArrayOps.NotEqual(lhs, rhs);

        public static ArithArray Maximum(ArithArray lhs, ArithArray rhs) => ArrayOps.Maximum(lhs, rhs);

        public static ArithArray Maximum(ArithArray lhs, float rhs) => ArrayOps.Maximum(lhs, rhs);

    }
}
