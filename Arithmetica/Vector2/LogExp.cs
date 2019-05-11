using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector2 Exp(Vector2 src) => Vector2.Out(ArrayOps.Exp(src.variable));

        public static Vector2 Log(Vector2 src) => Vector2.Out(ArrayOps.Log(src.variable));

        public static Vector2 Log1p(Vector2 src) => Vector2.Out(ArrayOps.Log1p(src.variable));

    }
}
