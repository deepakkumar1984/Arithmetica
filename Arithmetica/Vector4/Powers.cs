using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector4 Pow(Vector4 src, float value) => Vector4.Out(ArrayOps.Pow(src.variable, value));

        public static Vector4 Tpow(float value, Vector4 src) => Vector4.Out(ArrayOps.Tpow(value, src.variable));

        public static Vector4 Sqrt(Vector4 src) => Vector4.Out(ArrayOps.Sqrt(src.variable));

        public static Vector4 Square(Vector4 src) => Vector4.Out(ArrayOps.Square(src.variable));

    }
}
