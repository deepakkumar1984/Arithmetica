using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector2 Sum(Vector2 src) => Vector2.Out(ArrayOps.Sum(src.variable));

        public static Vector2 Sum(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Sum(src.variable, dimension));

        public static Vector2 Prod(Vector2 src) => Vector2.Out(ArrayOps.Prod(src.variable));

        public static Vector2 Prod(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Prod(src.variable, dimension));

        public static Vector2 Mean(Vector2 src) => Vector2.Out(ArrayOps.Mean(src.variable));

        public static Vector2 Mean(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Mean(src.variable, dimension));

        public static Vector2 Max(Vector2 src) => Vector2.Out(ArrayOps.Max(src.variable));

        public static Vector2 Max(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Max(src.variable, dimension));

        public static Vector2 Min(Vector2 src) => Vector2.Out(ArrayOps.Min(src.variable));

        public static Vector2 Min(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Min(src.variable, dimension));

        public static Vector2 Norm(Vector2 src, float value) => Vector2.Out(ArrayOps.Norm(src.variable, value));

        public static Vector2 Norm(Vector2 src, float value, int dimension) => Vector2.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Vector2 Var(Vector2 src) => Vector2.Out(ArrayOps.Var(src.variable));

        public static Vector2 Var(Vector2 src, bool normByN, int dimension) => Vector2.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Vector2 Argmin(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Vector2 Argmax(Vector2 src, int dimension) => Vector2.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
