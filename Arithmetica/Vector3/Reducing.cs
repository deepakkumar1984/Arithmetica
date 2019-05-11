using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 Sum(Vector3 src) => Vector3.Out(ArrayOps.Sum(src.variable));

        public static Vector3 Sum(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Sum(src.variable, dimension));

        public static Vector3 Prod(Vector3 src) => Vector3.Out(ArrayOps.Prod(src.variable));

        public static Vector3 Prod(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Prod(src.variable, dimension));

        public static Vector3 Mean(Vector3 src) => Vector3.Out(ArrayOps.Mean(src.variable));

        public static Vector3 Mean(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Mean(src.variable, dimension));

        public static Vector3 Max(Vector3 src) => Vector3.Out(ArrayOps.Max(src.variable));

        public static Vector3 Max(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Max(src.variable, dimension));

        public static Vector3 Min(Vector3 src) => Vector3.Out(ArrayOps.Min(src.variable));

        public static Vector3 Min(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Min(src.variable, dimension));

        public static Vector3 Norm(Vector3 src, float value) => Vector3.Out(ArrayOps.Norm(src.variable, value));

        public static Vector3 Norm(Vector3 src, float value, int dimension) => Vector3.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Vector3 Var(Vector3 src) => Vector3.Out(ArrayOps.Var(src.variable));

        public static Vector3 Var(Vector3 src, bool normByN, int dimension) => Vector3.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Vector3 Argmin(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Vector3 Argmax(Vector3 src, int dimension) => Vector3.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
