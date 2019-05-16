using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane Floor(Plane src) => Plane.Out(ArrayOps.Floor(src.variable));
        
        public static Plane Round(Plane src) => Plane.Out(ArrayOps.Round(src.variable));

        public static Plane Trunc(Plane src) => Plane.Out(ArrayOps.Trunc(src.variable));

        public static Plane Ceil(Plane src) => Plane.Out(ArrayOps.Ceil(src.variable));

        public static Plane Clip(Plane src, float min, float max) => Plane.Out(ArrayOps.Clip(src.variable, min, max));

        public static Plane Frac(Plane src) => Plane.Out(ArrayOps.Frac(src.variable));

        public static Plane Std(Plane src) => Plane.Out(ArrayOps.Std(src.variable));

        public static Plane Std(Plane src, bool normbyN, int dimension) => Plane.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
