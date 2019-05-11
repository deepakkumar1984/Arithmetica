using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector4 Exp(Vector4 src) => Vector4.Out(ArrayOps.Exp(src.variable));

        public static Vector4 Log(Vector4 src) => Vector4.Out(ArrayOps.Log(src.variable));

        public static Vector4 Log1p(Vector4 src) => Vector4.Out(ArrayOps.Log1p(src.variable));

    }
}
