using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static Matrix GreaterThan(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.GreaterThan(lhs.variable, rhs.variable));

        public static Matrix GreaterThan(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.GreaterThan(lhs.variable, rhs));

        public static Matrix GreaterEqual(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs.variable));

        public static Matrix GreaterEqual(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.GreaterOrEqual(lhs.variable, rhs));

        public static Matrix LessThan(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.LessThan(lhs.variable, rhs.variable));

        public static Matrix LessThan(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.LessThan(lhs.variable, rhs));

        public static Matrix LessEqual(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.LessOrEqual(lhs.variable, rhs.variable));

        public static Matrix LessEqual(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Matrix EqualTo(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.EqualTo(lhs.variable, rhs.variable));

        public static Matrix EqualTo(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.LessOrEqual(lhs.variable, rhs));

        public static Matrix NotEqualTo(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.NotEqual(lhs.variable, rhs.variable));

        public static Matrix NotEqualTo(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.NotEqual(lhs.variable, rhs));

        public static Matrix Maximum(Matrix lhs, Matrix rhs) => Matrix.Out(ArrayOps.Maximum(lhs.variable, rhs.variable));

        public static Matrix Maximum(Matrix lhs, float rhs) => Matrix.Out(ArrayOps.Maximum(lhs.variable, rhs));

    }
}
