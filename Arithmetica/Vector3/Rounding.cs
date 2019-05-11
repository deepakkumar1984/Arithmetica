using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 Floor(Vector3 src) => Vector3.Out(ArrayOps.Floor(src.variable));
        
        public static Vector3 Round(Vector3 src) => Vector3.Out(ArrayOps.Round(src.variable));

        public static Vector3 Trunc(Vector3 src) => Vector3.Out(ArrayOps.Trunc(src.variable));

        public static Vector3 Ceil(Vector3 src) => Vector3.Out(ArrayOps.Ceil(src.variable));

        public static Vector3 Clip(Vector3 src, float min, float max) => Vector3.Out(ArrayOps.Clip(src.variable, min, max));

        public static Vector3 Frac(Vector3 src) => Vector3.Out(ArrayOps.Frac(src.variable));

        public static Vector3 Std(Vector3 src) => Vector3.Out(ArrayOps.Std(src.variable));

        public static Vector3 Std(Vector3 src, bool normbyN, int dimension) => Vector3.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
