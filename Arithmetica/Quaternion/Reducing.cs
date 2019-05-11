using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion Sum(Quaternion src) => Quaternion.Out(ArrayOps.Sum(src.variable));

        public static Quaternion Sum(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Sum(src.variable, dimension));

        public static Quaternion Prod(Quaternion src) => Quaternion.Out(ArrayOps.Prod(src.variable));

        public static Quaternion Prod(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Prod(src.variable, dimension));

        public static Quaternion Mean(Quaternion src) => Quaternion.Out(ArrayOps.Mean(src.variable));

        public static Quaternion Mean(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Mean(src.variable, dimension));

        public static Quaternion Max(Quaternion src) => Quaternion.Out(ArrayOps.Max(src.variable));

        public static Quaternion Max(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Max(src.variable, dimension));

        public static Quaternion Min(Quaternion src) => Quaternion.Out(ArrayOps.Min(src.variable));

        public static Quaternion Min(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Min(src.variable, dimension));

        public static Quaternion Norm(Quaternion src, float value) => Quaternion.Out(ArrayOps.Norm(src.variable, value));

        public static Quaternion Norm(Quaternion src, float value, int dimension) => Quaternion.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Quaternion Var(Quaternion src) => Quaternion.Out(ArrayOps.Var(src.variable));

        public static Quaternion Var(Quaternion src, bool normByN, int dimension) => Quaternion.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Quaternion Argmin(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Quaternion Argmax(Quaternion src, int dimension) => Quaternion.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
