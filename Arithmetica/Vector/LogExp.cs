using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static Vector Exp(Vector src) => Vector.Out(ArrayOps.Exp(src.variable));

        public static Vector Log(Vector src) => Vector.Out(ArrayOps.Log(src.variable));

        public static Vector Log1p(Vector src) => Vector.Out(ArrayOps.Log1p(src.variable));

    }
}
