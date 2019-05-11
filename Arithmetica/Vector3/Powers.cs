using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 Pow(Vector3 src, float value) => Vector3.Out(ArrayOps.Pow(src.variable, value));

        public static Vector3 Tpow(float value, Vector3 src) => Vector3.Out(ArrayOps.Tpow(value, src.variable));

        public static Vector3 Sqrt(Vector3 src) => Vector3.Out(ArrayOps.Sqrt(src.variable));

        public static Vector3 Square(Vector3 src) => Vector3.Out(ArrayOps.Square(src.variable));

    }
}
