using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray Dot(ArithArray lhs, ArithArray rhs) => ArrayOps.Dot(lhs, rhs);

        public static ArithArray Addmm(float beta, ArithArray src, float alpha, ArithArray m1, ArithArray m2)
            => ArrayOps.Addmm(beta, src, alpha, m1, m2);

        public static ArithArray Add(ArithArray lhs, ArithArray rhs) => ArrayOps.Add(lhs, rhs);

        public static ArithArray Add(ArithArray lhs, float rhs) => ArrayOps.Add(lhs, rhs);

        public static ArithArray Add(float lhs, ArithArray rhs) => ArrayOps.Add(rhs, lhs);

        public static ArithArray Sub(ArithArray lhs, ArithArray rhs) => ArrayOps.Sub(lhs, rhs);

        public static ArithArray Sub(ArithArray lhs, float rhs) => ArrayOps.Sub(lhs, rhs);

        public static ArithArray Sub(float lhs, ArithArray rhs) => ArrayOps.Sub(lhs, rhs);

        public static ArithArray Mul(ArithArray lhs, ArithArray rhs) => ArrayOps.Mul(lhs, rhs);

        public static ArithArray Mul(ArithArray lhs, float rhs) => ArrayOps.Mul(lhs, rhs);

        public static ArithArray Mul(float lhs, ArithArray rhs) => ArrayOps.Mul(rhs, lhs);

        public static ArithArray Div(ArithArray lhs, ArithArray rhs) => ArrayOps.Div(lhs, rhs);

        public static ArithArray Div(ArithArray lhs, float rhs) => ArrayOps.Div(lhs, rhs);

        public static ArithArray Div(float lhs, ArithArray rhs) => ArrayOps.Div(lhs, rhs);

        public static ArithArray Mod(ArithArray lhs, float rhs) => ArrayOps.Mod(lhs, rhs);

        public static ArithArray Neg(ArithArray src) => ArrayOps.Neg(src);

        public static ArithArray Abs(ArithArray src) => ArrayOps.Abs(src);

        public static ArithArray Sign(ArithArray src) => ArrayOps.Sign(src);

        public static ArithArray Lerp(ArithArray a, ArithArray b, float weight) => ArrayOps.Lerp(a, b, weight);
    }
}
