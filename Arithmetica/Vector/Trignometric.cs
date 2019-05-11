using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static Vector Sin(Vector src) => Vector.Out(ArrayOps.Sin(src.variable));
        
        public static Vector Cos(Vector src) => Vector.Out(ArrayOps.Cos(src.variable));

        public static Vector Tan(Vector src) => Vector.Out(ArrayOps.Tan(src.variable));

        public static Vector Asin(Vector src) => Vector.Out(ArrayOps.Asin(src.variable));
       
        public static Vector Acos(Vector src) => Vector.Out(ArrayOps.Acos(src.variable));
        
        public static Vector Atan(Vector src) => Vector.Out(ArrayOps.Atan(src.variable));

        public static Vector Atan2(Vector srcY, Vector srcX) => Vector.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Vector Sinh(Vector src) => Vector.Out(ArrayOps.Sinh(src.variable));
        
        public static Vector Cosh(Vector src) => Vector.Out(ArrayOps.Cosh(src.variable));
      
        public static Vector Tanh(Vector src) => Vector.Out(ArrayOps.Tanh(src.variable));


    }
}
