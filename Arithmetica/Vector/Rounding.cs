using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector
    {
        public static Vector Floor(Vector src) => Vector.Out(ArrayOps.Floor(src.variable));
        
        public static Vector Round(Vector src) => Vector.Out(ArrayOps.Round(src.variable));

        public static Vector Trunc(Vector src) => Vector.Out(ArrayOps.Trunc(src.variable));

        public static Vector Ceil(Vector src) => Vector.Out(ArrayOps.Ceil(src.variable));

        public static Vector Clip(Vector src, float min, float max) => Vector.Out(ArrayOps.Clip(src.variable, min, max));

        public static Vector Frac(Vector src) => Vector.Out(ArrayOps.Frac(src.variable));

        public static Vector Std(Vector src) => Vector.Out(ArrayOps.Std(src.variable));

        public static Vector Std(Vector src, bool normbyN, int dimension) => Vector.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
