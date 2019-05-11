using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector2
    {
        public static Vector2 Sin(Vector2 src) => Vector2.Out(ArrayOps.Sin(src.variable));
        
        public static Vector2 Cos(Vector2 src) => Vector2.Out(ArrayOps.Cos(src.variable));

        public static Vector2 Tan(Vector2 src) => Vector2.Out(ArrayOps.Tan(src.variable));

        public static Vector2 Asin(Vector2 src) => Vector2.Out(ArrayOps.Asin(src.variable));
       
        public static Vector2 Acos(Vector2 src) => Vector2.Out(ArrayOps.Acos(src.variable));
        
        public static Vector2 Atan(Vector2 src) => Vector2.Out(ArrayOps.Atan(src.variable));

        public static Vector2 Atan2(Vector2 srcY, Vector2 srcX) => Vector2.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Vector2 Sinh(Vector2 src) => Vector2.Out(ArrayOps.Sinh(src.variable));
        
        public static Vector2 Cosh(Vector2 src) => Vector2.Out(ArrayOps.Cosh(src.variable));
      
        public static Vector2 Tanh(Vector2 src) => Vector2.Out(ArrayOps.Tanh(src.variable));


    }
}
