using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray Exp(ArithArray src) => ArrayOps.Exp(src);

        public static ArithArray Log(ArithArray src) => ArrayOps.Log(src);

        public static ArithArray Log1p(ArithArray src) => ArrayOps.Log1p(src);

    }
}
