using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static Matrix Dot(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Dot(lhs.variable, rhs.variable));

        public static Matrix Addmm(float beta, Matrix src, float alpha, Matrix m1, Matrix m2)
            => Matrix.Out(ArrayOps.Addmm(beta, src.variable, alpha, m1.variable, m2.variable));

        public static Matrix Add(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Add(lhs.variable, rhs.variable));

        public static Matrix Add(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Add(lhs.variable, rhs));

        public static Matrix Add(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Add(rhs.variable, lhs));

        public static Matrix Sub(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Sub(lhs.variable, rhs.variable));

        public static Matrix Sub(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Sub(lhs.variable, rhs));

        public static Matrix Sub(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Sub(lhs, rhs.variable));

        public static Matrix Mul(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Mul(lhs.variable, rhs.variable));

        public static Matrix Mul(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Mul(lhs.variable, rhs));

        public static Matrix Mul(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Mul(rhs.variable, lhs));

        public static Matrix Div(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Div(lhs.variable, rhs.variable));

        public static Matrix Div(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Div(lhs.variable, rhs));

        public static Matrix Div(float lhs, Matrix rhs) => Matrix.Out(ArrayOps.Div(lhs, rhs.variable));

        public static Matrix Mod(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Mod(lhs.variable, rhs));

        public static Matrix Neg(Matrix src) => Matrix.Out(ArrayOps.Neg(src.variable));

        public static Matrix Abs(Matrix src) => Matrix.Out(ArrayOps.Abs(src.variable));

        public static Matrix Sign(Matrix src) => Matrix.Out(ArrayOps.Sign(src.variable));

        public static Matrix Lerp(Matrix a, Matrix b, float weight) => Matrix.Out(ArrayOps.Lerp(a.variable, b.variable, weight));
    }
}
