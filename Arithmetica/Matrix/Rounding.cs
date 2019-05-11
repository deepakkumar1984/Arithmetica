using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static Matrix Floor(Matrix src) => Matrix.Out(ArrayOps.Floor(src.variable));
        
        public static Matrix Round(Matrix src) => Matrix.Out(ArrayOps.Round(src.variable));

        public static Matrix Trunc(Matrix src) => Matrix.Out(ArrayOps.Trunc(src.variable));

        public static Matrix Ceil(Matrix src) => Matrix.Out(ArrayOps.Ceil(src.variable));

        public static Matrix Clip(Matrix src, float min, float max) => Matrix.Out(ArrayOps.Clip(src.variable, min, max));

        public static Matrix Frac(Matrix src) => Matrix.Out(ArrayOps.Frac(src.variable));

        public static Matrix Std(Matrix src) => Matrix.Out(ArrayOps.Std(src.variable));

        public static Matrix Std(Matrix src, bool normbyN, int dimension) => Matrix.Out(ArrayOps.Std(src.variable, dimension, normbyN));

    }
}
