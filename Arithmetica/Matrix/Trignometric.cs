using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Matrix
    {
        public static Matrix Sin(Matrix src) => Matrix.Out(ArrayOps.Sin(src.variable));
        
        public static Matrix Cos(Matrix src) => Matrix.Out(ArrayOps.Cos(src.variable));

        public static Matrix Tan(Matrix src) => Matrix.Out(ArrayOps.Tan(src.variable));

        public static Matrix Asin(Matrix src) => Matrix.Out(ArrayOps.Asin(src.variable));
       
        public static Matrix Acos(Matrix src) => Matrix.Out(ArrayOps.Acos(src.variable));
        
        public static Matrix Atan(Matrix src) => Matrix.Out(ArrayOps.Atan(src.variable));

        public static Matrix Atan2(Matrix srcY, Matrix srcX) => Matrix.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Matrix Sinh(Matrix src) => Matrix.Out(ArrayOps.Sinh(src.variable));
        
        public static Matrix Cosh(Matrix src) => Matrix.Out(ArrayOps.Cosh(src.variable));
      
        public static Matrix Tanh(Matrix src) => Matrix.Out(ArrayOps.Tanh(src.variable));


    }
}
