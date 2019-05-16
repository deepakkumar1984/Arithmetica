using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane Pow(Plane src, float value) => Plane.Out(ArrayOps.Pow(src.variable, value));

        public static Plane Tpow(float value, Plane src) => Plane.Out(ArrayOps.Tpow(value, src.variable));

        public static Plane Sqrt(Plane src) => Plane.Out(ArrayOps.Sqrt(src.variable));

        public static Plane Square(Plane src) => Plane.Out(ArrayOps.Square(src.variable));

    }
}
