using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static Vector Pow(Vector src, float value) => Vector.Out(ArrayOps.Pow(src.variable, value));

        public static Vector Tpow(float value, Vector src) => Vector.Out(ArrayOps.Tpow(value, src.variable));

        public static Vector Sqrt(Vector src) => Vector.Out(ArrayOps.Sqrt(src.variable));

        public static Vector Square(Vector src) => Vector.Out(ArrayOps.Square(src.variable));

    }
}
