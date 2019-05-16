using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane Sum(Plane src) => Plane.Out(ArrayOps.Sum(src.variable));

        public static Plane Sum(Plane src, int dimension) => Plane.Out(ArrayOps.Sum(src.variable, dimension));

        public static Plane Prod(Plane src) => Plane.Out(ArrayOps.Prod(src.variable));

        public static Plane Prod(Plane src, int dimension) => Plane.Out(ArrayOps.Prod(src.variable, dimension));

        public static Plane Mean(Plane src) => Plane.Out(ArrayOps.Mean(src.variable));

        public static Plane Mean(Plane src, int dimension) => Plane.Out(ArrayOps.Mean(src.variable, dimension));

        public static Plane Max(Plane src) => Plane.Out(ArrayOps.Max(src.variable));

        public static Plane Max(Plane src, int dimension) => Plane.Out(ArrayOps.Max(src.variable, dimension));

        public static Plane Min(Plane src) => Plane.Out(ArrayOps.Min(src.variable));

        public static Plane Min(Plane src, int dimension) => Plane.Out(ArrayOps.Min(src.variable, dimension));

        public static Plane Norm(Plane src, float value) => Plane.Out(ArrayOps.Norm(src.variable, value));

        public static Plane Norm(Plane src, float value, int dimension) => Plane.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Plane Var(Plane src) => Plane.Out(ArrayOps.Var(src.variable));

        public static Plane Var(Plane src, bool normByN, int dimension) => Plane.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Plane Argmin(Plane src, int dimension) => Plane.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Plane Argmax(Plane src, int dimension) => Plane.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
