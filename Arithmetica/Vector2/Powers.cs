using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector2 Pow(Vector2 src, float value) => Vector2.Out(ArrayOps.Pow(src.variable, value));

        public static Vector2 Tpow(float value, Vector2 src) => Vector2.Out(ArrayOps.Tpow(value, src.variable));

        public static Vector2 Sqrt(Vector2 src) => Vector2.Out(ArrayOps.Sqrt(src.variable));

        public static Vector2 Square(Vector2 src) => Vector2.Out(ArrayOps.Square(src.variable));

    }
}
