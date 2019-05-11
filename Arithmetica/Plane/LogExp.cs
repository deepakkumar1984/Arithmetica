using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane Exp(Plane src) => Plane.Out(ArrayOps.Exp(src.variable));

        public static Plane Log(Plane src) => Plane.Out(ArrayOps.Log(src.variable));

        public static Plane Log1p(Plane src) => Plane.Out(ArrayOps.Log1p(src.variable));

    }
}
