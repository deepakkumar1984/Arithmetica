using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray Floor(ArithArray src) => ArrayOps.Floor(src);
        
        public static ArithArray Round(ArithArray src) => ArrayOps.Round(src);

        public static ArithArray Trunc(ArithArray src) => ArrayOps.Trunc(src);

        public static ArithArray Ceil(ArithArray src) => ArrayOps.Ceil(src);

        public static ArithArray Clip(ArithArray src, float min, float max) => ArrayOps.Clip(src, min, max);

        public static ArithArray Frac(ArithArray src) => ArrayOps.Frac(src);

        public static ArithArray Std(ArithArray src) => ArrayOps.Std(src);

        public static ArithArray Std(ArithArray src, bool normbyN, int dimension) => ArrayOps.Std(src, dimension, normbyN);

    }
}
