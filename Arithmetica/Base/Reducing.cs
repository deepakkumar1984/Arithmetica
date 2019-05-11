using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray Sum(ArithArray src) => ArrayOps.Sum(src);

        public static ArithArray Sum(ArithArray src, int dimension) => ArrayOps.Sum(src, dimension);

        public static ArithArray Prod(ArithArray src) => ArrayOps.Prod(src);

        public static ArithArray Prod(ArithArray src, int dimension) => ArrayOps.Prod(src, dimension);

        public static ArithArray Mean(ArithArray src) => ArrayOps.Mean(src);

        public static ArithArray Mean(ArithArray src, int dimension) => ArrayOps.Mean(src, dimension);

        public static ArithArray Max(ArithArray src) => ArrayOps.Max(src);

        public static ArithArray Max(ArithArray src, int dimension) => ArrayOps.Max(src, dimension);

        public static ArithArray Min(ArithArray src) => ArrayOps.Min(src);

        public static ArithArray Min(ArithArray src, int dimension) => ArrayOps.Min(src, dimension);

        public static ArithArray Norm(ArithArray src, float value) => ArrayOps.Norm(src, value);

        public static ArithArray Norm(ArithArray src, float value, int dimension) => ArrayOps.Norm(src, dimension, value);

        public static ArithArray Var(ArithArray src) => ArrayOps.Var(src);

        public static ArithArray Var(ArithArray src, bool normByN, int dimension) => ArrayOps.Var(src, dimension, normByN);

        public static ArithArray Argmin(ArithArray src, int dimension) => ArrayOps.Argmin(src, dimension);

        public static ArithArray Argmax(ArithArray src, int dimension) => ArrayOps.Argmax(src, dimension);
    }
}
