using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray Pow(ArithArray src, float value) => ArrayOps.Pow(src, value);

        public static ArithArray Tpow(float value, ArithArray src) => ArrayOps.Tpow(value, src);

        public static ArithArray Sqrt(ArithArray src) => ArrayOps.Sqrt(src);

        public static ArithArray Square(ArithArray src) => ArrayOps.Square(src);

    }
}
