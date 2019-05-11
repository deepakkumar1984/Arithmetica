using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Matrix
    {
        public static Matrix Exp(Matrix src) => Matrix.Out(ArrayOps.Exp(src.variable));

        public static Matrix Log(Matrix src) => Matrix.Out(ArrayOps.Log(src.variable));

        public static Matrix Log1p(Matrix src) => Matrix.Out(ArrayOps.Log1p(src.variable));

    }
}
