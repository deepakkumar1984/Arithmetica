using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Matrix
    {
        public static Matrix Pow(Matrix src, float value) => Matrix.Out(ArrayOps.Pow(src.variable, value));

        public static Matrix Tpow(float value, Matrix src) => Matrix.Out(ArrayOps.Tpow(value, src.variable));

        public static Matrix Sqrt(Matrix src) => Matrix.Out(ArrayOps.Sqrt(src.variable));

        public static Matrix Square(Matrix src) => Matrix.Out(ArrayOps.Square(src.variable));

    }
}
