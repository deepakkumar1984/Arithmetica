using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector4 Floor(Vector4 src) => Vector4.Out(ArrayOps.Floor(src.variable));
        
        public static Vector4 Round(Vector4 src) => Vector4.Out(ArrayOps.Round(src.variable));

        public static Vector4 Trunc(Vector4 src) => Vector4.Out(ArrayOps.Trunc(src.variable));

        public static Vector4 Ceil(Vector4 src) => Vector4.Out(ArrayOps.Ceil(src.variable));

        public static Vector4 Clip(Vector4 src, float min, float max) => Vector4.Out(ArrayOps.Clip(src.variable, min, max));

        public static Vector4 Frac(Vector4 src) => Vector4.Out(ArrayOps.Frac(src.variable));

        public static Vector4 Std(Vector4 src) => Vector4.Out(ArrayOps.Std(src.variable));

        public static Vector4 Std(Vector4 src, bool normbyN, int dimension) => Vector4.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
