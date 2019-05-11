using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector4
    {
        public static Vector4 Sin(Vector4 src) => Vector4.Out(ArrayOps.Sin(src.variable));
        
        public static Vector4 Cos(Vector4 src) => Vector4.Out(ArrayOps.Cos(src.variable));

        public static Vector4 Tan(Vector4 src) => Vector4.Out(ArrayOps.Tan(src.variable));

        public static Vector4 Asin(Vector4 src) => Vector4.Out(ArrayOps.Asin(src.variable));
       
        public static Vector4 Acos(Vector4 src) => Vector4.Out(ArrayOps.Acos(src.variable));
        
        public static Vector4 Atan(Vector4 src) => Vector4.Out(ArrayOps.Atan(src.variable));

        public static Vector4 Atan2(Vector4 srcY, Vector4 srcX) => Vector4.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Vector4 Sinh(Vector4 src) => Vector4.Out(ArrayOps.Sinh(src.variable));
        
        public static Vector4 Cosh(Vector4 src) => Vector4.Out(ArrayOps.Cosh(src.variable));
      
        public static Vector4 Tanh(Vector4 src) => Vector4.Out(ArrayOps.Tanh(src.variable));


    }
}
