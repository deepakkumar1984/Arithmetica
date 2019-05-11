using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion Exp(Quaternion src) => Quaternion.Out(ArrayOps.Exp(src.variable));

        public static Quaternion Log(Quaternion src) => Quaternion.Out(ArrayOps.Log(src.variable));

        public static Quaternion Log1p(Quaternion src) => Quaternion.Out(ArrayOps.Log1p(src.variable));

    }
}
