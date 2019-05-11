using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion Pow(Quaternion src, float value) => Quaternion.Out(ArrayOps.Pow(src.variable, value));

        public static Quaternion Tpow(float value, Quaternion src) => Quaternion.Out(ArrayOps.Tpow(value, src.variable));

        public static Quaternion Sqrt(Quaternion src) => Quaternion.Out(ArrayOps.Sqrt(src.variable));

        public static Quaternion Square(Quaternion src) => Quaternion.Out(ArrayOps.Square(src.variable));

    }
}
