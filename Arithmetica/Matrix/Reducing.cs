using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Matrix
    {
        public static Matrix Sum(Matrix src) => Matrix.Out(ArrayOps.Sum(src.variable));

        public static Matrix Sum(Matrix src, int dimension) => Matrix.Out(ArrayOps.Sum(src.variable, dimension));

        public static Matrix Prod(Matrix src) => Matrix.Out(ArrayOps.Prod(src.variable));

        public static Matrix Prod(Matrix src, int dimension) => Matrix.Out(ArrayOps.Prod(src.variable, dimension));

        public static Matrix Mean(Matrix src) => Matrix.Out(ArrayOps.Mean(src.variable));

        public static Matrix Mean(Matrix src, int dimension) => Matrix.Out(ArrayOps.Mean(src.variable, dimension));

        public static Matrix Max(Matrix src) => Matrix.Out(ArrayOps.Max(src.variable));

        public static Matrix Max(Matrix src, int dimension) => Matrix.Out(ArrayOps.Max(src.variable, dimension));

        public static Matrix Min(Matrix src) => Matrix.Out(ArrayOps.Min(src.variable));

        public static Matrix Min(Matrix src, int dimension) => Matrix.Out(ArrayOps.Min(src.variable, dimension));

        public static Matrix Norm(Matrix src, float value) => Matrix.Out(ArrayOps.Norm(src.variable, value));

        public static Matrix Norm(Matrix src, float value, int dimension) => Matrix.Out(ArrayOps.Norm(src.variable, dimension, value));

        public static Matrix Var(Matrix src) => Matrix.Out(ArrayOps.Var(src.variable));

        public static Matrix Var(Matrix src, bool normByN, int dimension) => Matrix.Out(ArrayOps.Var(src.variable, dimension, normByN));

        public static Matrix Argmin(Matrix src, int dimension) => Matrix.Out(ArrayOps.Argmin(src.variable, dimension));

        public static Matrix Argmax(Matrix src, int dimension) => Matrix.Out(ArrayOps.Argmax(src.variable, dimension));
    }
}
