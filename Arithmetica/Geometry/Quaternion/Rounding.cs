using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion Floor(Quaternion src) => Quaternion.Out(ArrayOps.Floor(src.variable));
        
        public static Quaternion Round(Quaternion src) => Quaternion.Out(ArrayOps.Round(src.variable));

        public static Quaternion Trunc(Quaternion src) => Quaternion.Out(ArrayOps.Trunc(src.variable));

        public static Quaternion Ceil(Quaternion src) => Quaternion.Out(ArrayOps.Ceil(src.variable));

        public static Quaternion Clip(Quaternion src, float min, float max) => Quaternion.Out(ArrayOps.Clip(src.variable, min, max));

        public static Quaternion Frac(Quaternion src) => Quaternion.Out(ArrayOps.Frac(src.variable));

        public static Quaternion Std(Quaternion src) => Quaternion.Out(ArrayOps.Std(src.variable));

        public static Quaternion Std(Quaternion src, bool normbyN, int dimension) => Quaternion.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
