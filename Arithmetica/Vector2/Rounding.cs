using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector2 Floor(Vector2 src) => Vector2.Out(ArrayOps.Floor(src.variable));
        
        public static Vector2 Round(Vector2 src) => Vector2.Out(ArrayOps.Round(src.variable));

        public static Vector2 Trunc(Vector2 src) => Vector2.Out(ArrayOps.Trunc(src.variable));

        public static Vector2 Ceil(Vector2 src) => Vector2.Out(ArrayOps.Ceil(src.variable));

        public static Vector2 Clip(Vector2 src, float min, float max) => Vector2.Out(ArrayOps.Clip(src.variable, min, max));

        public static Vector2 Frac(Vector2 src) => Vector2.Out(ArrayOps.Frac(src.variable));

        public static Vector2 Std(Vector2 src) => Vector2.Out(ArrayOps.Std(src.variable));

        public static Vector2 Std(Vector2 src, bool normbyN, int dimension) => Vector2.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
