using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector4 Sum(Vector4 src) => Vector4.Out(ArrayOps.Sum(src.variable));

        public static Vector4 Sum(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Sum(src.variable, dimension));

        public static Vector4 Prod(Vector4 src) => Vector4.Out(ArrayOps.Prod(src.variable));

        public static Vector4 Prod(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Prod(src.variable, dimension));

        public static Vector4 Mean(Vector4 src) => Vector4.Out(ArrayOps.Mean(src.variable));

        public static Vector4 Mean(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Mean(src.variable, dimension));

        public static Vector4 Max(Vector4 src) => Vector4.Out(ArrayOps.Max(src.variable));

        public static Vector4 Max(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Max(src.variable, dimension));

        public static Vector4 Min(Vector4 src) => Vector4.Out(ArrayOps.Min(src.variable));

        public static Vector4 Min(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Min(src.variable, dimension));

        public static Vector4 Norm(Vector4 src, float value) => Vector4.Out(ArrayOps.Norm(src.variable, value));

        public static Vector4 Norm(Vector4 src, float value, int dimension) => Vector4.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Vector4 Var(Vector4 src) => Vector4.Out(ArrayOps.Var(src.variable));

        public static Vector4 Var(Vector4 src, bool normByN, int dimension) => Vector4.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Vector4 Argmin(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Vector4 Argmax(Vector4 src, int dimension) => Vector4.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
