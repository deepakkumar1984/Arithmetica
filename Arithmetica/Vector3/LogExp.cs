using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 Exp(Vector3 src) => Vector3.Out(ArrayOps.Exp(src.variable));

        public static Vector3 Log(Vector3 src) => Vector3.Out(ArrayOps.Log(src.variable));

        public static Vector3 Log1p(Vector3 src) => Vector3.Out(ArrayOps.Log1p(src.variable));

    }
}
